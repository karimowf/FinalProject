using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Reviews
{
    public class CreateReviewCommandRequest(int userId, int productId, string name, int rating)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public CreateReviewCommandRequest() : this(0, 0, string.Empty, 0)
        {
        }

        public int UserId { get; set; } = userId;
        public int ProductId { get; set; } = productId;
        public string Name { get; set; } = name;
        public int Rating { get; set; } = rating;
    }
}
