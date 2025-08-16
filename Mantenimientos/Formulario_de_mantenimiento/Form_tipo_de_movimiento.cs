using ConsoleApp1;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class Form_tipo_de_movimiento : Form
    {
        public Form_tipo_de_movimiento()
        {
            InitializeComponent();
        }

        //Constructor para actualizar
        public Form_tipo_de_movimiento(Mantenimiento_tipo_de_movimiento formPadre, tipo_movimiento tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.formPadre = formPadre;
            cargarComponentes();
            lblTitulo.Text = "Modificar Tipo de movimiento";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;
        }
        private Mantenimiento_tipo_de_movimiento formPadre;
        private tipo_movimiento tipo;

        //Constructor para agregar
        public Form_tipo_de_movimiento(Mantenimiento_tipo_de_movimiento formPadre)
        {
            InitializeComponent();

            this.formPadre = formPadre;
            lblTitulo.Text = "Agregar Tipo de movimiento";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
        }

        private void limpiar()
        {
            txtDescripcion.Text = "";
            btnSi.Checked = false;
            btnNo.Checked = false;
            btnInactivo.Checked = false;
            btnActivo.Checked = false;
        }

        private void cargarComponentes()
        {
            txtDescripcion.Text = tipo.Descripcion;
            if (tipo.Afecta_stock == 1)
            {
                btnSi.Checked = true;
            }
            else if (tipo.Afecta_stock == -1)
            {
                btnNo.Checked = true;
            }

            if (tipo.Estado)
            {
                btnActivo.Checked = true;
            }
            else
            {
                btnNo.Checked = false;
            }

        }

        private void Form_tipo_de_movimiento_Load(object sender, EventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            formPadre.actualizar();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private Repositorio_tipo_movimiento repositorio = new Repositorio_tipo_movimiento();
        private bool validarDescripcion()
        {
            if (tipo != null && repositorio.exisDescripcion(txtDescripcion.Text, tipo.Id))
            {
                MessageBox.Show(this, "La descripcion esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (tipo == null && repositorio.exisDescripcion(txtDescripcion.Text))
            {
                MessageBox.Show(this, "La descripcion esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool validar()
        {
            if (txtDescripcion.Text.Length > 0 && (btnSi.Checked || btnNo.Checked) && (btnActivo.Checked || btnInactivo.Checked))
            {
                return validarDescripcion();
            }
            else
            {
                MessageBox.Show(this, "Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        private void agregar()
        {
            tipo_movimiento tipo = new tipo_movimiento();
            tipo.Descripcion = txtDescripcion.Text;
            if (btnActivo.Checked) tipo.Estado = true;
            else tipo.Estado = false;
            if (btnSi.Checked) tipo.Afecta_stock = 1;
            else tipo.Afecta_stock = -1;

            repositorio.agregar(tipo);
            MessageBox.Show(this, "Inserccion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void modificar()
        {
            tipo.Descripcion = txtDescripcion.Text;
            if (btnActivo.Checked) tipo.Estado = true;
            else tipo.Estado = false;
            if (btnSi.Checked) tipo.Afecta_stock = 1;
            else tipo.Afecta_stock = -1;

            repositorio.Actualizar(tipo);
            MessageBox.Show(this, "Actualziacio exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.formPadre.actualizar();
                    this.Close();
                }

            }
        }
    }
}
