using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.BLL.Abstract;
using Project.BLL.Model;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public JwtTokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<TokenResponse> GenerateJwtTokenAsync(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenResponse
            {
                Token = tokenString,
                Expiration = tokenDescriptor.Expires.Value
            };
        }
    }
}
