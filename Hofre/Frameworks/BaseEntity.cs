using System;

namespace Frameworks
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
