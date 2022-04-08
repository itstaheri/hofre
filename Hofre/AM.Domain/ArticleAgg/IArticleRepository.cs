using AM.Application.Contract.Article;
using AM.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        Task Create(ArticleModel commend);
        Task<ArticleModel> Getby(long Id);
        Task Save();
        Task Remove(long Id);
        Task<List<ArticleViewModel>> GetAll();
        Task<List<ArticleTagViewModel>> GetTagsBy(long Id);

    }
}
