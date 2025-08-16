namespace ConsoleApp1
{
    public class Producto
    {
        private int id_producto;
        private string nombre;
        private string descripcion;
        private int? id_categoria;
        private int? id_unidad;
        private decimal stock_actual;
        private decimal stock_minimo;
        private decimal precio_costo;
        private decimal precio_venta;
        private bool? estado;
        private string url_imagen;
        public override string ToString()
        {
            return $"id:{id_producto} nombre:{nombre} descripcion:{descripcion} id_categoria:{id_categoria} " +
                $"id_unidad:{id_unidad} stock_actual:{stock_actual} stock_minimo:{stock_minimo} precio_costo:{precio_costo}" +
                $" estado:{estado}";
        }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int? Id_categoria { get => id_categoria ?? 0; set => id_categoria = value; }
        public int Id_unidad { get => id_unidad ?? 0; set => id_unidad = value; }
        public decimal Stock_actual { get => stock_actual; set => stock_actual = value; }
        public decimal Stock_minimo { get => stock_minimo; set => stock_minimo = value; }
        public decimal Precio_costo { get => precio_costo; set => precio_costo = value; }
        public decimal Precio_venta { get => precio_venta; set => precio_venta = value; }
        public bool Estado { get => estado ?? false; set => estado = value; }
        public string Url_imagen { get => url_imagen; set => url_imagen = value; }

        public override bool Equals(object obj)
        {
            if (obj is Producto)
            {
                Producto producto = obj as Producto;

                return producto.nombre == nombre;
            }
            return false;
        }
    }
}
