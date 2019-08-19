using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSOFT.Security.DataAccess;
using BSOFT.Security.Models;

namespace BSOFT.Security.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private DbSecurityContext _context;
        public CompanyService(DbSecurityContext context)
        {
            _context = context;
        }

        public bool DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public List<tbl_company> ListCompany()
        {
            return _context.tbl_company.ToList();
        }

        public tbl_company ListCompanyById(int id)
        {
            return _context.tbl_company.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool RegisterCompany(tbl_company entity)
        {

            try
            {
                _context.tbl_company.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool UpdateCompany(tbl_company entity)
        {
            throw new NotImplementedException();
        }
    }
}
