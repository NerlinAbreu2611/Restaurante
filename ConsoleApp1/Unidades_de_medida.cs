using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Unidades_de_medida
    {

        private int id;
        private string nombre;
        private bool estado;

        public Unidades_de_medida(int id, string nombre, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = estado;
        }

        public Unidades_de_medida() { }

        public override string ToString()
        {
            return $"id:{id} nombre:{nombre} estado:{estado}";
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
