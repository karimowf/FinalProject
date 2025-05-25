using MediatR;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Command.Request.Carts
{
    public class UpdateShoppingCartCommandRequest(int userId, int productId, int newCount)
     : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public UpdateShoppingCartCommandRequest() : this(0, 0, 0)
        {
        }

        public int UserId { get; set; } = userId;
        public int ProductId { get; set; } = productId;
        public int NewCount { get; set; } = newCount;
    }
}
