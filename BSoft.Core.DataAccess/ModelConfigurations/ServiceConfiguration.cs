using BSoft.Invoices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess.ModelConfigurations
{
    class ServiceConfiguration : IEntityTypeConfiguration<tbl_service>
    {
        public void Configure(EntityTypeBuilder<tbl_service> builder)
        {
            builder.HasKey(prop => prop.idservice);
            builder.Property(prop => prop.code)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.internalcode)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.description)
                .HasMaxLength(500);
            builder.Property(prop => prop.price)
                .IsRequired();
            builder.Property(prop => prop.isactive)
                .IsRequired();
        }
    }
}
