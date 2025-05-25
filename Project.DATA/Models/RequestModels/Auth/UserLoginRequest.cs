using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.RequestModels.Auth
{
    public class UserLoginRequest(string userName, string password)
    {
        public UserLoginRequest() : this(string.Empty, string.Empty)
        {
        }

        public string UserName { get; set; } = userName;

        public string Password { get; set; } = password;
    }
}
