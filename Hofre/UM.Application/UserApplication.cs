using Exceptions;
using Frameworks;
using Frameworks.Auth;
using Frameworks.Sms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UM.Application.Contract.User;
using UM.Domain.UserAgg;

namespace UM.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IPasswordHasher _Hash;
        private readonly IUserRepository _repository;
        private readonly IFileHelper _uploader;
        private readonly IAuth _auth;
        private readonly ISmsServices _sms;
        public UserApplication(IPasswordHasher hash, IUserRepository repository, IFileHelper uploader, IAuth auth,ISmsServices sms)
        {
            _Hash = hash;
            _repository = repository;
            _uploader = uploader;
            _auth = auth;
            _sms = sms;
        }

        public async Task Active(long Id)
        {
            var user = await _repository.GetBy(Id);
            user.Active();
            await _repository.Save();
        }

        public async Task ChangePassword(long Id, string newPassword)
        {
            var user = await _repository.GetBy(Id);
            if (user == null)
                throw new NotFoundException(nameof(user), user.Id);
            var Password =await _Hash.Hash(newPassword);
            user.ChangePassword(Password);
            await _repository.Save();



        }

        public async Task Create(CreateUser commend)
        {
            var user = new UserModel(commend.Username, commend.Email, commend.Phone, commend.Password, "avatar.png", commend.RoleId);
            await _repository.Create(user);
        }

        public async Task DeActive(long Id)
        {
            var user = await _repository.GetBy(Id);
            user.DeActive();
            await _repository.Save();
        }

        public async Task<string> Edit(EditUser commend)
        {
            return await _repository.Edit(commend);

        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<EditUser> GetValueForEdit(long Id)
        {
            var user = await _repository.GetBy(Id);
            return new EditUser
            {
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public async Task<LoginResult> Login(Login commend)
        {

            var user = await _repository.GetBy(commend.Username);
            if (user == null) return new LoginResult(false, false, "کاربری با این نام کاربری وجود ندارد!");

            var check = await _repository.CheckIdentity(commend.Username, commend.Password);
            if (!check) return new LoginResult(true, check, "نام کاربری یا کلمه ی عبور شما اشتباه است");

            AuthViewModel auth = new AuthViewModel
            {
                Email = user.Email,
                Id = user.Id,
                Number = user.Phone,
                Picture = user.ProfilePicture,
                RoleId = user.RoleId,
                Username = user.Username
            };

            await _auth.SignIn(auth);

            return new LoginResult(true, true, "ورود موفق.");


        }

        public async Task Remove(long Id)
        {
            await _repository.Remove(Id);
            await _repository.Save();

        }

        public async Task<int> Signup(Register commend)
        {
            var user = await _repository.CheckIdentity(commend.Username, commend.Email, commend.PhoneNumber);
            if (!user)
            {
                var password =await _Hash.Hash(commend.Password);
                await _repository.Create(new UserModel(commend.Username, commend.Email, commend.PhoneNumber, password, "avatar.png", 7));

                return Status.seuccessfulRegister;

            }
            else if (user)
            {
                return Status.RepetitiousData;
            }
            else
            {
                return Status.UnseuccessfulRegister;
            }
        }

     
      
    }
}
