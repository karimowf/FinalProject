namespace Project.BLL.Patterns.CQRS.Query.Response.Discount
{
    public class GetActiveDiscountsQueryResponse(string name, int stockQuantity, string? description)
    {
        public GetActiveDiscountsQueryResponse() : this(string.Empty, 0, string.Empty)
        {
        }

        public string Name { get; set; } = name;
        public int StockQuantity { get; set; } = stockQuantity;
        public string? Description { get; set; } = description;
    }
}
