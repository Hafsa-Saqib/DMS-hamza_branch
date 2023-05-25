using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class Addnowplease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesMen",
                table: "SalesMen");

            migrationBuilder.RenameTable(
                name: "SalesMen",
                newName: "SalesMan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesMan",
                table: "SalesMan",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryFrom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevenueAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesReturnAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendor = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseRequistion = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseOrder = table.Column<bool>(type: "bit", nullable: false),
                    GoodsReceipt = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<bool>(type: "bit", nullable: false),
                    Warehouse = table.Column<bool>(type: "bit", nullable: false),
                    AccountPayableInvoice = table.Column<bool>(type: "bit", nullable: false),
                    SalesOrder = table.Column<bool>(type: "bit", nullable: false),
                    Customer = table.Column<bool>(type: "bit", nullable: false),
                    Delivery = table.Column<bool>(type: "bit", nullable: false),
                    Booker = table.Column<bool>(type: "bit", nullable: false),
                    SalesMan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesMan",
                table: "SalesMan");

            migrationBuilder.RenameTable(
                name: "SalesMan",
                newName: "SalesMen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesMen",
                table: "SalesMen",
                column: "ID");
        }
    }
}
