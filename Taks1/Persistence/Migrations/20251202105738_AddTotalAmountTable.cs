using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taks1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalAmountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Invoices",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Invoices");
        }
    }
}
