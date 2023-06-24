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

    [Column("role_id")]
    public int? RoleId { get; set; }

    [Column("username")]
    [StringLength(255)]
    public string? Username { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("user_address")]
    [StringLength(255)]
    public string? UserAddress { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
