namespace ConsoleApp1
{
    public class MetodoDePago
    {
        int id;
        string descripcion;
        bool estado;

        public MetodoDePago(int id, string descripcion, bool estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public MetodoDePago() { }

        public override string ToString()
        {
            return $"id:{id} descripcion:{descripcion} estado:{estado}";
        }
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
