using System;
using System.Collections.Generic;
using System.Text;

namespace BSOFT.Core.Proxy
{
    public class AppSettings
    {
        public string LogUrl { get; set; }

        public Logging Logging { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
