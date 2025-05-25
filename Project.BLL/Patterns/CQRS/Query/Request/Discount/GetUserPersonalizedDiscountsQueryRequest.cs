using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Discount
{
    public class GetUserPersonalizedDiscountsQueryRequest(int userId)
    : IRequest<GenericApiResponse<GetUserPersonalizedDiscountsQueryResponse>>
    {
        public GetUserPersonalizedDiscountsQueryRequest() : this(0)
        {
        }

        public int UserId { get; set; } = userId;
        public int? MaxResults { get; set; } = 10;
    }

}
