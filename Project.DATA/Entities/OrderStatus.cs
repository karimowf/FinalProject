using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public enum OrderStatus
    {
        Pending,           
        Processing,        
        Shipped,           
        InTransit,         
        Delivered,         
        Canceled,
        None
    }
}
