using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Review;
using Project.BLL.Patterns.CQRS.Query.Request.Review;

namespace Project.UI.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateReviewAsync([FromBody] CreateReviewCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("user-feedback-history")]
    public async Task<IActionResult> GetUserFeedbackHistoryAsync([FromQuery] GetUserFeedbackHistoryQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("has-user-feedback-product")]
    public async Task<IActionResult> HasUserReviewedProductAsync([FromQuery] HasUserReviewedProductQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpGet("product-feedback-summary")]
    public async Task<IActionResult> GetProductFeedbackSummaryAsync(
        [FromQuery] GetProductFeedbackSummaryQueryRequest request)
        => Ok(await mediator.Send(request));

    [HttpPut]
    public async Task<IActionResult> UpdateFeedbackAsync([FromBody] UpdateFeedbackCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedbackAsync([FromRoute] int id)
        => Ok(await mediator.Send(new DeleteFeedbackCommandRequest(id)));
}