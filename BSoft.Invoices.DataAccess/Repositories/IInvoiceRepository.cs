using BSoft.Invoices.Models;
using BSoft.Invoices.Models.Beans;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.DataAccess.Repositories
{
    public interface IInvoiceRepository:IRepository<tbl_invoice>
    {

        //Implemtar los metodos no genericos
        /*Listar*/
        IEnumerable<InvoiceBean> ListInvoicesByCustomer(int customerId);
        /*Pagar*/
        IEnumerable<string> PayInvoice(int invoiceId, int serviceId, int customerId);
        /*Extornar*/
        IEnumerable<string> ReverseInvoice(int invoiceId, int serviceId, int customerId);

    }
}
