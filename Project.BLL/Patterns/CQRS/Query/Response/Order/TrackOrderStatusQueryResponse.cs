using Project.Domain.Models.DTOs.Order;

namespace Project.BLL.Patterns.CQRS.Query.Response.Order
{
    public class TrackOrderStatusQueryResponse(
    int orderId,
    string currentStatus,
    List<StatusHistoryDto> statusHistory)
    {
        public TrackOrderStatusQueryResponse() : this(0, string.Empty, [])
        {
        }

        public string CurrentStatus { get; set; } = currentStatus;
        public List<StatusHistoryDto> StatusHistory { get; set; } = statusHistory;
    }

}
