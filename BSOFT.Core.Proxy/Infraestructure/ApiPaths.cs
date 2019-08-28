using System;
using System.Collections.Generic;
using System.Text;

namespace BSOFT.Core.Proxy.Infraestructure
{
   public class ApiPaths
    {
        public static class Log
        {
            public static string AddLog(string baseUri)
            {
                return $"{baseUri}/api/log";
            }
        }
    }
}
