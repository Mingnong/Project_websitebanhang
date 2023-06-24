using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    [StringLength(255)]
    public string? ProductName { get; set; }

    [Column("product_description")]
    public string? ProductDescription { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("product_price", TypeName = "decimal(10, 2)")]
    public decimal? ProductPrice { get; set; }

    [Column("product_image")]
    [StringLength(255)]
    public string? ProductImage { get; set; }

    [Column("category_id")]
    public int? CategoryId { get; set; }

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("Filter")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Filter { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }
}
