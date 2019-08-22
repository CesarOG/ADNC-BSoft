using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Models
{
    public class tbl_customer
    {
        public int IdCustomer { get; set; }
        public string Businessname { get; set; }
        public string Ruc { get; set; }
        public string ContactName { get; set; }
        public bool IsActive { get; set; }
    }
}
