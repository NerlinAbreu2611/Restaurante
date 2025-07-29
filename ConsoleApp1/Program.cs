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
          
            //Probar agregar

            MetodoDePago m = new MetodoDePago();
            m.Descripcion = "efectivo";
            m.Estado = true;
            m.Id = 1;
            RepositorioDeMetodoDePago rep = new RepositorioDeMetodoDePago();

            rep.buscarPorDescripcion("e").ForEach(Console.WriteLine);



        }
    }
}
