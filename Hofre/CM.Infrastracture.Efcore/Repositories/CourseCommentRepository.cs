using CM.Application.Contract.CourseComment;
using CM.Domain.CourseCommentAgg;
using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Infrastracture.Efcore.Repositories
{
    public class CourseCommentRepository : ICourseCommentRepository
    {
        private readonly CourseContext _context;

        public CourseCommentRepository(CourseContext context)
        {
            _context = context;
        }

        public async Task Create(CourseCommentModel commend)
        {
            await _context.courseComments.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CourseCommentViewModel>> GetAll()
        {
            return await _context.courseComments.Include(x => x.course).Select(x => new CourseCommentViewModel
            {
                CourseId = x.CourseId,
                CreationDate = x.CreationDate.ToFarsi(),
                IsActive = x.IsActive,
                Id = x.Id,
                Text = x.Text,
                Username = x.Username,
                CourseSubject = x.course.Subject


            }).ToListAsync();
        }

        public async Task<CourseCommentModel> GetBy(long Id)
        {
            return await _context.courseComments.FirstOrDefaultAsync(x => x.Id == Id);

        }

        public async Task<List<CourseCommentViewModel>> GetCommentsBy(long Id)
        {
            return await _context.courseComments.Include(x => x.course).Select(x => new CourseCommentViewModel
            {
                CourseId = x.CourseId,
                CreationDate = x.CreationDate.ToFarsi(),
                IsActive = x.IsActive,
                Id = x.Id,
                Text = x.Text,
                Username = x.Username,
                CourseSubject = x.course.Subject


            }).Where(q=>q.IsActive && q.CourseId == Id).ToListAsync();
        }

        public async Task Remove(long Id)
        {
            var comment = await _context.courseComments.FirstOrDefaultAsync(x => x.Id == Id);
            _context.courseComments.Remove(comment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
        public async Task Save()
        {


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
