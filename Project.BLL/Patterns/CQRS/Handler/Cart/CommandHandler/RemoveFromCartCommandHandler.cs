using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Carts;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Cart.CommandHandler
{
    public class RemoveFromCartCommandHandler(
     IUnitOfWork unitOfWork,
     ILogger<RemoveFromCartCommandHandler> logger)
     : IRequestHandler<RemoveFromCartCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(RemoveFromCartCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var cart = await unitOfWork.CartRepository.GetCartByUserAndProductAsync(request.UserId, request.ProductId);
                if (cart == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "cart not found" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                unitOfWork.CartRepository.DeleteAsync(cart);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse()
                        { IsSuccess = false, Message = "failed to remove cart from cart" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully removed cart from cart" }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while processing" +
                                    " remove to cart." + " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
