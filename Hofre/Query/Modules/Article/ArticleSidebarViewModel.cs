using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Article
{
    public class ArticleSidebarViewModel
    {
        public List<ArticleQueryViewModel> LastArticles { get; set; }
        public List<ArticleCategoryQueryModel> Categories { get; set; }

    }
}
