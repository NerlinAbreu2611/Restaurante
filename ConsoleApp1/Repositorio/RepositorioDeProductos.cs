using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class RepositorioDeProductos
        : IRepositorio<Producto>
    {
        private DbHelper<Producto> dbHelper = new DbHelper<Producto>();
        public bool Actualizar(Producto t)
        {
            string sql = "actualizarProducto";
            if (t.Url_imagen == null)
            {
                t.Url_imagen = "";
            }
            return dbHelper.ejecutar(sql, (cmd, p) =>
            {
                cmd.Parameters.AddWithValue("@id_producto ", p.Id_producto);
                cmd.Parameters.AddWithValue("@nombre ", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion ", p.Descripcion);
                cmd.Parameters.AddWithValue("@id_categoria ", p.Id_categoria);
                cmd.Parameters.AddWithValue("@id_unidad ", p.Id_unidad);
                cmd.Parameters.AddWithValue("@stock_actual ", p.Stock_actual);
                cmd.Parameters.AddWithValue("@stock_minimo ", p.Stock_minimo);
                cmd.Parameters.AddWithValue("@precio_costo", p.Precio_costo);
                cmd.Parameters.AddWithValue("@precio_venta", p.Precio_venta);
                cmd.Parameters.AddWithValue("@estado", p.Estado);
                cmd.Parameters.AddWithValue("@url_imagen", p.Url_imagen);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            }, t);
        }

        public bool agregar(Producto t)
        {
            string sql = "agregarProducto";
            if (t.Url_imagen == null)
            {
                t.Url_imagen = "";
            }

            return dbHelper.ejecutar(sql, (cmd, p) =>
            {
                cmd.Parameters.AddWithValue("@nombre ", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion ", p.Descripcion);
                cmd.Parameters.AddWithValue("@id_categoria ", p.Id_categoria);
                cmd.Parameters.AddWithValue("@id_unidad ", p.Id_unidad);
                cmd.Parameters.AddWithValue("@stock_actual ", p.Stock_actual);
                cmd.Parameters.AddWithValue("@stock_minimo ", p.Stock_minimo);
                cmd.Parameters.AddWithValue("@precio_costo", p.Precio_costo);
                cmd.Parameters.AddWithValue("@precio_venta", p.Precio_venta);
                cmd.Parameters.AddWithValue("@url_imagen", p.Url_imagen);
                cmd.Parameters.AddWithValue("@estado", p.Estado);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            }, t);
        }


        private List<Producto> listar(DataTable dt)
        {
            List<Producto> lis = new List<Producto>();

            foreach (DataRow dr in dt.Rows)
            {
                Producto producto = new Producto();
                producto.Id_producto = Convert.ToInt32(dr["id_producto"]);
                producto.Nombre = dr["nombre"].ToString();
                producto.Descripcion = dr["descripcion"].ToString();
                producto.Id_categoria = Convert.ToInt32(dr["id_categoria"]);
                producto.Id_unidad = Convert.ToInt32(dr["id_unidad"]);
                producto.Stock_actual = Convert.ToDecimal(dr["stock_actual"]);
                producto.Stock_minimo = Convert.ToDecimal(dr["stock_minimo"]);
                producto.Precio_costo = Convert.ToDecimal(dr["precio_costo"]);
                producto.Precio_venta = Convert.ToDecimal(dr["precio_venta"]);
                producto.Url_imagen = dr["url_imagen"].ToString();
                producto.Estado = Convert.ToBoolean(dr["estado"]);
                lis.Add(producto);
            }

            return lis;
        }


        public bool desahabilitar(Producto t)
        {
            string sql = "update producto set estado = 0 where id_producto = @id";


            return dbHelper.ejecutar(sql, (cmd, p) =>
            {
                cmd.Parameters.AddWithValue("@id ", p.Id_producto);

            }, t);
        }

        public bool habilitar(Producto t)
        {
            string sql = "update producto set estado = 1 where id_producto = @id";


            return dbHelper.ejecutar(sql, (cmd, p) =>
            {
                cmd.Parameters.AddWithValue("@id ", p.Id_producto);

            }, t);
        }

        public List<Producto> ObtenerDatos()
        {
            string sql = "select * from producto";
            Producto producto = new Producto();
            List<Producto> productos = listar(dbHelper.listar(sql, producto));
            return productos;
        }

        public List<Producto> consultarProductos(Producto p, int opcion, string estado)
        {
            string sql = "";
            if (estado == "Todo")
            {
                sql = "select * from consultaProductos(@nombre,@descripcion,@id_categoria,@id_unidad,null,@opcion)";
            }
            else
            {
                sql = "select * from consultaProductos(@nombre,@descripcion,@id_categoria,@id_unidad,@estado,@opcion)";
            }

            List<Producto> productos = listar(dbHelper.consultar(sql, new SqlParameter[]
                    {
                        new SqlParameter("@nombre",p.Nombre),
                        new SqlParameter("@descripcion",p.Descripcion),
                        new SqlParameter("@id_categoria",p.Id_categoria == 0 ?(object)DBNull.Value : p.Id_categoria),
                        new SqlParameter("@id_unidad",p.Id_unidad ==  0?(object)DBNull.Value:p.Id_unidad),
                        new SqlParameter("@estado",p.Estado),
                        new SqlParameter("@opcion",opcion)

                    }));

            return productos;
        }

        public Producto buscarPorId(int id)
        {
            string sql = "select * from producto where id_producto = @id";
            Producto producto = new Producto();
            producto.Id_producto = id;
            List<Producto> productos = listar(dbHelper.listar(sql, producto,
                (cmd, p) =>
                {
                    cmd.Parameters.AddWithValue("@id", p.Id_producto);
                }));
            return productos[0];

        }

        public List<Producto> listarNombre(string nombre)
        {
            string sql = "select * from producto where nombre like @nombre + '%'";
            Producto producto = new Producto();
            producto.Nombre = nombre;
            List<Producto> productos = listar(dbHelper.listar(sql, producto,
               (cmd, p) =>
               {
                   cmd.Parameters.AddWithValue("@nombre", p.Nombre);
               }));

            return productos;
        }

        public List<Producto> listarNombreEstado(string nombre, bool estado)
        {
            string sql = "select * from producto where nombre like @nombre + '%' and estado = @estado";
            Producto producto = new Producto();
            producto.Nombre = nombre;
            producto.Estado = estado;
            List<Producto> productos = listar(dbHelper.listar(sql, producto,
               (cmd, p) =>
               {
                   cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                   cmd.Parameters.AddWithValue("@estado", p.Estado);
               }));

            return productos;
        }

        public List<Producto> listarPorEstado(bool estado)
        {
            string sql = "select * from producto where estado = @estado";
            Producto producto = new Producto();
            producto.Estado = estado;
            List<Producto> productos = listar(dbHelper.listar(sql, producto,
               (cmd, p) =>
               {
                   cmd.Parameters.AddWithValue("@estado", p.Estado);
               }));

            return productos;
        }

        public bool existProducto(string nombre)
        {
            string sql = "select * from producto where nombre = @nombre";
            Producto producto = new Producto() { Nombre = nombre };
            DataTable dt = dbHelper.listar(sql, producto,
             (cmd, p) =>
             {
                 cmd.Parameters.AddWithValue("@nombre", p.Nombre);
             });

            if (dt.Rows.Count > 0) { return true; }
            return false;

        }

        public bool existProducto(string nombre, int id)
        {
            string sql = "select * from producto where nombre = @nombre and id_producto <> @id";
            Producto producto = new Producto() { Nombre = nombre, Id_producto = id };
            DataTable dt = dbHelper.listar(sql, producto,
             (cmd, p) =>
             {
                 cmd.Parameters.AddWithValue("@id", p.Id_producto);
                 cmd.Parameters.AddWithValue("@nombre", p.Nombre);
             });

            if (dt.Rows.Count > 0) { return true; }
            return false;

        }

    }
}
