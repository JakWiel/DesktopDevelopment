using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

public partial class CustomerReview
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column("ServiceID")]
    public int ServiceId { get; set; }

    public int Rating { get; set; }

    [StringLength(255)]
    public string Comment { get; set; } = null!;

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerReviews")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("CustomerReviews")]
    public virtual Product? Product { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("CustomerReviews")]
    public virtual ServicesOffered Service { get; set; }
}
