using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.ViewObject
{
    public class TransactionVO
    {
        public TransactionVO() { }

        public string Code { get; set; }
        public string Description { get; set; }
    }
}
