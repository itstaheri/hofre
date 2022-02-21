using AM.Application;
using AM.Application.Contract.ArticleCategory;
using AM.Domain.ArticleCategoryAgg;
using AM.Infrastracture.Efcore;
using AM.Infrastracture.Efcore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AM.Configuration
{
    public class ArticleBootestrapper
    {
        public static void Configuration(IServiceCollection services,string ConnectionString)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddDbContext<ArticleContext>(x => { x.UseSqlServer(ConnectionString); });
            
        }
    }
}
