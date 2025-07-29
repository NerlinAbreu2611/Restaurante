using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RepositorioCondicion : IRepositorio<Condicion>
    {
        private String conexion = "Server=localhost;" +
        "Database=restaurante;" +
        "Trusted_Connection=True;";
        public bool Actualizar(Condicion t)
        {
            
            using (SqlConnection conn = new SqlConnection(conexion))
                using(SqlCommand cmd = new SqlCommand("actualizarCondicion", conn))
            {
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@descripcion", t.Descripcion);
                cmd.Parameters.AddWithValue("@autopago",t.EsAutopago);
                cmd.Parameters.AddWithValue("@dias_de_credito", t.DiasDeCredito);
                cmd.Parameters.AddWithValue("@estado",t.Estado);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if(resultado > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool agregar(Condicion t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("insertarCondicion", conn))
            {
                cmd.Parameters.AddWithValue("@descripcion", t.Descripcion);
                cmd.Parameters.AddWithValue("@autopago", t.EsAutopago);
                cmd.Parameters.AddWithValue("@dias_de_credito", t.DiasDeCredito);
                cmd.Parameters.AddWithValue("@estado", t.Estado);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool desahabilitar(Condicion t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("deshabilitarCondicion", conn))
            {
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool habilitar(Condicion t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("habilitarCondicion", conn))
            {
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public Condicion buscarPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from condicion where id_condicion = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader fila = cmd.ExecuteReader();
                Condicion condicion = new Condicion();
                if (fila.Read()) 
                {
                    condicion.Id = Convert.ToInt32(fila["id_condicion"].ToString());
                    condicion.Descripcion = fila["descripcion"].ToString();
                    condicion.Estado = Convert.ToBoolean(fila["estado"].ToString());
                    condicion.DiasDeCredito = Convert.ToInt32(fila["dias_credito"].ToString());
                    condicion.EsAutopago = Convert.ToBoolean(fila["autopago"].ToString());
                    
                    return condicion;
                }

                return null;


            }
        }
        public List<Condicion> ObtenerDatos()
        {
            List<Condicion> condiciones = new List<Condicion>();    
            string sql = "select * from condicion";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, conn)) 
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
               DataTable tabla = new DataTable();

                adapter.Fill(tabla);

                foreach(DataRow dr in tabla.Rows)
                {
                    Condicion condicion = new Condicion();
                    condicion.Id = Convert.ToInt32(dr["id_condicion"].ToString());
                    condicion.Descripcion = dr["descripcion"].ToString();
                    condicion.DiasDeCredito = Convert.ToInt32(dr["dias_credito"].ToString());
                    condicion.EsAutopago = Convert.ToBoolean(dr["autopago"].ToString());
                    condicion.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    condiciones.Add(condicion);
                }
            
                return condiciones;
            
            
            
            }
        }

        public List<Condicion> BuscarPorDescripcion(String text)
        {
            List<Condicion> condiciones = new List<Condicion>();

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from dbo.filtrarPorCondicion(@text)", conn))
            {
                cmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();

                adapter.Fill(tabla);

                foreach (DataRow dr in tabla.Rows)
                {
                    Condicion condicion = new Condicion();
                    condicion.Id = Convert.ToInt32(dr["id_condicion"].ToString());
                    condicion.Descripcion = dr["descripcion"].ToString();
                    condicion.DiasDeCredito = Convert.ToInt32(dr["dias_credito"].ToString());
                    condicion.EsAutopago = Convert.ToBoolean(dr["autopago"].ToString());
                    condicion.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    condiciones.Add(condicion);
                }

                return condiciones;
            }
        }

        public List<Condicion> BuscarPorDescripcionSegunElEstado(String text,bool estado)
        {
            List<Condicion> condiciones = new List<Condicion>();

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from filtrarPorCondicion(@text) where estado = @estado", conn))
            {
                cmd.Parameters.AddWithValue("@text", text);
                cmd.Parameters.AddWithValue("@estado", estado);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();

                adapter.Fill(tabla);

                foreach (DataRow dr in tabla.Rows)
                {
                    Condicion condicion = new Condicion();
                    condicion.Id = Convert.ToInt32(dr["id_condicion"].ToString());
                    condicion.Descripcion = dr["descripcion"].ToString();
                    condicion.DiasDeCredito = Convert.ToInt32(dr["dias_credito"].ToString());
                    condicion.EsAutopago = Convert.ToBoolean(dr["autopago"].ToString());
                    condicion.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    condiciones.Add(condicion);
                }

                return condiciones;
            }
        }

        public List<Condicion> obtenerCondicionesPorEstado(bool estado)
        {
            List<Condicion> condiciones = new List<Condicion>();

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from obtenerCondicionPorEstado(@estado)", conn))
            {
                
                cmd.Parameters.AddWithValue("@estado", estado);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();

                adapter.Fill(tabla);

                foreach (DataRow dr in tabla.Rows)
                {
                    Condicion condicion = new Condicion();
                    condicion.Id = Convert.ToInt32(dr["id_condicion"].ToString());
                    condicion.Descripcion = dr["descripcion"].ToString();
                    condicion.DiasDeCredito = Convert.ToInt32(dr["dias_credito"].ToString());
                    condicion.EsAutopago = Convert.ToBoolean(dr["autopago"].ToString());
                    condicion.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    condiciones.Add(condicion);
                }

                return condiciones;
            }
        }


    }
}
