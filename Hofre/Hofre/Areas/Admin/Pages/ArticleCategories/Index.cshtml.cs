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

        public void OnGet()
        {

            articleCategories = _repository.GetAll();
        }
        public RedirectToPageResult OnPost(long Id)
        {
            var remove = _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}