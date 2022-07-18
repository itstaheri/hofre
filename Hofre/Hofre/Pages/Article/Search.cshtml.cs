using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages.Article
{
    public class SearchModel : PageModel
    {
        private readonly IArticleQueryRepository _repository;
        public List<ArticleQueryViewModel> Articles { get; set; }
        public string searchTitle;
        public SearchModel(IArticleQueryRepository repository)
        {
            _repository = repository;


        }
        public async Task OnGet(string searchentery)
        {
            searchTitle = searchentery;
            Articles = await _repository.Search(searchentery);
        }
    }
}
