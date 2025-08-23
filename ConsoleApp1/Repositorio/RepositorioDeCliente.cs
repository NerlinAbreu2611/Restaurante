using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConsoleApp1
{
    public class RepositorioDeCliente : IRepositorio<Cliente>
    {
        private String conexion = "Server=localhost;" +
      "Database=restaurante;" +
      "Trusted_Connection=True;";
        public bool Actualizar(Cliente t)
        {

            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("actualizarCliente", conn))
            {
                try
                {
                    comman.CommandType = System.Data.CommandType.StoredProcedure;
                    comman.Parameters.AddWithValue("@id", t.Id);
                    comman.Parameters.AddWithValue("@nombre", t.Nombre);
                    comman.Parameters.AddWithValue("@telefono", t.Telefono);
                    comman.Parameters.AddWithValue("@email", t.Email);
                    comman.Parameters.AddWithValue("@direccion", t.Direccion);
                    comman.Parameters.AddWithValue("@id_condicion", t.Id_condicion);
                    comman.Parameters.AddWithValue("@estado", t.Estado);

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


        public List<Cliente> clientes_Con_Ordenes_Pendientes()
        {
           DbHelper<Cliente> db = new DbHelper<Cliente>();

            string sql = "select c.id_cliente,c.nombre,c.telefono,c.email,c.direccion,c.id_condicion,\r\nc.estado from cliente as c\r\ninner join\r\n(select  c.id_cliente as 'id', count(c.id_cliente) as 'ordenes'\r\nfrom cliente as c\r\ninner join orden on c.id_cliente = orden.id_cliente\r\nwhere c.id_cliente <> 20 and orden.procesada <> 1\r\ngroup by c.id_cliente) as sub on sub.id = c.id_cliente;";
            return listar( db.consultar(sql));
        }


        public bool agregar(Cliente t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("agregarCliente", conn))
            {
                try
                {
                    comman.CommandType = System.Data.CommandType.StoredProcedure;
                    comman.Parameters.AddWithValue("@nombre", t.Nombre);
                    comman.Parameters.AddWithValue("@telefono", t.Telefono);
                    comman.Parameters.AddWithValue("@email", t.Email);
                    comman.Parameters.AddWithValue("@direccion", t.Direccion);
                    comman.Parameters.AddWithValue("@id_condicion", t.Id_condicion);
                    comman.Parameters.AddWithValue("@estado", t.Estado);

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

        public Cliente obtenerPorId(int id)
        {

            string sql = "select * from cliente where id_cliente = @id";
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand(sql, conn))
            {
                comman.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader fila = comman.ExecuteReader();
                Cliente cliente = new Cliente();

                if (fila.Read())
                {
                    cliente.Id = Convert.ToInt32(fila["id_cliente"]);
                    cliente.Nombre = fila["nombre"].ToString();
                    cliente.Telefono = fila["telefono"].ToString();
                    cliente.Email = fila["email"].ToString();
                    cliente.Direccion = fila["direccion"].ToString();
                    cliente.Id_condicion = Convert.ToInt32(fila["id_condicion"]);
                    cliente.Estado = Convert.ToBoolean(fila["estado"]);

                    return cliente;
                }
                else
                {
                    return null;
                }



            }
        }

        public bool desahabilitar(Cliente t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("deshabilitarCliente", conn))
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

        public bool habilitar(Cliente t)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("habilitarCliente", conn))
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

        public List<Cliente> ObtenerDatos()
        {
            List<Cliente> clientes = new List<Cliente>();
            string sql = "select * from cliente";
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
                        int id = Convert.ToInt32(fila["id_cliente"]);
                        string nombre = fila["nombre"].ToString();
                        string telefono = fila["telefono"].ToString();
                        string email = fila["email"].ToString();
                        string direccion = fila["direccion"].ToString();
                        int condicion = Convert.ToInt32(fila["id_condicion"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);

                        Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                        clientes.Add(cliente);

                    }


                    return clientes;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return clientes;
        }

        public List<Cliente> filtrarActivos()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("select * from filtrarClientesActivos()", conn))
            {
                try
                {

                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_cliente"]);
                        string nombre = fila["nombre"].ToString();
                        string telefono = fila["telefono"].ToString();
                        string email = fila["email"].ToString();
                        string direccion = fila["direccion"].ToString();
                        int condicion = Convert.ToInt32(fila["id_condicion"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);

                        Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                        clientes.Add(cliente);

                    }


                    return clientes;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return clientes;
        }

        public List<Cliente> listar(DataTable dt)
        {
            List<Cliente> clientes = new List<Cliente>();   
            foreach (DataRow fila in dt.Rows)
            {
                int id = Convert.ToInt32(fila["id_cliente"]);
                string nombre = fila["nombre"].ToString();
                string telefono = fila["telefono"].ToString();
                string email = fila["email"].ToString();
                string direccion = fila["direccion"].ToString();
                int condicion = Convert.ToInt32(fila["id_condicion"]);
                bool estado = Convert.ToBoolean(fila["estado"]);

                Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                clientes.Add(cliente);

            }
            return clientes;
        }

        public List<Cliente> filtrarInactivos()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("select * from filtrarClientesInactivos()", conn))
            {
                try
                {

                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_cliente"]);
                        string nombre = fila["nombre"].ToString();
                        string telefono = fila["telefono"].ToString();
                        string email = fila["email"].ToString();
                        string direccion = fila["direccion"].ToString();
                        int condicion = Convert.ToInt32(fila["id_condicion"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);

                        Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                        clientes.Add(cliente);

                    }


                    return clientes;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return clientes;
        }

        public List<Cliente> filtrarPorNombre(String nom)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("select * from filtrarPorElNombreDelCliente(@nombre)", conn))
            {
                try
                {

                    conn.Open();
                    comman.Parameters.AddWithValue("@nombre", nom);
                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_cliente"]);
                        string nombre = fila["nombre"].ToString();
                        string telefono = fila["telefono"].ToString();
                        string email = fila["email"].ToString();
                        string direccion = fila["direccion"].ToString();
                        int condicion = Convert.ToInt32(fila["id_condicion"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);

                        Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                        clientes.Add(cliente);

                    }


                    return clientes;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return clientes;
        }

        public List<Cliente> filtrarPorNombreActivo(String nom)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("select * from filtrarPorElNombreDelClienteActivos(@nombre)", conn))
            {
                try
                {

                    conn.Open();
                    comman.Parameters.AddWithValue("@nombre", nom);
                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_cliente"]);
                        string nombre = fila["nombre"].ToString();
                        string telefono = fila["telefono"].ToString();
                        string email = fila["email"].ToString();
                        string direccion = fila["direccion"].ToString();
                        int condicion = Convert.ToInt32(fila["id_condicion"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);

                        Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                        clientes.Add(cliente);

                    }


                    return clientes;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return clientes;
        }

        public List<Cliente> filtrarPorNombreInactivo(String nom)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand comman = new SqlCommand("select * from filtrarPorElNombreDelClienteInactivos(@nombre)", conn))
            {
                try
                {

                    conn.Open();
                    comman.Parameters.AddWithValue("@nombre", nom);
                    SqlDataAdapter adapter = new SqlDataAdapter(comman);
                    DataTable tabla = new DataTable();

                    adapter.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["id_cliente"]);
                        string nombre = fila["nombre"].ToString();
                        string telefono = fila["telefono"].ToString();
                        string email = fila["email"].ToString();
                        string direccion = fila["direccion"].ToString();
                        int condicion = Convert.ToInt32(fila["id_condicion"]);
                        bool estado = Convert.ToBoolean(fila["estado"]);

                        Cliente cliente = new Cliente(id, nombre, telefono, email, direccion, condicion, estado);
                        clientes.Add(cliente);

                    }


                    return clientes;


                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return clientes;
        }

        public bool validarEmail(String email)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.validarEmail(@email)", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@email", email);
                int resultado = (int)cmd.ExecuteScalar();
                if (resultado == 0) { return false; }
                else return true;
            }
        }

        public bool validarTelefono(String telefono)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.validarTelefono(@telefono)", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@telefono", telefono);
                int resultado = (int)cmd.ExecuteScalar();
                if (resultado == 0) { return false; }
                else return true;
            }
        }

    }
}
