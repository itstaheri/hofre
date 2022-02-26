using AM.Application.Contract.Article;
using AM.Domain.ArticleAgg;
using AM.Domain.ArticleCategoryAgg;
using AM.Infrastracture.Efcore;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _Upload;
        private readonly IArticleRepository _repository;
        private readonly ArticleContext _context;
        public ArticleApplication(IArticleRepository repository, ArticleContext context, IFileUploader Upload)
        {
            _repository = repository;
            _context = context;
            _Upload = Upload;
        }

        public bool Create(CreateArticle commend)
        {
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _context.Database.BeginTransaction();
            string PictureName = _Upload.ArticleUploader(commend.Picture, commend.Title);
            string VideoName = _Upload.ArticleUploader(commend.Video, commend.Title);
            var article = new ArticleModel(commend.Title, commend.Slug, commend.ShortDescription, commend.Description,
              VideoName, PictureName, commend.PictureAlt, commend.PictureTitle);
            _repository.Create(article);

            foreach (var tag in commend.Tags)
            {
                var addtag = new ArticleTagsModel(tag, article.Id);
                _context.articleTags.Add(addtag);
            }

            foreach (var item in commend.Categories)
            {
                var a2c = new ArticleToCategoryModel(article.Id, item);
                _context.articleToCategories.Add(a2c);
            }
            _repository.Save();

            transaction.Commit();
            return true;
        }

        public bool Edit(EditArticle commend)
        {
            string PictureName = _Upload.ArticleUploader(commend.Picture, commend.Title);
            string VideoName = _Upload.ArticleUploader(commend.Video, commend.Title);
            var article = _repository.Getby(commend.Id);
            article.Edit(commend.Title, commend.Slug, commend.ShortDescription, commend.Description
              , VideoName, PictureName, commend.PictureAlt, commend.PictureTitle);
            var a2c = _context.articleToCategories.Where(x => x.ArticleId == commend.Id);
            var tags = _context.articleTags.Where(x => x.ArticleId == commend.Id);
            #region tag
            foreach (var item in tags)
            {
                _context.articleTags.Remove(item);
            }
            _repository.Save();
            foreach (var tag in commend.Tags)
            {
                var addtag = new ArticleTagsModel(tag, article.Id);
                _context.articleTags.Add(addtag);
            }
            #endregion
            #region articletocategory
            foreach (var item in a2c)
            {
                _context.articleToCategories.Remove(item);
            }
            _repository.Save();
            foreach (var item in commend.Categories)
            {
                var articletocategory = new ArticleToCategoryModel(article.Id, item);
                _context.articleToCategories.Add(articletocategory);
            }
            #endregion
            _repository.Save();
            return true;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditArticle GetValueForEdit(long Id)
        {
            var article = _repository.Getby(Id);
            return new EditArticle
            {
                Id = article.Id,
                Description = article.Description,
                ShortDescription = article.ShortDescription,
                PictureAlt = article.PictureAlt,
                PictureTitle = article.PictureTitle,
                Slug = article.Slug,
                Title = article.Slug,
            };
        }

        public bool Remove(long Id)
        {
            _repository.Remove(Id);
            _repository.Save();
            return true;
        }
    }
}
