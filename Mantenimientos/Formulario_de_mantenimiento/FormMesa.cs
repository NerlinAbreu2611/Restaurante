using ConsoleApp1;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class FormMesa : Form
    {
        public FormMesa()
        {
            InitializeComponent();
        }
        //Constructor para ingresar valores
        public FormMesa(MantenimientoMesas padre)
        {
            InitializeComponent();
            this.padre = padre;
            lblTitulo.Text = "Insertar Mesa";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            this.m = new Mesa();
        }
        //Constructor para actualizar la mesa

        private Mesa m;
        private MantenimientoMesas padre;
        public FormMesa(MantenimientoMesas padre, Mesa mesa)
        {
            InitializeComponent();
            this.padre = padre;
            lblTitulo.Text = "Modificar Mesa";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;
            //Establecer componentes
            txtAsiento.Text = "" + mesa.Asientos;
            txtDesc.Text = mesa.Descripcion;
            dateTimePicker.Value = mesa.Fecha;
            if (mesa.Estado)
            {
                btnActivo.Checked = true;
            }
            else
            {
                btnInactivo.Checked = true;
            }

            m = mesa;

        }

        public bool validarCampos()
        {
            try
            {
                int num = Convert.ToInt32(txtAsiento.Text);

                if (num > 0 && num <= 14)
                {
                    if (btnActivo.Checked || btnInactivo.Checked)
                    {
                        if (txtDesc.Text.Length > 0)
                        {
                            return true;
                        }
                        MessageBox.Show("Error, la descripcion de la mesa es obligatoria");
                        return false;
                    }
                    MessageBox.Show("Error, estado no seleccionado");
                    return false;
                }
                MessageBox.Show("Error,sillas fuera del rango aceptado");
                txtAsiento.Text = "";
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error porque: {ex.Message}");
                txtAsiento.Text = "";
                return false;
            }



            return false;

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            padre.actualizarFormulario();
            this.Close();
        }
        RepositorioDeMesa repositorio = new RepositorioDeMesa();
        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (btnProceso.Text == "Agregar")
                {
                    agregarMesa();
                }
                else
                {
                    actualizarMesa();
                }

            }

        }

        private void limpiarComponentes()
        {
            txtAsiento.Text = "";
            txtDesc.Text = "";
            btnInactivo.Checked = false;
            btnActivo.Checked = false;
            dateTimePicker.Value = DateTime.Now;
        }

        private void agregarMesa()
        {
            if (btnActivo.Checked) { m.Estado = true; }
            else { m.Estado = false; }
            m.Descripcion = txtDesc.Text;
            m.Asientos = Convert.ToInt32(txtAsiento.Text);
            m.Fecha = dateTimePicker.Value;
            if (repositorio.agregar(m))
            {
                MessageBox.Show("Insercion exitosa");
                limpiarComponentes();
            }

        }


        private void actualizarMesa()
        {
            if (btnActivo.Checked) { m.Estado = true; }
            else { m.Estado = false; }
            m.Descripcion = txtDesc.Text;
            m.Asientos = Convert.ToInt32(txtAsiento.Text);
            m.Fecha = dateTimePicker.Value;
            repositorio.Actualizar(m);
            MessageBox.Show("Actualizacion exitosa");
            padre.actualizarFormulario();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMesa_Load(object sender, EventArgs e)
        {

        }
    }
}
