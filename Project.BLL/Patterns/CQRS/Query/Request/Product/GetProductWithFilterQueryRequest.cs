using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Product
{
    public class GetProductWithFilterQueryRequest(
    int? productId,
    int? stockQuantity,
    string? name) : IRequest<GenericApiResponse<List<GetProductWithFilterQueryResponse>>>
    {
        public GetProductWithFilterQueryRequest() : this(null, null, null)
        {
        }

        public int? ProductId { get; set; } = productId;
        public int? StockQuantity { get; set; } = stockQuantity;
        public string? Name { get; set; } = name;
    }
}
