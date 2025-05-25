using Microsoft.AspNetCore.Identity;
using Project.BLL.Patterns.CQRS.BaseResponse;
using Project.Domain.Models.RequestModels.Auth;
using Project.Domain.Models.ResponseModels.Auth;
using Project.Domain.Services.Auth;
using Project.Shared;
using System.Security.Claims;

namespace Project.BLL.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<GenericApiResponse<BaseResponse>> RegisterUserAsync(UserRegisterRequest model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var successData = new BaseResponse { IsSuccess = true, Message = "Registration successful." };
                return GenericApiResponse<BaseResponse>.Success(successData, 200);
            }

            var errors = result.Errors.Select(e => e.Description).ToList();
            return GenericApiResponse<BaseResponse>.Fail(errors, 400);
        }


        public async Task<GenericApiResponse<UserLoginResponse>> UserLoginAsync(UserLoginRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return GenericApiResponse<UserLoginResponse>.Fail("User not found.", 404);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!signInResult.Succeeded)
            {
                return GenericApiResponse<UserLoginResponse>.Fail("Invalid credentials or user cannot sign in.", 400);
            }

            var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
        };

            var accessToken = _tokenService.GenerateAccessToken(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var accessTokenExp = _tokenService.GetAccessTokenExpiration();
            var refreshTokenExp = _tokenService.GetRefreshTokenExpiration();

            var response = new UserLoginResponse
            {
                UserId = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiration = accessTokenExp,
                RefreshTokenExpiration = refreshTokenExp
            };

            return GenericApiResponse<UserLoginResponse>.Success(response, 200);
        }
    }

}
