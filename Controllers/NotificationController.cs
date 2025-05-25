using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Notifications;

namespace Project.UI.Controllers;

[Route("api/notifications")]
[ApiController]
public class NotificationController(IMediator mediator) : Controller
{
    [HttpPost("send-notification")]
    public async Task<IActionResult> SendNotificationAsync([FromBody] SendNotificationCommandRequest request)
        => Ok(await mediator.Send(request));

    [HttpPut("mark-as-read/{userId}")]
    public async Task<IActionResult> MarkAsReadNotificationAsync(
        [FromBody] MarkNotificationsAsReadCommandRequest request)
        => Ok(await mediator.Send(request));
    
    [HttpGet]
    public async Task<IActionResult> GetNotificationsAsync()
}