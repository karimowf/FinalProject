using Microsoft.AspNetCore.Identity;
using Project.BLL.Abstract;
using Project.BLL.Exceptions;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException($"User with ID {userId} was not found.");

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
                throw new RoleAssignmentFailedException($"Failed to assign role {roleName} to user {userId}.");
        }
    }
}
