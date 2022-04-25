using AM.Infrastracture.Efcore;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Infrastracture.Efcore;

namespace Query.Modules.Article
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleContext _context;
        private readonly UserContext _user;
        public ArticleRepository(ArticleContext context, UserContext user)
        {
            _context = context;
            _user = user;
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


            }).AsNoTracking().ToListAsync();

            query.ForEach(async x => x.CategoriesId = await _context.articleToCategories
          .Where(q => q.ArticleId == x.Id).Select(c => c.ArticleCategoryId).ToListAsync());

            return query;

        }

        public async Task<List<ArticleCommentQueryViewModel>> GetCommentsById(long Id)
        {
            var query = await _context.articleComments.Where(c => c.Id == Id && c.IsActive == true).Select(x => new ArticleCommentQueryViewModel
            {
                Id = x.Id,
                Text = x.Text,
                UserId = x.UserId,
                CreationDate = x.CreationDate.ToFarsi(),
            }).ToListAsync();
            query.ForEach(async x => x.Username = (await _user.users.FirstOrDefaultAsync(c => c.Id == x.UserId)).Username);
            return query;

        }

        public async Task<ArticleQueryViewModel> GetDetailById(long Id)
        {
            var query =await _context.articles.Select(x=>new ArticleQueryViewModel  
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
                
            }).FirstOrDefaultAsync(q=>q.Id == Id);

            query.ArticleTags.ForEach(async tag => tag =(await _context.articleTags.FirstOrDefaultAsync(q => q.ArticleId == Id)).Name);

            return query;
            
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

            }).AsNoTracking()
            .Where(x => x.Title.Contains(entery)).ToListAsync();

            query.ForEach(async x => x.CategoriesId = await _context.articleToCategories
          .Where(q => q.ArticleId == x.Id).Select(c => c.ArticleCategoryId).ToListAsync());

            return query;
        }
    }
}
