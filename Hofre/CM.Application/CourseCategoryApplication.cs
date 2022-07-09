using CM.Application.Contract.CourseCategory;
using CM.Domain.CourseCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application
{
    public class CourseCategoryApplication : ICourseCategoryApplication
    {
        private readonly ICourseCategoryRepository _repository;

        public CourseCategoryApplication(ICourseCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateCourseCategory commend)
        {
            var courseCategory = new CourseCategoryModel(commend.Name, commend.Slug);
           await _repository.Create(courseCategory);
           await _repository.Save();
        }

        public async Task Edit(EditCourseCategory commend)
        {
            var courseCategory =await _repository.GetBy(commend.Id);
            courseCategory.Edit(commend.Name, commend.Slug);
           await _repository.Save();
        }

        public async Task<List<CourseCategoryViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<EditCourseCategory> GetValueForEdit(long Id)
        {
            var courseCategory = await _repository.GetBy(Id);
            return new EditCourseCategory
            {
                Id = courseCategory.Id,
                Name =courseCategory.Name,
                Slug =courseCategory.Slug
            };
        }

        public async Task Remove(long Id)
        {
           await _repository.Remove(Id);
           await _repository.Save();
        }
    }
}
