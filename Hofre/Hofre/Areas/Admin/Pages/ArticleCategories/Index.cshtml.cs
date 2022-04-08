using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.Application;
using AM.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hofre.Areas.Admin.Pages.ArticleCategories
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _repository;
        public List<ArticleCategoryViewModel> articleCategories;
     ///   IArticleCategoryApplication a = new ArticleCategoryApplication();
        public IndexModel(IArticleCategoryApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {

            articleCategories =await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPost(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
