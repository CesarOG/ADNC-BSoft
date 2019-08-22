using BSoft.Invoices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess.ModelConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<tbl_invoice>
    {
        public void Configure(EntityTypeBuilder<tbl_invoice> builder)
        {
            builder.HasKey(prop => prop.IdInvoice);
            builder.Property(prop => prop.AmountTotal)
                .IsRequired();
            builder.Property(prop => prop.ResidueTotal)
                .IsRequired();
            builder.Property(prop => prop.IdCustomer)
                .IsRequired();
            builder.Property(prop => prop.IdService)
                .IsRequired();
            builder.Property(prop => prop.IsPay)
                .IsRequired();

        }
    }
}
