using CM.Application.Contract.Course;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CM.Presentation.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseApplication _application;

        public CourseController(ICourseApplication application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<List<CourseViewModel>> GetAll()
        {
           return await _application.GetAll();
        }
    }
}
