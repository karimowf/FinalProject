using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Products
{
    public class UpdateProductCommandRequest(
    int id,
    string? name,
    int? stockQuantity,
    string? description,
    int? categoryId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public UpdateProductCommandRequest() : this(0, string.Empty, 0,
            string.Empty, 0)
        {
        }

        public int Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public int? StockQuantity { get; set; } = stockQuantity;
        public string? Description { get; set; } = description;
        public int? CategoryId { get; set; } = categoryId;
    }
}
