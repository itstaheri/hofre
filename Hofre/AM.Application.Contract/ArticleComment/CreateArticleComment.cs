using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.ArticleComment
{
    public class CreateArticleComment
    {
        public string Text { get; set; }
        public long UserId { get; set; }
        public long ArticleId { get; set; }
    }
}
