using ConsoleApp1;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class FormMetPago : Form
    {
        public FormMetPago()
        {
            InitializeComponent();
        }



        private MantenimientoMetodoDePago formPadre;
        private MetodoDePago metodoDePago;

        //constructor para Modificar
        public FormMetPago(MetodoDePago metodoDePago, MantenimientoMetodoDePago formPadre)
        {
            InitializeComponent();
            this.formPadre = formPadre;
            this.metodoDePago = metodoDePago;

            lblTitulo.Text = "Modificar Metodo de Pago";
            btnProceso.Text = "Modificar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;

            txtDesc.Text = metodoDePago.Descripcion;
            if (metodoDePago.Estado) btnActivo.Checked = true;
            else btnInactivo.Checked = true;


        }

        //constructor para agregar
        public FormMetPago(MantenimientoMetodoDePago metodoDePago)
        {
            InitializeComponent();

            formPadre = metodoDePago;

            lblTitulo.Text = "Agregar Metodo de Pago";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
        }

        private void limpiar()
        {
            txtDesc.Clear();
            btnActivo.Checked = false;
            btnInactivo.Checked = false;
        }
        private bool validar()
        {
            if (txtDesc.Text.Length < 1)
            {
                MessageBox.Show(this, "Debe ingresar la descripcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!btnActivo.Checked && !btnInactivo.Checked)
            {
                MessageBox.Show(this, "Debe seleccionar una opcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void FormMetPago_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.formPadre.actualizarFormulario();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (btnProceso.Text == "Modificar")
                {
                    modificar();
                }
                else if (btnProceso.Text == "Agregar")
                {
                    agregar();
                }
            }
        }

        private void agregar()
        {
            try
            {
                MetodoDePago met = new MetodoDePago();
                met.Descripcion = txtDesc.Text;
                if (btnActivo.Checked) met.Estado = true;
                else btnInactivo.Checked = false;
                RepositorioDeMetodoDePago repositorio = new RepositorioDeMetodoDePago();
                repositorio.agregar(met);
                MessageBox.Show(this, $"Insercion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, $"Ocurrio un error de {ex.Number}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void modificar()
        {
            try
            {
                metodoDePago.Descripcion = txtDesc.Text;
                if (btnActivo.Checked) metodoDePago.Estado = true;
                else metodoDePago.Estado = false;
                RepositorioDeMetodoDePago repositorio = new RepositorioDeMetodoDePago();
                repositorio.Actualizar(metodoDePago);
                MessageBox.Show(this, $"Modificacion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.formPadre.actualizarFormulario();
                this.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, $"Ocurrio un error de {ex.Number}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
    }
}
