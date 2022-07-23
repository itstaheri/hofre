using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Article
{
    public class ArticlePageViewModel
    {
        public List<ArticleQueryViewModel> Articles { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
