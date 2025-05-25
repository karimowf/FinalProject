using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Orders;
using Project.BLL.Patterns.CQRS.Query.Request.Order;
using Project.Domain.Entities;

namespace Project.UI.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpDelete("cancel-order/{id}")]
    public async Task<IActionResult> CancelOrderAsync([FromRoute] int id)
        => Ok(await mediator.Send(new CancelOrderCommandRequest() { Id = id }));

    [HttpGet("created-orders")]
    public async Task<IActionResult> GetAllCreatedOrdersAsync([FromQuery] GetAllCreatedOrdersQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpPut("order-address")]
    public async Task<IActionResult> UpdateOrderAddressAsync([FromBody] UpdateOrderAddressCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpPut("order-status")]
    public async Task<IActionResult> UpdateOrderStatusAsync([FromBody] UpdateOrderStatusCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("track-order-status")]
    public async Task<IActionResult> TrackOrderStatusAsync([FromQuery] TrackOrderStatusQueryRequest request)
        => Ok(await mediator.Send(request));
}