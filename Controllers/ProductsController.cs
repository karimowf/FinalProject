using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Products;
using Project.BLL.Patterns.CQRS.Handler.Product.CommandHandler;
using Project.BLL.Patterns.CQRS.Query.Request.Product;

namespace Project.UI.Controllers;

[Route("api/products")]
[ApiController]

public class ProductsController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddProductAsync([FromBody] AddProductCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("all-categories-filter")]
    public async Task<IActionResult> GetProductsWithFilterAsync([FromQuery] GetProductWithFilterQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpDelete]
    //to do: burda rol esasli olacaq ancaq sailer rolundakilara access olacaq
    public async Task<IActionResult> DeleteProductAsync([FromBody] DeleteProductCommandHandler request)
        => Ok(await mediator.Send(request));
}