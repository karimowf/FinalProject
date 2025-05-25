using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Orders
{
    public class CancelOrderCommandRequest(int id) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public CancelOrderCommandRequest() : this(0)
        {
        }

        public int Id { get; set; }
    }
}
