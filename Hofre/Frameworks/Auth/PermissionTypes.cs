using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Auth
{
    public static class PermissionTypes
    {
        public static class Article
        {
            public const string Create = "Permission.Article.Create";
            public const string View = "Permission.Article.View";
            public const string Edit = "Permission.Article.Edit";
            public const string Delete = "Permission.Article.Delete";
        }
        public static class Course
        {
            public const string Create = "Permission.Course.Create";
            public const string View = "Permission.Course.View";
            public const string Edit = "Permission.Course.Edit";
            public const string Delete = "Permission.Course.Delete";
        }
        public static class User
        {
            public const string Create = "Permission.User.Create";
            public const string View = "Permission.User.View";
            public const string Edit = "Permission.User.Edit";
            public const string Delete = "Permission.User.Delete";
        }
        public static class Setting
        {
            public const string Edit = "Permission.Setting.Edit";
        }
        public static class Discount
        {
            public const string Create = "Permission.Discount.Create";
            public const string View = "Permission.Discount.View";
            public const string Edit = "Permission.Discount.Edit";
            public const string Delete = "Permission.Discount.Delete";
        }
    }
}
