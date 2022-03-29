using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.Article
{
    public interface IArticleApplication
    {
        bool Create(CreateArticle commend);
        bool Edit(EditArticle commend);
        EditArticle GetValueForEdit(long Id);
        bool Remove(long Id);
        List<ArticleViewModel> GetAll();
        List<ArticleTagViewModel> GetTagsBy(long Id); 

    }
}
