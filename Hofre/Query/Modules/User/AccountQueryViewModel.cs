using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Modules.User
{
    public class AccountQueryViewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public long RoleId { get; set; }
        public string ProfilePicture { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<UserCourseQueryViewModel> Courses { get; set; }
        public List<UserCourseCommentQueryViewModel> CourseComments { get; set; }
        public List<UserArticleCommentQueryViewModel> ArticleComments { get; set; }
        public List<UserOrderQueryViewModel> Orders { get; set; }
    }
}
