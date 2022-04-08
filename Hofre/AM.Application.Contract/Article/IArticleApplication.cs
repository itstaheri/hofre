using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.Article
{
    public interface IArticleApplication
    {
        Task Create(CreateArticle commend);
        Task Edit(EditArticle commend);
        Task<EditArticle> GetValueForEdit(long Id);
        Task Remove(long Id);
        Task<List<ArticleViewModel>> GetAll();
        Task<List<ArticleTagViewModel>> GetTagsBy(long Id); 

    }
}
