using ConsoleApp1.Modelo;
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.Proceso
{
    public class PDetalle_Pago
    {

        public List<Detalle_pago> listar(DataTable dt)
        {
            List<Detalle_pago> detalles = new List<Detalle_pago>();
            foreach (DataRow dr in dt.Rows) {
                Detalle_pago detalle = new Detalle_pago();
                detalle.Id_detalle = Convert.ToInt32(dr["id_detalle"]);
                detalle.Id_pago = Convert.ToInt32(dr["id_pago"]);
                detalle.Id_orden = Convert.ToInt32(dr["id_orden"]);
                detalle.Monto_aplicado = Convert.ToDecimal(dr["monto_aplicado"]);
                detalles.Add(detalle);
            }

            return detalles;
        }

        public static int ultimoPago()
        {
            string sql = "select  max(id_pago) from pago;";
            DbHelper<Pago> dbHelper = new DbHelper<Pago>();
            return (int)dbHelper.ejecutarEscalar(sql);
        }

        public List<Detalle_pago> detalles_Por_Pago(int id_pago)
        {
            string sql = "select * from detalle_pago where id_pago = @id";
            DbHelper<Detalle_pago> db = new DbHelper<Detalle_pago> ();

            return listar(db.consultar(sql, new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@id", id_pago) }));
        }
        private String conexion = "Server=localhost;" +
           "Database=restaurante;" +
           "Trusted_Connection=True;";

        public bool procesarPago(Pago pago, List<Detalle_pago> detalles, List<Orden> ordenes)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                   SqlCommand cmd = con.CreateCommand ();
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"
                INSERT INTO [dbo].[pago]
                   ([fecha_pago]
                   ,[monto_total]
                   ,[id_metodo_pago]
                   ,[nota]
                   ,[estado])
                VALUES
                   (@fecha_pago, @monto_total, @id_metodo_pago, @nota, @estado);
                    ";

                    SqlParameter[] parametros = new SqlParameter[]
               {
                    new SqlParameter("@fecha_pago", pago.Fecha_pago) ,
                    new SqlParameter("@monto_total", pago.Monto_total) ,
                    new SqlParameter("@id_metodo_pago", pago.Id_metodo_pago) ,
                    new SqlParameter("@estado", pago.Estado) ,
                    new SqlParameter("@nota", pago.Nota) 
               };
                    cmd.Parameters.AddRange(parametros);
                    cmd.ExecuteNonQuery ();
                    cmd.Parameters.Clear ();

                    //Obtener el siguiente id
                    cmd.CommandText = "select  max(id_pago) from pago";
                    object result = cmd.ExecuteScalar ();

                    pago.Id_pago = Convert.ToInt32 (result);

                    //Crear detalles de pago
                    cmd.CommandText = @"
                     INSERT INTO [dbo].[detalle_pago]
                         ([id_pago], [id_orden], [monto_aplicado])
                     VALUES
                         (@id_pago, @id_orden, @monto_aplicado);
                     ";

                    // Crear un arreglo de parámetros
                    
                    foreach(Detalle_pago detalle in detalles)
                    {
                        cmd.Parameters.AddRange(
                            new SqlParameter[]
                            {
                                new SqlParameter("@id_pago", SqlDbType.Int) { Value = pago.Id_pago },
                                new SqlParameter("@id_orden", SqlDbType.Int) { Value = detalle.Id_orden },
                                new SqlParameter("@monto_aplicado", SqlDbType.Decimal) { Value = detalle.Monto_aplicado, Precision = 16, Scale = 4 }
                            }
                            );
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    //Actualizar las ordenes
                    cmd.CommandText = @"
                    UPDATE [dbo].[orden]
                    SET 
                    [procesada] = 1,
                    [saldo_pendiente] = 0
                     WHERE 
                    [id_orden] = @id_orden;
                    ";

                    foreach(Orden orden in ordenes)
                    {
                        cmd.Parameters.AddRange(new SqlParameter[]
                        {
                             new SqlParameter("@id_orden", SqlDbType.Int) { Value = orden.Id_orden }
                        });
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear ();
                    }


                    trans.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                
                }
                return false;
            }
        }
    }
}
