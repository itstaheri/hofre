using AM.Application.Contract.ArticleCategory;
using AM.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;

        public ArticleCategoryApplication(IArticleCategoryRepository repoiitory)
        {
            _repository = repoiitory;
        }

        public bool Create(CreateArticleCategory commend)
        {

            var articleCategory = new ArticleCategoryModel(commend.Name);
            _repository.Create(articleCategory);
            return true;

        }

        public bool Edit(EditArticleCategory commend)
        {
            var articleCategory = _repository.GetBy(commend.Id);
            articleCategory.Edit(commend.Name);
            _repository.Save();
            return true;
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditArticleCategory GetValueForEdit(long Id)
        {
            var articleCategory = _repository.GetBy(Id);
            return new EditArticleCategory
            {
                Id = articleCategory.Id,
                Name = articleCategory.Name
            };
        }

        public bool Remove(long Id)
        {
            _repository.Remove(Id);
            return true;
        }
    }
}
