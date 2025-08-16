using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.Proceso
{
    public class PMovimientoInventario
    {
        private static DbHelper<ConsoleApp1.Modelo.MovimientoInventario> dbHelper = new DbHelper<ConsoleApp1.Modelo.MovimientoInventario>();

        public static bool crearMovimiento(List<ConsoleApp1.Modelo.MovimientoInventario> movimientos, List<Producto> productos)
        {
            List<string> sqlS = new List<string>();
            List<Action<SqlCommand>> acciones = new List<Action<SqlCommand>>();

            for (int i = 0; i < movimientos.Count; i++)
            {
                sqlS.Add("insertarMovimiento");
                int idx = i;
                acciones.Add(cmd =>
                {

                    cmd.Parameters.AddWithValue("@id_producto", movimientos[idx].Id_producto);
                    cmd.Parameters.AddWithValue("@id_tipo_mov", movimientos[idx].Id_tipo_mov);
                    cmd.Parameters.AddWithValue("@cantidad", movimientos[idx].Cantidad);
                    cmd.Parameters.AddWithValue("@fecha", movimientos[idx].Fecha);

                    if (movimientos[idx].Id_proveedor == 0)
                    {
                        cmd.Parameters.AddWithValue("@id_proveedor", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id_proveedor", movimientos[idx].Id_proveedor);
                    }
                    cmd.Parameters.AddWithValue("@stock_actual", productos[idx].Stock_actual);
                    cmd.Parameters.AddWithValue("@observaciones", movimientos[idx].Observaciones);
                });
            }

            return dbHelper.ejecutarTransaccion(sqlS, acciones);
        }

    }
}
