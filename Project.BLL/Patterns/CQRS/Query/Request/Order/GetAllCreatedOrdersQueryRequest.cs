using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Query.Request.Order
{
    public class GetAllCreatedOrdersQueryRequest(bool isShow)
    : IRequest<GenericApiResponse<List<GetAllCreatedOrdersQueryResponse>>>
    {
        public GetAllCreatedOrdersQueryRequest() : this(true)
        {
        }

        public bool IsShow { get; set; } = isShow;
    }
}
