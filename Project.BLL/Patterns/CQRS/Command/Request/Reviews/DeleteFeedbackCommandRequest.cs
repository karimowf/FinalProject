using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Reviews
{
    public class DeleteFeedbackCommandRequest(int feedbackId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public DeleteFeedbackCommandRequest() : this(0)
        {
        }

        public int FeedbackId { get; set; } = feedbackId;
    }
}
