using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Discounts;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Discount.CommandHandler
{
    public class ApplyDiscountCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<ApplyDiscountCommandHandler> logger) : IRequestHandler<ApplyDiscountCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(ApplyDiscountCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var existProduct = await unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
                if (existProduct == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Any product not found" }),
                        HttpStatusCode.BadRequest.GetHashCode());
                var discount = new Domain.Entities.Discount()
                {
                    ProductId = request.ProductId,
                    Amount = request.DiscountValue,
                    DiscountType = request.DiscountType.ToString(),
                    EndDate = request.ExpiryDate
                };

                await unitOfWork.DiscountRepository.AddDiscountAsync(discount);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Failed to create discount" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully created discount" }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing create to discount." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
