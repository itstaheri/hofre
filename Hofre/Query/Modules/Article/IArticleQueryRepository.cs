using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Article
{
    public interface IArticleQueryRepository
    {
        Task<ArticlePageViewModel> GetAll(int pageId = 1);
        Task<List<ArticleQueryViewModel>> GetAll(long Id);
        Task<ArticleQueryViewModel> GetDetailBy(long Id);
        Task<ArticleQueryViewModel> GetDetailBy(string slug);
        Task<ArticlePageViewModel> Search(string entery, int pageId = 1);
        Task<List<ArticleQueryViewModel>> GetRelatedArticlesBy(List<ArticleCategoryQueryModel> CategoryIds);
        Task<List<ArticleCategoryQueryModel>> GetAllCategories();
        Task<ArticlePageViewModel> GetArticlesByCategory(long CategoryId, int pageId = 1);
    }
}
