using System;

namespace DesktopDevelopment.Models.Dtos
{
    class OrdersDto
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int StatusID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
