using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Notifications;
using Project.DAL.UnitOfWorkModel;
using Project.Domain.Entities;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Notification.CommandHandler
{
    public class SendNotificationCommandHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork,
    ILogger<SendNotificationCommandHandler> logger)
    : IRequestHandler<SendNotificationCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(SendNotificationCommandRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Any user not found" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                var notification = new Domain.Entities.Notification
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Message = request.Message,
                    RedirectUrl = request.RedirectUrl,
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                await unitOfWork.NotificationRepository.AddAsync(notification);
                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Failed to send notification." }),
                        HttpStatusCode.BadRequest.GetHashCode());
                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse() { IsSuccess = true, Message = "Successfully sended notification." }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing send notification." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
