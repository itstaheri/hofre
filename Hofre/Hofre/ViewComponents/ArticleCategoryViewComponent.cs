using Microsoft.AspNetCore.Mvc;
using Query.Modules.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.ViewComponents
{
    public class ArticleCategoryViewComponent : ViewComponent
    {
        private readonly IArticleQueryRepository _repository;
        public ArticleCategoryViewComponent(IArticleQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _repository.GetAllCategories();
            return View(categories);
        }
    }
}
