using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.RequestModels.Auth
{
    public class UserRegisterRequest(string userName, string email, string password, string confirmPassword)
    {
        public UserRegisterRequest() : this(string.Empty, string.Empty, string.Empty,
            string.Empty)
        {
        }

        public string UserName { get; set; } = userName;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public string ConfirmPassword { get; set; } = confirmPassword;
    }
}
