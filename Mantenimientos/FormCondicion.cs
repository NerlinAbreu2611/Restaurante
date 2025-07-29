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
    public partial class FormCondicion : Form
    {
        public FormCondicion()
        {
            InitializeComponent();
        }

        //Para actualizaciones
        private Condicion condicion;
        private MantenimientoCondicion Mantenimiento;
        public FormCondicion(Condicion condicion, MantenimientoCondicion mantenimiento)
        {
            InitializeComponent();
            this.condicion = condicion;
            this.Mantenimiento = mantenimiento;
            rollBack();

        }

        private void rollBack()
        {
            
            txtDescripcion.Text = condicion.Descripcion;
            txtDiasDeCredito.Text = condicion.DiasDeCredito + "";
            if (condicion.Estado) btnActivo.Checked = true;
            else btnInactivo.Checked = true;
            if (condicion.DiasDeCredito > 0) btnSi.Checked = true;
            else btnNo.Checked = true;
            lblTitulo.Text = "Modificar Condicion";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;
         

        }


        //Para agregar
        public FormCondicion(MantenimientoCondicion mantenimiento)
        {
            InitializeComponent();
         
          
            lblTitulo.Text = "Agregar Condicion";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            this.Mantenimiento = mantenimiento;

        }

        private void btnSi_CheckedChanged(object sender, EventArgs e)
        {
            txtDiasDeCredito.Enabled = true;
        }

        private void validarCampos()
        {

        }

        private void limpiar()
        {
            txtDiasDeCredito.Text = "";
            txtDescripcion.Text = "";
            btnActivo.Checked = false;
            btnInactivo.Checked = false;
            btnSi.Checked = false;
            btnNo.Checked = false;
        }

        private bool validar()
        {
            if (btnActivo.Checked || btnInactivo.Checked) 
            {
                if (txtDescripcion.Text.Length > 0)
                {
                    if (btnSi.Checked)
                    {
                        if (txtDiasDeCredito.Text.Length > 0)
                        {
                            
                            return true;
                        }
                    }
                    else if (btnNo.Checked) 
                    {
                        return true;
                    }
                }

            }
            

            return false;

        }
        private void btnNo_CheckedChanged(object sender, EventArgs e)
        {
            txtDiasDeCredito.Enabled = false;
            txtDiasDeCredito.Text = "";
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
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
            Mantenimiento.actualizarDatagrid();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private RepositorioCondicion repositorio = new RepositorioCondicion();  
        private void Actualizar()
        {
            condicion.Descripcion = txtDescripcion.Text;
            if (btnNo.Checked) { condicion.DiasDeCredito = 0; condicion.EsAutopago = true; }
            else { condicion.DiasDeCredito = Convert.ToInt32(txtDiasDeCredito.Text); condicion.EsAutopago = false; }
            if (btnActivo.Checked) condicion.Estado = true;
            else condicion.Estado = false;

            if (repositorio.Actualizar(condicion))
            {
                MessageBox.Show(this, "Actualizacion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            this.Close();
            this.Mantenimiento.actualizarDatagrid();
        }

        private void agregar()
        {
            Condicion con = new Condicion();
            con.Descripcion = txtDescripcion.Text;
            if (btnNo.Checked) { con.DiasDeCredito = 0; con.EsAutopago = true; }
            else { con.DiasDeCredito = Convert.ToInt32(txtDiasDeCredito.Text); con.EsAutopago = false; }
            if (btnActivo.Checked) con.Estado = true;
            else con.Estado = false;

            if (repositorio.agregar(con))
            {
                MessageBox.Show(this, "Insercion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiar();
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            if (validar())
            {
              if(btnProceso.Text == "Agregar")
                {
                    agregar();
                }else if(btnProceso.Text == "Actualizar")
                {
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show(this, "Debe llenar todos los campos necesarios", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rollBack();
            }
        }

        private void FormCondicion_Load(object sender, EventArgs e)
        {

        }

        private void FormCondicion_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
