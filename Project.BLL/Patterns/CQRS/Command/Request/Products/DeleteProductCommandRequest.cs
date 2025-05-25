using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Products
{
    public class DeleteProductCommandRequest(int productId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public DeleteProductCommandRequest() : this(0)
        {
        }

        public int ProductId { get; set; } = productId;
    }
}
