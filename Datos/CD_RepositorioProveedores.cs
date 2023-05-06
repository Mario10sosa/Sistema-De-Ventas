using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_RepositorioProveedores : CD_InterfaceRepositorio<CE_Proveedores>
    {
        string ruta = "Proveedores.txt";
        public string Add(CE_Proveedores proveedores)
        {
            try
            {
                //1 Abrir.
                StreamWriter sw = new StreamWriter(ruta, true);
                //2 Operaciones
                sw.WriteLine(proveedores.ToString());

                //3 cerrar
                sw.Close();

                return "Datos almacenados";
            }
            catch (Exception ex)
            {
                return "No se almaceno el proveerdor error " + ex.Message;
            }
        }

        public string Delete(List<CE_Proveedores> proveedores)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var proveedor in proveedores)
                {
                    sw.WriteLine(proveedor.ToString());
                }

                sw.Close();

                return "El Proveedor fue eliminado";
            }
            catch (Exception ex)
            {
                return $"Error {ex}";
            }
        }

        public List<CE_Proveedores> GetAll()
        {
            try
            {
                var proveedor = new List<CE_Proveedores>();
                var sr = new StreamReader(ruta);

                while (!sr.EndOfStream)
                {
                    proveedor.Add(Mappeador(sr.ReadLine()));
                }
                sr.Close();
                return proveedor;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public CE_Proveedores Mappeador(string linea)
        {
            var proveedores = new CE_Proveedores();
            string[] aux;

            aux = linea.Split(';');

            proveedores.Id_Proveedor = int.Parse(aux[0]);
            proveedores.Nombre_Proveedor = aux[1];
            proveedores.Nit = aux[2];
            proveedores.Direccion = aux[3];
            proveedores.Telefono = aux[4];
            proveedores.Email = aux[5];

            return proveedores;
        }

        public string Update(List<CE_Proveedores> proveedores)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var proveedor in proveedores)
                {
                    sw.WriteLine(proveedores);
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
