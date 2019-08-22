using BSoft.Invoices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess.ModelConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<tbl_customer>
    {
        public void Configure(EntityTypeBuilder<tbl_customer> builder)
        {
            builder.HasKey(prop => prop.IdCustomer);
            builder.Property(prop => prop.Businessname)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.Ruc)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.ContactName)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(prop => prop.IsActive)
                .IsRequired();
        }
    }
}
