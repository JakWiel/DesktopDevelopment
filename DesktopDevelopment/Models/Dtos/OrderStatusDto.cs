namespace DesktopDevelopment.Models.Dtos
{
    public class OrderStatusDto
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
