using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Query.Modules.Article;
using Query.Modules.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hofre.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleQueryRepository _article;
        private readonly ICourseQueryRepository _course;

        public IndexModel(ILogger<IndexModel> logger, IArticleQueryRepository article,ICourseQueryRepository course)
        {
            _logger = logger;
            _article = article;
            _course = course;
        }

        public List<ArticleQueryViewModel> Articles { get; set; }
        public List<ArticleCommentQueryViewModel> Comments { get; set; }
        public List<CourseQueryViewModel> Courses { get; set; }
        

        public  async Task OnGet()
        {
            Articles = (await _article.GetAll()).Articles.Take(6).ToList();
            Courses = (await _course.GetAll()).Courses.Take(6).ToList();
        
        }
       
      
    }
}
