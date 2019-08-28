using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Models
{
    public class tbl_customer
    {
        public int idcustomer { get; set; }
        public string businessname { get; set; }
        public string ruc { get; set; }
        public string contactname { get; set; }
        public bool isactive { get; set; }
    }
}
