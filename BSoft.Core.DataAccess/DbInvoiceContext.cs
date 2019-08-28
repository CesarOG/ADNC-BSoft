using BSoft.Invoices.DataAccess.ModelConfigurations;
using BSoft.Invoices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess
{
    public class DbInvoiceContext : DbContext
    {
        public DbInvoiceContext(DbContextOptions<DbInvoiceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();



            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());

        }
        public DbSet<tbl_customer> tbl_customer { get; set; }
        public DbSet<tbl_invoice> tbl_invoice { get; set; }
        public DbSet<tbl_service> tbl_service { get; set; }
    }
}
