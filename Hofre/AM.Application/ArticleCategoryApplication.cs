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

        public async Task Create(CreateArticleCategory commend)
        {

            var articleCategory = new ArticleCategoryModel(commend.Name);
            await _repository.Create(articleCategory);

        }

        public async Task Edit(EditArticleCategory commend)
        {
            var articleCategory = await _repository.GetBy(commend.Id);
            articleCategory.Edit(commend.Name);
            await _repository.Save();
        }

        public async Task<List<ArticleCategoryViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<EditArticleCategory> GetValueForEdit(long Id)
        {
            var articleCategory = await _repository.GetBy(Id);
            return new EditArticleCategory
            {
                Id = articleCategory.Id,
                Name = articleCategory.Name
            };
        }

        public async Task Remove(long Id)
        {
           await _repository.Remove(Id);
        }
    }
}
