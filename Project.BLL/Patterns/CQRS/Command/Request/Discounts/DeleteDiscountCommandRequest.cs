using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Discounts
{
    public class DeleteDiscountCommandRequest(int discountId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public DeleteDiscountCommandRequest() : this(0)
        {
        }

        public int DiscountId { get; set; } = discountId;
    }
}
