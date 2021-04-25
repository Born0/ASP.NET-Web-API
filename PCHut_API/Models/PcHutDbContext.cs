
//using PCHut_API.Migrations;
using System;
using System.Data.Entity;
using System.Linq;

namespace PCHut_API.Models
{
    public class PcHutDbContext : DbContext
    {
       
        public PcHutDbContext(): base("name=PcHutDbContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PcHutDbContext, Configuration>());
        }

        
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchManager> BranchManagers { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalesRecord> SalesRecords { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}