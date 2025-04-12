using Microsoft.AspNetCore.Identity;
using Project.BLL.Abstract;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            var role = new Role { Name = roleName };
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }
    }
}
