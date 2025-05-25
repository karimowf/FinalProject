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
    public class MarkNotificationsAsReadCommandHandler(
    UserManager<User> userManager,
    IUnitOfWork unitOfWork,
    ILogger<MarkNotificationsAsReadCommandHandler> logger)
    : IRequestHandler<MarkNotificationsAsReadCommandRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(
            MarkNotificationsAsReadCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "Any user not found" }),
                        HttpStatusCode.BadRequest.GetHashCode());

                var unreadNotifications =
                    await unitOfWork.NotificationRepository.WhereAsync(x => x.UserId == user.Id && x.IsRead == false);

                if (!unreadNotifications.Any())
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse() { IsSuccess = false, Message = "No unread notifications found." }),
                        HttpStatusCode.BadRequest.GetHashCode());

                foreach (var notification in unreadNotifications)
                {
                    notification.IsRead = true;
                }

                if (await unitOfWork.CommitAsync() < 0)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                        (new BaseResponse.BaseResponse()
                        { IsSuccess = false, Message = "Failed to mark unread notification." }),
                        HttpStatusCode.BadRequest.GetHashCode());
                return GenericApiResponse<BaseResponse.BaseResponse>.Success(
                    (new BaseResponse.BaseResponse()
                    { IsSuccess = true, Message = "Successfully marked unread notification." }),
                    HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while processing mark us read notification." +
                    " Request: {@request}, Exception: {@exception}",
                    request, ex.Message);

                return GenericApiResponse<BaseResponse.BaseResponse>.Fail(
                    "An error occurred while processing the request.",
                    HttpStatusCode.BadRequest.GetHashCode());
            }
        }
    }
}
