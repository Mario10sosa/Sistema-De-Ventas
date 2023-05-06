using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public interface CL_InterContacto<T>
    {
        string Save(T contacto);
        List<T> Mostrar();
        string Delete(T contacto);
        string Update(T contacto);
        List<T> Buscar(string contacto);
        T BuscarId(int id, List<T> contacto);
    }
}
