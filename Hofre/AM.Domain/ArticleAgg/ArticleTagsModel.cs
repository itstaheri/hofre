using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleAgg
{
    public class ArticleTagsModel : BaseEntity
    {
        public ArticleTagsModel(string name, long articleId)
        {
            Name = name;
            ArticleId = articleId;
        }

        public string Name { get;private set; }
        public long ArticleId { get; private set; }
        public ArticleModel article { get; private set; }
    }
}
