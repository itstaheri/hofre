using AM.Application.Contract.Article;
using AM.Domain.ArticleAgg;
using AM.Domain.ArticleCategoryAgg;
using AM.Infrastracture.Efcore.Exceptions;
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
            if (commend == null)
                throw new NotFoundException("CreateArticleModel");

            _context.articles.Add(commend);
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
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
                CreationDate = x.CreationDate.ToFarsi(),

            }).ToList();
        }

        public ArticleModel Getby(long Id)
        {
            return _context.articles.FirstOrDefault(x => x.Id == Id);
        }

        public List<ArticleTagViewModel> GetTagsBy(long Id)
        {
            return _context.articleTags.Where(x => x.ArticleId == Id)
                .Select(x => new ArticleTagViewModel { TagId = x.Id, Title = x.Name })
                .ToList();
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
