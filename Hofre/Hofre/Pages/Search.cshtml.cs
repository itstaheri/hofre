using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Query.Modules.Article;
using Query.Modules.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IArticleQueryRepository _article;
        private readonly ICourseQueryRepository _course;
        public List<ArticleQueryViewModel> articles { get; set; }
        public ArticlePageViewModel ArticlePage { get; set; }
        public List<CourseQueryViewModel> courses { get; set; }
        public string Value;
        public SearchModel(IArticleQueryRepository article, ICourseQueryRepository course)
        {
            _article = article;
            _course = course;
        }
        public async Task OnGet(string entery,int pageId = 1)
        {
            Value = entery;
            ArticlePage = await _article.Search(entery,pageId);
            courses  = await _course.Search(entery);
        
        }
    }
}
