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
          
            RepositorioDeEmpleado repositorio = new RepositorioDeEmpleado();

            //foreach (Empleado em in repositorio.filtrarPorNombreApellidoYEstado("j",true))
            //{
            //    Console.WriteLine(em);
            //} 

            Empleado emp = repositorio.buscarPorId(1);

            repositorio.desahabilitar(emp);

            //if (repositorio.habilitar(clientes[10])) Console.WriteLine("Exito"); 

        }
    }
}
