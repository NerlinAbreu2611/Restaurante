using System;

namespace ConsoleApp1
{
    public class Mesa
    {
        private int id;
        private int asientos;
        private bool estado;
        private string descripcion;
        private DateTime fecha;

        public Mesa(int id, int asientos, bool estado, string descripcion, DateTime fecha)
        {
            this.id = id;
            this.asientos = asientos;
            this.estado = estado;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }
        public Mesa() { }

        public int Id { get => id; set => id = value; }
        public int Asientos { get => asientos; set => asientos = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public override string ToString()
        {
            return $"id:{this.id} asientos:{this.asientos} descripcion:{this.descripcion} estado:{this.estado} fecha:{this.fecha}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Mesa)
            {
                Mesa m = obj as Mesa;
                if(m.id == this.id)
                {
                    return true;
                }
            }

            return false ;
        }
    }
}
