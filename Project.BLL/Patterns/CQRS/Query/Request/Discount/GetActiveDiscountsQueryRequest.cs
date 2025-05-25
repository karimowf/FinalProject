using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Discount
{
    public class GetActiveDiscountsQueryRequest(int productId)
    : IRequest<GenericApiResponse<List<GetActiveDiscountsQueryResponse>>>
    {
        public GetActiveDiscountsQueryRequest() : this(0)
        {
        }

        public int ProductId { get; set; } = productId;
    }
}
