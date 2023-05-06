using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CE_Empresas
    {
        public CE_Empresas()
        {
        }

        public int Id_Empresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id_Empresa} ; {Nombre}; {Direccion}; {Telefono}; {Email}";
        }
    }
}
