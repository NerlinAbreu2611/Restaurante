using ConsoleApp1.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                orden.Total = Convert.ToDecimal(dr["total"]);
                orden.Saldo_pendiente = Convert.ToDecimal(dr["saldo_pendiente"]);
                orden.Procesada = Convert.ToBoolean(dr["procesada"]);
                orden.Estado = Convert.ToBoolean(dr["estado"]);
                ordenes.Add(orden);
            }

            return ordenes;
        
        }

    }
}
