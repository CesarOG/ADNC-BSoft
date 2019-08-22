using BSoft.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Business.Services
{
    public interface ICustomerService
    {
        List<tbl_customer> ListCustomer();
        tbl_customer ListCustomerById(int id);
        bool UpdateCustomer(tbl_customer entity);
        bool DeleteCustomer(int id);
        bool RegisterCustomer(tbl_customer entity);
    }
}
