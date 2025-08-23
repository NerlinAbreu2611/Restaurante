using ConsoleApp1.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Proceso
{
    public class PDetalle_de_Orden
    {

        private static DbHelper<Detalle_de_orden> _dbHelper = new DbHelper<Detalle_de_orden>();

        public static List<Detalle_de_orden> getListByOrden(int id_orden)
        {
            string sql = "select * from detalle_de_orden where id_orden = @id";
            
            
            return listar(_dbHelper.consultar(sql, new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@id", id_orden) }));
           
        }

        

        private static List<Detalle_de_orden> listar(DataTable dt)
        {
            List<Detalle_de_orden> detalles = new List<Detalle_de_orden> ();

            foreach (DataRow dr in dt.Rows) 
            {
                Detalle_de_orden d = new Detalle_de_orden ();
                d.Id_detalle = Convert.ToInt32(dr["id_detalle"]);
                d.Id_orden = Convert.ToInt32(dr["id_orden"]);
                d.Id_producto = Convert.ToInt32(dr["id_producto"]);
                d.Cantidad = Convert.ToDecimal(dr["cantidad"]);
                d.Precio_unitario = Convert.ToDecimal(dr["precio_unitario"]);
                d.Sub_total = Convert.ToDecimal(dr["subtotal"]);
                d.Estado = Convert.ToBoolean(dr["estado"]);
                detalles.Add (d);
            }

            return detalles;
        }
    }
}
