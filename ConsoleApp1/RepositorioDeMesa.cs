using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RepositorioDeMesa
        : IRepositorio<Mesa>
    {
        
       private String conexion = "Server=localhost;" +
            "Database=restaurante;" +
            "Trusted_Connection=True;";
        public bool Actualizar(Mesa t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("actualizarMesa", conn))
            {
                try
                {
                    comman.CommandType = System.Data.CommandType.StoredProcedure;
                    comman.Parameters.AddWithValue("@id", t.Id);
                    comman.Parameters.AddWithValue("@asientos", t.Asientos);
                    comman.Parameters.AddWithValue("@estado", t.Estado);
                    comman.Parameters.AddWithValue("@descripcion", t.Descripcion);
                    comman.Parameters.AddWithValue("@fecha", t.Fecha);

                    conn.Open();
                    int filasAfectadas = comman.ExecuteNonQuery();

                    if (filasAfectadas > 0) { return true; }


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }

            return false;

        }

        public bool agregar(Mesa t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("insertarMesa", conn))
            {
                try
                {
                    comman.CommandType = System.Data.CommandType.StoredProcedure;

                    comman.Parameters.AddWithValue("@asientos", t.Asientos);
                    comman.Parameters.AddWithValue("@estado", t.Estado);
                    comman.Parameters.AddWithValue("@descripcion", t.Descripcion);
                    comman.Parameters.AddWithValue("@fecha", t.Fecha);

                    conn.Open();
                    int filasAfectadas = comman.ExecuteNonQuery();

                    if(filasAfectadas > 0) { return true; }


                }catch (SqlException ex)
                {
                    throw ex;
                }

                   
            }

            return false;
           
        }

        public bool desahabilitar(Mesa t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("deshabilitarMesa", conn))
            {
                try
                {
                    comman.CommandType = System.Data.CommandType.StoredProcedure;
                    comman.Parameters.AddWithValue("@id", t.Id);          
                    conn.Open();
                    int filasAfectadas = comman.ExecuteNonQuery();

                    if (filasAfectadas > 0) { return true; }


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }

            return false;
        }

        public bool habilitar(Mesa t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("habilitarMesa", conn))
            {
                try
                {
                    comman.CommandType = System.Data.CommandType.StoredProcedure;
                    comman.Parameters.AddWithValue("@id", t.Id);
                    conn.Open();
                    int filasAfectadas = comman.ExecuteNonQuery();

                    if (filasAfectadas > 0) { return true; }


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }

            return false;
        }

        public  List<Mesa> ObtenerDatos()
        {
            List<Mesa> mesas = new List<Mesa>();
            string sql = "select * from mesa";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                try
                {
                
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_mesa"]);
                        int asientos = Convert.ToInt32(fila["asientos"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);
                        string descripcion = fila["descripcion"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);

                        Mesa mesa = new Mesa(id, asientos, estado, descripcion, fecha);
                        mesas.Add(mesa);

                    }


                   return mesas;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return mesas;
        }

        public Mesa obtenerPorId(int id)
        {
            string sql = "SELECT * FROM mesa WHERE id_mesa = @id";

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                comman.Parameters.AddWithValue("@id", id);
                conn.Open();

                using (SqlDataReader reader = comman.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Mesa(
                     reader.GetInt32(reader.GetOrdinal("id_mesa")),
                     reader.GetInt32(reader.GetOrdinal("asientos")),
                     reader.GetBoolean(reader.GetOrdinal("estado")),
                     reader.GetString(reader.GetOrdinal("descripcion")),
                     reader.GetDateTime(reader.GetOrdinal("fecha"))
                      );

                    
                    }
                }
            }

            return null; // Si no encontró nada
        }

        public bool DesactivarMesa(int id)
        {
            string sql = "UPDATE mesa SET estado = 0 WHERE id_mesa = @id";

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@id", id);
                conn.Open();

                int filasAfectadas = command.ExecuteNonQuery();
                return filasAfectadas > 0; // Devuelve true si alguna fila fue actualizada
            }
        }

        public bool ActivarMesa(int id)
        {
            string sql = "UPDATE mesa SET estado = 1 WHERE id_mesa = @id";

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@id", id);
                conn.Open();

                int filasAfectadas = command.ExecuteNonQuery();
                return filasAfectadas > 0; // Devuelve true si alguna fila fue actualizada
            }
        }

        public List<Mesa> ObtenerMesasActivas()
        {
            List<Mesa> mesas = new List<Mesa>();
            string sql = "select * from mesa where estado = 1";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                try
                {

                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_mesa"]);
                        int asientos = Convert.ToInt32(fila["asientos"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);
                        string descripcion = fila["descripcion"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);

                        Mesa mesa = new Mesa(id, asientos, estado, descripcion, fecha);
                        mesas.Add(mesa);

                    }


                    return mesas;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return mesas;
        }
        
        public List<Mesa> ObtenerMesasInactivas()
        {
            List<Mesa> mesas = new List<Mesa>();
            string sql = "select * from mesa where estado = 0";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                try
                {

                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_mesa"]);
                        int asientos = Convert.ToInt32(fila["asientos"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);
                        string descripcion = fila["descripcion"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);

                        Mesa mesa = new Mesa(id, asientos, estado, descripcion, fecha);
                        mesas.Add(mesa);

                    }


                    return mesas;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return mesas;
        }

        public List<Mesa> ObtenerPorDescripcion(String desc)
        {
            List<Mesa> mesas = new List<Mesa>();
            string sql = "select * from mesa where descripcion like @descripcion";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                try
                {
                    comman.Parameters.AddWithValue("@descripcion", desc + "%");
                    conn.Open();
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_mesa"]);
                        int asientos = Convert.ToInt32(fila["asientos"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);
                        string descripcion = fila["descripcion"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);

                        Mesa mesa = new Mesa(id, asientos, estado, descripcion, fecha);
                        mesas.Add(mesa);

                    }


                    return mesas;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return mesas;
        }

        public List<Mesa> obtenerMesasActivasPorDescripcion(String desc)
        {
            List<Mesa> mesas = new List<Mesa>();
            string sql = "select * from mesa where descripcion like @descripcion and estado = 1";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                try
                {
                    comman.Parameters.AddWithValue("@descripcion", desc + "%");
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_mesa"]);
                        int asientos = Convert.ToInt32(fila["asientos"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);
                        string descripcion = fila["descripcion"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);

                        Mesa mesa = new Mesa(id, asientos, estado, descripcion, fecha);
                        mesas.Add(mesa);

                    }


                    return mesas;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return mesas;
        }

        public List<Mesa> obtenerMesasInactivasPorDescripcion(String desc)
        {
            List<Mesa> mesas = new List<Mesa>();
            string sql = "select * from mesa where descripcion like @descripcion and estado = 0";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                try
                {
                    comman.Parameters.AddWithValue("@descripcion", desc + "%");
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_mesa"]);
                        int asientos = Convert.ToInt32(fila["asientos"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);
                        string descripcion = fila["descripcion"].ToString();
                        DateTime fecha = Convert.ToDateTime(fila["fecha"]);

                        Mesa mesa = new Mesa(id, asientos, estado, descripcion, fecha);
                        mesas.Add(mesa);

                    }


                    return mesas;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return mesas;
        }

    }
}
