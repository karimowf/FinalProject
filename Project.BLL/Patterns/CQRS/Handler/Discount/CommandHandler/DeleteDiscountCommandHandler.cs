using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Discounts;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Discount.CommandHandler
{
    public class DeleteDiscountCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<DeleteDiscountCommandHandler> logger) : IRequestHandler<DeleteDiscountCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(DeleteDiscountCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var discount = await unitOfWork.DiscountRepository.FindDiscountByIdAsync(request.DiscountId);
                if (discount == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Any discount not found" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                unitOfWork.DiscountRepository.DeleteDiscount(discount);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Failed to delete discount" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully deleted discount" }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing delete to discount." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
