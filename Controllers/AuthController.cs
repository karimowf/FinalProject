using Microsoft.AspNetCore.Mvc;
using Project.Domain.Models.RequestModels.Auth;
using Project.Domain.Models.ResponseModels;
using Project.Domain.Services.Auth;

namespace Project.UI.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthController(IAuthService authService) : Controller
{
    [HttpPost("user-register")]
    public async Task<IActionResult> UserRegisterAsync([FromBody] UserRegisterRequest request)
    {
        var response = await authService.RegisterUserAsync(request);

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpPost("user-login")]
    public async Task<IActionResult>? UserLoginAsync([FromBody] UserLoginRequest request)
    {
        var userLoginData= await authService.UserLoginAsync(request);
    }
}