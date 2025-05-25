using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Review
{
    public class GetProductFeedbackSummaryQueryRequest(int productId)
    : IRequest<GenericApiResponse<GetProductFeedbackSummaryQueryResponse>>
    {
        public GetProductFeedbackSummaryQueryRequest() : this(0)
        {
        }

        public int ProductId { get; set; } = productId;
    }
}
