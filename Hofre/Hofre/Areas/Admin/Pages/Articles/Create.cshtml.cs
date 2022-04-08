using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.Application.Contract.Article;
using AM.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hofre.Areas.Admin.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _articlecategory;
        public List<SelectListItem> categories;
        private readonly IArticleApplication _repository;
        public CreateModel(IArticleCategoryApplication articlecategory, IArticleApplication repository)
        {
            _articlecategory = articlecategory;
            _repository = repository;
        }

        public async Task OnGet()
        {
            var Getcategories = await _articlecategory.GetAll();
            categories=Getcategories.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

        }
        public async Task<RedirectToPageResult> OnPost(CreateArticle commend)
        {
           await _repository.Create(commend);

            return RedirectToPage("./Index");
        }

    }
}
