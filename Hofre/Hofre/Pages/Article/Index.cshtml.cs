using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages.Article
{
    public class IndexModel : PageModel
    {
        private readonly IArticleQueryRepository _repository;
        public List<ArticleQueryViewModel> Articles { get; set; }
        public ArticlePageViewModel ArticlePage { get; set; }
        public IndexModel(IArticleQueryRepository repository)
        {
            _repository = repository;

        }
        public async Task OnGet(int pageId =1)
        {
            ArticlePage = (await _repository.GetAll(pageId));
        }
       
    }
}
