using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taks1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issuers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsibleAuthority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsibleAuthority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DocumentTypeVersion = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DateTimeIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalSalesAmount = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    TotalNetAmount = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    IssuerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Issuers_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Issuers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Receivers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    TaxType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Issuers",
                columns: new[] { "Id", "Address", "Name", "ResponsibleAuthority" },
                values: new object[] { new Guid("019addf3-0c6e-74e3-aff7-d10bc7f69e06"), "123 St, Shebin-Elkom, Egypt", "Adham Said Hemdia", "Fox Shop" });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "Id", "Address", "Name", "ResponsibleAuthority" },
                values: new object[] { new Guid("019addf3-0c6e-74e3-aff7-d10ce7ae2c08"), "Melig, Shebin-Elkom", "Ali Mohamed Ali", "customer" });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_IssuerId",
                table: "Invoices",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReceiverId",
                table: "Invoices",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Issuers");

            migrationBuilder.DropTable(
                name: "Receivers");
        }
    }
}
