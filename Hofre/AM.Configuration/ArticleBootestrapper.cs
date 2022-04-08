using AM.Application;
using AM.Application.Contract.Article;
using AM.Application.Contract.ArticleCategory;
using AM.Application.Contract.ArticleComment;
using AM.Domain.ArticleAgg;
using AM.Domain.ArticleCategoryAgg;
using AM.Domain.ArticleCommentAgg;
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
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleCommentRepository, ArticleCommentRepository>();
            services.AddTransient<IArticleCommentApplication, ArticleCommentApplication>();
            services.AddDbContext<ArticleContext>(x => { x.UseSqlServer(ConnectionString); });
            
        }
    }
}
