using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Comparisons
{
    public class DeleteComparisonCommandRequest(int comparisonId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public DeleteComparisonCommandRequest() : this(0)
        {
        }

        public int ComparisonId { get; set; } = comparisonId;
    }
}
