using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.ViewObject
{
    public class InvoiceVO
    {
        public InvoiceVO()
        {
        }

        public InvoiceVO(int codigo, string estado, decimal monto, CustomerVO cliente, ServiceVO producto)
        {
            this.codigo = codigo;
            this.estado = estado;
            this.monto = monto;
            this.cliente = cliente;
            this.producto = producto;
        }

        public int codigo { get; set; }
        public string estado { get; set; }
        public decimal monto { get; set; }
        public CustomerVO cliente { get; set; }
        public ServiceVO producto { get; set; }
    }
}
