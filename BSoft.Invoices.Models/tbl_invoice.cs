using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Models
{
    public class tbl_invoice
    {
        public int IdInvoice { get; set; }
        public decimal AmountTotal { get; set; }
        public decimal ResidueTotal { get; set; }
        public int IdCustomer { get; set; }
        public int IdService { get; set; }
        public bool IsPay { get; set; }
    }
}
