using AM.Application.Contract.ArticleComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleCommentAgg
{
    public interface IArticleCommentRepository
    {
        Task Create(ArticleCommentModel commend);
        Task Remove(long Id);
        Task<ArticleCommentModel> GetBy(long Id);
        Task<List<ArticleCommentViewModel>> GetAll();
        Task Save();

    }
}
