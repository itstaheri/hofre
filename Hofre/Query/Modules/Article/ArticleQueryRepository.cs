using AM.Infrastracture.Efcore;
using Frameworks;
using Frameworks.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Infrastracture.Efcore;

namespace Query.Modules.Article
{
    public class ArticleQueryRepository : IArticleQueryRepository
    {
        private readonly ILogger<ArticleQueryRepository> _logger;
        private readonly ArticleContext _context;
        private readonly UserContext _user;
        private readonly IAuth _auth;
        public ArticleQueryRepository(ArticleContext context, UserContext user, ILogger<ArticleQueryRepository> logger,IAuth auth)
        {
            _context = context;
            _user = user;
            _logger = logger;
            _auth = auth;
        }

        public async Task<List<ArticleQueryViewModel>> GetAll()
        {
            var query = await _context.articles.Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Video = x.Video,
                CreationDate = x.CreationDate.ToFarsi(),
                Slug = x.Slug,
                ArticleCategories = new List<ArticleCategoryQueryModel>(),
                ArticleComments = new List<ArticleCommentQueryViewModel>(),
                ArticleTags = new List<ArticleTagQueryViewModel>()



            }).AsNoTracking().ToListAsync();

            foreach (var item in query)
            {
                var categories = await _context.articleToCategories.Where(c => c.ArticleId == item.Id).Select(x => x.articleCategory).ToListAsync();
                foreach (var cat in categories)
                {
                    item.ArticleCategories.Add(new ArticleCategoryQueryModel { Id = cat.Id, Name = cat.Name });
                }
            }

            if (query == null)
            {
                throw new Exception();
            }
            return query;


        }

        public async Task<List<ArticleCategoryQueryModel>> GetAllCategories()
        {
            return await _context.articleCategories.Select(x=>new ArticleCategoryQueryModel { Id = x.Id,Name=x.Name}).ToListAsync();
        }

        public async Task<List<ArticleCategoryQueryModel>> GetArticlesCategories()
        {
            return await _context.articleToCategories.Include(x => x.articleCategory)
                .Select(x => new ArticleCategoryQueryModel
                {
                    Id = x.ArticleCategoryId,
                    Name = x.articleCategory.Name
                }).ToListAsync();
        }

        public async Task<ArticleQueryViewModel> GetDetailBy(string slug)
        {
            var query = await _context.articles.Include(x => x.articleTags).Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Video = x.Video,
                Slug = x.Slug,
                ArticleTags = new List<ArticleTagQueryViewModel>(),
                ArticleCategories = new List<ArticleCategoryQueryModel>(),
                ArticleComments = new List<ArticleCommentQueryViewModel>()

            }).FirstOrDefaultAsync(q => q.Slug == slug);

            //get tags
            var tags = await _context.articleTags.Where(x => x.ArticleId == query.Id).ToListAsync();
            foreach (var tag in tags)
            {
                var at = new ArticleTagQueryViewModel { Id = tag.Id, Name = tag.Name };
                query.ArticleTags.Add(at);

            }
            //get categories
            var categories = await _context.articleToCategories.Where(x => x.ArticleId == query.Id).ToListAsync();
            foreach (var item in categories)
            {
                var ac = new ArticleCategoryQueryModel{ Id = item.ArticleId, Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == item.ArticleCategoryId)).Name };
               
                query.ArticleCategories.Add(ac);
            }
            //get comments
            var comments = await _context.articleComments.Where(x=>x.IsActive && x.ArticleId == query.Id).ToListAsync();
            foreach (var item in comments)
            {
                var ac = new ArticleCommentQueryViewModel
                {
                    Id = item.Id,
                    CreationDate = item.CreationDate.ToFarsi(),
                    Text = item.Text,
                    UserId = item.UserId,

                };
                var userProfile = await _user.users.Include(x => x.userRole).FirstOrDefaultAsync(x => x.Id == ac.UserId);
                ac.Username = userProfile.Username;
                ac.UserRole = userProfile.userRole.RoleName;
                ac.UserProfile = userProfile.ProfilePicture;

                query.ArticleComments.Add(ac);
            }

            return query;
        }

        public async Task<ArticleQueryViewModel> GetDetailBy(long Id)
        {
            var profile = await _auth.CurrentUserInfo();
            
            var query = await _context.articles.Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Video = x.Video,
                ArticleTags = new List<ArticleTagQueryViewModel>(),
                ArticleCategories = new List<ArticleCategoryQueryModel>(),
                ArticleComments = new List<ArticleCommentQueryViewModel>()

            }).FirstOrDefaultAsync(q => q.Id == Id);

            //get tags
            var tags = await _context.articleTags.Where(x => x.ArticleId == query.Id).ToListAsync();
            foreach (var tag in tags)
            {
                var at = new ArticleTagQueryViewModel { Id = tag.Id, Name = tag.Name };
                query.ArticleTags.Add(at);

            }
            //get categories
            var categories = await _context.articleToCategories.Where(x => x.ArticleId == query.Id).ToListAsync();
            foreach (var item in categories)
            {
                var ac = new ArticleCategoryQueryModel { Id = item.ArticleId, Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == item.ArticleCategoryId)).Name };

                query.ArticleCategories.Add(ac);
            }
            //get comments
            var comments = from x in _context.articleComments where x.ArticleId == query.Id select x;
            foreach (var item in comments)
            {
                var ac = new ArticleCommentQueryViewModel
                {
                    Id = item.Id,
                    CreationDate = item.CreationDate.ToFarsi(),
                    Text = item.Text,
                    UserId = item.UserId,

                };
                var userProfile = await _user.users.Include(x=>x.userRole).FirstOrDefaultAsync(x => x.Id == ac.UserId);
                ac.Username = userProfile.Username;
                ac.UserRole = userProfile.userRole.RoleName;
                ac.UserProfile = userProfile.ProfilePicture;

                query.ArticleComments.Add(ac);
            }
            return query;

        }

        public async Task<List<ArticleQueryViewModel>> GetRelatedArticlesBy(long CategoryId)
        {
            var articles = new List<ArticleQueryViewModel>();
            var category = await _context.articleToCategories.Where(x => x.ArticleCategoryId == CategoryId).Take(2).ToListAsync();
            foreach (var item in category)
            {
               var article = await _context.articles.FirstOrDefaultAsync(x => x.Id == item.ArticleId);
                articles.Add(new ArticleQueryViewModel
                {
                    Id = article.Id,
                    Slug = article.Slug,
                    Title = article.Title,
                    CreationDate = article.CreationDate.ToFarsi(),
                    Picture = article.Picture
                });
            }
            return articles;
        }

        public async Task<List<ArticleQueryViewModel>> Search(string entery)
        {
            var query = await _context.articles.Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Video = x.Video,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Description = x.Description,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCategories = new List<ArticleCategoryQueryModel>()

            }).AsNoTracking()
            .Where(x => x.Title.Contains(entery)).ToListAsync();

            foreach (var item in query)
            {
                var categories = await _context.articleToCategories.Where(x => x.ArticleId == item.Id).ToListAsync();
                foreach (var cat in categories)
                {
                    var ac = new ArticleCategoryQueryModel { Id = cat.ArticleId, Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == cat.ArticleCategoryId)).Name };

                    item.ArticleCategories.Add(ac);
                }
            }
            return query;
        }
    }
}
