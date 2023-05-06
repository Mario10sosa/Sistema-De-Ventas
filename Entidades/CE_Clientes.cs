using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CE_Clientes
    {
        public CE_Clientes()
        {
        }

        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id_Cliente} ; {Nombre} ; {Cedula} ; {Direccion} ; {Telefono} ; {Email}";
        }
    }
}
