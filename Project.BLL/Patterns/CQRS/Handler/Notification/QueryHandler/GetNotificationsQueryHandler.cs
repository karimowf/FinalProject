using MediatR;
using Project.BLL.Patterns.CQRS.Query.Request.Notification;
using Project.BLL.Patterns.CQRS.Query.Response.Notification;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Handler.Notification.QueryHandler
{
    public class GetNotificationsQueryHandler(
 ) : IRequestHandler<GetNotificationsQueryRequest, GenericApiResponse<GetNotificationsQueryResponse>>
    {
        public async Task<GenericApiResponse<GetNotificationsQueryResponse>> Handle(GetNotificationsQueryRequest request,
            CancellationToken cancellationToken)
        {

        }
    }

}
