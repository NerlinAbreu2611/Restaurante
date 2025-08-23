using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public class Detalle_pago
    {
        private int id_detalle;
        private int id_pago;
        private int id_orden;
        private decimal monto_aplicado;

        public int Id_detalle { get => id_detalle; set => id_detalle = value; }
        public int Id_pago { get => id_pago; set => id_pago = value; }
        public int Id_orden { get => id_orden; set => id_orden = value; }
        public decimal Monto_aplicado { get => monto_aplicado; set => monto_aplicado = value; }
    }
}
