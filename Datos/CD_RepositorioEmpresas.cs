using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CD_RepositorioEmpresas : CD_InterfaceRepositorio<CE_Empresas>
    {
        string ruta = "Empresas.Txt";
        public string Add(CE_Empresas empresas)
        {
            try
            {
                //1 Abrir.
                StreamWriter sw = new StreamWriter(ruta, true);
                //2 Operaciones
                sw.WriteLine(empresas.ToString());
                //3 cerrar
                sw.Close();

                return "Datos almacenados";
            }
            catch (Exception ex)
            {
                return "No se almaceno el dato error " + ex.Message;
            }
        }

        public string Delete(List<CE_Empresas> empresas)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var empresa in empresas)
                {
                    sw.WriteLine(empresas.ToString());
                }

                sw.Close();

                return "El Cliente fue eliminado";
            }
            catch (Exception ex)
            {
                return $"Error {ex}";
            }
        }

        public List<CE_Empresas> GetAll()
        {
            try
            {
                var empresas = new List<CE_Empresas>();
                var sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    empresas.Add(Mappeador(sr.ReadLine()));
                }
                sr.Close();
                return empresas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CE_Empresas Mappeador(string linea)
        {
            var empresa = new CE_Empresas();
            string[] aux;

            aux = linea.Split(';');

            empresa.Id_Empresa = int.Parse(aux[0]);
            empresa.Nombre = aux[1];
            empresa.Direccion = aux[2];
            empresa.Telefono = aux[3];
            empresa.Email = aux[4];

            return empresa;
        }

        public string Update(List<CE_Empresas> empresas)
        {
            try
            {
                var sw = new StreamWriter(ruta, false);

                foreach (var empresa in empresas)
                {
                    sw.WriteLine(empresa);
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
