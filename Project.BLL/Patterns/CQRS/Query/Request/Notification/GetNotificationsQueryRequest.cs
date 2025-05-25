using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Notification
{
    public class GetNotificationsQueryRequest : IRequest<GenericApiResponse<GetNotificationsQueryResponse>>
    {

    }
}
