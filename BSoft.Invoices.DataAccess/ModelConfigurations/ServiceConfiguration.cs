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
            builder.HasKey(prop => prop.IdService);
            builder.Property(prop => prop.Code)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.InternalCode)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Description)
                .HasMaxLength(500);
            builder.Property(prop => prop.Price)
                .IsRequired();
            builder.Property(prop => prop.IsActive)
                .IsRequired();
        }
    }
}
