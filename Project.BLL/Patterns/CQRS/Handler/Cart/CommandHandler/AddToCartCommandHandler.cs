using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Carts;
using Project.DAL.UnitOfWorkModel;
using Project.Domain.Entities;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Cart.CommandHandler
{
    public class AddToCartCommandHandler(
     IUnitOfWork unitOfWork,
     ILogger<AddToCartCommandHandler> logger)
     : IRequestHandler<AddToCartCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(AddToCartCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var shoppingCart = new ShoppingCart(request.ProductId, request.ProductId, request.Count);
                await unitOfWork.CartRepository.AddAsync(shoppingCart);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "failed to add shopping cart." }),
                        HttpStatusCode.BadRequest.GetHashCode());

                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully added shopping cart." }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing add to cart." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
