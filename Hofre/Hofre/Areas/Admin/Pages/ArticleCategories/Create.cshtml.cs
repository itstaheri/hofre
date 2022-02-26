using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.ArticleCategories
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCategoryApplication _repository;

        public CreateModel(IArticleCategoryApplication repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(CreateArticleCategory commend)
        {
            _repository.Create(commend);
            return RedirectToPage("./Index");
        }
    }
}
