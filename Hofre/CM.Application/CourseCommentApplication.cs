using CM.Application.Contract.CourseComment;
using CM.Domain.CourseAgg;
using CM.Domain.CourseCommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application
{
    public class CourseCommentApplication : ICourseCommentApplication
    {
        private readonly ICourseCommentRepository _repository;

        public CourseCommentApplication(ICourseCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task Active(long Id)
        {
            var comment = await _repository.GetBy(Id);
            comment.Active();
            await _repository.Save();

        }

        public async Task Create(CreateCourseComment commend)
        {
            var comment = new CourseCommentModel(commend.Text, commend.Username, commend.CourseId);
            await _repository.Create(comment);
            await _repository.Save();

        }

        public async Task DeActive(long Id)
        {
            var comment = await _repository.GetBy(Id);
            comment.DeActive();
            await _repository.Save();
        }

        public async Task<List<CourseCommentViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<CourseCommentViewModel>> GetCommentsBy(long Id)
        {
            return await _repository.GetCommentsBy(Id);
        }

        public async Task Remove(long Id)
        {
            await _repository.Remove(Id);
        }
    }
}
