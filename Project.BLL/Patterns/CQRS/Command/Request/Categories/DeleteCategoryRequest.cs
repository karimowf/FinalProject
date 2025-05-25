using MediatR;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Command.Request.Categories
{
    public class DeleteCategoryRequest(int categoryId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public DeleteCategoryRequest() : this(0)
        { }
        public int CategoryId { get; set; } = categoryId;
    }
}
