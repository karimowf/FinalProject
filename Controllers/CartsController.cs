using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Carts;
using Project.BLL.Patterns.CQRS.Query.Request.Cart;

namespace Project.UI.Controllers;

[Route("api/carts")]
[ApiController]
public class CartsController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddToCartsAsync([FromBody] AddToCartCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpDelete]
    public async Task<IActionResult> RemoveFromCartAsync([FromBody] RemoveFromCartCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpPut]
    public async Task<IActionResult> UpdateCartAsync([FromBody] UpdateShoppingCartCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("by-user-id/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetCartsByUserIdAsync([FromRoute] int userId, GetCartsByUserIdQueryRequest request)
        => Ok(await mediator.Send(request));
}