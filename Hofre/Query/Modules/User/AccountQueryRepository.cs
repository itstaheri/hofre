using AM.Infrastracture.Efcore;
using CM.Infrastracture.Efcore;
using Exceptions;
using Frameworks;
using Frameworks.Auth;
using Frameworks.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OM.Infrastracture.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.User;
using UM.Domain.UserAgg;
using UM.Infrastracture.Efcore;

namespace Query.Modules.User
{
    public class AccountQueryRepository : IAccountQueryRepository
    {
        private readonly UserContext _user;
        private readonly CourseContext _course;
        private readonly ArticleContext _article;
        private readonly OrderContext _order;
        private readonly IFileHelper _fileHelper;
        private readonly IAuth _auth;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISmtpService _smtp;
     
        public AccountQueryRepository(UserContext user, CourseContext course, ArticleContext article, 
            OrderContext order,IFileHelper fileHelper,IAuth auth,IPasswordHasher passwordHasher,ISmtpService smtp)
        {
            _user = user;
            _course = course;
            _passwordHasher = passwordHasher;
            _article = article;
            _order = order;
            _fileHelper = fileHelper;
            _auth = auth;
            _smtp = smtp;
        }


        public async Task<bool> ChangePassword(ChangePassword commend)
        {
            var user = await _user.users.FirstOrDefaultAsync(x => x.Id == commend.UserId);
            if (user == null) throw new NotFoundException(nameof(user), commend.UserId);
            (bool verified,bool needUpgrade) =  _passwordHasher.Check(user.Password, commend.OldPassword);
            if (verified == true)
            {
                string password =await _passwordHasher.Hash(commend.NewPassword); 
                user.ChangePassword(password);
                try
                {
                    await _user.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {

                    throw new SaveErrorException(ex.Message, ex.InnerException);
                }
            }
            else
            {
                return false;
            }
            
        }

      

        public async Task<bool> ForgetPassword(string entery)
        {
            var user = await _user.users.FirstOrDefaultAsync(x => x.Username == entery || x.Email == entery);
            if (user ==null) return false;
            var code = await CodeGenerator.Generate($"reset{entery}");

            await _user.userReset.AddAsync(new UserResetModel(user.Id,code));

            try
            {
               await _user.SaveChangesAsync();
                
                //send code to Useremail
                await _smtp.Send(new EmailViewModel
                {
                    Emailreceiver = user.Email,
                    Subject = "بازیابی کلمه ی عبور",
                    Text = $"لینک بازیابی کلمه ی عبور(انقضا 1 روز) : https://hofre.net/resetpassword/{code}"
                });
                //
                return true;
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }


        }

        public async Task<AccountQueryViewModel> GetBy(string username)
        {
            List<UserCourseQueryViewModel> courses = new List<UserCourseQueryViewModel>();
            var query = await _user.users.FirstOrDefaultAsync(x => x.Username == username);
            var comments = await _course.courseComments.Where(x => x.Username == username && x.IsActive).Select(x => new UserCourseCommentQueryViewModel
            {
                IsActive = x.IsActive,
                CreationDate = x.CreationDate.ToFarsi(),
                CourseId = x.CourseId,
                Text = x.Text,
                Username = x.Username,


            }).ToListAsync();

            var courseIds = await _user.userCourses.Where(x => x.UserId == query.Id).Select(x => x.CourseId).ToListAsync();
            foreach (var Id in courseIds)
            {
                var course = await _course.courses.FirstOrDefaultAsync(x => x.Id == Id);
                courses.Add(new UserCourseQueryViewModel { CourseId = course.Id, CourseName = course.Subject, Picture = course.Picture, Slug = course.Slug });

            }
            var articles = await _article.articleComments.Where(x => x.UserId == query.Id && x.IsActive).Select(x => new UserArticleCommentQueryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleId = x.ArticleId,
                IsActive = x.IsActive,
                Text = x.Text,

            }).ToListAsync();

            foreach(var article in articles)
            {
                article.ArticleTitle = (await _article.articles.FirstOrDefaultAsync(x => x.Id == article.Id)).Title;
            }
            return new AccountQueryViewModel
            {
                Id = query.Id,
                CourseComments = comments,
                Courses =courses,
                Email = query.Email,
                PhoneNumber = query.Phone,
                ProfilePicture = query.ProfilePicture,
                RoleId = query.RoleId,
                Username = query.Username,
                ArticleComments = articles,
                
            };
        }

        public async Task<AccountQueryViewModel> GetBy(long userId,string commend)
        {
            var query = await _user.users.FirstOrDefaultAsync(x => x.Id == userId);

            AccountQueryViewModel Model = new AccountQueryViewModel();
            List<UserCourseQueryViewModel> courses = new List<UserCourseQueryViewModel>();
            List<UserCourseCommentQueryViewModel> courseComments = new List<UserCourseCommentQueryViewModel>();
            List<UserArticleCommentQueryViewModel> articleComments = new List<UserArticleCommentQueryViewModel>();
            List<UserOrderQueryViewModel> orders = new List<UserOrderQueryViewModel>();
            //get user courseComments
            if (commend == "comment")
            {
                courseComments = await _course.courseComments.Where(x => x.Username == query.Username && x.IsActive).Select(x => new UserCourseCommentQueryViewModel
                {
                    IsActive = x.IsActive,
                    CreationDate = x.CreationDate.ToFarsi(),
                    CourseId = x.CourseId,
                    Text = x.Text,
                    Username = x.Username,


                }).ToListAsync();
                foreach (var item in courseComments)
                {
                    item.CourseName =  _course.courses.FirstOrDefault(x => x.Id == item.CourseId).Subject;
                }
                //get user artcileComments
                articleComments = await _article.articleComments.Where(x => x.UserId == query.Id && x.IsActive).Select(x => new UserArticleCommentQueryViewModel
                {
                    Id = x.Id,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ArticleId = x.ArticleId,
                    IsActive = x.IsActive,
                    Text = x.Text,

                }).ToListAsync();
                foreach (var article in articleComments)
                {
                    article.ArticleTitle = (await _article.articles.FirstOrDefaultAsync(x => x.Id == article.ArticleId)).Title;
                }
            }
            //get UserCourses
            else if (commend == "course")
            {
                var courseIds =  _user.userCourses.Where(x => x.UserId == query.Id).Select(x => x.CourseId).ToList();
             
                foreach (var Id in courseIds)
                {
                    var course = await _course.courses.FirstOrDefaultAsync(x => x.Id == Id);
                    courses.Add(new UserCourseQueryViewModel { CourseId = course.Id, CourseName = course.Subject, Picture = course.Picture, Slug = course.Slug });

                }
              
            }

            //get user orders
            else if(commend == "order")
            {
                orders = await _order.orders.Where(x => x.UserId == query.Id).Select(x => new UserOrderQueryViewModel
                {
                    OrderId = x.Id,
                    CreationDate = x.CreationDate.ToFarsi(),
                    PayAmount = x.PayAmount,
                    CourseId = x.CourseId,
                    Code = x.Code,
                    IsFinaly = x.Isfinaly
                }).ToListAsync();
                foreach (var item in orders)
                {
                    item.ProductName = (await _course.courses.FirstOrDefaultAsync(x => x.Id == item.CourseId)).Subject;
                }

            }

         
            return new AccountQueryViewModel
            {
                Id = query.Id,
                Email = query.Email,
                PhoneNumber = query.Phone,
                ProfilePicture = query.ProfilePicture,
                RoleId = query.RoleId,
                Username = query.Username,
                CourseComments = courseComments,
                Courses = courses,
                ArticleComments = articleComments,
                Orders = orders

            };
           
        }

        public async Task RemoveAllResetRequests(long UserId)
        {
            var requests = await _user.userReset.Where(x=>x.UserId == UserId).ToListAsync();
            foreach (var request in requests)
            {
                _user.userReset.Remove(request);
                try
                {
                    await _user.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    throw new SaveErrorException(ex.Message, ex.InnerException);
                }
            }
        }

        public async Task<string> ResetPassword(ResetPasswordViewModel commend)
        {
            var checkuser = await _user.userReset.Where(x=>x.ExpireDate >= DateTime.Now).FirstOrDefaultAsync(x=>x.GenericCode == commend.Code);
            if (checkuser == null) return  nameof(ResetPasswordStatus.ExpireTime);
            var password = await _passwordHasher.Hash(commend.NewPassword);
            var user = await _user.users.FirstOrDefaultAsync(x => x.Id == checkuser.UserId);
            (bool hash, bool needupdate) =  _passwordHasher.Check(user.Password,commend.NewPassword);
            if (hash) return nameof(ResetPasswordStatus.EqualPassword);
            
            user.ChangePassword(password);
            try
            {
                await _user.SaveChangesAsync();
                await RemoveAllResetRequests(checkuser.UserId);
                return nameof(ResetPasswordStatus.SuccessfulReset);
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }


        }

        public async Task UpdateProfilePicture(long userId, IFormFile picture)
        {

            var user = (await _user.users.FirstOrDefaultAsync(x => x.Id == userId));
            await _fileHelper.DeleteFile($"/Media/User/{user.Id}/{user.ProfilePicture}");
            var profilePicture = await _fileHelper.SingleUploader(picture, "user", userId.ToString());


            user.ChangeProfilePicture(profilePicture);
            try
            {
                await _user.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }

        }

        public async Task<bool> ValidationResetCode(string code)
        {
            return await _user.userReset.AnyAsync(x => x.GenericCode == code);
        }
    }
}
