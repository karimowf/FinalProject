namespace Project.BLL.Patterns.CQRS.Query.Response.Discount
{
    public class GetUserPersonalizedDiscountsQueryResponse(string name, string imageUrl)
    {
        public GetUserPersonalizedDiscountsQueryResponse() : this(string.Empty, string.Empty)
        {
        }

        public string Name { get; set; } = name;
        public string ImageUrl { get; set; } = imageUrl;
    }
}
