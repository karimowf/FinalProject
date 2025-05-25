using MediatR;
using Project.Domain.Enums;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Discounts
{
    public class ApplyDiscountCommandRequest(
     int productId,
     decimal discountValue,
     DiscountType discountType,
     DateTime expirationDate) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public ApplyDiscountCommandRequest() : this(0, 0, DiscountType.None, DateTime.MinValue)
        {
        }

        public int ProductId { get; set; } = productId;
        public decimal DiscountValue { get; set; } = discountValue;
        public DiscountType DiscountType { get; set; } = discountType;
        public DateTime ExpiryDate { get; set; } = expirationDate;
    }
}
