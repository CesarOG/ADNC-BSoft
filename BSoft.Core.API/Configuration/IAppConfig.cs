using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.Configuration
{
    public interface IAppConfig
    {
        int MaxTrys { get; }
        int SecondToWay { get; }
    }
}
