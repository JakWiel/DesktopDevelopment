namespace DesktopDevelopment.Models.Dtos
{
    public class RepairTicketDto
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public string Description { get; set; } = null!;

    }
}
