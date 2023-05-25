using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class AddVendor : Migration
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public string Phone { get; internal set; }
        public string Address { get; internal set; }
        public string VendorCategory { get; internal set; }
        public string NTN { get; internal set; }
        public string CompNo { get; internal set; }
        public bool IsActive { get; internal set; }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NTN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
