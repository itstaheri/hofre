using AM.Application.Contract.ArticleComment;
using AM.Domain.ArticleCommentAgg;
using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Infrastracture.Efcore;

namespace AM.Infrastracture.Efcore.Repositories
{
    public class ArticleCommentRepository : IArticleCommentRepository
    {
        private readonly ArticleContext _context;
        private readonly UserContext _user;
        public ArticleCommentRepository(ArticleContext context, UserContext user)
        {
            _context = context;
            _user = user;
        }

        public async Task Create(ArticleCommentModel commend)
        {
            _context.articleComments.Add(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ArticleCommentViewModel>> GetAll()
        {
            var query = await _context.articleComments.Select(x => new ArticleCommentViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleId = x.ArticleId,
                IsActive = x.IsActive,
                Text = x.Text,
                UserId = x.UserId,

            }).ToListAsync();
            foreach (var item in query)
            {
                item.ArticleName = _context.articles.FirstOrDefault(x => x.Id == item.ArticleId).Title;
                item.Username = _user.users.FirstOrDefault(x => x.Id == item.UserId).Username;
            }
            return query;
        }

        public async Task<ArticleCommentModel> GetBy(long Id)
        {
            return await _context.articleComments.FirstOrDefaultAsync(x => x.Id == Id);
        }

       
        public async Task Remove(long Id)
        {
            var comment = await _context.articleComments.FirstOrDefaultAsync(x => x.Id == Id);
            _context.articleComments.Remove(comment);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
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
