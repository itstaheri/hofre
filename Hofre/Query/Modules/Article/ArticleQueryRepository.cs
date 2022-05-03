﻿using AM.Infrastracture.Efcore;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Infrastracture.Efcore;

namespace Query.Modules.Article
{
    public class ArticleQueryRepository : IArticleQueryRepository
    {
        private readonly ILogger<ArticleQueryRepository> _logger;
        private readonly ArticleContext _context;
        private readonly UserContext _user;
        public ArticleQueryRepository(ArticleContext context, UserContext user, ILogger<ArticleQueryRepository> logger)
        {
            _context = context;
            _user = user;
            _logger = logger;
        }

        public async Task<List<ArticleQueryViewModel>> GetAll()
        {
            var query =await _context.articles.Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Video = x.Video,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCategories = new List<ArticleCategoryQueryModel>(),
                ArticleComments = new List<ArticleCommentQueryViewModel>(),
                ArticleTags = new List<string>()
                


            }).AsNoTracking().ToListAsync();

            foreach (var item in query)
            {
                var categories = await _context.articleToCategories.Where(c => c.ArticleId == item.Id).Select(x => x.articleCategory).ToListAsync();
                foreach (var cat in categories)
                {
                    item.ArticleCategories.Add(new ArticleCategoryQueryModel { Id = cat.Id, Name = cat.Name });
                }
            }

            if (query == null)
            {
                throw new Exception();
            }
            return query;


        }

        

        public async Task<List<ArticleCommentQueryViewModel>> GetCommentsById(long Id)
        {
            var query = await _context.articleComments.Where(c => c.Id == Id && c.IsActive == true).Select(x => new ArticleCommentQueryViewModel
            {
                Id = x.Id,
                Text = x.Text,
                UserId = x.UserId,
                CreationDate = x.CreationDate.ToFarsi(),
            }).ToListAsync();
            query.ForEach(async x => x.Username = (await _user.users.FirstOrDefaultAsync(c => c.Id == x.UserId)).Username);
            return query;

        }

        public async Task<ArticleQueryViewModel> GetDetailById(long Id)
        {
            var query =await _context.articles.Select(x=>new ArticleQueryViewModel  
            {
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Video = x.Video,
                
            }).FirstOrDefaultAsync(q=>q.Id == Id);

            query.ArticleTags.ForEach(async tag => tag =(await _context.articleTags.FirstOrDefaultAsync(q => q.ArticleId == Id)).Name);

            var categories =await _context.articleToCategories.Where(x => x.ArticleId == query.Id).ToListAsync();
            foreach (var item in categories)
            {
                foreach (var ct in query.ArticleCategories)
                {
                    ct.Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == item.ArticleCategoryId)).Name;
                    ct.Id = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == item.ArticleCategoryId)).Id;
                }
            }
           
            return query;
            
        }

        public async Task<List<ArticleQueryViewModel>> Search(string entery)
        {
            var query = await _context.articles.Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Video = x.Video,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Description = x.Description,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToFarsi(),

            }).AsNoTracking()
            .Where(x => x.Title.Contains(entery)).ToListAsync();

            foreach (var item in query)
            {
                foreach (var cat in item.ArticleCategories)
                {
                    cat.Id = (await _context.articleToCategories.FirstOrDefaultAsync(x => x.ArticleId == item.Id)).ArticleCategoryId;
                    cat.Name = (await _context.articleCategories.FirstOrDefaultAsync(x => x.Id == cat.Id)).Name;
                }
            }

            return query;
        }
    }
}