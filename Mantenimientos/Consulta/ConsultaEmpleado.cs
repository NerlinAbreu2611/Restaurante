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

namespace Mantenimientos.Consulta
{
    public partial class ConsultaEmpleado : Form
    {
        public ConsultaEmpleado()
        {
            InitializeComponent();
        }

        private void ConsultaEmpleado_Load(object sender, EventArgs e)
        {
            RepositorioDeEmpleado repo = new RepositorioDeEmpleado();
            cargarDatagrid(repo.ObtenerPorEstado(true));
        }
        RepositorioCondicion condiciones = new RepositorioCondicion();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private Empleado empleado;

        public Empleado Empleado { get => empleado; set => empleado = value; }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                RepositorioDeEmpleado repositorio = new RepositorioDeEmpleado();    
                string nombre = dataGrid.Rows[e.RowIndex].Cells["ColNombre"].Value.ToString();
                empleado = repositorio.filtrarPorNombreYApellido(nombre)[0];
                if (nombre != null) {
                this.Close();
                }
            }
        }


        
        private void cargarDatagrid(List<Empleado>  empleados)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            dataGrid.RowHeadersVisible = false;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGrid.Columns.Add("ColNombre", "Nombre");
            dataGrid.Columns.Add("colApellido", "Apellido");
          
            List<Condicion> list = condiciones.ObtenerDatos();

            foreach (Empleado empleado in empleados)
            {
                dataGrid.Rows.Add(empleado.Nombre, empleado.Apellido);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_MouseDown(object sender, MouseEventArgs e)
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            RepositorioDeEmpleado repositorio = new RepositorioDeEmpleado();
            cargarDatagrid(repositorio.filtrarPorNombreApellidoYEstado(txtBusqueda.Text, true));
        }
    }
}
