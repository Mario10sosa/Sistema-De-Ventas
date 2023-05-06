using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class CD_RepositorioClientes : CD_InterfaceRepositorio<CE_Clientes>
    {
        string ruta = "Clientes.txt";
        public string Add(CE_Clientes cliente)
        {
            try
            {
                //1 Abrir.
                StreamWriter sw = new StreamWriter(ruta, true);
                //2 Operaciones
                sw.WriteLine(cliente.ToString());
                //3 cerrar
                sw.Close();

                return "Datos almacenados";
            }
            catch (Exception ex)
            {
                return "No se almaceno el dato error " + ex.Message;
            }
        }

        public string Delete(List<CE_Clientes> clientes)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var cliente in clientes)
                {
                    sw.WriteLine(cliente.ToString());
                }

                sw.Close();

                return "El Cliente fue eliminado";
            }
            catch (Exception ex)
            {
                return $"Error {ex}";
            }
        }

        public List<CE_Clientes> GetAll()
        {
            
            try
            {
                var clientes = new List<CE_Clientes>();
                var sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    clientes.Add(Mappeador(sr.ReadLine()));
                }
                sr.Close();
                return clientes;
            }
            catch (Exception)
            {
                return null;
            }
            

        }

        public CE_Clientes Mappeador(string linea)
        {
            var cliente = new CE_Clientes();
            string[] aux;

            aux = linea.Split(';');

            cliente.Id_Cliente = int.Parse(aux[0]);
            cliente.Nombre = aux[1];
            cliente.Cedula = aux[2];
            cliente.Direccion = aux[3];
            cliente.Telefono = aux[4];
            cliente.Email = aux[5];

            return cliente;
        }

        public string Update(List<CE_Clientes> clientes)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var cliente in clientes)
                {
                    sw.WriteLine(cliente);
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
