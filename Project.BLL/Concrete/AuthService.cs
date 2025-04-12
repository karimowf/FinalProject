using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Project.BLL.Abstract;
using Project.BLL.Exceptions;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new UserNotFoundException("User with the provided email was not found.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                throw new InvalidPasswordException("The provided password is incorrect.");

            return await _jwtTokenService.GenerateJwtTokenAsync(user);
        }

        public async Task<bool> RegisterAsync(string email, string password, int? age)
        {
            var user = new User
            {
                UserName = email,
                Email = email,
                Age = age
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return false;

            await _userManager.AddToRoleAsync(user, "Customer");
            return true;
        }
    }
}
