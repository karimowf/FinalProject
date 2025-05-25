namespace Project.BLL.Patterns.CQRS.Query.Response.Order
{
    public class GetAllCreatedOrdersQueryResponse(Domain.Entities.Order? order)
    {
        public GetAllCreatedOrdersQueryResponse() : this(null)
        {
        }

        public Domain.Entities.Order? Order { get; set; } = order;
    }
}
