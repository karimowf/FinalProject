using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Exceptions
{
    public class RoleAssignmentFailedException : Exception
    {
        public RoleAssignmentFailedException() : base("Role assignment failed.")
        {
        }

        public RoleAssignmentFailedException(string message) : base(message)
        {
        }
    }
}
