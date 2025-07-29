using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        public FormCliente(MantenimientoClientes mantenimiento)
        {
            InitializeComponent();
            this.mantenimiento = mantenimiento;
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            btnProceso.Text = "Agregar";
            lblTitulo.Text = "Agregar Cliente";

            foreach (Condicion c in repositorioCondicion.obtenerCondicionesPorEstado(true)) 
            {
                combo.Items.Add(c.Descripcion);              
            }

            combo.SelectedIndex = 0;

        }

        private RepositorioCondicion repositorioCondicion = new RepositorioCondicion();
        private Cliente cliente;
        public FormCliente(MantenimientoClientes mantenimiento, Cliente cliente)
        {
            this.cliente = cliente;
            InitializeComponent();
            this.mantenimiento = mantenimiento;
            lblTitulo.Text = "Modificar Cliente";
            txtNombre.Text = cliente.Nombre;
            txtDireccion.Text = cliente.Direccion;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            if (cliente.Estado)
            {
                btnActivo.Checked= true;
            }
            else
            {
                btnInactivo.Checked = true;
            }
           
            foreach(Condicion c in repositorioCondicion.ObtenerDatos())
            {
                combo.Items.Add(c.Descripcion);
                if (cliente.Id_condicion == c.Id)
                {
                    combo.SelectedIndex = combo.Items.Count - 1;

                }
            }
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;

            

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private bool validarEmail()
        {
            string email = txtEmail.Text.Trim();

            if (!email.Contains("@"))
            {
                MessageBox.Show(this, "El email necesita una @", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!email.Contains("."))
            {
                MessageBox.Show(this, "El email necesita un .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int posArroba = email.IndexOf("@");
            int posPunto = email.LastIndexOf(".");

            // Validar que @ esté antes que . y que no estén al inicio/final
            if (posArroba > posPunto || posArroba == 0 || posPunto == email.Length - 1)
            {
                MessageBox.Show(this, "Formato de email inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que haya al menos un carácter entre @ y .
            if ((posPunto - posArroba) <= 1)
            {
                MessageBox.Show(this, "El email debe tener un dominio como '@example.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

    
          

            return true; // Todo válido
        }



        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void FormCliente_Load(object sender, EventArgs e)
        {

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
            mantenimiento.actualizarDatagrid();
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private bool validarTelefono()
        {
          
                if(txtTelefono.Text.Length > 8)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, "El numero de telefono es muy corto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
               
            
        }

        private bool validarCampos()
        {
            if (validarEmail() && validarTelefono())
            {
                if (btnActivo.Checked || btnInactivo.Checked)
                {
                    if (txtNombre.Text.Length > 0 && txtDireccion.Text.Length > 0 && txtEmail.Text.Length > 0 && txtTelefono.Text.Length > 0)
                    {
                        return true;                   
                    }
                    else
                    {
                        MessageBox.Show(this, "Error debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Error debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false ;
                }

            }
            return false;
        }

        private void agregarCliente()
        {
            Cliente cliente1 = new Cliente();
            cliente1.Nombre = txtNombre.Text;
            cliente1.Direccion = txtDireccion.Text;
            cliente1.Email = txtEmail.Text;
            cliente1.Telefono = txtTelefono.Text;
            if (btnActivo.Checked)
            {
                cliente1.Estado = true;
            }
            else
            {
                cliente1.Estado = false;
            }
            cliente1.Id_condicion = combo.SelectedIndex + 1;
            RepositorioDeCliente repositorio = new RepositorioDeCliente();
            try
            {
                repositorio.agregar(cliente1);
                MessageBox.Show(this, "Insercion Exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }catch (SqlException ex)
           {
                MessageBox.Show(this,$"El correo ya esta en uso {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

        }

        MantenimientoClientes mantenimiento;
        private void modificarCliente()
        {
            cliente.Nombre = txtNombre.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefono = txtTelefono.Text;
            if (btnActivo.Checked)
            {
                cliente.Estado = true;
            }
            else
            {
                cliente.Estado = false;
            }
            cliente.Id_condicion = combo.SelectedIndex + 1;
            RepositorioDeCliente repositorio = new RepositorioDeCliente();
            try
            {
                repositorio.Actualizar(cliente);
                MessageBox.Show(this, "Insercion Exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                mantenimiento.actualizarDatagrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, $"El correo ya esta en uso {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        

        }


        private void limpiar()
        {
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            btnActivo.Checked = false;
            btnInactivo.Checked = false;
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {

            bool camposValidos = validarCampos();

            if( btnProceso.Text == "Agregar" && camposValidos)
            {
                agregarCliente();
                limpiar();
            }
            else if(btnProceso.Text == "Actualizar" && camposValidos)
            {
                modificarCliente();

            }
            
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
