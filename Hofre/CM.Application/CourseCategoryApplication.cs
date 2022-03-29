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

        public void Create(CreateCourseCategory commend)
        {
            var courseCategory = new CourseCategoryModel(commend.Name, commend.Slug);
            _repository.Create(courseCategory);
            _repository.Save();
        }

        public void Edit(EditCourseCategory commend)
        {
            var courseCategory = _repository.GetBy(commend.Id);
            courseCategory.Edit(commend.Name, commend.Slug);
            _repository.Save();
        }

        public List<CourseCategoryViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditCourseCategory GetValueForEdit(long Id)
        {
            var courseCategory = _repository.GetBy(Id);
            return new EditCourseCategory
            {
                Id = courseCategory.Id,
                Name =courseCategory.Name,
                Slug =courseCategory.Slug
            };
        }

        public void Remove(long Id)
        {
            _repository.Remove(Id);
            _repository.Save();
        }
    }
}
