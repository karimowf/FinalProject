namespace Project.BLL.Patterns.CQRS.Query.Response.Review
{
    public class GetUserFeedbackHistoryQueryResponse(string productName, int rating, string commenterName, DateTime createDate)
    {
        public GetUserFeedbackHistoryQueryResponse() : this(string.Empty, 0, string.Empty, DateTime.MinValue)
        {
        }

        public string ProductName { get; set; } = productName;
        public int Rating { get; set; } = rating;
        public string CommenterName { get; set; } = commenterName;
        public DateTime CreateDate { get; set; } = createDate;
    }
}
