using BSoft.Invoices.Models;
using BSoft.Invoices.Models.Beans;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Business.Services
{
    public interface IInvoiceService
    {
        IEnumerable<tbl_invoice> ListInvoice();
        tbl_invoice ListInvoiceceById(int id);
        bool UpdateInvoice(tbl_invoice entity);
        bool DeleteInvoice(tbl_invoice entity);
        int RegisterInvoice(tbl_invoice entity);

        /*Listar*/
        IEnumerable<InvoiceBean> ListInvoicesByCustomer(int customerId);
        /*Pagar*/
        IEnumerable<string> PayInvoice(int invoiceId, int serviceId, int customerId);
        /*Extornar*/
        IEnumerable<string> ReversePay(int invoiceId, int serviceId, int customerId);


    }
}
