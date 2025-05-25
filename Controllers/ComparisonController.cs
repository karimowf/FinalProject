using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Comparisons;
using Project.BLL.Patterns.CQRS.Query.Request.Comparison;

namespace Project.UI.Controllers;

[Route("api/comparisons")]
[ApiController]

public class ComparisonController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddToComparisonAsync([FromBody] AddComparisonQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("comparison-products-by-userId/{userId}")]
    public async Task<IActionResult> GetComparisonProductsByUserIdAsync([FromRoute] int userId)
        => Ok(await mediator.Send(new GetComparisonProductsByUserIdRequest() { UserId = userId }));

    [HttpDelete("{comparisonId}")]
    public async Task<IActionResult> RemoveFromComparisonAsync([FromRoute] int comparisonId)
        => Ok(await mediator.Send(new DeleteComparisonCommandRequest() { ComparisonId = comparisonId }));
}