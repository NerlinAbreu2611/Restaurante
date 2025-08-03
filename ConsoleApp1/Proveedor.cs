using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Proveedor
    {
        private int id;
        private String nombre;
        private String telefono;
        private String email;
        private String direccion;
        private bool estado;

        public Proveedor(int id, string nombre, string telefono, string email, string direccion, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.email = email;
            this.direccion = direccion;
            this.estado = estado;
        }
        public Proveedor() { }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Estado { get => estado; set => estado = value; }

        public override string ToString()
        {
            return $"id:{Id} nombre:{Nombre} telefono:{Telefono} direccion:{direccion} email:{email} estado:{true}";
        }
    }
}
