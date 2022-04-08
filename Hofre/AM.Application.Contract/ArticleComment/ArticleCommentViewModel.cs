using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Contract.ArticleComment
{
    public class ArticleCommentViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public string ArticleName { get; set; }
        public long ArticleId { get; set; }
        public long UserId { get; set; }
        public string CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
