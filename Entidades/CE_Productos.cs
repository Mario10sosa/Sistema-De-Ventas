using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CE_Productos
    {
        public CE_Productos() { }

        public int Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Presentacion { get; set; }
        public int Costo_Unitario { get; set; }
        public int Precio_Venta { get; set; }

        public override string ToString()
        {
            return $" {Id_Producto} ; {Nombre_Producto} ; {Descripcion} ; {Presentacion} ; {Costo_Unitario} ; {Precio_Venta}";
        }
    }
}
