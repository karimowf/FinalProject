namespace Project.BLL.Patterns.CQRS.Query.Response.Review
{
    public class GetProductFeedbackSummaryQueryResponse(
     int totalFeedbackCount,
     double averageRating,
     string? lastestComment)
    {
        public GetProductFeedbackSummaryQueryResponse() : this(0, 0, string.Empty)
        {
        }

        public int TotalFeedbackCount { get; set; } = totalFeedbackCount;
        public double AverageRating { get; set; } = averageRating;
        public string? LatestComment { get; set; } = lastestComment;
    }
}
