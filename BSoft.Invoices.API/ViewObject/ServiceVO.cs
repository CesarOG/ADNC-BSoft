using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.ViewObject
{
    public class ServiceVO
    {
        public ServiceVO()
        {
        }
        public ServiceVO(int codigo, string descripcion, string precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public int codigo { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
    }
}
