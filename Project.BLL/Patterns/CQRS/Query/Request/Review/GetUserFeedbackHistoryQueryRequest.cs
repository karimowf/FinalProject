using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Review
{
    public class GetUserFeedbackHistoryQueryRequest(int userId)
    : IRequest<GenericApiResponse<List<GetUserFeedbackHistoryQueryResponse>>>
    {
        public GetUserFeedbackHistoryQueryRequest() : this(0)
        {
        }

        public int UserId { get; set; } = userId;
    }
}
