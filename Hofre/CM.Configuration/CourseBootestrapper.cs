using CM.Application;
using CM.Application.Contract.Course;
using CM.Application.Contract.CourseCategory;
using CM.Domain.CourseAgg;
using CM.Domain.CourseCategoryAgg;
using CM.Infrastracture.Efcore;
using CM.Infrastracture.Efcore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CM.Configuration
{
    public class CourseBootestrapper
    {
        public static void Configuration(IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<CourseContext>(x => { x.UseSqlServer(ConnectionString); });
            services.AddTransient<ICourseApplication, CourseApplication>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseCategoryApplication, CourseCategoryApplication>();
            services.AddTransient<ICourseCategoryRepository, CourseCategoryRepository>();
        }
    }
}
