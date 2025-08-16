using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class DbHelper<T>
    {
        private String conexion = "Server=localhost;" +
        "Database=restaurante;" +
        "Trusted_Connection=True;";


        public bool ejecutar(string sql, Action<SqlCommand, T> action, T entidad)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();

                action(cmd, entidad);
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    return true;
                }
                return false;
            }

        }


        public bool ejecutarTransaccion(List<string> sqls, List<Action<SqlCommand>> acciones)
        {
            // Validaciones previas
            if (sqls == null || acciones == null) return false;
            if (sqls.Count == 0) return true; // o false, según tu necesidad
            if (acciones.Count != sqls.Count) return false;

            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();

                using (SqlTransaction trans = con.BeginTransaction())
                {
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.StoredProcedure; // Si siempre usas SP

                    try
                    {


                        for (int a = 0; a < sqls.Count; a++)
                        {
                            cmd.CommandText = sqls[a];
                            acciones[a].Invoke(cmd);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        try { trans.Rollback(); } catch { /* opcional: log */ }
                        return false;
                    }
                    catch
                    {
                        try { trans.Rollback(); } catch { /* opcional: log */ }
                        throw; // Mantener la excepción original
                    }
                }
            }
        }






        public DataTable consultar(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable listar(string sql, T entidad, Action<SqlCommand, T> action = null)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                if (action != null)
                {
                    action(cmd, entidad);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
