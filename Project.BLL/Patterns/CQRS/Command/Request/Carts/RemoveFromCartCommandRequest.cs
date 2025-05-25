using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Carts
{
    public class RemoveFromCartCommandRequest(int? productId, int? userId)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public RemoveFromCartCommandRequest() : this(0, 0)
        {
        }

        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
