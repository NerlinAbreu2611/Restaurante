using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp1
{
    public class Repositorio_de_unidad_de_medida
        : IRepositorio<Unidades_de_medida>
    {
        DbHelper<Unidades_de_medida> dbhelper = new DbHelper<Unidades_de_medida>();


        public bool Actualizar(Unidades_de_medida t)
        {
            string sql = "update unidad_medida set nombre = @nombre, estado = @estado " +
                  "where id_unidad = @id";
            return dbhelper.ejecutar(sql, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@id", u.Id);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@estado", u.Estado);
            }, t);
        }


        public bool agregar(Unidades_de_medida t)
        {
            string sql = "insert into unidad_medida(nombre,estado)" +
                "values (@nombre,@estado)";

            return dbhelper.ejecutar(sql, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@estado", u.Estado);
            }, t);
        }

        public bool desahabilitar(Unidades_de_medida t)
        {
            string sql = "update unidad_medida set estado = 0 where id_unidad = @id";

            return dbhelper.ejecutar(sql, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@id", u.Id);
            }, t);
        }

        public bool habilitar(Unidades_de_medida t)
        {
            string sql = "update unidad_medida set estado = 1 where id_unidad = @id";

            return dbhelper.ejecutar(sql, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@id", u.Id);
            }, t);
        }

        public List<Unidades_de_medida> ObtenerDatos()
        {
            String sql = "select * from unidad_medida";
            return listar(dbhelper.listar(sql, new Unidades_de_medida()));
        }

        public Unidades_de_medida buscar_por_id(int id)
        {
            String sql = "select * from unidad_medida where id_unidad = @id";
            Unidades_de_medida unidad = new Unidades_de_medida();
            unidad.Id = id;
            return listar(dbhelper.listar(sql, unidad, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@id", u.Id);
            }))[0];
        }

        public List<Unidades_de_medida> buscar_por_nombre(string nombre)
        {
            String sql = "select * from unidad_medida where nombre like @nombre + '%'";
            Unidades_de_medida unidad = new Unidades_de_medida();
            unidad.Nombre = nombre;
            return listar(dbhelper.listar(sql, unidad, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
            }));

        }

        public List<Unidades_de_medida> listar_por_estado(bool estado)
        {
            String sql = "select * from unidad_medida where estado = @estado";
            Unidades_de_medida unidad = new Unidades_de_medida();
            unidad.Estado = estado;
            return listar(dbhelper.listar(sql, unidad, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@estado", u.Estado);
            }));

        }

        public List<Unidades_de_medida> listar_por_nombre_y_estado(string nombre, bool estado)
        {
            String sql = "select * from unidad_medida where estado = @estado and nombre like @nombre + '%'";
            Unidades_de_medida unidad = new Unidades_de_medida();
            unidad.Estado = estado;
            unidad.Nombre = nombre;
            return listar(dbhelper.listar(sql, unidad, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@estado", u.Estado);
            }));
        }

        public bool exisUnidad(string nombre)
        {
            string sql = "select * from unidad_medida where nombre = @nombre";
            Unidades_de_medida unidad = new Unidades_de_medida();
            unidad.Nombre = nombre;

            DataTable dt = dbhelper.listar(sql, unidad, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
            });

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool exisUnidad(string nombre, int id)
        {
            string sql = "select * from unidad_medida where nombre = @nombre and id_unidad <> @id";
            Unidades_de_medida unidad = new Unidades_de_medida();
            unidad.Nombre = nombre;
            unidad.Id = id;

            DataTable dt = dbhelper.listar(sql, unidad, (cmd, u) =>
            {
                cmd.Parameters.AddWithValue("@id", unidad.Id);
                cmd.Parameters.AddWithValue("@nombre", unidad.Nombre);
            });

            if (dt.Rows.Count > 0) { return true; }
            return false;
        }


        public List<Unidades_de_medida> listar(DataTable dt)
        {
            List<Unidades_de_medida> lista = new List<Unidades_de_medida>();

            foreach (DataRow d in dt.Rows)
            {
                Unidades_de_medida unidad = new Unidades_de_medida();
                unidad.Id = Convert.ToInt32(d["id_unidad"].ToString());
                unidad.Nombre = d["nombre"].ToString();
                unidad.Estado = Convert.ToBoolean(d["estado"]);
                lista.Add(unidad);
            }

            return lista;

        }

    }
}
