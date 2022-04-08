using AM.Domain.ArticleAgg;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.ArticleCommentAgg
{
    public class ArticleCommentModel : BaseEntity
    {
        public ArticleCommentModel(string text, long articleId, long userId)
        {
            Text = text;
            ArticleId = articleId;
            UserId = userId;
            IsActive = false;
        }

        public void Active()=>IsActive = true;

        public string Text { get; private set; }
        public long ArticleId { get; private set; }
        public ArticleModel article { get; private set; }
        public long UserId { get; private set; }
        public bool IsActive { get; private set; }


    }
}
