using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class CL_ServicioContactoProveedores : CL_InterContacto<CE_Proveedores>
    {
        CD_RepositorioProveedores repositorioProveedores = new CD_RepositorioProveedores();
        List<CE_Proveedores> contactoProveedores = new List<CE_Proveedores>();

        public List<CE_Proveedores> GetProveedores()
        {
            contactoProveedores = repositorioProveedores.GetAll();
            return contactoProveedores;
        }
        public string Save(CE_Proveedores proveedores)
        {
            try
            {

                if (proveedores == null)
                {
                    return "No Se Pudo Guardar El Proveedor";
                }
                else
                {
                    repositorioProveedores.Add(proveedores);
                    return " El Proveedor " + proveedores.Nombre_Proveedor + " Fue Guardado";
                }
            }
            catch (Exception ex)
            {
                return $"\n Error" + ex + "\n";
            }
        }
        public List<CE_Proveedores> Mostrar()
        {
            if (!GetProveedores().Any()) { return null; }
            return GetProveedores();
        }
        public string Delete(CE_Proveedores proveedores)
        {
            contactoProveedores = GetProveedores();
            var buscado = BuscarId(proveedores.Id_Proveedor, contactoProveedores);
            contactoProveedores.Remove(buscado);
            var respuesta = repositorioProveedores.Delete(contactoProveedores);
            return respuesta;
        }

        public string Update(CE_Proveedores proveedores)
        {
            contactoProveedores = GetProveedores();

            foreach (CE_Proveedores proveedor in contactoProveedores)
            {
                if (proveedor.Id_Proveedor == proveedores.Id_Proveedor)
                {
                    proveedor.Nombre_Proveedor = proveedores.Nombre_Proveedor;
                    proveedor.Nit = proveedores.Nit;
                    proveedor.Direccion = proveedores.Direccion;
                    proveedor.Telefono = proveedores.Telefono;
                    proveedor.Email = proveedores.Email;
                }
                var msg = repositorioProveedores.Update(contactoProveedores);
                return msg;

            }
            return "\n No Se Encontro El Proveedor\n";
        }

        public List<CE_Proveedores> Buscar(string contacto)
        {
            string nombre_proveedor, nit, telefono , comparar;

            contactoProveedores = GetProveedores();
            List<CE_Proveedores> coincide = new List<CE_Proveedores>();

            comparar = contacto.ToUpper();

            foreach (CE_Proveedores proveedor in contactoProveedores)
            {
                
                nombre_proveedor = proveedor.Nombre_Proveedor.ToUpper();
                nit = proveedor.Nit.ToUpper();
                telefono = proveedor.Telefono.ToUpper();


                if ((nombre_proveedor.Contains(comparar)) || (nit.Contains(comparar))|| (telefono.Contains(comparar)))
                {
                    coincide.Add(proveedor);
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

        public CE_Proveedores BuscarId(int id, List<CE_Proveedores> proveedores)
        {
            foreach (CE_Proveedores proveedor in proveedores)
            {
                if (proveedor.Id_Proveedor == id)
                {
                    return proveedor;
                }
            }
            return null;
        }
    }
}
