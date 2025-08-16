using System;

namespace ConsoleApp1.Modelo
{
    public class MovimientoInventario
    {
        private int id_movimiento;
        private int id_producto;
        private int id_tipo_mov;
        private decimal cantidad;
        private DateTime fecha;
        private int id_proveedor;
        private string observaciones;
        private bool estado;

        public int Id_movimiento { get => id_movimiento; set => id_movimiento = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_tipo_mov { get => id_tipo_mov; set => id_tipo_mov = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
