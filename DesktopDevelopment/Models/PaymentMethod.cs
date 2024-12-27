using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

public partial class PaymentMethod
{
    [Key]
    [Column("PaymentMethodID")]
    public int PaymentMethodId { get; set; }

    [StringLength(50)]
    public string MethodName { get; set; } = null!;

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
