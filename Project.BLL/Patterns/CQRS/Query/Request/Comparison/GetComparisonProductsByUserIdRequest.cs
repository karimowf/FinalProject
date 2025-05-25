using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Comparison
{
    public class GetComparisonProductsByUserIdRequest(int userId)
    : IRequest<GenericApiResponse<List<GetComparisonProductsByUserIdResponse>>>
    {
        public GetComparisonProductsByUserIdRequest() : this(0)
        {
        }

        public int UserId { get; set; } = userId;
    }
}
