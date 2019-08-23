using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Models
{
    public class tbl_invoice
    {
        public int idinvoice { get; set; }
        public decimal amounttotal { get; set; }
        public decimal residuetotal { get; set; }
        public int idcustomer { get; set; }
        public int idservice { get; set; }
        public bool ispay { get; set; }
    }
}
