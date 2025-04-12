using MediatR;
using Project.BLL.CQRS.BaseResponse;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.CQRS.Command.Request
{
    public class CreateCategoryRequest : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }

}
