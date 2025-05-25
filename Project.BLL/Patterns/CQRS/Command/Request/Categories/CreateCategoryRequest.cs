using MediatR;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Command.Request.Categories
{
    public class CreateCategoryRequest(string name, int? parentCategoryId)
    : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public CreateCategoryRequest() : this(string.Empty, 0)
        {
        }
        public string Name { get; set; } = name; public int? ParentCategoryId { get; set; } = parentCategoryId;
    }
}
