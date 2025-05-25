using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.DTOs.Order
{
    public class StatusHistoryDto(string status, DateTime modifiedDate)
    {
        public string Status { get; set; } = status;
        public DateTime ModifiedDate { get; set; } = modifiedDate;
    }
}
