using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Exceptions
{
    public class IsExistException: Exception
    {
        public IsExistException(): base()
        {
            
        }

        public IsExistException(string message): base(message)
        {
            
        }
    }
}
