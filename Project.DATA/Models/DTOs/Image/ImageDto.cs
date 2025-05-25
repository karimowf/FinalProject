using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.DTOs.Image
{
    public class ImageDto(int id, string url)
    {
        public ImageDto() : this(0, string.Empty)
        {
        }

        public int Id { get; set; } = id;
        public string Url { get; set; } = url;
    }
}
