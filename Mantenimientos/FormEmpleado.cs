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
                return false ;
            }
            if(txtUsuario.Text.Length == 0) 
            {
                MessageBox.Show(this, "Debe Ingresar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public FormEmpleado(Empleado emp,MantenimientoEmpleado formPadre)
        {
            InitializeComponent();
            this.emp = emp;
            this.formPadre = formPadre;
            lblTitulo.Text = "Modificar Empleado";

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

            btnProceso.Text = "Modificar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;
        
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void agregarEmpleado()
        {
            emp.Apellido = txtApellido.Text;
            emp.Clave = txtClave.Text;  
            emp.Usuario = txtUsuario.Text;
            
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {          
            if (validarCampos())
            {
                if(btnProceso.Text == "Modificar")
                {

                }else if(btnProceso.Text == "Agregar")
                {

                }
            }
        }
    }
}
