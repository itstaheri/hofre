using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.ArticleCategories
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _repository;
        [BindProperty] public EditArticleCategory articleCategory { get; set; }
        public EditModel(IArticleCategoryApplication repository)
        {
            _repository = repository;
        }

        public void OnGet(long Id)
        {
            articleCategory = _repository.GetValueForEdit(Id);
        }
        public RedirectToPageResult OnPost(EditArticleCategory commend)
        {
            var result = _repository.Edit(commend);

            return RedirectToPage("./Index");
        }
    }
}
