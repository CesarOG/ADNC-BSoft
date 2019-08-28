using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Models
{
    public class tbl_service
    {
        public int idservice { get; set; }
        public string code { get; set; }
        public string internalcode { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public bool isactive { get; set; }
    }
}
