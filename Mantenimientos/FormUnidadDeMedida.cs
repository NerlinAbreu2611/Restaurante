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
    public partial class FormUnidadDeMedida : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public FormUnidadDeMedida()
        {
            InitializeComponent();
            lblTitulo.Text = "Agregar Unidad de Medida";
            btnProceso.Text = "Agregar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
        }

        Repositorio_de_unidad_de_medida repo = new Repositorio_de_unidad_de_medida();
        private bool validar()
        {
            if(txtNombre.Text.Length > 0 && (btnActivo.Checked || btnInactivo.Checked))
            {
                if (unidad != null && repo.exisUnidad(txtNombre.Text, unidad.Id)){
                    MessageBox.Show(this, "Error, el nombre ya esta en uso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }else if(unidad == null && repo.exisUnidad(txtNombre.Text))
                {
                    MessageBox.Show(this, "Error, el nombre ya esta en uso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            MessageBox.Show(this,"Error,debe llenar los campos","",MessageBoxButtons.OK,MessageBoxIcon.Error);  
            return false;
           

        }

        private MantenimientoUnidadDeMedida formPadre;
        private Unidades_de_medida unidad;

        //Constructor de actualizacion
        public FormUnidadDeMedida(MantenimientoUnidadDeMedida formPadre, Unidades_de_medida unidad)
        {
            InitializeComponent ();
            this.formPadre = formPadre;
            this.unidad = unidad;
            lblTitulo.Text = "Modificar Unidad de Medida";
            btnProceso.Text = "Actualizar";
            btnProceso.IconChar = FontAwesome.Sharp.IconChar.Pen;


            cargarDatos();
        }

        
        private void cargarDatos()
        {
             txtNombre.Text = unidad.Nombre;
             if(unidad.Estado) btnActivo.Checked= true;
             else btnInactivo.Checked = true;
        }




        private void FormUnidadDeMedida_Load(object sender, EventArgs e)
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
            this.Close();
        }

        private void agregar()
        {
            Unidades_de_medida uni = new Unidades_de_medida();
            uni.Nombre = txtNombre.Text;
            if (btnActivo.Checked) uni.Estado = true;
            else uni.Estado = false;

            if (repo.agregar(uni))
            {
                MessageBox.Show(this,"Insercion exitosa","",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this,"Ocurrio un error","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void actualizar()
        {
            unidad.Nombre = txtNombre.Text;
            if(btnActivo.Checked) unidad.Estado = true;
            else unidad.Estado = false;

            if (repo.Actualizar(unidad))
            {
                MessageBox.Show(this, "Actualizacion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Ocurrio un error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void limpiar()
        {
            txtNombre.Text = "";
            btnActivo.Checked = false;
            btnInactivo.Checked = false;
            
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
                    actualizar();
                }
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
