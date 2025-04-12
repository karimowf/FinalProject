using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Invalid password.")
        {
        }

        public InvalidPasswordException(string message) : base(message)
        {
        }
    }
}
