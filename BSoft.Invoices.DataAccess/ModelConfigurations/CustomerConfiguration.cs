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
            builder.HasKey(prop => prop.idcustomer);
            builder.Property(prop => prop.businessname)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(prop => prop.ruc)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.contactname)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(prop => prop.isactive)
                .IsRequired();
        }
    }
}
