using ConsoleApp1;
using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class FormEmpleado : Form
    {
        public FormEmpleado()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private MantenimientoEmpleado formPadre;
        private Empleado emp;
        //Para actualizar 


        private bool validarCampos()
        {
            if (txtNombre.Text.Length == 0)
            {
                MessageBox.Show(this, "Debe ingresar el nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            if (txtApellido.Text.Length == 0)
            {
                MessageBox.Show(this, "Debe ingresar el apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            if (txtClave.Text.Length == 0)
            {
                MessageBox.Show(this, "Debe ingresar la clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show(this, "Debe Ingresar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }


        public FormEmpleado(MantenimientoEmpleado formPadre)
        {
            InitializeComponent();
            this.formPadre = formPadre;
            lblTitulo.Text = "Agregar Empleado";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
        }



        //para modificar
        public FormEmpleado(Empleado emp, MantenimientoEmpleado formPadre)
        {
            InitializeComponent();
            this.emp = emp;
            this.formPadre = formPadre;
            lblTitulo.Text = "Modificar Empleado";
            cargarCampos();


            btnProceso.Text = "Modificar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;

        }

        private void cargarCampos()
        {
            txtNombre.Text = emp.Nombre;
            txtApellido.Text = emp.Apellido;
            txtClave.Text = emp.Clave;
            txtUsuario.Text = emp.Usuario;
            if (emp.Estado)
            {
                btnActivo.Checked = true;

            }
            else
            {
                btnInactivo.Checked = true;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            formPadre.actualizarDataGrid();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        private void FormEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            txtApellido.Text = "";
            txtClave.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            btnActivo.Checked = false;
            btnInactivo.Checked = false;
        }

        private void modificarEmpleado()
        {
            emp.Nombre = txtNombre.Text;
            emp.Apellido = txtApellido.Text;
            emp.Clave = txtClave.Text;
            emp.Usuario = txtUsuario.Text;
            if (btnActivo.Checked) emp.Estado = true;
            else emp.Estado = false;

            if (repositorioDeEmpleado.Actualizar(emp))
            {
                MessageBox.Show(this, "Actualizacion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formPadre.actualizarDataGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Ocurrio un error en la insercion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cargarCampos();
            }

        }

        private RepositorioDeEmpleado repositorioDeEmpleado = new RepositorioDeEmpleado();

        private void agregarEmpleado()
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Clave = txtClave.Text;
            empleado.Usuario = txtUsuario.Text;
            if (btnActivo.Checked) empleado.Estado = true;
            else empleado.Estado = false;

            if (repositorioDeEmpleado.agregar(empleado))
            {
                MessageBox.Show(this, "Insercion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show(this, "Ocurrio un error al agregar el elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
        private void btnProceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    if (btnProceso.Text == "Modificar")
                    {
                        modificarEmpleado();
                    }
                    else if (btnProceso.Text == "Agregar")
                    {
                        agregarEmpleado();
                    }
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(this, "Este usuario ya esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
