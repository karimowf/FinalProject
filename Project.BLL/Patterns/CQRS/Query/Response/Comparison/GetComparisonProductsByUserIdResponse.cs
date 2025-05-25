namespace Project.BLL.Patterns.CQRS.Query.Response.Comparison
{
    public class GetComparisonProductsByUserIdResponse(
    string productName,
    string categoryName,
    int stockQuantity,
    string? description)
    {
        public GetComparisonProductsByUserIdResponse() : this(string.Empty, string.Empty,
            0, string.Empty)
        {
        }

        public string ProductName { get; set; } = productName;
        public string CategoryName { get; set; } = categoryName;
        public int StockQuantity { get; set; } = stockQuantity;
        public string? Description { get; set; } = description;
    }
}
