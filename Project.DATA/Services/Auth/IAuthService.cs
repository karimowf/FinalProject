using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Services.Auth
{
    public interface IAuthService
    {
        Task<GenericApiResponse<BaseResponse>> RegisterUserAsync(UserRegisterRequest model);

        Task<GenericApiResponse<UserLoginResponse>> UserLoginAsync(UserLoginRequest model);
    }
}
