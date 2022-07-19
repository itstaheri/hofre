﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.Article
{
    public interface IArticleQueryRepository
    {
        Task<List<ArticleQueryViewModel>> GetAll();
        Task<List<ArticleQueryViewModel>> GetAll(long Id);
        Task<ArticleQueryViewModel> GetDetailBy(long Id);
        Task<ArticleQueryViewModel> GetDetailBy(string slug);
        Task<List<ArticleQueryViewModel>> Search(string entery);
        Task<List<ArticleQueryViewModel>> GetRelatedArticlesBy(long CategoryId);
        Task<List<ArticleCategoryQueryModel>> GetAllCategories();
        Task<List<ArticleQueryViewModel>> GetArticlesByCategory(long CategoryId);
    }
}
