using System;
using System.Collections.Generic;
using System.Text;

namespace BSoft.Invoices.Models.Beans
{
    public class InvoiceBean
    {
        public int CustomerId { get; set; }
        public string ContactName { get; set; }
        public string BusinessName { get; set; }
        public int serviceid { get; set; }
        public string description { get; set; }
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
        public decimal ResidueTotal { get; set; }
        public bool IsPay { get; set; }
    }
}
