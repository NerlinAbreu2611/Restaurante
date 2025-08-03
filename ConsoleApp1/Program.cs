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
            tipo_movimiento tipo = new tipo_movimiento();

            tipo.Id = 1;
            tipo.Descripcion = "salida por venta";
            tipo.Estado = true;
            tipo.Afecta_stock = -1;

            Repositorio_tipo_movimiento re = new Repositorio_tipo_movimiento();

    

            if(re.Actualizar(tipo))
            {
                Console.WriteLine("bien");
            }
        
        }

    }

}
