using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Review
{
    public class HasUserReviewedProductQueryRequest(int userId, int productId)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public HasUserReviewedProductQueryRequest() : this(0, 0)
        {
        }

        public int UserId { get; set; } = userId;
        public int ProductId { get; set; } = productId;
    }
}
