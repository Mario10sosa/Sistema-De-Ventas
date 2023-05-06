using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface CD_InterfaceRepositorio<T>
    {
        string Add(T contacto);
        List<T> GetAll();
        string Delete(List<T> contacto);
        string Update(List<T> contacto);
        T Mappeador(string contacto);
    }
}
