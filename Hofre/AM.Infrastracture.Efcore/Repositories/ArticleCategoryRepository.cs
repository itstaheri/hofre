using AM.Application.Contract.ArticleCategory;
using AM.Domain.ArticleCategoryAgg;
using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
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

        public async Task Create(ArticleCategoryModel commend)
        {
            _context.articleCategories.Add(commend);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ArticleCategoryViewModel>> GetAll()
        {

            var query = await _context.articleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Name = x.Name,
            }).ToListAsync();

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

        public async Task<ArticleCategoryModel> GetBy(long Id)
        {
            return await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Remove(long Id)
        {
            var value = await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == Id);
            if (value == null)
            {
                throw new NotFoundException(nameof(value), value.Id);
            }
            _context.articleCategories.Remove(value);
            await _context.SaveChangesAsync();

        }

        public async Task Save()
        {
            try
            {
               await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }
    }
}
