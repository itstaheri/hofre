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
        public ArticleQueryRepository(ArticleContext context, UserContext user, ILogger<ArticleQueryRepository> logger, IAuth auth)
        {
            _context = context;
            _user = user;
            _logger = logger;
            _auth = auth;
        }

        public async Task<ArticlePageViewModel> GetAll(int pageId = 1)
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
                var categories = await _context.articleToCategories.Where(c => c.ArticleId == item.Id)
                    .Select(x => x.articleCategory).ToListAsync();

                foreach (var cat in categories)
                {
                    item.ArticleCategories.Add(new ArticleCategoryQueryModel { Id = cat.Id, Name = cat.Name });
                }
            }

            if (query == null)
            {
                throw new Exception();
            }
            ArticlePageViewModel page = new ArticlePageViewModel();
            if (query.Count >= 9)
            {
                page.CurrentPage = pageId;
                page.PageCount = (int)Math.Ceiling(query.Count / (double)9);
                page.Articles = query.OrderBy(x => x.Id).Skip((pageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = pageId;
                page.PageCount = 1;
                page.Articles = query;
            }


            return page;

        }



        public async Task<List<ArticleQueryViewModel>> GetAll(long Id)
        {
            var query = await _context.articles.Where(x => x.Id == Id).Select(x => new ArticleQueryViewModel
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
            return await _context.articleCategories.Select(x => new ArticleCategoryQueryModel { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public async Task<ArticlePageViewModel> GetArticlesByCategory(long CategoryId, int pageId = 1)
        {
            var query = new List<ArticleQueryViewModel>();
            var categories = await _context.articleToCategories.Where(x => x.ArticleCategoryId == CategoryId).ToListAsync();
            foreach (var item in categories)
            {
                query.Add(await GetDetailBy(item.ArticleId));
            }
            ArticlePageViewModel page = new ArticlePageViewModel();
            if (query.Count >= 9)
            {
                page.CurrentPage = pageId;
                page.PageCount = (int)Math.Ceiling(query.Count / (double)9);
                page.Articles = query.OrderBy(x => x.Id).Skip((pageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = pageId;
                page.PageCount = 1;
                page.Articles = query;
            }
            return page;
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
                var ac = new ArticleCategoryQueryModel { Id = item.ArticleCategoryId, Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == item.ArticleCategoryId)).Name };

                query.ArticleCategories.Add(ac);
            }
            //get comments
            var comments = await _context.articleComments.Where(x => x.IsActive && x.ArticleId == query.Id).ToListAsync();
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
                var userProfile = await _user.users.Include(x => x.userRole).FirstOrDefaultAsync(x => x.Id == ac.UserId);
                ac.Username = userProfile.Username;
                ac.UserRole = userProfile.userRole.RoleName;
                ac.UserProfile = userProfile.ProfilePicture;

                query.ArticleComments.Add(ac);
            }
            return query;

        }

        public async Task<List<ArticleQueryViewModel>> GetRelatedArticlesBy(List<ArticleCategoryQueryModel> CategoryIds)
            {
            var Model = new List<ArticleToCategoryViewModel>();
            var articles = new List<ArticleQueryViewModel>();
            foreach (var item in CategoryIds)
            {
                var value = (await _context.articleToCategories.Where(x => x.ArticleCategoryId == item.Id)
                  .Select(x => new ArticleToCategoryViewModel { ArticleId = x.ArticleId, CategoryId = x.ArticleCategoryId }).ToListAsync());

                    value.ForEach(x => Model.Add(new ArticleToCategoryViewModel { ArticleId = x.ArticleId, CategoryId = x.CategoryId }));
               
            }
            foreach (var item in Model)
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
            return articles.Take(2).ToList();
        }

        public async Task<ArticlePageViewModel> Search(string entery, int pageId = 1)
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
                Slug = x.Slug,
                ArticleCategories = new List<ArticleCategoryQueryModel>()

            }).AsNoTracking()
            .Where(x => x.Title.Contains(entery)).ToListAsync();

            if (query.Count == 0) return new ArticlePageViewModel();

            foreach (var item in query)
            {
                var categories = await _context.articleToCategories.Where(x => x.ArticleId == item.Id).ToListAsync();
                foreach (var cat in categories)
                {
                    var ac = new ArticleCategoryQueryModel { Id = cat.ArticleId, Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == cat.ArticleCategoryId)).Name };

                    item.ArticleCategories.Add(ac);
                }
            }
            ArticlePageViewModel page = new ArticlePageViewModel();
            if (query.Count >= 9)
            {
                page.CurrentPage = pageId;
                page.PageCount = (int)Math.Ceiling(query.Count / (double)9);
                page.Articles = query.OrderBy(x => x.Id).Skip((pageId - 1) * 9).Take(9).ToList();

            }
            else
            {
                page.CurrentPage = pageId;
                page.PageCount = 1;
                page.Articles = query;
            }

            return page;
        }
    }
}
