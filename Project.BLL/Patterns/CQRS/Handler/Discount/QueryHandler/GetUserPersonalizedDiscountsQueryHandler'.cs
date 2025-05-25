using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Query.Request.Discount;
using Project.BLL.Patterns.CQRS.Query.Response.Discount;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Discount.QueryHandler
{
    public class GetUserPersonalizedDiscountsQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<GetUserPersonalizedDiscountsQueryHandler> logger)
    : IRequestHandler<GetUserPersonalizedDiscountsQueryRequest,
        GenericApiResponse<GetUserPersonalizedDiscountsQueryResponse>>
    {
        public async Task<GenericApiResponse<GetUserPersonalizedDiscountsQueryResponse>> Handle(
            GetUserPersonalizedDiscountsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var recommendedProductsIdsWithImagesList =
                    await unitOfWork.ProductRepository.GetRecommendedCategoriesAsync(request.UserId);
                if (recommendedProductsIdsWithImagesList is null)
                    return GenericApiResponse<GetUserPersonalizedDiscountsQueryResponse>.Fail("Any categoryId not found",
                        HttpStatusCode.BadRequest.GetHashCode());

                foreach (var getUserPersonalizedDiscountsQueryResponse in recommendedProductsIdsWithImagesList.Select(product =>
                             new GetUserPersonalizedDiscountsQueryResponse()
                             {
                                 Name = product.
    
                             }))
                {
                }

                return GenericApiResponse<GetUserPersonalizedDiscountsQueryResponse>.Success(
                    "Successfully get user personalized discounts", HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing get to user personalized discounts." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<GetUserPersonalizedDiscountsQueryResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }

}
