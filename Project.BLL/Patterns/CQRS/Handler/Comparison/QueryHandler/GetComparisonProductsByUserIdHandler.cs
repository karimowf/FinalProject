using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Query.Request.Comparison;
using Project.BLL.Patterns.CQRS.Query.Response.Comparison;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Comparison.QueryHandler
{
    public class GetComparisonProductsByUserIdHandler(
     IUnitOfWork unitOfWork,
     ILogger<GetComparisonProductsByUserIdHandler> logger) : IRequestHandler<GetComparisonProductsByUserIdRequest,
     GenericApiResponse<List<GetComparisonProductsByUserIdResponse>>>
    {
        public async Task<GenericApiResponse<List<GetComparisonProductsByUserIdResponse>>> Handle(
            GetComparisonProductsByUserIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comparisons = await unitOfWork.ComparisonRepository.GetComparisonsByUserIdAsync(request.UserId);

                if (comparisons.Count == 0)
                    return GenericApiResponse<List<GetComparisonProductsByUserIdResponse>>.Fail("any comparison not found",
                        HttpStatusCode.BadRequest.GetHashCode());

                var response = comparisons.Select(c => new GetComparisonProductsByUserIdResponse()
                {
                    ProductName = c.Product.Name,
                    CategoryName = c.Product.Category.Name,
                    StockQuantity = c.Product.StockQuantity,
                    Description = c.Product.Description
                }).ToList();

                return GenericApiResponse<List<GetComparisonProductsByUserIdResponse>>.Success(response,
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing comparison." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<List<GetComparisonProductsByUserIdResponse>>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }

}
