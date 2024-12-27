using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

public partial class Transaction
{
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("PaymentMethodID")]
    public int PaymentMethodId { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Transactions")]
    public virtual Order Order { get; set; }

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("Transactions")]
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
