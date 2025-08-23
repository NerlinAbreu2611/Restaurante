using ConsoleApp1;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimientos.Procesos
{
    public partial class ControlProductos : UserControl
    {
        public ControlProductos()
        {
            InitializeComponent();
        }

        
       public IconButton _btnMas {  get => btnMin; set => btnMin = value; }
        public IconButton _btnMin { get => btnMas; set => btnMas = value; }

        public TextBox _txtCant { get => txtCant; set => txtCant = value; }

        public Label _lblPrecio { get => lblPrecio;set => lblPrecio = value; }

        public Label _lblNombre { get => lblNombre; set => lblNombre = value; }

        private Producto producto;

        public PictureBox _fotoProducto { get => fotoProducto;set => fotoProducto = value;}
        public Producto Producto { get => producto; set => producto = value; }
        public decimal CantidadPro { get => cantidadPro; set => cantidadPro = value; }

        public DataGridView dataGrid;

        private decimal stock_original;

        private void ControlProductos_Load(object sender, EventArgs e)
        {
            stock_original = producto.Stock_actual;
            txtCant.Text = producto.Stock_actual.ToString();
        }

        private void agregarProducto(int cant)
        {
            bool existe = false;

            //buscar
            int i = 0;
            while (!existe && i < dataGrid.Rows.Count)
            {
                if (dataGrid.Rows[i].Cells["ColProducto"].Value.ToString() == producto.Nombre)
                {
                    existe = true;
                    dataGrid.Rows[i].Cells["ColCantidad"].Value = cant;
                    dataGrid.Rows[i].Cells["ColSubTotal"].Value = (cant * producto.Precio_venta).ToString("c");
                }
                else
                {
                    i++;
                }
                
            }

            if (!existe)
            {
                dataGrid.Rows.Add(1,producto.Nombre,producto.Precio_venta,producto.Precio_venta);
            }

        }
        private void btnMas_Click(object sender, EventArgs e)
        {
            RepositorioDeProductos repositorio = new RepositorioDeProductos();
            decimal num = producto.Stock_actual;
            if(producto.Stock_actual > 0)
            {
                producto.Stock_actual = producto.Stock_actual - 1;
                txtCant.Text = producto.Stock_actual.ToString();
                CantidadPro += 1;
                agregarProducto((int)CantidadPro);
                repositorio.Actualizar(producto);
            }
            

        }

        private decimal cantidadPro = 0;
        private void btnMin_Click(object sender, EventArgs e)
        {

            int i = 0;
            bool encontrado = false;
            decimal pico = 0;
            while (i < dataGrid.Rows.Count && !encontrado)
            {
                if (dataGrid.Rows[i].Cells["ColProducto"].Value.ToString() == producto.Nombre)
                {
                    encontrado = true;
                    pico = Convert.ToDecimal(dataGrid.Rows[i].Cells["ColCantidad"].Value);
                }
                else
                {
                    i++;
                }
            }

       
           
            RepositorioDeProductos repositorio = new RepositorioDeProductos();
            if (pico >= 1 && pico - 1 > 0) {
                producto.Stock_actual = producto.Stock_actual + 1;
                txtCant.Text = producto.Stock_actual.ToString();
                CantidadPro -= 1;
                agregarProducto((int)CantidadPro);
                repositorio.Actualizar(producto);

            }else if(pico == 1)
            {
                cantidadPro = 0;
                removerProducto();
            }
           
        }

        private void removerProducto()
        {
            int i = 0;
            bool encontrado = false;
            while (i < dataGrid.Rows.Count && !encontrado)
            {

                if (dataGrid.Rows[i].Cells["ColProducto"].Value.ToString() == producto.Nombre)
                {
                    RepositorioDeProductos repositorio = new RepositorioDeProductos();
                    producto.Stock_actual = Convert.ToDecimal(txtCant.Text) + 1;
                    dataGrid.Rows.RemoveAt(i);
                    txtCant.Text = producto.Stock_actual.ToString();
                    encontrado = true;
                    repositorio.Actualizar(producto);
                }
                else
                {
                    i++;
                }

            }
        }
    }
}
