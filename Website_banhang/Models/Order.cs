using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Models;

[Table("Order")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("order_item")]
    public int? OrderItem { get; set; }

    [Column("purchase_date", TypeName = "date")]
    public DateTime? PurchaseDate { get; set; }

    [Column("total_price", TypeName = "decimal(10, 2)")]
    public decimal? TotalPrice { get; set; }
}
