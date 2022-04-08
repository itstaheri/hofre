using AM.Application.Contract.Article;
using AM.Domain.ArticleAgg;
using AM.Domain.ArticleCategoryAgg;
using AM.Infrastracture.Efcore.Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
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

        public async Task Create(ArticleModel commend)
        {
            if (commend == null)
                throw new NotFoundException("CreateArticleModel");

            _context.articles.Add(commend);
            try
            {
               await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ArticleViewModel>> GetAll()
        {
            return await _context.articles.Select(x => new ArticleViewModel
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

            }).ToListAsync();
           
        }

        public async Task<ArticleModel> Getby(long Id)
        {
            return await _context.articles.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ArticleTagViewModel>> GetTagsBy(long Id)
        {
            return await _context.articleTags.Where(x => x.ArticleId == Id)
                .Select(x => new ArticleTagViewModel { TagId = x.Id, Title = x.Name })
                .ToListAsync();
        }

        public async Task Remove(long Id)
        {
            var article =await _context.articles.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Remove(article);
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

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
