using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Comparisons
{
    public class AddComparisonQueryRequest(int productId, int userId)
     : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public AddComparisonQueryRequest() : this(0, 0)
        {
        }

        public int ProductId { get; set; } = productId;
        public int UserId { get; set; } = userId;
    }
}
