using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
    
{
    public class Repositorio_tipo_movimiento
        : IRepositorio<tipo_movimiento>
    {
        DbHelper<tipo_movimiento> _dbHelper = new DbHelper<tipo_movimiento>();
        
        public bool Actualizar(tipo_movimiento t)
        {
            string sql = "update tipo_movimiento set descripcion = @descripcion, " +
                "afecta_stock = @afecta_stock, estado = @estado" +
                " where id_tipo_mov = @id";
         
            return _dbHelper.ejecutar(sql, cargarParametros, t);
        }
         
        public List<tipo_movimiento> buscarPorId(int id)
        {
            string sql = "select * from tipo_movimiento where id_tipo_mov = @id";
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Id = id;
            return listar(_dbHelper.listar(sql, tipo,cargarParametros));
        }
        private void cargarParametros(SqlCommand cmd, tipo_movimiento t)
        {
            cmd.Parameters.AddWithValue("@id", t.Id);
            if(t.Descripcion == null)
            {
                t.Descripcion = "";
            }
            cmd.Parameters.AddWithValue("@descripcion", t.Descripcion);
            cmd.Parameters.AddWithValue("@estado", t.Estado);
            cmd.Parameters.AddWithValue("@afecta_stock", t.Afecta_stock);

        }
        public bool agregar(tipo_movimiento t)
        {
            string sql = "insert into tipo_movimiento(descripcion, afecta_stock,estado)" +
                " values (@descripcion,@afecta_stock,@estado)";

           
            return _dbHelper.ejecutar(sql,cargarParametros,t);
        }

        public bool desahabilitar(tipo_movimiento t)
        {
            string sql = "update tipo_movimiento set estado = 0" +
                  " where id_tipo_mov = @id";
      
            return _dbHelper.ejecutar(sql, cargarParametros,t);
        }

        public bool habilitar(tipo_movimiento t)
        {
            string sql = "update tipo_movimiento set estado = 1" +
          " where id_tipo_mov = @id";

            return _dbHelper.ejecutar(sql, cargarParametros, t);
        }


       private List<tipo_movimiento> listar(DataTable dt)
        {
            List<tipo_movimiento> lista = new List<tipo_movimiento> ();
            foreach (DataRow row in dt.Rows)
            { 
                tipo_movimiento tipo_ = new tipo_movimiento ();
                tipo_.Descripcion = row["descripcion"].ToString();
                tipo_.Estado = Convert.ToBoolean(row["estado"].ToString());
                tipo_.Afecta_stock = Convert.ToInt32(row["afecta_stock"].ToString());
                tipo_.Id = Convert.ToInt32(row["id_tipo_mov"].ToString());
                lista.Add(tipo_);
            }

            return lista;
        }

        public List<tipo_movimiento> ObtenerDatos()
        {
            string sql = "select * from tipo_movimiento";
            tipo_movimiento tipo = new tipo_movimiento();
            return listar(_dbHelper.listar(sql, tipo));
           
        }

        public List<tipo_movimiento> ObtenerPorEstado(bool estado)
        {
            string sql = "select * from tipo_movimiento where estado = @estado";
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Estado = estado;
           
            return listar(_dbHelper.listar(sql, tipo,cargarParametros));
        }

        public List<tipo_movimiento> obtener_por_descripcion(string descripcion) 
        {
         string sql = "select * from tipo_movimiento where descripcion like @descripcion + '%'";
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Descripcion = descripcion;
            return listar(_dbHelper.listar(sql, tipo, cargarParametros));
        }

        public List<tipo_movimiento> obtener_por_descripcion_y_estado(string descripcion, bool estado)
        {
            string sql = "select * from tipo_movimiento where descripcion like @descripcion + '%' and estado = @estado";
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Descripcion = descripcion;
            tipo.Estado = estado;
            return listar(_dbHelper.listar(sql, tipo, cargarParametros));
        }

        public bool exisDescripcion(string descripcion)
        {
            string sql = "select * from tipo_movimiento where descripcion like @descripcion";
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Descripcion = descripcion;
            if (_dbHelper.listar(sql, tipo,cargarParametros).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
     
        }

        public bool exisDescripcion(string descripcion, int id)
        {
            string sql = "select * from tipo_movimiento where descripcion like @descripcion and id_tipo_mov <> @id";
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Descripcion = descripcion;
            tipo.Id = id;   
            if (_dbHelper.listar(sql, tipo,cargarParametros).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
