using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSoft.Invoices.DataAccess;
using BSoft.Invoices.Models;

namespace BSoft.Invoices.Business.Services
{
    public class ServiceService : IServiceService
    {
        private DbInvoiceContext _context;
        public ServiceService(DbInvoiceContext context)
        {
            _context = context;
        }
        public bool DeleteService(int id)
        {
            try
            {
                var data = _context.tbl_service.Where(x => x.idservice == id).FirstOrDefault();
                data.isactive = false;
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public List<tbl_service> ListService()
        {
            return _context.tbl_service.ToList();
        }

        public tbl_service ListServiceById(int id)
        {
            return _context.tbl_service.Where(x => x.idservice == id).FirstOrDefault();
        }

        public bool RegisterService(tbl_service entity)
        {
            try
            {
                _context.tbl_service.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateService(tbl_service entity)
        {
            try
            {
                var data = _context.tbl_service.Where(x => x.idservice == entity.idservice).FirstOrDefault();
                data.code = entity.code;
                data.internalcode = entity.internalcode;
                data.description = entity.description;
                data.price = entity.price;
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
