using System;
using System.Text;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //El delegado multicast ejecuta todos los métodos, pero solo devuelve el resultado del último. 
            string datos = "uno dos tres cuatro cinco y seis";
            string[] d = datos.Split(' ');

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < d.Length; i++)
            {
                sb.Append(d[i]);
                if (i != d.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            Console.WriteLine(sb.ToString());
        }

    }

}
