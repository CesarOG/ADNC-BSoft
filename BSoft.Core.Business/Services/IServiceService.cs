using BSoft.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Business.Services
{
    public interface IServiceService
    {
        List<tbl_service> ListService();
        tbl_service ListServiceById(int id);
        bool UpdateService(tbl_service entity);
        bool DeleteService(int id);
        bool RegisterService(tbl_service entity);
    }
}
