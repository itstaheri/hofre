using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.UserAgg
{
    public class UserResetModel
    {
        public UserResetModel(long userId, string genericCode)
        {
            UserId = userId;
            CreationDate = DateTime.Now;
            ExpireDate = DateTime.Now.AddDays(1);
            GenericCode = genericCode;
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string GenericCode { get; set; }
    }
}
