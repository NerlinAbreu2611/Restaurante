using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //El delegado multicast ejecuta todos los métodos, pero solo devuelve el resultado del último. 
            RepositorioDeProductos r = new RepositorioDeProductos();

            r.ObtenerDatos().ForEach(Console.WriteLine);
        }

    }

}
