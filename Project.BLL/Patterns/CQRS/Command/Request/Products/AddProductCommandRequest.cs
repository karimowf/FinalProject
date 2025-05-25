using MediatR;
using Project.Domain.Entities;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Products
{
    public class AddProductCommandRequest(
    int userId,
    int categoryId,
    string name,
    int stockQuantity,
    string? description,
    ProductCondition productCondition)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public AddProductCommandRequest() : this(0, 0, string.Empty, 0,
            string.Empty, ProductCondition.None)
        {
        }

        public int UserId { get; set; } = userId;
        public int CategoryId { get; set; } = categoryId;
        public string Name { get; set; } = name;
        public int StockQuantity { get; set; } = stockQuantity;
        public string? Description { get; set; } = description;
        public ProductCondition ProductCondition { get; set; }
    }
}
