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
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articlecategory;
        public List<SelectListItem> categories;
        private readonly IArticleApplication _repository;
        public List<SelectListItem> articleTags;
        [BindProperty] public EditArticle Article { get; set; }

        public EditModel(IArticleCategoryApplication articlecategory, IArticleApplication repository)
        {
            _articlecategory = articlecategory;
            _repository = repository;
        }

        public async Task OnGet(long Id)
        {
            Article =await _repository.GetValueForEdit(Id);
            articleTags =(await _repository.GetTagsBy(Id)).Select(x=>new SelectListItem(x.Title,x.TagId.ToString())).ToList();
            categories =(await _articlecategory.GetAll()).Select(x => new SelectListItem(x.Name, x.Id.ToString(),true)).ToList();
        }
        public async Task<RedirectToPageResult> OnPost(EditArticle commend)
        {
           await _repository.Edit(commend);
            return RedirectToPage("./Index");
        }
    }
}
