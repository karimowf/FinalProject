using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Query.Response.Notification
{
    public class GetNotificationsQueryResponse(string title, string message)
    {
        public GetNotificationsQueryResponse() : this(string.Empty, string.Empty)
        {
        }

        public string Title { get; set; } = title;
        public string Message { get; set; } = message;
    }
}
