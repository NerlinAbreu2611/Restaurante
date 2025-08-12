using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class FormCategoriaProducto : Form
    {
        public FormCategoriaProducto()
        {
            InitializeComponent();
            lblTitulo.Text = "Agregar Categoria";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
        }

        private CategoriaProducto categoria;
        
        //Constructor para agregar

        public FormCategoriaProducto(MantenimientoCategoriaProducto formPadre,CategoriaProducto categoria)
        {
            InitializeComponent (); 
            this.categoria = categoria; 
            this.formPadre = formPadre;
            cargarComponentes();
            lblTitulo.Text = "Modificar categoria";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;

        }

        public void cargarComponentes()
        {
            txtNombre.Text = categoria.Nombre;
            if (categoria.Estado) btnActivo.Checked = true;
            else btnInactivo.Checked = true;
        }




        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        private void FormCategoriaProducto_Load(object sender, EventArgs e)
        {

        }
        
        private RepositorioCategoriaDeProducto repo = new RepositorioCategoriaDeProducto();
        private bool validar()
        {
            
            if (txtNombre.Text.Length > 0 && (btnActivo.Checked || btnInactivo.Checked))
            {
                if (categoria != null && repo.exisCategoria(txtNombre.Text,categoria.Id))
                {
                    MessageBox.Show(this, "Error, esta categoria ya existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if(categoria == null && repo.exisCategoria(txtNombre.Text))
                {
                    MessageBox.Show(this, "Error, esta categoria ya existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }

            MessageBox.Show(this, "Error, debe llenar todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private MantenimientoCategoriaProducto formPadre = new MantenimientoCategoriaProducto();

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void agregar()
        {
            CategoriaProducto c = new CategoriaProducto();
            c.Nombre = txtNombre.Text;
            if(btnActivo.Checked)c.Estado = true;
            else c.Estado = false;
            if (repo.agregar(c))
            {
                MessageBox.Show(this, "Insercion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            btnActivo.Checked = false;
            btnInactivo.Checked = false;
        }
        private void modificar()
        {
            categoria.Nombre = txtNombre.Text;
            if (btnActivo.Checked) categoria.Estado = true;
            else categoria.Estado = false;

            if (repo.Actualizar(categoria))
            {
                MessageBox.Show(this, "Actualizacion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }


        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if(btnProceso.Text == "Agregar")
                {
                    agregar();
                }
                else
                {
                    modificar();
                }
            }
        }
    }
}
