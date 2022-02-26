using AM.Application.Contract.Article;
using AM.Domain.ArticleAgg;
using AM.Domain.ArticleCategoryAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleContext _context;

        public ArticleRepository(ArticleContext context)
        {
            _context = context;
        }

        public bool Create(ArticleModel commend)
        {
           
            _context.articles.Add(commend);
            _context.SaveChanges();
            return true;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _context.articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
                Video = x.Video,
                CreationDate = x.CreationDate.ToFarsi()
            }).ToList();
        }

        public ArticleModel Getby(long Id)
        {
            return _context.articles.FirstOrDefault(x => x.Id == Id);
        }

        public bool Remove(long Id)
        {
            var article = _context.articles.FirstOrDefault(x => x.Id == Id);
            _context.Remove(article);
            _context.SaveChanges();
            return true; 
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
