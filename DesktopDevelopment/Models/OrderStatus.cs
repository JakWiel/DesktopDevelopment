using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

[Table("Order_Status")]
public partial class OrderStatus
{
    [Key]
    [Column("StatusID")]
    public int StatusId { get; set; }

    [StringLength(50)]
    public string StatusName { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
