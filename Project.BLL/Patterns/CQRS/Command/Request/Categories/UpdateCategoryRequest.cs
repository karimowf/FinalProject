using MediatR;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Command.Request.Categories
{
    public class UpdateCategoryRequest(int id, string name, int? parentCategoryId) : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public UpdateCategoryRequest() : this(0, string.Empty, 0)
        { }
        public int Id { get; set; } = id;
        public string Name { get; set; } = name; public int? ParentCategoryId { get; set; } = parentCategoryId;
    }
}
