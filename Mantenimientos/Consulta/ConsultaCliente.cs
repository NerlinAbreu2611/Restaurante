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
    public partial class ConsultaCliente : Form
    {
        public ConsultaCliente()
        {
            InitializeComponent();
            cargarDatagrid(repositorio.filtrarActivos());   
        }



        private void ConsultaCliente_Load(object sender, EventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void label1_Click(object sender, EventArgs e)
        {

        }

        RepositorioCondicion condiciones = new RepositorioCondicion();
        RepositorioDeCliente cliente = new RepositorioDeCliente();
        public void cargarDatagrid(List<Cliente> clientes)
        {
            dataGrid.Rows.Clear();  
            dataGrid.Columns.Clear();
            dataGrid.RowHeadersVisible = false;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGrid.Columns.Add("ColCliente", "Cliente");
            dataGrid.Columns.Add("colTelefono", "Telefono");
            dataGrid.Columns.Add("ColEmail", "Email");
            dataGrid.Columns.Add("ColDireccion", "Direccion");
            dataGrid.Columns.Add("ColCondicion", "Condicion");

            List<Condicion> list = condiciones.ObtenerDatos();

            foreach (Cliente cliente in clientes) 
            { 
                
                Condicion c = list.Where(x => x.Id == cliente.Id_condicion).FirstOrDefault();
            
                dataGrid.Rows.Add(cliente.Nombre,cliente.Telefono,cliente.Email,cliente.Direccion,c.Descripcion);
            }
        }

        RepositorioDeCliente repositorio = new RepositorioDeCliente();  
        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatagrid(repositorio.filtrarPorNombreActivo(txtBusqueda.Text));
        }

        private Cliente c;

        public Cliente C { get => c; set => c = value; }
        public Condicion Con { get => con; set => con = value; }

        private Condicion con;

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombre = dataGrid.Rows[e.RowIndex].Cells["ColCliente"].Value.ToString();

               c = repositorio.filtrarPorNombre(nombre)[0];

                if (c != null) {

                    con = condiciones.buscarPorId(c.Id_condicion);

                    this.Close();

                
                }


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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarDatagrid(repositorio.filtrarPorNombreActivo(txtBusqueda.Text));
        }
    }
}
