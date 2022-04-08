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
        Task Create(ArticleCategoryModel commend);
        Task Save();
        Task<ArticleCategoryModel> GetBy(long Id);
        Task<List<ArticleCategoryViewModel>> GetAll();
        Task Remove(long Id);

    }
}
