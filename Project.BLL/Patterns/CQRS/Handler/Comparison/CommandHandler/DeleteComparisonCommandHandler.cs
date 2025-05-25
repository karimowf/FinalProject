using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Comparisons;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Comparison.CommandHandler
{
    public class DeleteComparisonCommandHandler(
     IUnitOfWork unitOfWork,
     ILogger<DeleteComparisonCommandHandler> logger)
     : IRequestHandler<DeleteComparisonCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(DeleteComparisonCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var comparison = await unitOfWork.ComparisonRepository.GetComparisonByIdAsync(request.ComparisonId);
                if (comparison == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "comparison not found." }),
                        HttpStatusCode.BadRequest.GetHashCode());
                unitOfWork.ComparisonRepository.RemoveFromComparisonAsync(comparison);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Failed to delete comparison." }),
                        HttpStatusCode.BadRequest.GetHashCode());
                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "successfully deleted." }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing delete comparison." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
