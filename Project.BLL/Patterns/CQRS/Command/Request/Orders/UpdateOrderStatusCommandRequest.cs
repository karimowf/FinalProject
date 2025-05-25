using MediatR;
using Project.Domain.Entities;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Orders
{
    public class UpdateOrderStatusCommandRequest(int orderId, OrderStatus newStatus)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public UpdateOrderStatusCommandRequest() : this(0, OrderStatus.None)
        {
        }

        public int OrderId { get; set; } = orderId;
        public OrderStatus NewStatus { get; set; } = newStatus;
    }
}
