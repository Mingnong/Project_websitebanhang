using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Models;

[Table("Order_item")]
public partial class OrderItem
{
    [Key]
    [Column("order_item")]
    public int OrderItem1 { get; set; }

    [Column("product_id")]
    public int? ProductId { get; set; }

    [Column("order_quantity")]
    public int? OrderQuantity { get; set; }

    [Column("order_price", TypeName = "decimal(10, 2)")]
    public decimal? OrderPrice { get; set; }

    [Column("order_totalprice", TypeName = "decimal(10, 2)")]
    public decimal? OrderTotalprice { get; set; }

    [InverseProperty("OrderItemNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("ProductId")]
    [InverseProperty("OrderItems")]
    public virtual Product? Product { get; set; }
}
