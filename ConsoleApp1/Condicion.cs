using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Condicion
    {
        int id;
        string descripcion;
        bool esAutopago;
        int diasDeCredito;
        bool estado;

        public Condicion(int id, string descripcion, bool esAutopago, int diasDeCredito, bool estado)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.EsAutopago = esAutopago;
            this.DiasDeCredito = diasDeCredito;
            this.Estado = estado;
        }

        public Condicion() { }
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool EsAutopago { get => esAutopago; set => esAutopago = value; }
        public int DiasDeCredito { get => diasDeCredito; set => diasDeCredito = value; }
        public bool Estado { get => estado; set => estado = value; }

        public override string ToString()
        {
            return $"id:{id} desc:{descripcion} autopago:{esAutopago} diasDeCredito:{diasDeCredito} estado:{estado}";
        }
    }
}
