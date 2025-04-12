using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string roleName);
    }
}
