using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastracture.Efcore.Exceptions
{
    public class NotFoundException : Exception
    {
      
        public NotFoundException(string entityName,object key) : base($"Entity {entityName} not found with {key}")
        {

        }
        public NotFoundException(string entityName) : base($"There is no value inside the {entityName}")
        {

        }
    }
}
