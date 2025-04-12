using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IUserService
    {
        Task<bool> AssignRoleAsync(string userId, string roleName);
    }
}
