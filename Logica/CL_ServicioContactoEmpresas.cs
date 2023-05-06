using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CL_ServicioContactoEmpresas : CL_InterContacto<CE_Empresas>
    {
        CD_RepositorioEmpresas repositorioEmpresas = new CD_RepositorioEmpresas();
        List<CE_Empresas> contactoEmpresas = new List<CE_Empresas>();

        public List<CE_Empresas> GetEmpresas()
        {
            contactoEmpresas = repositorioEmpresas.GetAll();
            return contactoEmpresas;
        }

        public string Save(CE_Empresas empresas)
        {
            try
            {
                //contactoClientes = GetClientes();
                if (empresas == null)
                {
                    return "No Se Pudo Guardar El Cliente";
                }
                else
                {
                    repositorioEmpresas.Add(empresas);
                    return " El Cliente " + empresas.Nombre + " Fue Guardado";
                }
            }
            catch (Exception ex)
            {
                return $"\n Error" + ex + "\n";
            }
        }

        public List<CE_Empresas> Mostrar()
        {
            if (!GetEmpresas().Any()) { return null; }
            return GetEmpresas();
        }

        public string Delete(CE_Empresas empresas)
        {
            contactoEmpresas = GetEmpresas();
            var buscado = BuscarId(empresas.Id_Empresa, contactoEmpresas);
            contactoEmpresas.Remove(buscado);
            var respuesta = repositorioEmpresas.Delete(contactoEmpresas);
            return respuesta;
        }

        public string Update(CE_Empresas empresas)
        {
            contactoEmpresas = GetEmpresas();

            foreach (CE_Empresas empresa in contactoEmpresas)
            {
                if (empresa.Id_Empresa == empresas.Id_Empresa)
                {
                    empresa.Nombre = empresas.Nombre;
                    empresa.Direccion = empresas.Direccion;
                    empresa.Telefono = empresas.Telefono;
                    empresa.Email = empresas.Email;
                }
                var msg = repositorioEmpresas.Update(contactoEmpresas);
                return msg;

            }
            return "\n No Se Encontro La Empresa\n";
        }

        public List<CE_Empresas> Buscar(string contacto)
        {
            string nombre,id, comparar;

            contactoEmpresas = GetEmpresas();
            List<CE_Empresas> empresas = new List<CE_Empresas>();

            comparar = contacto.ToUpper();

            foreach (CE_Empresas empresa in contactoEmpresas)
            {
                nombre = empresa.Nombre.ToUpper();
                id = empresa.Id_Empresa.ToString();

                if ((nombre.Contains(comparar))||(id.Contains(comparar)))
                {
                    empresas.Add(empresa);
                }

            }
            if (empresas.Any())
            {
                return empresas;
            }
            else
            {
                return null;
            }
        }

        public CE_Empresas BuscarId(int id, List<CE_Empresas> empresas)
        {
            foreach (CE_Empresas empresa in empresas)
            {
                if (empresa.Id_Empresa == id)
                {
                    return empresa;
                }
            }
            return null;
        }
    }
}
