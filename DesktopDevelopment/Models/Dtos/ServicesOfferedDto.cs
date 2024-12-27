namespace DesktopDevelopment.Models.Dtos
{
    public class ServicesOfferedDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
