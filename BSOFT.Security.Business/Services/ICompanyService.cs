using BSOFT.Security.Models;
using System.Collections.Generic;

namespace BSOFT.Security.Business.Services
{
    public interface ICompanyService
    {
        List<tbl_company> ListCompany();
        tbl_company ListCompanyById(int id);
        bool UpdateCompany(tbl_company entity);
        bool DeleteCompany(int id);
        bool RegisterCompany(tbl_company entity);
    }
}
