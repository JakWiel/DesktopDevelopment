using System;

namespace DesktopDevelopment.Models.Dtos
{
    public class OrdersDto
    {
        public int OrderId { get; set; }
        public string CustomerFullName { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int StatusID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
