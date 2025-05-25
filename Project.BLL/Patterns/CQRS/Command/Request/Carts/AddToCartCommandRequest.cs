using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Carts
{
    public class AddToCartCommandRequest(
    ) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
    }
}
