using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string password, int? age);
    }
}
