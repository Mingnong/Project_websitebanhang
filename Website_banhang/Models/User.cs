using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("user_name")]
    [StringLength(255)]
    public string? UserName { get; set; }

    [Column("user_age")]
    public int? UserAge { get; set; }

    [Column("user_address")]
    [StringLength(255)]
    public string? UserAddress { get; set; }

    [Column("user_phone")]
    [StringLength(255)]
    public string? UserPhone { get; set; }

    [Column("role_id")]
    public int? RoleId { get; set; }

    [Column("isActive")]
    public bool? IsActive { get; set; }

    [Column("fillter")]
    [StringLength(255)]
    public string? Fillter { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; }
}
