using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class SaleOrder : Migration
    {
        public int UserID { get; internal set; }
        public int CustomerID { get; internal set; }
        public int BookerID { get; internal set; }
        public string Description { get; internal set; }
        public int OrderDate { get; internal set; }
        public int EnytryDate { get; internal set; }
        public double TotalPrice { get; internal set; }
        public bool IsActive { get; internal set; }
        public Guid ProductID { get; internal set; }
        public double ProductQuantity { get; internal set; }
        public object ID { get; internal set; }
        public double QuantityRemaining { get; internal set; }
        public double Ammount { get; internal set; }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
