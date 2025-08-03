using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RepositorioDeProveedor
        : IRepositorio<Proveedor>
    {
        private String conexion = "Server=localhost;" +
                                  "Database=restaurante;" +
                                  "Trusted_Connection=True;";
        public bool Actualizar(Proveedor t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
                using (SqlCommand command = new SqlCommand("actualizarPro", conn))
            {
                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@nombre", t.Nombre);
                command.Parameters.AddWithValue("@telefono", t.Telefono);
                command.Parameters.AddWithValue("@email", t.Email);
                command.Parameters.AddWithValue("@direccion", t.Direccion);
                command.Parameters.AddWithValue("@estado", t.Estado);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                if( command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool exisTelefono(int id, String telefono)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select telefono from proveedor where telefono = @telefono and id_proveedor <> @id", con))
            {
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read())
                {
                    return true;
                }
                return false;


            }

        }

        public bool exisTelefono(String telefono)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select telefono from proveedor where telefono = @telefono", con))
            {
                cmd.Parameters.AddWithValue("@telefono", telefono);
               
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                return false;


            }

        }

        public bool exisEmail(int id, String email)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select telefono from proveedor where email = @email and id_proveedor <> @id", con))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                return false;


            }

        }

        public bool exisEmail(String email)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select telefono from proveedor where email = @email", con))
            {
                cmd.Parameters.AddWithValue("@email", email);
    
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                return false;


            }

        }
        public bool agregar(Proveedor t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand("insertarPro", conn))
            {
                command.Parameters.AddWithValue("@nombre", t.Nombre);
                command.Parameters.AddWithValue("@telefono", t.Telefono);
                command.Parameters.AddWithValue("@email", t.Email);
                command.Parameters.AddWithValue("@direccion", t.Direccion);
                command.Parameters.AddWithValue("@estado", t.Estado);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Proveedor buscarId(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand("select * from buscarIdPro(@id)", conn))
            {
                command.Parameters.AddWithValue("@id", id);
             
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Proveedor proveedor = new Proveedor();
                if (reader.Read())
                {
                    proveedor.Id = Convert.ToInt32(reader["id_proveedor"].ToString());
                    proveedor.Nombre = reader["nombre"].ToString();
                    proveedor.Telefono = reader["telefono"].ToString();
                    proveedor.Email = reader["email"].ToString();
                    proveedor.Direccion = reader["direccion"].ToString();
                    proveedor.Estado = Convert.ToBoolean(reader["estado"].ToString());
                }

                return proveedor;

            }
        }
        public bool desahabilitar(Proveedor t)
        { 
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand("cambiarEstadoPro", conn))
            {
                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@estado", 0);
                command.CommandType = System.Data.CommandType.StoredProcedure;  
                conn.Open();

                if (command.ExecuteNonQuery() > 0) return true;
                return false;
            }
        }

        public bool habilitar(Proveedor t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand("cambiarEstadoPro", conn))
            {
                command.Parameters.AddWithValue("@id", t.Id);
                command.Parameters.AddWithValue("@estado", 1);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                if (command.ExecuteNonQuery() > 0) return true;
                return false;
            }
        }

        public List<Proveedor> ObtenerDatos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand command = new SqlCommand("Select * from proveedor", conn))
            {
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable(); 
                adapter.Fill(dt);

                List<Proveedor> proveedores = new List<Proveedor>();

                foreach(DataRow dr in dt.Rows)
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = Convert.ToInt32(dr["id_proveedor"].ToString());
                    proveedor.Nombre = dr["nombre"].ToString(); 
                    proveedor.Telefono = dr["telefono"].ToString();
                    proveedor.Direccion = dr["direccion"].ToString();
                    proveedor.Email = dr["email"].ToString();
                    proveedor.Estado = Convert.ToBoolean(dr["estado"].ToString());
                   
                    proveedores.Add(proveedor);
                }

                return proveedores;

            }
        }

        public List<Proveedor> obtenerDatosPorNombre(String nombre)
        {
            using(SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select * from buscarPro(@nombre)", conn))
            {

                cmd.Parameters.AddWithValue("@nombre", nombre);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<Proveedor> proveedores = new List<Proveedor>();

                foreach (DataRow dr in dt.Rows)
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = Convert.ToInt32(dr["id_proveedor"].ToString());
                    proveedor.Nombre = dr["nombre"].ToString();
                    proveedor.Telefono = dr["telefono"].ToString();
                    proveedor.Direccion = dr["direccion"].ToString();
                    proveedor.Email = dr["email"].ToString();
                    proveedor.Estado = Convert.ToBoolean(dr["estado"].ToString());

                    proveedores.Add(proveedor);
                }

                return proveedores;


            }
        }

        public List<Proveedor> listarPorEstado(bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select * from listarProEstado(@estado)", conn))
            {

                cmd.Parameters.AddWithValue("@estado", estado);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<Proveedor> proveedores = new List<Proveedor>();

                foreach (DataRow dr in dt.Rows)
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = Convert.ToInt32(dr["id_proveedor"].ToString());
                    proveedor.Nombre = dr["nombre"].ToString();
                    proveedor.Telefono = dr["telefono"].ToString();
                    proveedor.Direccion = dr["direccion"].ToString();
                    proveedor.Email = dr["email"].ToString();
                    proveedor.Estado = Convert.ToBoolean(dr["estado"].ToString());

                    proveedores.Add(proveedor);
                }

                return proveedores;


            }
        }

        public List<Proveedor> listarPorNombreYEstado(string nombre,bool estado)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("Select * from listarEstadoPro(@nombre,@estado)", conn))
            {

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@estado", estado);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<Proveedor> proveedores = new List<Proveedor>();

                foreach (DataRow dr in dt.Rows)
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = Convert.ToInt32(dr["id_proveedor"].ToString());
                    proveedor.Nombre = dr["nombre"].ToString();
                    proveedor.Telefono = dr["telefono"].ToString();
                    proveedor.Direccion = dr["direccion"].ToString();
                    proveedor.Email = dr["email"].ToString();
                    proveedor.Estado = Convert.ToBoolean(dr["estado"].ToString());

                    proveedores.Add(proveedor);
                }

                return proveedores;


            }
        }
    }
}
