using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BSOFT.Core.Proxy.Service
{
    public interface ILogService
    {
        Task<bool> Info(string message);
        Task<bool> Error(string message);
    }
}
