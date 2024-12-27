using System;

namespace DesktopDevelopment.Models.Dtos
{
    public class PromotionsDto
    {
        public int Id { get; set; }
        public string PromotionName { get; set; } = null!;
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
