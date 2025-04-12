using MediatR;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.CQRS.Command.Request
{
        public class UpdateCategoryRequest : IRequest<GenericApiResponse<BaseResponse.BaseResponse>>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ParentCategoryId { get; set; }
        }
}
