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
            builder.HasKey(prop => prop.idinvoice);
            builder.Property(prop => prop.amounttotal)
                .IsRequired();
            builder.Property(prop => prop.residuetotal)
                .IsRequired();
            builder.Property(prop => prop.idcustomer)
                .IsRequired();
            builder.Property(prop => prop.idservice)
                .IsRequired();
            builder.Property(prop => prop.ispay)
                .IsRequired();

        }
    }
}
