using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Empleado
    {
        private int id;
        private string nombre;
        private string apellido;
        private bool estado;
        private string clave;
        private string usuario;

        public Empleado(int id, string nombre, string apellido, bool estado, string clave, string usuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.estado = estado;
            this.clave = clave;
            this.usuario = usuario;
        }

        public Empleado() { }

        public override string ToString()
        {
            return $"id:{id} nombre:{nombre} apellido:{apellido} estado:{estado} usuario:{usuario} clave:{clave} ";
        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Usuario { get => usuario; set => usuario = value; }
    }
}
