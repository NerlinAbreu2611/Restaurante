using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DbHelper<T>
    {
      private String conexion = "Server=localhost;" +
      "Database=restaurante;" +
      "Trusted_Connection=True;";

      
        public bool ejecutar(string sql, Action<SqlCommand,T> action, T entidad)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
             con.Open();
             
                action(cmd,entidad);
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    return true;
                }
               return false;
            }

        }

        public DataTable listar(string sql,T entidad, Action<SqlCommand,T> action = null) 
        { 
        using(SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                if (action != null) 
                {
                    action(cmd,entidad);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }       
        }
    }
}
