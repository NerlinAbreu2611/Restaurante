using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CategoriaProducto
    {
        private int id;
        private string nombre;
        private bool estado;

        public CategoriaProducto(){}
        public override string ToString()
        {
            return $"id:{id} nombre:{nombre} estado:{estado}";
        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
