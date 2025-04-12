using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.CQRS.BaseResponse
{
    public class BaseResponse(bool isSuccess, string message)
    {
        public bool IsSuccess { get; set; } = isSuccess;
        public string Message { get; set; } = message;
    }
}
