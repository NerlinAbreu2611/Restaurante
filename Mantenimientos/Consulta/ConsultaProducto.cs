using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos.Consulta
{
    public partial class ConsultaProducto : Form
    {
        public ConsultaProducto()
        {
            InitializeComponent();
            panel1.Visible = false;
        }
        RepositorioDeProductos repositorioDeProductos = new RepositorioDeProductos();
        private void cargarDataGrid(List<Producto> pro)
        {

            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            //Sirve para quitar primera columna a la izquiera que solo sirve para seleccionar items
            dataGrid.RowHeadersVisible = false;
            //Sirve para quitar la ultima fila por defecto
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black; // Puedes usar cualquier color
            //definir la cabecera de las columnas
            dataGrid.Columns.Add("colId", "Id");
            dataGrid.Columns.Add("colNombre", "Nombre");
            dataGrid.Columns.Add("colDescripcion", "Descripcion");
            dataGrid.Columns.Add("colCategoria", "categoria");
            dataGrid.Columns.Add("colUnidad", "Unidad");
            dataGrid.Columns.Add("colStockActual", "Stock Actual");
            dataGrid.Columns.Add("colStokMinimo", "Stock Minimo");
            dataGrid.Columns.Add("colCosto", "Costo");
            dataGrid.Columns.Add("colVenta", "Venta");
            //definir la columna de tipo imagen de estado
            DataGridViewImageColumn imgEstado = new DataGridViewImageColumn();
            imgEstado.Name = "colEstado"; //nombre de la columna
            imgEstado.HeaderText = "Estado"; //Nombre del header de la columna
                                             // imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; //para que la imagen se ajuste
                                             //imgEstado.Width = 50;
            dataGrid.Columns.Add(imgEstado);//agregar la columna de tipo imagen al data grid

            //traer la lista de elementos para agregar el data grid

            //Cambiar el ancho de las columna/ajusta el ancho de las columnas al datagrid
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dataGridView1.Columns[0].Width = dataGridView1.Width / 8;
            //dataGridView1.Columns[1].Width = dataGridView1.Width / 8;
            //dataGridView1.Columns[2].Width = dataGridView1.Width / 4;
            //dataGridView1.Columns[3].Width = dataGridView1.Width / 4;
            //dataGridView1.Columns[4].Width = dataGridView1.Width / 12;
            //dataGridView1.Columns[5].Width = dataGridView1.Width / 12;

            //Cargar el data grid con la lista secuencialmente
            //dataGridView1.Columns["colEstado"].DefaultCellStyle.BackColor = Color.LightBlue; //cambiar color a una columna especificada

            List<CategoriaProducto> categorias = categoriasDeProductos.ObtenerDatos();
            List<Unidades_de_medida> unidades = unidadesDeMedida.ObtenerDatos();

            foreach (Producto p in pro)
            {

                Unidades_de_medida uni = unidades.Where(u => u.Id == p.Id_unidad).FirstOrDefault();
                CategoriaProducto ca = categorias.Where(c => c.Id == p.Id_categoria).FirstOrDefault();

                if (p.Estado)
                {
                    dataGrid.Rows.Add(p.Id_producto, p.Nombre, p.Descripcion, ca.Nombre, uni.Nombre, p.Stock_actual, p.Stock_minimo, p.Precio_costo, p.Precio_venta, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
                }
                else
                {
                    dataGrid.Rows.Add(p.Id_producto, p.Nombre, p.Descripcion, ca.Nombre, uni.Nombre, p.Stock_actual, p.Stock_minimo, p.Precio_costo, p.Precio_venta, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\hidden.png"));
                }
            }

        }


        //Constructor de consulta

        public ConsultaProducto(Mantenimientos.Procesos.MovimientoInventario mov)
        {
            InitializeComponent();
            this.mov = mov;
            dataGrid.CellDoubleClick += dataGrid_CellDoubleClick;
            this.Size = new System.Drawing.Size(721, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private Mantenimientos.Procesos.MovimientoInventario mov;



        RepositorioCategoriaDeProducto categoriasDeProductos = new RepositorioCategoriaDeProducto();
        Repositorio_de_unidad_de_medida unidadesDeMedida = new Repositorio_de_unidad_de_medida();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void ConsultaProducto_Load(object sender, EventArgs e)
        {
            comboFiltro.Items.AddRange(new string[] { "Nombre", "Descripcion", "Nombre y descripcion" });
            comboCategoria.Items.Add("Todo");
            categoriasDeProductos.listarPorEstado(true).ForEach(
                c => { comboCategoria.Items.Add(c.Nombre); }
                );
            comboUnidad.Items.Add("Todo");
            unidadesDeMedida.listar_por_estado(true).ForEach(
                u => { comboUnidad.Items.Add(u.Nombre); }
                );
            comboEstado.Items.AddRange(new string[] { "Todo", "Activo", "Inactivo" });

            comboFiltro.SelectedIndexChanged -= _SelectedIndexChanged;
            comboFiltro.SelectedIndex = 0;
            comboCategoria.SelectedIndex = 0;
            comboUnidad.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;

            cargarDataGrid(repositorioDeProductos.ObtenerDatos());
            comboCategoria.SelectedIndexChanged += _SelectedIndexChanged;
            comboEstado.SelectedIndexChanged += _SelectedIndexChanged;
            comboUnidad.SelectedIndexChanged += _SelectedIndexChanged;
            comboFiltro.SelectedIndexChanged += _SelectedIndexChanged;

        }

        private void consultar()
        {
            Producto p = new Producto();
            p.Nombre = "";
            p.Descripcion = "";
            int op = 1;

            string opcion = comboFiltro.SelectedItem.ToString();
            if (opcion == "Nombre")
            {
                p.Nombre = txtBusqueda.Text;
            }
            else if (opcion == "Descripcion")
            {
                p.Descripcion = txtBusqueda.Text;
            }
            else if (opcion == "Nombre y descripcion")
            {
                op = 0;
                p.Nombre = txtBusqueda.Text;
            }

            string estado = "";
            estado = comboEstado.SelectedItem.ToString();

            if (estado == "Activo")
            {
                p.Estado = true;
            }
            else if (estado == "Inactivo")
            {
                p.Estado = false;
            }

            foreach (CategoriaProducto c in categoriasDeProductos.ObtenerDatos())
            {
                if (c.Nombre == comboCategoria.SelectedItem.ToString())
                {
                    p.Id_categoria = c.Id;
                    break;
                }
            }

            foreach (Unidades_de_medida u in unidadesDeMedida.ObtenerDatos())
            {
                if (u.Nombre == comboUnidad.SelectedItem.ToString())
                {
                    p.Id_unidad = u.Id;
                    break;
                }
            }

            cargarDataGrid(repositorioDeProductos.consultarProductos(p, op, estado));

        }

        private void _SelectedIndexChanged(object sender, EventArgs e)
        {
            consultar();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            consultar();
        }

        private Producto producto;

        public Producto Producto { get => producto; set => producto = value; }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int num = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells[0].Value);
            this.producto = repositorioDeProductos.buscarPorId(num);
            if (mov != null)
            {
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
