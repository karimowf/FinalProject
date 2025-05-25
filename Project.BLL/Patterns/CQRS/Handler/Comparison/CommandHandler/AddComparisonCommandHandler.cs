using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Comparisons;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Handler.Comparison.CommandHandler
{
    public class AddComparisonQueryHandler(
    IUnitOfWork unitOfWork,
    ILogger<AddComparisonQueryHandler> logger) : IRequestHandler<AddComparisonQueryRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(AddComparisonQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comparisonResponse = new Domain.Entities.Comparison(request.ProductId, request.UserId);
                await unitOfWork.ComparisonRepository.AddToComparisonAsync(comparisonResponse);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "failed to add comparison." }),
                        HttpStatusCode.BadRequest.GetHashCode());

                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully added comparison." }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing add to comparison." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
