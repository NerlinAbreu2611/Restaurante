using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp1
{
    public class RepositorioCategoriaDeProducto
        : IRepositorio<CategoriaProducto>
    {
        public bool Actualizar(CategoriaProducto t)
        {
            string sql = "update categoria_producto set nombre = @nombre, estado = @estado where id_categoria = @id";

            return db.ejecutar(sql, (cmd, c) =>
            {
                cmd.Parameters.AddWithValue("@id", c.Id);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@estado", c.Estado);

            }, t);
        }

        private DbHelper<CategoriaProducto> db = new DbHelper<CategoriaProducto>();
        public bool exisCategoria(string nombre, int id)
        {
            string sql = "select * from categoria_producto where nombre = @nombre and id_categoria <> @id";
            CategoriaProducto categoriaProducto = new CategoriaProducto();
            categoriaProducto.Id = id;
            categoriaProducto.Nombre = nombre;
            DataTable dt = db.listar(sql, categoriaProducto, (cmd, c) =>
            {
                cmd.Parameters.AddWithValue("@id", c.Id);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
            });

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool exisCategoria(string nombre)
        {
            string sql = "select * from categoria_producto where nombre = @nombre";
            CategoriaProducto categoriaProducto = new CategoriaProducto();
            categoriaProducto.Nombre = nombre;
            DataTable dt = db.listar(sql, categoriaProducto, (cmd, c) =>
            {
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
            });


            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;

        }

        public List<CategoriaProducto> listar(DataTable dt)
        {
            List<CategoriaProducto> lista = new List<CategoriaProducto>();

            foreach (DataRow dr in dt.Rows)
            {
                CategoriaProducto c = new CategoriaProducto();
                c.Id = Convert.ToInt32(dr["id_categoria"]);
                c.Nombre = dr["nombre"].ToString();
                c.Estado = Convert.ToBoolean(dr["estado"]);
                lista.Add(c);
            }

            return lista;
        }


        public bool agregar(CategoriaProducto t)
        {
            string sql = "insert into categoria_producto values(@nombre,@estado)";
            return db.ejecutar(sql, (cmd, c) =>
            {
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@estado", c.Estado);
            }, t);
        }

        public List<CategoriaProducto> ObtenerDatos()
        {
            string sql = "select * from categoria_producto";
            CategoriaProducto c = new CategoriaProducto();
            DataTable dt = db.listar(sql, c);

            return listar(dt);

        }

        public bool desahabilitar(CategoriaProducto t)
        {
            string sql = "update categoria_producto set estado = 0 where id_categoria = @id";

            return db.ejecutar(sql, (cmd, c) => { cmd.Parameters.AddWithValue("@id", c.Id); }, t);
        }

        public bool habilitar(CategoriaProducto t)
        {
            string sql = "update categoria_producto set estado = 1 where id_categoria = @id";

            return db.ejecutar(sql, (cmd, c) => { cmd.Parameters.AddWithValue("@id", c.Id); }, t);
        }

        public CategoriaProducto buscarPorId(int id)
        {
            string sql = "select * from categoria_producto where id_categoria = @id";
            CategoriaProducto p = new CategoriaProducto();
            p.Id = id;
            DataTable dt = db.listar(sql, p, (cmd, c) => { cmd.Parameters.AddWithValue("@id", c.Id); });
            return listar(dt)[0];
        }


        public List<CategoriaProducto> listarPorNombre(string nombre)
        {
            string sql = "select * from categoria_producto where nombre like @nombre + '%'";
            CategoriaProducto ca = new CategoriaProducto();
            ca.Nombre = nombre;
            DataTable dt = db.listar(sql, ca, (cmd, c) => { cmd.Parameters.AddWithValue("@nombre", c.Nombre); });
            return listar(dt);
        }

        public List<CategoriaProducto> listarPorEstado(bool estado)
        {
            string sql = "select * from categoria_producto where estado = @estado";
            CategoriaProducto ca = new CategoriaProducto();
            ca.Estado = estado;
            DataTable dt = db.listar(sql, ca, (cmd, c) => { cmd.Parameters.AddWithValue("@estado", c.Estado); });
            return listar(dt);
        }


        public List<CategoriaProducto> listarPorNombreYEstado(string nombre, bool estado)
        {
            string sql = "select * from categoria_producto where nombre like @nombre + '%' and estado = @estado";
            CategoriaProducto ca = new CategoriaProducto();
            ca.Nombre = nombre;
            ca.Estado = estado;
            DataTable dt = db.listar(sql, ca, (cmd, c) =>
            {
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@estado", c.Estado);
            });
            return listar(dt);
        }


    }
}
