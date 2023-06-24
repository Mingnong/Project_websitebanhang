using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Website_banhang.Migrations
{
    /// <inheritdoc />
    public partial class updateFiltter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Filter",
            table: "Product",
            nullable: true,
            computedColumnSql: "LOWER([product_name])",
            stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
