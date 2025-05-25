using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.ResponseModels.Auth
{
    public class UserLoginResponse(
     string userId,
     string userName,
     string email,
     string accessToken,
     string refreshToken,
     DateTime accessTokenExpiry,
     DateTime refreshTokenExpiry)
    {
        public UserLoginResponse() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
            DateTime.MinValue, DateTime.MinValue)
        {
        }

        public string UserId { get; set; } = userId;
        public string UserName { get; set; } = userName;
        public string Email { get; set; } = email;
        public string AccessToken { get; set; } = accessToken;
        public string RefreshToken { get; set; } = refreshToken;
        public DateTime AccessTokenExpiration { get; set; } = accessTokenExpiry;
        public DateTime RefreshTokenExpiration { get; set; } = refreshTokenExpiry;
    }
}
