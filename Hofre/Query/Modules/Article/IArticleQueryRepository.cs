using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Article
{
    public interface IArticleQueryRepository
    {
        Task<List<ArticleQueryViewModel>> GetAll();
        Task<ArticleQueryViewModel> GetDetailById(long Id);
        Task<List<ArticleQueryViewModel>> Search(string entery);
        Task<List<ArticleCommentQueryViewModel>> GetCommentsById(long Id);
    }
}
