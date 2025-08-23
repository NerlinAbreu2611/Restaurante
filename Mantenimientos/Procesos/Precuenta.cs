using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Mantenimientos.Procesos
{
    public partial class Precuenta : Form
    {
        public Precuenta()
        {
            InitializeComponent();
        }

        private Mesa mesa;
        private DataGridView dataGridView;
        private Empleado empleado;
        private Cliente cliente;
       

        public Mesa Mesa { get => mesa; set => mesa = value; }
        public DataGridView DataGridView { get => dataGridView; set => dataGridView = value; }
        public Empleado Empleado { get => empleado; set => empleado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public decimal Total { get => total; set => total = value; }

        private decimal total;

        private void Precuenta_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Mesa no.{mesa.Id}";
            txtCliente.Text = cliente.Nombre;
            txtEmpleado.Text = empleado.Nombre;
            txtFecha.Text = DateTime.Now.ToString("mm/dd/yyyy");
            RepositorioCondicion repositorio = new RepositorioCondicion();
            Condicion condicion = repositorio.buscarPorId(cliente.Id_condicion);
            txtCondicion.Text = condicion.Descripcion;
            txtTotal.Text = total.ToString("c");
           
            cargarDataGrid();
            dataGridView1.ClearSelection();
        }

        private void cargarDataGrid()
        {
            int i = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                i++;
                decimal importe = Convert.ToDecimal(row.Cells["ColCantidad"].Value) * Convert.ToDecimal(row.Cells["ColPrecio"].Value);
                dataGridView1.Rows.Add(i, row.Cells["ColProducto"].Value, row.Cells["ColCantidad"].Value, row.Cells["ColPrecio"].Value,importe);    
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
