using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class RepositorioDeEmpleado : IRepositorio<Empleado>
    {
        private String conexion = "Server=localhost;" +
        "Database=restaurante;" +
        "Trusted_Connection=True;";
        public bool Actualizar(Empleado t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("actualizarEmpleado", conn))
            {
                /*
                 @id int,
                 @nombre varchar(50),
                 @apellido varchar(50),
                    @estado bit,
                    @clave varchar(30),
                    @usuario varchar(30)
                 */
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@apellido", t.Apellido);
                cmd.Parameters.AddWithValue("@estado", t.Estado);
                cmd.Parameters.AddWithValue("@clave", t.Clave);
                cmd.Parameters.AddWithValue("@usuario", t.Usuario);
                conn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool agregar(Empleado t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("agregarEmpleado", conn))
            {
                /*
                 @id int,
                 @nombre varchar(50),
                 @apellido varchar(50),
                    @estado bit,
                    @clave varchar(30),
                    @usuario varchar(30)
                 */
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@apellido", t.Apellido);
                cmd.Parameters.AddWithValue("@estado", t.Estado);
                cmd.Parameters.AddWithValue("@clave", t.Clave);
                cmd.Parameters.AddWithValue("@usuario", t.Usuario);
                conn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool desahabilitar(Empleado t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("actualizarEstadoDelEmpleado", conn))
            {
                /*
                 @id int,
                 @nombre varchar(50),
                 @apellido varchar(50),
                    @estado bit,
                    @clave varchar(30),
                    @usuario varchar(30)
                 */
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@estado", false);
                conn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool habilitar(Empleado t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("actualizarEstadoDelEmpleado", conn))
            {
                /*
                 @id int,
                 @nombre varchar(50),
                 @apellido varchar(50),
                    @estado bit,
                    @clave varchar(30),
                    @usuario varchar(30)
                 */
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t.Id);
                cmd.Parameters.AddWithValue("@estado", true);
                conn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Empleado> ObtenerDatos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from empleado", conn))
            {
                List<Empleado> empleados = new List<Empleado>();
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = Convert.ToInt32(dr["id_empleado"].ToString());
                    empleado.Nombre = dr["nombre"].ToString();
                    empleado.Apellido = dr["apellido"].ToString();
                    empleado.Estado = Convert.ToBoolean(dr["Estado"].ToString());
                    empleado.Clave = dr["clave"].ToString();
                    empleado.Usuario = dr["usuario"].ToString();
                    empleados.Add(empleado);
                }




                return empleados;
            }
        }

        public List<Empleado> ObtenerPorEstado(bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from obtenerEmpleadoPorEstado(@estado)", conn))
            {
                List<Empleado> empleados = new List<Empleado>();
                cmd.Parameters.AddWithValue("@estado", estado);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = Convert.ToInt32(dr["id_empleado"].ToString());
                    empleado.Nombre = dr["nombre"].ToString();
                    empleado.Apellido = dr["apellido"].ToString();
                    empleado.Estado = Convert.ToBoolean(dr["Estado"].ToString());
                    empleado.Clave = dr["clave"].ToString();
                    empleado.Usuario = dr["usuario"].ToString();
                    empleados.Add(empleado);
                }




                return empleados;
            }
        }

        public Empleado buscarPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select  * from buscarEmpleado(@id)", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Empleado empleado = new Empleado();

                if (reader.Read())
                {
                    empleado.Id = Convert.ToInt32(reader["id_empleado"].ToString());
                    empleado.Nombre = reader["nombre"].ToString();
                    empleado.Apellido = reader["apellido"].ToString();
                    empleado.Estado = Convert.ToBoolean(reader["estado"].ToString());
                    empleado.Clave = reader["clave"].ToString();
                    empleado.Usuario = reader["usuario"].ToString();

                }

                return empleado;


            }
        }

        public bool cambiarEstado(int id, bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("actualizarEstadoDelEmpleado", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@estado", estado);

                conn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public List<Empleado> filtrarPorNombreYApellido(string texto)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from filtrarPorNombreYApellidoEmpleado(@texto)", conn))
            {
                List<Empleado> empleados = new List<Empleado>();
                cmd.Parameters.AddWithValue("@texto", texto);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = Convert.ToInt32(dr["id_empleado"].ToString());
                    empleado.Nombre = dr["nombre"].ToString();
                    empleado.Apellido = dr["apellido"].ToString();
                    empleado.Estado = Convert.ToBoolean(dr["Estado"].ToString());
                    empleado.Clave = dr["clave"].ToString();
                    empleado.Usuario = dr["usuario"].ToString();
                    empleados.Add(empleado);
                }




                return empleados;
            }
        }

        public List<Empleado> filtrarPorNombreApellidoYEstado(string texto, bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("select * from filtrarPorNombreYApellidoEstadoEmpleado(@texto,@estado)", conn))
            {
                List<Empleado> empleados = new List<Empleado>();
                cmd.Parameters.AddWithValue("@texto", texto);
                cmd.Parameters.AddWithValue("@estado", estado);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Empleado empleado = new Empleado();
                    empleado.Id = Convert.ToInt32(dr["id_empleado"].ToString());
                    empleado.Nombre = dr["nombre"].ToString();
                    empleado.Apellido = dr["apellido"].ToString();
                    empleado.Estado = Convert.ToBoolean(dr["Estado"].ToString());
                    empleado.Clave = dr["clave"].ToString();
                    empleado.Usuario = dr["usuario"].ToString();
                    empleados.Add(empleado);
                }

                return empleados;


            }
        }
    }
}
