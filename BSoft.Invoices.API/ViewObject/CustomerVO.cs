using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSoft.Invoices.API.ViewObject
{
    public class CustomerVO
    {

        public CustomerVO()
        {
        }
        public CustomerVO(int codigo, string nombres, string empresa)
        {
            this.codigo = codigo;
            this.nombres = nombres;
            this.empresa = empresa;
        }

        public int codigo { get; set; }
        public string nombres { get; set; }
        public string empresa { get; set; }

    }
}
