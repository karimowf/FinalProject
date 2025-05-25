using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Query.Request.Discount;
using Project.BLL.Patterns.CQRS.Query.Response.Discount;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Discount.QueryHandler
{
    public class GetActiveDiscountsQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<GetActiveDiscountsQueryHandler> logger) : IRequestHandler<GetActiveDiscountsQueryRequest, GenericApiResponse<List<GetActiveDiscountsQueryResponse>>>
    {
        public async Task<GenericApiResponse<List<GetActiveDiscountsQueryResponse>>> Handle(
            GetActiveDiscountsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existProduct = await unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
                if (existProduct == null)
                    return GenericApiResponse<List<GetActiveDiscountsQueryResponse>>.Fail("Any product not found",
                        HttpStatusCode.BadRequest.GetHashCode());

                var activeDiscountedProducts =
                    await unitOfWork.DiscountRepository.CheckActiveAndGetDiscountsAsync();
                if (activeDiscountedProducts == null)
                    return GenericApiResponse<List<GetActiveDiscountsQueryResponse>>.Fail(
                        "Any product not found with active discounts",
                        HttpStatusCode.BadRequest.GetHashCode());

                var responseList = new List<GetActiveDiscountsQueryResponse>();

                foreach (var product in activeDiscountedProducts)
                {
                    responseList.Add(new GetActiveDiscountsQueryResponse
                    {
                        Name = product.Name,
                        StockQuantity = product.StockQuantity,
                        Description = product.Description
                    });
                }

                return GenericApiResponse<List<GetActiveDiscountsQueryResponse>>.Success(
                    responseList, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing get to active discounted products." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<List<GetActiveDiscountsQueryResponse>>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
