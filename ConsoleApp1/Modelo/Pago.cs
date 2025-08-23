using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public class Pago
    {
        private int id_pago;
        private DateTime fecha_pago;
        private decimal monto_total;
        private int id_metodo_pago;
        private string nota;
        private bool estado;

        public int Id_pago { get => id_pago; set => id_pago = value; }
        public DateTime Fecha_pago { get => fecha_pago; set => fecha_pago = value; }
        public decimal Monto_total { get => monto_total; set => monto_total = value; }
        public int Id_metodo_pago { get => id_metodo_pago; set => id_metodo_pago = value; }
        public string Nota { get => nota; set => nota = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
