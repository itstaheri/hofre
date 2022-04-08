using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.ArticleComment
{
    public interface IArticleCommentApplication
    {
        Task<List<ArticleCommentViewModel>> GetAll();
        Task Remove(long Id);
        Task Active(long Id);
        Task DeActive(long Id);

    }
}
