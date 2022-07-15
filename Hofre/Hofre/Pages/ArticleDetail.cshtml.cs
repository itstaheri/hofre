using AM.Application.Contract.ArticleComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class ArticleDetailModel : PageModel
    {
        private readonly IArticleQueryRepository _repository;
        private readonly IArticleCommentApplication _comment;
        public ArticleQueryViewModel Article { get; set; }

        public ArticleDetailModel(IArticleQueryRepository repository,IArticleCommentApplication comment)
        {
            _repository = repository;
            _comment = comment;
        }
        public async Task OnGet(string slug)
        
        {
            Article = await _repository.GetDetailBy(slug);
        
        }
        public async Task<RedirectToPageResult> OnPost(CreateArticleComment commend)
        {
            await _comment.Create(commend);
            return RedirectToPage();
        }
        
    }
}
