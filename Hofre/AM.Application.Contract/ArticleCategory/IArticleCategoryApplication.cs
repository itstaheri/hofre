using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        Task Create(CreateArticleCategory commend);
        Task<EditArticleCategory> GetValueForEdit(long Id);
        Task Edit(EditArticleCategory commend);
        public Task Remove(long Id);
        Task<List<ArticleCategoryViewModel>> GetAll();
    }
}
