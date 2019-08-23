using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSoft.Invoices.DataAccess;
using BSoft.Invoices.Models;

namespace BSoft.Invoices.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private DbInvoiceContext _context;
        public InvoiceService(DbInvoiceContext context)
        {
            _context = context;
        }
        public bool DeleteInvoice(int id)
        {
            try
            {
                var data = _context.tbl_invoice.Where(x => x.idinvoice == id).FirstOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<tbl_invoice> ListInvoice()
        {
            return _context.tbl_invoice.ToList();
        }

        public tbl_invoice ListInvoiceceById(int id)
        {
            return _context.tbl_invoice.Where(x => x.idinvoice == id).FirstOrDefault();
        }

        public bool RegisterInvoice(tbl_invoice entity)
        {
            try
            {
                _context.tbl_invoice.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateInvoice(tbl_invoice entity)
        {
            try
            {
                var data = _context.tbl_invoice.Where(x => x.idinvoice == entity.idinvoice).FirstOrDefault();
                data.ispay = true;
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
