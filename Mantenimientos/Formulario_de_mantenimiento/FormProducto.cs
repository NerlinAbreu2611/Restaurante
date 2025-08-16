using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
            cargarComponentes();
            lblTitulo.Text = "Agregar Producto";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private RepositorioDeProductos repositorio = new RepositorioDeProductos();
        private Repositorio_de_unidad_de_medida unidadesDeMedida = new Repositorio_de_unidad_de_medida();
        private RepositorioCategoriaDeProducto categoriasDeProdutos = new RepositorioCategoriaDeProducto();
        private void FormProducto_Load(object sender, EventArgs e)
        {


        }






        //Constructor para actualizar

        private Producto producto;
        public FormProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
            cargarComponentes();
            cargarDatos();
            lblTitulo.Text = "Modificar Producto";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;

        }

        private void cargarComponentes()
        {

            List<CategoriaProducto> categorias = categoriasDeProdutos.ObtenerDatos();
            List<Unidades_de_medida> unidades = unidadesDeMedida.ObtenerDatos();

            foreach (CategoriaProducto c in categorias)
            {
                comboCategoria.Items.Add(c.Nombre);
            }
            foreach (Unidades_de_medida u in unidades)
            {
                comboUnidad.Items.Add(u.Nombre);
            }

            comboCategoria.SelectedIndex = 0;
            comboUnidad.SelectedIndex = 0;
            imgProducto.LoadAsync("C:\\Users\\elmen\\Desktop\\imagenes\\no-fotos.png");
            imgProducto.SizeMode = PictureBoxSizeMode.Zoom;


        }

        private void cargarDatos()
        {
            txtNombre.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            Unidades_de_medida uni = unidadesDeMedida.buscar_por_id(producto.Id_unidad);
            CategoriaProducto cat = categoriasDeProdutos.buscarPorId(producto.Id_categoria ?? 0);

            bool encontrado = false; int i = 0;
            while (!encontrado)
            {
                if (comboCategoria.Items[i].ToString() == cat.Nombre)
                {
                    comboCategoria.SelectedIndex = i;
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }
            encontrado = false; i = 0;
            while (!encontrado)
            {
                if (comboUnidad.Items[i].ToString() == uni.Nombre)
                {
                    comboUnidad.SelectedIndex = i;
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }

            txtStockActual.Text = producto.Stock_actual + "";
            txtStockMinimo.Text = producto.Stock_minimo + "";
            txtCosto.Text = producto.Precio_costo + "";
            txtVenta.Text = producto.Precio_venta + "";
            if (producto.Estado) btnActivo.Checked = true;
            else btnInactivo.Checked = true;
            if (producto.Url_imagen.Length != 0)
            {
                imgProducto.LoadAsync(producto.Url_imagen);
                imgProducto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private bool validarNombre()
        {
            if (producto != null && repositorio.existProducto(txtNombre.Text, producto.Id_producto))
            {
                MessageBox.Show(this, "Error,el nombre ya esta en uso", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
            else if (producto == null && repositorio.existProducto(txtNombre.Text))
            {
                MessageBox.Show(this, "Error,el nombre ya esta en uso", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
            return true;
        }

        private bool validar()
        {
            if (txtNombre.Text.Length > 0 &&
                txtDescripcion.Text.Length > 0 &&
                 txtStockActual.Text.Length > 0 &&
                  txtStockMinimo.Text.Length > 0 &&
                   txtCosto.Text.Length > 0 &&
                    txtVenta.Text.Length > 0 &&
                     (btnActivo.Checked || btnInactivo.Checked))
            {

                return validarNombre();

            }
            MessageBox.Show(this, "Error,Debe llenar todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            return false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private string urlImg = "";

        private void btnAnexarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Seleccionar imagen del producto";
            openFileDialog.InitialDirectory = "C:\\Users\\elmen\\Desktop\\imagenes";
            openFileDialog.Filter = "Imágenes (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgProducto.LoadAsync(openFileDialog.FileName);
                imgProducto.SizeMode = PictureBoxSizeMode.Zoom;
                urlImg = openFileDialog.FileName;
            }

        }

        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de retroceso
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir un solo punto decimal y que no esté al inicio
            if (e.KeyChar == '.')
            {
                if (txtStockActual.Text.Contains(".") || txtStockActual.SelectionStart == 0)
                {
                    e.Handled = true; // Bloquear
                }
                return;
            }

            // Bloquear cualquier otra cosa
            e.Handled = true;
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de retroceso
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir un solo punto decimal y que no esté al inicio
            if (e.KeyChar == '.')
            {
                if (txtCosto.Text.Contains(".") || txtCosto.SelectionStart == 0)
                {
                    e.Handled = true; // Bloquear
                }
                return;
            }

            // Bloquear cualquier otra cosa
            e.Handled = true;
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de retroceso
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir un solo punto decimal y que no esté al inicio
            if (e.KeyChar == '.')
            {
                if (txtVenta.Text.Contains(".") || txtVenta.SelectionStart == 0)
                {
                    e.Handled = true; // Bloquear
                }
                return;
            }

            // Bloquear cualquier otra cosa
            e.Handled = true;
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir tecla de retroceso
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir un solo punto decimal y que no esté al inicio
            if (e.KeyChar == '.')
            {
                if (txtStockMinimo.Text.Contains(".") || txtStockMinimo.SelectionStart == 0)
                {
                    e.Handled = true; // Bloquear
                }
                return;
            }

            // Bloquear cualquier otra cosa
            e.Handled = true;
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (btnProceso.Text == "Agregar")
                {
                    agregar();
                    limpiar();
                }
                else
                {
                    modificar();
                }

            }
        }

        private void agregar()
        {
            Producto pro = new Producto();
            pro.Nombre = txtNombre.Text;
            pro.Descripcion = txtDescripcion.Text;
            List<CategoriaProducto> categorias = categoriasDeProdutos.ObtenerDatos();
            bool encontrado = false; int i = 0;
            while (!encontrado)
            {
                if (comboCategoria.Items[i].ToString() == categorias[i].Nombre)
                {
                    encontrado = true;
                    pro.Id_categoria = categorias[i].Id;
                }
                else
                {
                    i++;
                }
            }
            i = 0; encontrado = false;
            List<Unidades_de_medida> unidades = unidadesDeMedida.ObtenerDatos();
            while (!encontrado)
            {
                if (comboUnidad.Items[i].ToString() == unidades[i].Nombre)
                {
                    encontrado = true;
                    pro.Id_unidad = unidades[i].Id;
                }
                else
                {
                    i++;
                }
            }

            pro.Stock_actual = Convert.ToDecimal(txtStockActual.Text);
            pro.Stock_minimo = Convert.ToDecimal(txtStockMinimo.Text);
            pro.Precio_costo = Convert.ToDecimal(txtCosto.Text);
            pro.Precio_venta = Convert.ToDecimal(txtVenta.Text);
            if (btnActivo.Checked == true) pro.Estado = true;
            else pro.Estado = false;
            pro.Url_imagen = urlImg;

            if (repositorio.agregar(pro))
            {
                MessageBox.Show(this, "Insercion Exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            comboCategoria.SelectedIndex = 0;
            comboUnidad.SelectedIndex = 0;
            txtStockActual.Text = "";
            txtStockMinimo.Text = "";
            txtVenta.Text = "";
            txtCosto.Text = "";

            btnActivo.Checked = false;
            btnInactivo.Checked = false;
            imgProducto.LoadAsync("C:\\Users\\elmen\\Desktop\\imagenes\\no-fotos.png");
            imgProducto.SizeMode = PictureBoxSizeMode.Zoom;
            urlImg = "";
        }

        private void modificar()
        {

            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            List<CategoriaProducto> categorias = categoriasDeProdutos.ObtenerDatos();
            bool encontrado = false; int i = 0;
            while (!encontrado)
            {
                String campo = comboCategoria.SelectedItem.ToString();
                if (campo == categorias[i].Nombre)
                {
                    encontrado = true;
                    producto.Id_categoria = categorias[i].Id;
                }
                else
                {
                    i++;
                }
            }
            i = 0; encontrado = false;
            List<Unidades_de_medida> unidades = unidadesDeMedida.ObtenerDatos();
            while (!encontrado)
            {
                if (comboUnidad.SelectedItem.ToString() == unidades[i].Nombre)
                {
                    encontrado = true;
                    producto.Id_unidad = unidades[i].Id;
                }
                else
                {
                    i++;
                }
            }

            producto.Stock_actual = Convert.ToDecimal(txtStockActual.Text);
            producto.Stock_minimo = Convert.ToDecimal(txtStockMinimo.Text);
            producto.Precio_costo = Convert.ToDecimal(txtCosto.Text);
            producto.Precio_venta = Convert.ToDecimal(txtVenta.Text);
            if (btnActivo.Checked == true) producto.Estado = true;
            else producto.Estado = false;
            producto.Url_imagen = urlImg;

            if (repositorio.Actualizar(producto))
            {
                MessageBox.Show(this, "Actualizacion Exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


    }
}
