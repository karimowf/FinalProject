namespace Project.BLL.Patterns.CQRS.Query.Response.Product
{
    public class GetProductWithFilterQueryResponse(
     int? categoryId,
     int? minStockQuantity,
     int? maxStockQuantity,
     string? name)
    {
        public GetProductWithFilterQueryResponse() : this(0, 0, 0, string.Empty)
        {
        }

        public int? CategoryId { get; set; } = categoryId;
        public int? MinStockQuantity { get; set; } = minStockQuantity;
        public int? MaxStockQuantity { get; set; } = maxStockQuantity;
        public string? Name { get; set; } = name;
    }
}
