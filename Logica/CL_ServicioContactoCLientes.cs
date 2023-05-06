using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Logica
{
    public class CL_ServicioContactoCLientes : CL_InterContacto<CE_Clientes>
    {
        CD_RepositorioClientes repositorioClientes = new CD_RepositorioClientes();
        List<CE_Clientes> contactoClientes = new List<CE_Clientes>();

        public List<CE_Clientes> GetClientes()
        {
            contactoClientes = repositorioClientes.GetAll();
            return contactoClientes;
        }

        public string Save(CE_Clientes clientes)
        {
            try
            {
                //contactoClientes = GetClientes();
                if (clientes == null)
                {
                    return "No Se Pudo Guardar El Cliente";
                }
                else
                {
                    repositorioClientes.Add(clientes);
                    return " El Cliente " + clientes.Nombre + " Fue Guardado";
                }
            }
            catch (Exception ex)
            {
                return $"\n Error" + ex + "\n";
            }
        }

        public List<CE_Clientes> Mostrar()
        {
            if (!GetClientes().Any()) { return null; }
            return GetClientes();
        }

        public string Delete(CE_Clientes clientes)
        {
            contactoClientes = GetClientes();
            var buscado = BuscarId(clientes.Id_Cliente, contactoClientes);
            contactoClientes.Remove(buscado);
            var respuesta = repositorioClientes.Delete(contactoClientes);
            return respuesta;
        }

        public string Update(CE_Clientes clientes)
        {
            contactoClientes = GetClientes();

            foreach (CE_Clientes cliente in contactoClientes)
            {
                if (cliente.Id_Cliente == clientes.Id_Cliente)
                {
                    cliente.Nombre = clientes.Nombre;
                    cliente.Cedula = clientes.Cedula;
                    cliente.Direccion = clientes.Direccion;
                    cliente.Telefono = clientes.Telefono;
                    cliente.Email = clientes.Email;
                }
                var msg = repositorioClientes.Update(contactoClientes);
                return msg;

            }
            return "\n No Lo Encontro El Cliente\n";
        }
        public List<CE_Clientes> Buscar(string contacto)
        {
            string nombre, cedula, telefono, id,  comparar;

            contactoClientes = GetClientes();
            List<CE_Clientes> clientes = new List<CE_Clientes>();

            comparar = contacto.ToUpper();

            foreach (CE_Clientes cliente in contactoClientes)
            {
                id = cliente.Id_Cliente.ToString();
                nombre = cliente.Nombre.ToUpper();
                cedula = cliente.Cedula.ToUpper();
                telefono = cliente.Telefono.ToUpper();

                if ((nombre.Contains(comparar)) || (cedula.Contains(comparar)) || (id.Contains(comparar)) ||(telefono.Contains(comparar)))
                {
                    clientes.Add(cliente);
                }

            }
            if (clientes.Any())
            {
                return clientes;
            }
            else
            {
                return null;
            }
        }

        public CE_Clientes BuscarId(int id, List<CE_Clientes> clientes)
        {
            foreach (CE_Clientes cliente in clientes)
            {
                if (cliente.Id_Cliente == id)
                {
                    return cliente;
                }
            }
            return null;
        }
    }
}
