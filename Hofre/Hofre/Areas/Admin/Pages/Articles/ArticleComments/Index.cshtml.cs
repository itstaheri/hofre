using AM.Application.Contract.ArticleComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Areas.Admin.Pages.Articles.ArticleComments
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCommentApplication _repository;
        public List<ArticleCommentViewModel> ArticleComments { get; set; }
        public IndexModel(IArticleCommentApplication repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            ArticleComments = await _repository.GetAll();
        }
        public async Task<RedirectToPageResult> OnPostActive(long Id)
        {
            await _repository.Active(Id);
            return RedirectToPage();
        }
        public async Task<RedirectToPageResult> OnPostDeActive(long Id)
        {
            await _repository.DeActive(Id);
            return RedirectToPage();
        }
        public async Task<RedirectToPageResult> OnPostRemove(long Id)
        {
            await _repository.Remove(Id);
            return RedirectToPage();
        }
    }
}
