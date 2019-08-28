using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSoft.Invoices.DataAccess;
using BSoft.Invoices.Models;

namespace BSoft.Invoices.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private DbInvoiceContext _context;
        public CustomerService(DbInvoiceContext context)
        {
            _context = context;
        }
        public bool DeleteCustomer(int id)
        {
            try
            {

                var data = _context.tbl_customer.Where(x => x.idcustomer == id).FirstOrDefault();
                data.isactive = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<tbl_customer> ListCustomer()
        {
            return _context.tbl_customer.ToList();
        }

        public tbl_customer ListCustomerById(int id)
        {
            return _context.tbl_customer.Where(x => x.idcustomer == id).FirstOrDefault();
        }

        public bool RegisterCustomer(tbl_customer entity)
        {
            try
            {
                _context.tbl_customer.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateCustomer(tbl_customer entity)
        {
            try
            {
                var data = _context.tbl_customer.Where(x => x.idcustomer == entity.idcustomer).FirstOrDefault();
                data.businessname = entity.businessname;
                data.ruc = entity.ruc;             
                data.contactname = entity.contactname;
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
