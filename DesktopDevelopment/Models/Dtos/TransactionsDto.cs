using System;

namespace DesktopDevelopment.Models.Dtos
{
    class TransactionsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
