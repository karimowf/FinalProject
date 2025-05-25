using MediatR;
using Project.BLL.Patterns.CQRS.Command.Request.Discounts;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Handler.Discount.CommandHandler
{
    public class DeleteUserPersonalizedDiscountCommandHandler(
    ) : IRequestHandler<DeleteUserPersonalizedDiscountCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(DeleteUserPersonalizedDiscountCommandRequest request, CancellationToken cancellationToken)
        {

        }
    }
}
