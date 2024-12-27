using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

public partial class Supplier
{
    [Key]
    [Column("SupplierID")]
    public int SupplierId { get; set; }

    [StringLength(100)]
    public string SupplierName { get; set; } = null!;

    [StringLength(255)]
    public string ContactInfo { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }
}
