using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public class Orden
    {
        private int id_orden;
        private int id_cliente;
        private int id_mesa;
        private int id_empleado;
        private int id_condicion;
        private DateTime fecha_hora;
        private decimal total;
        private decimal saldo_pendiente;
        private bool procesada;
        private bool estado;

        public int Id_orden { get => id_orden; set => id_orden = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public int Id_mesa { get => id_mesa; set => id_mesa = value; }
        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public int Id_condicion { get => id_condicion; set => id_condicion = value; }
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
        public decimal Total { get => total; set => total = value; }
        public decimal Saldo_pendiente { get => saldo_pendiente; set => saldo_pendiente = value; }
        public bool Procesada { get => procesada; set => procesada = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
