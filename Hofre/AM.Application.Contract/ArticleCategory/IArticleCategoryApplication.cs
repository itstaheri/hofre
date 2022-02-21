using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        bool Create(CreateArticleCategory commend);
        EditArticleCategory GetValueForEdit(long Id);
        bool Edit(EditArticleCategory commend);
        public bool Remove(long Id);
        List<ArticleCategoryViewModel> GetAll();
    }
}
