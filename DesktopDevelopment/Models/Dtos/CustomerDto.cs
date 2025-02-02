namespace DesktopDevelopment.Models.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
    }
}
