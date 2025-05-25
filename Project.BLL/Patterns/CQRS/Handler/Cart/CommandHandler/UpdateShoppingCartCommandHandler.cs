using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Carts;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Cart.CommandHandler
{
    public class UpdateShoppingCartCommandHandler(
    IUnitOfWork unitOfWork,
    ILogger<UpdateShoppingCartCommandHandler> logger)
    : IRequestHandler<UpdateShoppingCartCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(UpdateShoppingCartCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var cart = await unitOfWork.CartRepository.GetCartByUserAndProductAsync(request.UserId, request.ProductId);
                if (cart == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "cart not found" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                unitOfWork.CartRepository.UpdateAsync(cart);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse()
                        { IsSuccess = false, Message = "failed to update cart from cart" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully update cart from cart" }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while processing" +
                                    " update to cart." + " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
