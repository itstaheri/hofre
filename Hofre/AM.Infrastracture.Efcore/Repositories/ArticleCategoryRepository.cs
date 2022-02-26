using AM.Application.Contract.ArticleCategory;
using AM.Domain.ArticleCategoryAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly ArticleContext _context;

        public ArticleCategoryRepository(ArticleContext context)
        {
            _context = context;
        }

        public bool Create(ArticleCategoryModel commend)
        {
            _context.articleCategories.Add(commend);
            _context.SaveChanges();
            return true;
        }

        public List<ArticleCategoryViewModel> GetAll()
        {

            var query = _context.articleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
            }).ToList();

            foreach (var item in query)
            {
                //var getcount = _context.articleCategories.SelectMany(x=>x.articles).SelectMany(x=>x.articleCategories);
                //if (getcount != null)
                //    item.ArticleCounts = 0;
                //else
                //    item.ArticleCounts = 0;
                item.ArticleCounts = 0;
            }

            return query;
        }

        public ArticleCategoryModel GetBy(long Id)
        {
            return _context.articleCategories.FirstOrDefault(x => x.Id == Id);
        }

        public bool Remove(long Id)
        {
            var value = _context.articleCategories.FirstOrDefault(x => x.Id == Id);
            _context.articleCategories.Remove(value);
            _context.SaveChanges();
            return true;

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
