using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Discounts
{
    public class DeleteUserPersonalizedDiscountCommandRequest(int userId)
     : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public DeleteUserPersonalizedDiscountCommandRequest() : this(0)
        {
        }

        public int UserId { get; set; } = userId;
    }
}
