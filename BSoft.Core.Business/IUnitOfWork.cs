using BSoft.Invoices.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Business
{
    public interface IUnitOfWork
    {
        IInvoiceService Invoice { get; }
    }
}
