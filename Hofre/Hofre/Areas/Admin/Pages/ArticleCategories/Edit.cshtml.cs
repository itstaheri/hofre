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

        public async Task OnGet(long Id)
        {
            articleCategory =await _repository.GetValueForEdit(Id);
        }
        public async Task<RedirectToPageResult> OnPost(EditArticleCategory commend)
        {
            await _repository.Edit(commend);

            return RedirectToPage("./Index");
        }
    }
}
