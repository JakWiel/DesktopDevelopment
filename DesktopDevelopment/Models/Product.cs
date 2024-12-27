using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [StringLength(100)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CustomerReview> CustomerReviews { get; set; } = new List<CustomerReview>();

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
