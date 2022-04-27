using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Query.Modules.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleQueryRepository _article;

        public IndexModel(ILogger<IndexModel> logger, IArticleQueryRepository article)
        {
            _logger = logger;
            _article = article;
        }

        public List<ArticleQueryViewModel> Articles { get; set; }
        public List<ArticleCommentQueryViewModel> Comments { get; set; }
        

        public  async Task OnGet()
        {
            Articles = await _article.GetAll();
            //throw new Exception("hey budy");
            //_logger.Log(LogLevel.Trace, 234, "ops");
            //_logger.Log(LogLevel.Information,555, "این یک پیام امتحانی است");
            //_logger.LogWarning("warning",4545454);
            //_logger.Log(LogLevel.Critical, "hi", 2323);
        }
    }
}
