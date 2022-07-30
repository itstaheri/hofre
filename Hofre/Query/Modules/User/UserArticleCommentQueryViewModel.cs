using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class UserArticleCommentQueryViewModel
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public string CreationDate { get; set; }
    }
}
