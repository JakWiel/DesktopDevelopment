using System;

namespace DesktopDevelopment.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
