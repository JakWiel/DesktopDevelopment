using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

public partial class RepairTicket
{
    [Key]
    [Column("RepairTicketID")]
    public int RepairTicketId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DateOpened { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateClosed { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("RepairTickets")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("RepairTickets")]
    public virtual Employee? Employee { get; set; }
}
