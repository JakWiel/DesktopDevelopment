using System;

namespace DesktopDevelopment.Models.Dtos
{
    public class TransactionsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
