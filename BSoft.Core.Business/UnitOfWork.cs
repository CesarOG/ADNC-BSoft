using System;
using System.Collections.Generic;
using System.Text;
using BSoft.Invoices.Business.Services;

namespace BSoft.Invoices.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string cnString)
        {
            Invoice = new InvoiceService(cnString);
        }
        public IInvoiceService Invoice { get; private set; }
    }
}
