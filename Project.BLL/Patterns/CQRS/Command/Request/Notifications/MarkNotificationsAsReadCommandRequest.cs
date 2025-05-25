using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Notifications
{
    public class MarkNotificationsAsReadCommandRequest(int userId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public MarkNotificationsAsReadCommandRequest() : this(0)
        {
        }

        public int UserId { get; set; } = userId;
    }
}
