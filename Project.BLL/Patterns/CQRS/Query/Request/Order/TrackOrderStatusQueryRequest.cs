using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Order
{
    public class TrackOrderStatusQueryRequest(int orderId, int userId) : IRequest<GenericApiResponse<TrackOrderStatusQueryResponse>>
    {
        public TrackOrderStatusQueryRequest() : this(0, 0)
        {
        }

        public int UserId { get; set; } = userId;
        public int OrderId { get; set; } = orderId;
    }
}
