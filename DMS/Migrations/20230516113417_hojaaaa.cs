using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class hojaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountPayable",
                table: "AccountPayable");

            migrationBuilder.RenameTable(
                name: "AccountPayable",
                newName: "AccountPayableInvoice");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AccountPayableInvoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountPayableInvoice",
                table: "AccountPayableInvoice",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountPayableInvoice",
                table: "AccountPayableInvoice");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AccountPayableInvoice");

            migrationBuilder.RenameTable(
                name: "AccountPayableInvoice",
                newName: "AccountPayable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountPayable",
                table: "AccountPayable",
                column: "Id");
        }
    }
}
