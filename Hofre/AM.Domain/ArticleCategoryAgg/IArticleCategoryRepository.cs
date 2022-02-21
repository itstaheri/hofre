using AM.Application.Contract.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        bool Create(ArticleCategoryModel commend);
        void Save();
        ArticleCategoryModel GetBy(long Id);
        List<ArticleCategoryViewModel> GetAll();
        bool Remove(long Id);

    }
}
