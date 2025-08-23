using ConsoleApp1.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1.Proceso
{
    public class POrden
    {
        private DbHelper<Orden> DbHelper = new DbHelper<Orden>();   

        private List<Orden> listar(DataTable dt)
        {
            List<Orden> ordenes  = new List<Orden>();

            foreach (DataRow dr in dt.Rows) 
            {
                Orden orden = new Orden();
                orden.Id_orden = Convert.ToInt32(dr["id_orden"]);
                orden.Id_cliente = Convert.ToInt32(dr["id_cliente"]);
                orden.Id_mesa = Convert.ToInt32(dr["id_mesa"]);
                orden.Id_empleado = Convert.ToInt32(dr["id_empleado"]);
                orden.Id_condicion = Convert.ToInt32(dr["id_condicion"]);
                orden.Fecha_hora = DateTime.Parse(dr["fecha_hora"].ToString());
                orden.Fecha_vencimiento = DateTime.Parse(dr["fecha_vencimiento"].ToString());
                orden.Total = Convert.ToDecimal(dr["total"]);
                orden.Saldo_pendiente = Convert.ToDecimal(dr["saldo_pendiente"]);
                orden.Procesada = Convert.ToBoolean(dr["procesada"]);
                orden.Estado = Convert.ToBoolean(dr["estado"]);
                ordenes.Add(orden);
            }

            return ordenes;
        
        }
        private String conexion = "Server=localhost;" +
             "Database=restaurante;" +
             "Trusted_Connection=True;";

        public  Orden buscarPorId(int id)
        {
            string sql = "select * from orden where id_orden = @id";
            DbHelper<Orden> db = new DbHelper<Orden>();
            return listar(db.consultar(sql, new SqlParameter[] { new SqlParameter("@id", id) }))[0];
        }

        public static int ultimoID()
        {
            string sql = "select max(id_orden) from orden";
            DbHelper<Orden> db = new DbHelper<Orden>();
            return (int) db.ejecutarEscalar(sql);
        }

        public  List<Orden> ordenes_Por_Cliente(int id)
        {
            string sql = "select * from orden where id_cliente = @id and orden.procesada <> 1 ";
            DbHelper<Orden> db = new DbHelper<Orden>();

            return listar(db.consultar(sql,new SqlParameter[] {new SqlParameter("@id",id)})); 

        }

        public bool procesarOrdenContado(Orden orden,List<Detalle_de_orden> ordenes,
            Detalle_pago detalle,Pago pago)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                try
                {
                    //Insertar orden
                    string sql = "insert into orden" +
                        "(id_cliente," +
                        "id_mesa," +
                        "id_empleado," +
                        "id_condicion," +
                        "fecha_hora," +
                        "fecha_vencimiento," +
                        "total," +
                        "saldo_pendiente," +
                        "procesada," +
                        "estado)" +
                        " values" +
                        "(@id_cliente," +
                        "@id_mesa," +
                        "@id_empleado," +
                        "@id_condicion," +
                        "@fecha_hora," +
                        "@fecha_vencimiento," +
                        "@total," +
                        "@saldo_pendiente," +
                        "@procesada," +
                        "@estado);";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@id_cliente",orden.Id_cliente),
                        new SqlParameter("@id_empleado",orden.Id_empleado),
                        new SqlParameter("@id_mesa",orden.Id_mesa),
                        new SqlParameter("@id_condicion",orden.Id_condicion),
                        new SqlParameter("@fecha_hora",orden.Fecha_hora),
                        new SqlParameter("@fecha_vencimiento",orden.Fecha_vencimiento),
                        new SqlParameter("@total",orden.Total ),
                        new SqlParameter("@saldo_pendiente",orden.Saldo_pendiente),
                        new SqlParameter("@procesada",orden.Procesada),
                        new SqlParameter("@estado",orden.Estado) }
                        );
                    cmd.ExecuteNonQuery();
                    //Buscar el id de la orden
                    
                    sql = "select max(id_orden) from orden";
                    cmd.CommandText = sql;
                    Object resultado = cmd.ExecuteScalar();

                     int idOrden = Convert.ToInt32(resultado);

                    cmd.Parameters.Clear();
                    //Agregar Detalle de orden
                    sql = "insert into detalle_de_orden(" +
                          "id_orden," +
                         " id_producto," +
                         " cantidad," +
                         " precio_unitario, " +
                         " subtotal, " +
                         " estado) " +
                         " values" +
                         "(" +
                         " @id_orden" +
                         ",@id_producto," +
                         " @cantidad," +
                         " @precio_unitario, " +
                         " @subtotal, " +
                         " @estado) " +
                         " ";
                    cmd.CommandText = sql;
                    foreach (Detalle_de_orden d in ordenes)
                    {
                        cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@id_orden" ,idOrden),
                        new SqlParameter("@id_producto" ,d.Id_producto),
                        new SqlParameter("@cantidad" ,d.Cantidad),
                        new SqlParameter("@precio_unitario",d.Precio_unitario),
                        new SqlParameter("@subtotal" ,d.Sub_total),
                        new SqlParameter("@estado" ,d.Estado)
                        });
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }



                    //Agregar Pago
                    sql = "insert into pago" +
                        "(fecha_pago,monto_total,id_metodo_pago,nota,estado)" +
                        "values(" +
                        "@fecha_pago," +
                        "@monto_total," +
                        "@id_metodo_pago," +
                        "@nota," +
                        "@estado)";
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    if (pago.Nota == null)
                    {
                        pago.Nota = "";
                    }

                    cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@fecha_pago" ,pago.Fecha_pago) ,
                        new SqlParameter("@monto_total" ,pago.Monto_total),
                        new SqlParameter("@id_metodo_pago" ,pago.Id_metodo_pago) ,
                        new SqlParameter("@nota" ,pago.Nota),
                        new SqlParameter("@estado",pago.Estado)
                     });
                    cmd.ExecuteNonQuery();

                     sql = "select max(id_pago) from pago";
                     cmd.CommandText = sql;
                     resultado = cmd.ExecuteScalar();
                     int idPago = Convert.ToInt32(resultado);      
                    //Agregar detalle de pago
                    sql = "insert into detalle_pago (" +
                       "id_pago," +
                       "id_orden," +
                       "monto_aplicado)" +
                       "values" +
                       "(" +
                       "@id_pago," +
                       "@id_orden," +
                       "@monto_aplicado" +
                       ")";
                    cmd.CommandText =  sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@id_pago",idPago),
                        new SqlParameter("@id_orden",idOrden),
                        new SqlParameter("@monto_aplicado",detalle.Monto_aplicado)
                    });
                    cmd.ExecuteNonQuery();

                    tran.Commit();
                    return true;


                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    return false;
                }
                
            }
        }

        public bool procesarOrdenCredito(Orden orden, List<Detalle_de_orden> ordenes)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = tran;
                try
                {
                    //Insertar orden
                    string sql = "insert into orden" +
                        "(id_cliente," +
                        "id_mesa," +
                        "id_empleado," +
                        "id_condicion," +
                        "fecha_hora," +
                        "fecha_vencimiento," +
                        "total," +
                        "saldo_pendiente," +
                        "procesada," +
                        "estado)" +
                        " values" +
                        "(@id_cliente," +
                        "@id_mesa," +
                        "@id_empleado," +
                        "@id_condicion," +
                        "@fecha_hora," +
                        "@fecha_vencimiento," +
                        "@total," +
                        "@saldo_pendiente," +
                        "@procesada," +
                        "@estado);";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@id_cliente",orden.Id_cliente),
                        new SqlParameter("@id_empleado",orden.Id_empleado),
                        new SqlParameter("@id_mesa",orden.Id_mesa),
                        new SqlParameter("@id_condicion",orden.Id_condicion),
                        new SqlParameter("@fecha_hora",orden.Fecha_hora),
                        new SqlParameter("@fecha_vencimiento",orden.Fecha_vencimiento),
                        new SqlParameter("@total",orden.Total ),
                        new SqlParameter("@saldo_pendiente",orden.Saldo_pendiente),
                        new SqlParameter("@procesada",orden.Procesada),
                        new SqlParameter("@estado",orden.Estado) }
                        );
                    cmd.ExecuteNonQuery();
                    //Buscar el id de la orden

                    sql = "select max(id_orden) from orden";
                    cmd.CommandText = sql;
                    Object resultado = cmd.ExecuteScalar();

                    int idOrden = Convert.ToInt32(resultado);

                    cmd.Parameters.Clear();
                    //Agregar Detalle de orden
                    sql = "insert into detalle_de_orden(" +
                          "id_orden," +
                         " id_producto," +
                         " cantidad," +
                         " precio_unitario, " +
                         " subtotal, " +
                         " estado) " +
                         " values" +
                         "(" +
                         " @id_orden" +
                         ",@id_producto," +
                         " @cantidad," +
                         " @precio_unitario, " +
                         " @subtotal, " +
                         " @estado) " +
                         " ";
                    cmd.CommandText = sql;
                    foreach (Detalle_de_orden d in ordenes)
                    {
                        cmd.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@id_orden" ,idOrden),
                        new SqlParameter("@id_producto" ,d.Id_producto),
                        new SqlParameter("@cantidad" ,d.Cantidad),
                        new SqlParameter("@precio_unitario",d.Precio_unitario),
                        new SqlParameter("@subtotal" ,d.Sub_total),
                        new SqlParameter("@estado" ,d.Estado)
                        });
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    tran.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    return false;
                }

            }
        }


        public List<Orden> listarOrdenes()
        {
            string sql = "Select * from orden";
            Orden o = new Orden();
            List<Orden> ordenes = listar(DbHelper.listar(sql, o));
            return ordenes;
        }

        public List<Orden> listarActivas()
        {
            string sql = "Select * from orden where estado = 1";
            Orden o = new Orden();
            List<Orden> ordenes = listar(DbHelper.listar(sql, o));
            return ordenes;
        }

        public List<Orden> listarOrdenesPorCliente()
        {
            string sql = "select * from orden where estado = 1 and id_cliente = @id";
            Orden o = new Orden();
            List<Orden> ordens = listar(DbHelper.listar(sql,o));
            return ordens;
        }
    }
}
