using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_ServiocioContactoProductos : CL_InterContacto<CE_Productos>
    {
        CD_RepositorioProductos repositorioProductos = new CD_RepositorioProductos();
        List<CE_Productos> contactoProductos = new List<CE_Productos>();

        public List<CE_Productos> GetProductos()
        {
            contactoProductos = repositorioProductos.GetAll();
            return contactoProductos;
        }
        public string Save(CE_Productos productos)
        {
            try
            {

                if (productos == null)
                {
                    return "No Se Pudo Guardar El Producto";
                }
                else
                {
                    repositorioProductos.Add(productos);
                    return " El Producto " + productos.Nombre_Producto + " Fue Guardado";
                }
            }
            catch (Exception ex)
            {
                return $"\n Error" + ex + "\n";
            }
        }
        public List<CE_Productos> Mostrar()
        {
            if (!GetProductos().Any()) { return null; }
            return GetProductos();
        }
        public string Delete(CE_Productos productos)
        {
            contactoProductos = GetProductos();
            var buscado = BuscarId(productos.Id_Producto, contactoProductos);
            contactoProductos.Remove(buscado);
            var respuesta = repositorioProductos.Delete(contactoProductos);
            return respuesta;
        }
        public string Update(CE_Productos productos)
        {
            contactoProductos = GetProductos();
            foreach (CE_Productos producto in contactoProductos)
            {
                if (productos.Id_Producto == productos.Id_Producto)
                {
                    producto.Nombre_Producto = productos.Nombre_Producto;
                    producto.Descripcion = productos.Descripcion;
                    producto.Presentacion = productos.Presentacion;
                    producto.Costo_Unitario = productos.Costo_Unitario;
                    producto.Precio_Venta = productos.Precio_Venta;
                }
                var msg = repositorioProductos.Update(contactoProductos);
                return msg;

            }
            return "\n No Lo Encontro El Producto\n";
        }

        public List<CE_Productos> Buscar(string contacto)
        {
            string nombre_producto, decripcion,id, comparar;

            contactoProductos = GetProductos();
            List<CE_Productos> coincide = new List<CE_Productos>();

            comparar = contacto.ToUpper();

            foreach (CE_Productos productos in contactoProductos)
            {
                nombre_producto = productos.Nombre_Producto.ToUpper();
                decripcion = productos.Descripcion.ToUpper();
                id = productos.Id_Producto.ToString();


                if ((nombre_producto.Contains(comparar)) || (decripcion.Contains(comparar)) ||(id.Contains(comparar)))
                {
                    coincide.Add(productos);
                }
            }
            if (coincide.Any())
            {
                return coincide;
            }
            else
            {
                return null;
            }
        }

        public CE_Productos BuscarId(int id, List<CE_Productos> productos)
        {
            foreach (CE_Productos producto in productos)
            {
                if (producto.Id_Producto == id)
                {
                    return producto;
                }
            }
            return null;
        }
    }
}
