using AM.Application.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleApplication _application;
        public ArticleController(IArticleApplication application)
        {
            _application = application;
        }
        [HttpGet]
        public async Task<List<ArticleViewModel>> GetAll()
        {
            return await _application.GetAll();
        }
       
    }
}
