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
    public partial class FormProveedor : Form
    {
        public FormProveedor()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //Constructor para insertar
        public FormProveedor(MantenimientoProveedor formPadre)
        {
            InitializeComponent ();
            this.formPadre = formPadre;
            lblTitulo.Text = "Agregar Proveedor";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;

        }


        //Constructor para Actualizar

        public FormProveedor(MantenimientoProveedor formPadre,Proveedor proveedor)
        {
            InitializeComponent();
            this.formPadre = formPadre;
            this.proveedor = proveedor;
            lblTitulo.Text = "Actualizar Proveedor";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;
            inicializarControles();
        }


        private MantenimientoProveedor formPadre;
        private Proveedor proveedor = new Proveedor();
        private void inicializarControles()
        {
            txtNombre.Text = proveedor.Nombre;
            txtEmail.Text = proveedor.Email;
            txtDireccion.Text = proveedor.Direccion;  
            txtTelefono.Text = proveedor.Telefono;
            if (proveedor.Estado) btnActivo.Checked = true;
            else btnInactivo.Checked = true;
        }
        private void limpiar()
        {
           txtNombre.Clear();   
            txtEmail.Clear();
            txtDireccion.Clear();   
            txtTelefono.Clear();
            btnInactivo.Checked= false;
            btnActivo.Checked = false;
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
            this.formPadre.actualizar();
        }


        private bool validarEmail()
        {
            if (txtEmail.Text.Length > 3)
            {
                if (!txtEmail.Text.Contains("."))
                {
                    MessageBox.Show(this, "Error, el correo debe contener '.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (!txtEmail.Text.Contains('@'))
                {
                    MessageBox.Show(this, "Error, el correo debe contener '@'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txtEmail.Text.IndexOf(".") < txtEmail.Text.IndexOf("@"))
                {
                    MessageBox.Show(this, "Error, el formato del correo es invalido. EL '.' no puede estar antes que la '@'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtEmail.Text.IndexOf(".") - txtEmail.Text.IndexOf("@") <= 1)
                {
                    MessageBox.Show(this, "Error, no existe direccion de dominio.ejemplo '@gmail.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txtEmail.Text.Substring(txtEmail.Text.IndexOf(".")).Length <= 1)
                {
                    MessageBox.Show(this, "Error, el correo necesita una extension de dominio. ejemplo '.com' o '.do'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (contarCaracterEnCadena(txtEmail.Text, '@') > 1 || contarCaracterEnCadena(txtEmail.Text, '.') > 1)
                {
                    MessageBox.Show(this, "Error, el correo tiene mas de un '.' o '@'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (proveedor != null && re.exisEmail(proveedor.Id, txtEmail.Text))
                    {
                        MessageBox.Show(this, "Error, el correo ya esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (proveedor == null && re.exisEmail(txtEmail.Text))
                    {
                        MessageBox.Show(this, "Error, el correo ya esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }




            }
            MessageBox.Show(this, "Error, el correo es muy corto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        
        private bool validarCampos()
        {
            if(txtNombre.Text.Length > 0 && txtEmail.Text.Length > 0 && txtTelefono.Text.Length > 0 && (btnActivo.Checked || btnInactivo.Checked))
            {
                return validarEmail() && validarTelefono();
            }
            else
            {
                MessageBox.Show(this, "Debe completar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool validarTelefono()
        {
            txtTelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string telefono = txtTelefono.Text;

      
            if(telefono.Length == 10)
            {
                if (proveedor != null && re.exisTelefono(proveedor.Id, txtTelefono.Text)) 
                {

                    MessageBox.Show(this, "El numero de telefono esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }else if (proveedor == null && re.exisTelefono(telefono))
                {
                    MessageBox.Show(this, "El numero de telefono esta en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }


            }
                MessageBox.Show(this, "El numero de telefono esta incompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }

              


        private int contarCaracterEnCadena(String cadena,char letra)
        {
            int cont = 0;
            int i = 0;

            while (i < cadena.Length && cont <= 1)
            {
                if(cadena[i] == letra)
                {
                    cont++;
                }

                i++;
            }
            return cont;  
        }


        private RepositorioDeProveedor re = new RepositorioDeProveedor();
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {

        }


        private void agregar() 
        {
            Proveedor pro = new Proveedor();
            pro.Telefono = txtTelefono.Text;
            pro.Email = txtEmail.Text;
            pro.Estado = true;
            pro.Direccion = txtDireccion.Text;
            pro.Nombre = txtNombre.Text;

            if (re.agregar(pro))
            {
                MessageBox.Show(this, "Insercion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Ocurrio un error en la insercion", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }

        private void actualizar()
        {
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Nombre= txtNombre.Text;
            proveedor.Direccion= txtDireccion.Text;
            proveedor.Email= txtEmail.Text;
            if(btnActivo.Checked) proveedor.Estado = true;
            else proveedor.Estado = false;

            if (re.Actualizar(proveedor))
            {
                MessageBox.Show(this, "Actualizacion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.formPadre.actualizar();
                this.Close();

            }
            else
            {
                MessageBox.Show(this, "Ocurrio un error en la actualizacion", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if(btnProceso.Text == "Actualizar")
                {
                    actualizar();
                }
                else
                {
                    agregar();
                    limpiar();
                }
       
            }
        }
    }
}
