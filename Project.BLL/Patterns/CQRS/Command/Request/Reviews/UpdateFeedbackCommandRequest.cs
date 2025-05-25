using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Reviews
{
    public class UpdateFeedbackCommandRequest(int feedbackId, int rating, string comment)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public UpdateFeedbackCommandRequest() : this(0, 0, string.Empty)
        {
        }

        public int FeedbackId { get; set; } = feedbackId;
        public int Rating { get; set; } = rating;
        public string Comment { get; set; } = comment;
    }

}
