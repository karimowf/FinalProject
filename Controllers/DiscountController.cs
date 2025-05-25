using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Discounts;
using Project.BLL.Patterns.CQRS.Query.Request.Discount;

namespace Project.UI.Controllers;

[Route("api/dicounts")]
[ApiController]
public class DiscountController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> ApplyDiscountAsync([FromBody] ApplyDiscountCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("active-discounts/{productId}")]
    public async Task<IActionResult> GetActiveDiscountsAsync([FromRoute] int productId)
        => Ok(await mediator.Send(new GetActiveDiscountsQueryRequest(productId)));

    [HttpGet("user-personalized-discounts")]
    public async Task<IActionResult> GetUserPersonalizedDiscountsAsync(
        [FromQuery] GetUserPersonalizedDiscountsQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpDelete("discounts/{discountId}")]
    public async Task<IActionResult> DeleteDiscountAsync([FromRoute] int discountId)
        => Ok(await mediator.Send(new DeleteDiscountCommandRequest(discountId)));

    [HttpDelete("user-personalized-discounts/{userId}")]
    public async Task<IActionResult> DeleteUserPersonalizedDiscountsAsync([FromRoute] int userId);
}