using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mantenimientos.Consulta
{
    public partial class ConsultaProveedor : Form
    {
        public ConsultaProveedor()
        {
            InitializeComponent();

            cargarDataGrid(repositorio.listarPorEstado(true));
        }

        private RepositorioDeProveedor repositorio = new RepositorioDeProveedor();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void ConsultaProveedor_Load(object sender, EventArgs e)
        {

        }

        private Proveedor proveedor;

        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }

        private void cargarDataGrid(List<Proveedor> proveedors)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            dataGrid.RowHeadersVisible = false;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black;

            dataGrid.Columns.Add("ColId", "Id");
            dataGrid.Columns.Add("ColNombre", "Nombre");
            dataGrid.Columns.Add("ColTelefono", "Telefono");
            dataGrid.Columns.Add("ColEmail", "Email");
            dataGrid.Columns.Add("ColDirrecion", "Direccion");
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewImageColumn imgEstado = new DataGridViewImageColumn();
            imgEstado.Name = "colEstado";
            imgEstado.HeaderText = "Estado";
            dataGrid.Columns.Add(imgEstado);

            foreach (Proveedor p in proveedors)
            {
                dataGrid.Rows.Add(p.Id, p.Nombre, p.Telefono, p.Email, p.Direccion, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cargarDataGrid(repositorio.listarPorNombreYEstado(textBox1.Text, true));
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                int id = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["colId"].Value);
                this.proveedor = repositorio.buscarId(id);

                if (proveedor != null)
                {
                    this.Close();
                }


            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
