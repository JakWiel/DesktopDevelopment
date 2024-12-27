using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopDevelopment.Models;

[Index("Email", Name = "UQ__Employee__A9D1053400BD5C41", IsUnique = true)]
public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateDeleted { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Employee")]
    public virtual ICollection<RepairTicket> RepairTickets { get; set; } = new List<RepairTicket>();

    [ForeignKey("RoleId")]
    [InverseProperty("Employees")]
    public virtual UserRole? Role { get; set; }
}
