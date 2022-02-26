using AM.Domain.ArticleAgg;
using AM.Domain.ArticleCategoryAgg;
using AM.Infrastracture.Efcore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace AM.Infrastracture.Efcore
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {

        }
        public DbSet<ArticleToCategoryModel> articleToCategories { get; set; }
        public DbSet<ArticleCategoryModel> articleCategories { get; set; }
        public DbSet<ArticleModel> articles { get; set; }
        public DbSet<ArticleTagsModel> articleTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleMapp());
            builder.ApplyConfiguration(new ArticleCategoryMapp());
            builder.ApplyConfiguration(new ArticleTagsMapp());
            builder.ApplyConfiguration(new ArticleToCategoryMapp());
            base.OnModelCreating(builder);
        }
    }
}
