using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IRepositorio<T>
    {
        List<T> ObtenerDatos();
     
        bool agregar(T t);
        bool Actualizar(T t);
        bool desahabilitar (T t);
        bool habilitar(T t);
        
    }
}
