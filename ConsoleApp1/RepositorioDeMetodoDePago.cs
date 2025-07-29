using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RepositorioDeMetodoDePago : IRepositorio<MetodoDePago>
    {
        private String conexion = "Server=localhost;" +
        "Database=restaurante;" +
        "Trusted_Connection=True;";
        public bool Actualizar(MetodoDePago t)
        {
            using(SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("actualizarMetPago", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",t.Id);
                cmd.Parameters.AddWithValue("@descripcion", t.Descripcion);
                cmd.Parameters.AddWithValue("@estado",t.Estado);
                conn.Open();
                
                int filas = cmd.ExecuteNonQuery();  
                if(filas > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool agregar(MetodoDePago t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("agregarMetPago", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", t.Descripcion);
                cmd.Parameters.AddWithValue("@estado", t.Estado);
                conn.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool desahabilitar(MetodoDePago t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("cambiarEstadoMetPago", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@estado", 0);
                conn.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public bool habilitar(MetodoDePago t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("cambiarEstadoMetPago", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@estado", 1);
                conn.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public List<MetodoDePago> ObtenerDatos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from metodo_pago", conn))
            {
              List<MetodoDePago> metodoDePagos = new List<MetodoDePago>();
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    MetodoDePago metodo = new MetodoDePago();
                    metodo.Id = Convert.ToInt32(dr["id_metodo_pago"].ToString());
                    metodo.Descripcion = dr["descripcion"].ToString();
                    metodo.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    metodoDePagos.Add(metodo);
                }

                return metodoDePagos;
            }
        }

        public List<MetodoDePago> ObtenerDatosPorEstado(bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from obtenerMetPagoEstado(@estado)", conn))
            {
                List<MetodoDePago> metodoDePagos = new List<MetodoDePago>();
                cmd.Parameters.AddWithValue("@estado",estado);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    MetodoDePago metodo = new MetodoDePago();
                    metodo.Id = Convert.ToInt32(dr["id_metodo_pago"].ToString());
                    metodo.Descripcion = dr["descripcion"].ToString();
                    metodo.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    metodoDePagos.Add(metodo);
                }

                return metodoDePagos;
            }
        }


        public List<MetodoDePago> buscarPorDescripcion(String text)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("obtenerMetPagoPorDesc", conn))
            {
                List<MetodoDePago> metodoDePagos = new List<MetodoDePago>();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    MetodoDePago metodo = new MetodoDePago();
                    metodo.Id = Convert.ToInt32(dr["id_metodo_pago"].ToString());
                    metodo.Descripcion = dr["descripcion"].ToString();
                    metodo.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    metodoDePagos.Add(metodo);
                }

                return metodoDePagos;
            }

        }

        public List<MetodoDePago> buscarMetPagoPorDescEstado(String text,bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("obtenerMetPagoPorDescEstado", conn))
            {
                List<MetodoDePago> metodoDePagos = new List<MetodoDePago>();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@text", text);
                cmd.Parameters.AddWithValue("@estado", estado);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    MetodoDePago metodo = new MetodoDePago();
                    metodo.Id = Convert.ToInt32(dr["id_metodo_pago"].ToString());
                    metodo.Descripcion = dr["descripcion"].ToString();
                    metodo.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    metodoDePagos.Add(metodo);
                }

                return metodoDePagos;
            }

        }

        public MetodoDePago buscarPorId(int id)
        {
            using(SqlConnection conn = new SqlConnection(conexion))
                using (SqlCommand cmd = new SqlCommand("buscarMetPagoId",conn))
            {
                MetodoDePago met = new MetodoDePago();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    met.Id = Convert.ToInt32(dataReader["id_metodo_pago"].ToString());
                    met.Descripcion = dataReader["descripcion"].ToString();
                    met.Estado = Convert.ToBoolean(dataReader["estado"].ToString());
                }
                return met;

            }


        }
    }
}
