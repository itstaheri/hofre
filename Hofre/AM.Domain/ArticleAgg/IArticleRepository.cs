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
        bool Create(ArticleModel commend);
        ArticleModel Getby(long Id);
        void Save();
        bool Remove(long Id);
        List<ArticleViewModel> GetAll();
    }
}
