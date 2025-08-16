namespace ConsoleApp1
{
    public class tipo_movimiento
    {
        int id;
        string descripcion;
        int afecta_stock;
        bool estado;

        public tipo_movimiento(int id, string descripcion, int afecta_stock, bool estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.afecta_stock = afecta_stock;
            this.estado = estado;
        }
        public tipo_movimiento() { }

        public override string ToString()
        {
            return $"id:{id} descripcion:{descripcion} afecta_stock:{afecta_stock} estado:{estado}";
        }
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Afecta_stock { get => afecta_stock; set => afecta_stock = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
