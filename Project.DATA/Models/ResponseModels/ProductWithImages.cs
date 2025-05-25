using Project.Domain.Models.DTOs.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models.ResponseModels
{
    public class ProductWithImages(int categoryId, List<ImageDto> images)
    {
        public ProductWithImages() : this(0, [])
        {
        }

        public int Id { get; set; } = categoryId;
        public List<ImageDto> Images { get; set; } = images;
    }
}
