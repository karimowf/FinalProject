using MediatR;
using Project.Shared;

namespace Project.BLL.Patterns.CQRS.Command.Request.Orders
{
    public class UpdateOrderAddressCommandRequest(
    int orderId,
    string country,
    string city,
    string street,
    string postCode) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public UpdateOrderAddressCommandRequest() : this(0, string.Empty, string.Empty, string.Empty,
            string.Empty)
        {
        }

        public int OrderId { get; set; } = orderId;
        public string Country { get; set; } = country;
        public string City { get; set; } = city;
        public string Street { get; set; } = street;
        public string PostCode { get; set; } = postCode;
    }
}
