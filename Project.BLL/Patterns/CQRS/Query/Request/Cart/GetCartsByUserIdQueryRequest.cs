namespace Project.BLL.Patterns.CQRS.Query.Request.Cart
{
    public class GetCartsByUserIdQueryRequest(int id)
    {
        public GetCartsByUserIdQueryRequest() : this(0)
        {
        }

        public int Id { get; set; } = id;
    }
}
