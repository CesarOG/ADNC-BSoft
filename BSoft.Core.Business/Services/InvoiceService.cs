using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSoft.Invoices.DataAccess;
using BSoft.Invoices.DataAccess.Repositories;
using BSoft.Invoices.Models;
using BSoft.Invoices.Models.Beans;

namespace BSoft.Invoices.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        public IInvoiceRepository invoiceRepository { get; private set; }
        public InvoiceService(string cnString)
        {
            invoiceRepository = new InvoiceRepository(cnString);
        }
        public bool DeleteInvoice(tbl_invoice entity)
        {
            return invoiceRepository.Delete(entity);
        }

        public IEnumerable<tbl_invoice> ListInvoice()
        {
            return invoiceRepository.GetList();
        }

        public tbl_invoice ListInvoiceceById(int id)
        {
            return invoiceRepository.GetById(id);
        }

        public IEnumerable<InvoiceBean> ListInvoicesByCustomer(int customerId)
        {
            return invoiceRepository.ListInvoicesByCustomer(customerId);
        }

        public IEnumerable<string> PayInvoice(int invoiceId, int serviceId, int customerId)
        {
            return invoiceRepository.PayInvoice(invoiceId, serviceId, customerId);
        }

        public int RegisterInvoice(tbl_invoice entity)
        {
            return invoiceRepository.Insert(entity);
        }

        public IEnumerable<string> ReversePay(int invoiceId, int serviceId, int customerId)
        {
            return invoiceRepository.ReversePay(invoiceId, serviceId, customerId);
        }

        public bool UpdateInvoice(tbl_invoice entity)
        {
            return invoiceRepository.Update(entity);
        }
    }
}
