using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_RepositorioProductos : CD_InterfaceRepositorio<CE_Productos>
    {
        string ruta = "Productos.txt";
        public string Add(CE_Productos productos)
        {
            try
            {
                //1 Abrir.
                StreamWriter sw = new StreamWriter(ruta, true);
                //2 Operaciones
                sw.WriteLine(productos.ToString());

                //3 cerrar
                sw.Close();

                return "Datos almacenados";
            }
            catch (Exception ex)
            {
                return "No se almaceno el dato error " + ex.Message;
            }
        }

        public string Delete(List<CE_Productos> productos)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var producto in productos)
                {
                    sw.WriteLine(producto.ToString());
                }

                sw.Close();

                return "El Producto Fue Eliminado";
            }
            catch (Exception ex)
            {
                return $"Error {ex}";
            }
        }

        public List<CE_Productos> GetAll()
        {
            try
            {
                List<CE_Productos> productos = new List<CE_Productos>();
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    productos.Add(Mappeador(sr.ReadLine()));
                }
                sr.Close();
                return productos;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public CE_Productos Mappeador(string linea)
        {
            var productos = new CE_Productos();
            string[] aux;

            aux = linea.Split(';');

            productos.Id_Producto = int.Parse(aux[0]);
            productos.Nombre_Producto = aux[1];
            productos.Descripcion = aux[2];
            productos.Presentacion = aux[3];
            productos.Costo_Unitario = int.Parse(aux[4]);
            productos.Precio_Venta = int.Parse(aux[5]);

            return productos;
        }

        public string Update(List<CE_Productos> producto)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var productos in producto)
                {
                    sw.WriteLine(productos);
                }
                sw.Close();
                return "Datos modificados";
            }
            catch (Exception ex)
            {
                return $"Error : {ex}";
            }
        }
    }
}
