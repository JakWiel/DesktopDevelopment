using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

[Table("ServicesOffered")]
public partial class ServicesOffered
{
    [Key]
    [Column("ServiceID")]
    public int ServiceId { get; set; }

    [StringLength(100)]
    public string ServiceName { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<CustomerReview> CustomerReviews { get; set; } = new List<CustomerReview>();
}
