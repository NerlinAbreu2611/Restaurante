namespace ConsoleApp1
{
    public class Cliente
    {
        int id;
        string nombre;
        string telefono;
        string email;
        string direccion;
        int id_condicion;
        bool estado;

        public Cliente(int id, string nombre, string telefono, string email, string direccion, int id_condicion, bool estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
            this.Id_condicion = id_condicion;
            this.Estado = estado;
        }
        public Cliente() { }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Id_condicion { get => id_condicion; set => id_condicion = value; }
        public bool Estado { get => estado; set => estado = value; }

        public override string ToString() { return $"id:{id} nombre:{nombre} telefono:{telefono} email:{email} direccion:{direccion} condicion:{id_condicion} estado:{estado}"; }
    }
}
