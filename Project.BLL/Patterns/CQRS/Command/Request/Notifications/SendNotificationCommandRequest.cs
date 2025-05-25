using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Notifications
{
    public class SendNotificationCommandRequest(int userId, string title, string message, string? redirectUrl)
     : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public SendNotificationCommandRequest() : this(0, string.Empty, string.Empty, string.Empty)
        {
        }

        public int UserId { get; set; } = userId;
        public string Title { get; set; } = title;
        public string Message { get; set; } = message;
        public string? RedirectUrl { get; set; } = redirectUrl;
    }
}
