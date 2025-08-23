using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public class Detalle_de_orden
    {

        private int id_detalle;
        private int id_orden;
        private int id_producto;
        private decimal cantidad;
        private decimal precio_unitario;
        private decimal sub_total;
        private bool estado;

        public int Id_detalle { get => id_detalle; set => id_detalle = value; }
        public int Id_orden { get => id_orden; set => id_orden = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
        public decimal Sub_total { get => sub_total; set => sub_total = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
