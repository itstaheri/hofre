using Microsoft.AspNetCore.Mvc;
using Query.Modules.Article;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.ViewComponents
{
    public class ArticleSidebarViewComponent : ViewComponent
    {
        private readonly IArticleQueryRepository _article;
        public ArticleSidebarViewModel Model { get; set; }

        public ArticleSidebarViewComponent(IArticleQueryRepository article)
        {
            _article = article;
            Model = new ArticleSidebarViewModel();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Model.LastArticles = (await _article.GetAll()).Articles.OrderBy(x=>x.CreationDate).Take(4).ToList();
            Model.Categories = await _article.GetAllCategories();
            return View(Model);
        }
    }
}
