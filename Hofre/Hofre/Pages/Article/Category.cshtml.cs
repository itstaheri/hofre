using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages.Article
{
    public class CategoryModel : PageModel
    {
        private readonly IArticleQueryRepository _repository;
        public ArticlePageViewModel ArticlePage { get; set; }
        public long CategoryId = 0;
        public CategoryModel(IArticleQueryRepository repository)
        {
            _repository = repository;
        }
        public List<ArticleQueryViewModel> articles { get; set; }
        public async Task OnGet(long categoryId,int pageId = 1)
        {
            CategoryId = categoryId;
            ArticlePage = (await _repository.GetArticlesByCategory(categoryId,pageId));
        }
    }
}
