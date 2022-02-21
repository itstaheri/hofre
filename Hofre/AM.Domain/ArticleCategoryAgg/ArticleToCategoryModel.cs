using AM.Domain.ArticleAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleCategoryAgg
{
    public class ArticleToCategoryModel
    {
        public long ArticleId { get;private set; }
        public long ArticleCategoryId { get;private set; }
        public ArticleCategoryModel articleCategory { get;private set; }
        public ArticleModel article { get;private set; }
    }
}
