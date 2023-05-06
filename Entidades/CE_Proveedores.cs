using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CE_Proveedores
    {
        public CE_Proveedores() { }

        public int Id_Proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        public override string ToString()
        {
            return $" {Id_Proveedor} ; {Nombre_Proveedor} ; {Nit} ; {Direccion} ; {Telefono} ; {Email}";
        }
    }
}
