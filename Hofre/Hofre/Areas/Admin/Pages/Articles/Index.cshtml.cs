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
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _repository;
        public List<ArticleViewModel> articles;
        public IndexModel(IArticleApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            articles =await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPost(long Id)
        {
           await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
