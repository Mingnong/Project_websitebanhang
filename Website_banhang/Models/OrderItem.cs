using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Models;

[Table("Order_Item")]
public partial class OrderItem
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("order_item")]
    public int OrderItem1 { get; set; }

    [Column("order_id")]
    public int? OrderId { get; set; }

    [Column("product_id")]
    public int? ProductId { get; set; }

    [Column("order_quantity")]
    public int? OrderQuantity { get; set; }

    [Column("order_price", TypeName = "decimal(10, 2)")]
    public decimal? OrderPrice { get; set; }

    [Column("order_totalprice", TypeName = "decimal(10, 2)")]
    public decimal? OrderTotalprice { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order? Order { get; set; }
}
