using BSoft.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Business.Services
{
    public interface IInvoiceService
    {
        List<tbl_invoice> ListInvoice();
        tbl_invoice ListInvoiceceById(int id);
        bool UpdateInvoice(tbl_invoice entity);
        bool DeleteInvoice(int id);
        bool RegisterInvoice(tbl_invoice entity);
    }
}
