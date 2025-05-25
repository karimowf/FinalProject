using MediatR;
using Project.Domain.Entities;
using Project.Domain.Models.RequestModels.Orders;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Orders
{
    public class CreateOrderCommandRequest(
     decimal totalAmount,
     PaymentMethod paymentMethod,
     string country,
     string city,
     string street,
     string postCode,
     DateTime orderDate,
     List<CreateOrderDetailRequest>? orderDetail,
     List<CreateOrderStatusHistory>? orderStatusHistory) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public CreateOrderCommandRequest() : this(0, Domain.Entities.PaymentMethod.None, string.Empty, string.Empty,
            string.Empty, string.Empty, DateTime.MinValue, [], [])
        {
        }

        public decimal TotalAmount { get; set; } = totalAmount;
        public PaymentMethod PaymentMethod { get; set; } = paymentMethod;
        public string Country { get; set; } = country;
        public string City { get; set; } = city;
        public string Street { get; set; } = street;
        public string PostCode { get; set; } = postCode;
        public DateTime OrderDate { get; set; } = orderDate;
        public List<CreateOrderDetailRequest>? OrderDetail { get; set; } = orderDetail;
        public List<CreateOrderStatusHistory>? OrderStatusHistory { get; set; } = orderStatusHistory;
    }
}
