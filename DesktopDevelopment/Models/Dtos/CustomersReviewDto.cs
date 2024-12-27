namespace DesktopDevelopment.Models.Dtos
{
    public class CustomersReviewDto
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int ServiceID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = null!;
    }
}
