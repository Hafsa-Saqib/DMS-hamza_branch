using DMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class DMSDbContext : DbContext
    {
        public DMSDbContext()
        {
        }
        public DMSDbContext (DbContextOptions options) : base(options) { }
        //public DbSet <Login> Logins { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet<CustomerCategory> CustomersCategory { get; set; }
        public DbSet <Vendor> Vendor { get; set; }
        public DbSet <Booker> Bookers { get; set; }
        public DbSet<Product> Products { get; set;}
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<GoodsDelivery> GoodsDelivery { get; set; }
        public DbSet<GoodReceipt> GoodsReceipt { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set;}
        public DbSet<PurchaseRequisition> PurchaseRequisition { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturn { get; set;}
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SalesReturn> SalesReturn { get; set; }
        public DbSet<SalesMan> SalesMan { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<AccountPayableInvoice> AccountPayableInvoice { get; set; }
        public DbSet<AccountReceivble> AccountReceivble { get; set;}
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ChartOfAccounts> ChartOfAccounts { get; set; }
        public DbSet<PurchaseCategory> PurchaseCategory { get; set; }

    }
}
