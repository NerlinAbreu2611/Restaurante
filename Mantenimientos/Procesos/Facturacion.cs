using ConsoleApp1;
using ConsoleApp1.Modelo;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Mantenimientos.Procesos
{
    public partial class Facturacion : Form
    {
        public Facturacion()
        {
            InitializeComponent();
        }
       private List<Mesa> mesas = new List<Mesa> ();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public void cargarProductos()
        {
            RepositorioDeProductos repositorio = new RepositorioDeProductos();
            if (productos == null)
            {
                productos = repositorio.listarPorEstado(true);
            }
            else
            {
                List<Producto> productosAux = repositorio.listarPorEstado(true);
                //Actualizar stock

                int i = 0;

                while (i < productosAux.Count)
                {
                    if (i < productos.Count)
                    {
                        if (productosAux[i].Id_producto == productos[i].Id_producto)
                        {
                            productos[i].Stock_actual = productosAux[i].Stock_actual;
                        }
                    }
                    else
                    {
                        productos.Add(productosAux[i]);
                    }
                    i++;
                }


            }
        }
        private void Facturacion_Shown(object sender, EventArgs e)
        {
            
            
            cargarMesas();
            cargarBotones();
            cargarCombo();
            agregarMesas(1);

        }

        private List<Orden> ordenes = new List<Orden> ();
        private List<Producto> productos;
        private void cargarCombo()
        {
            comboPag.Items.Clear();
            for (int i = 1; i <= paginas; i++) { comboPag.Items.Add(i); }
            comboPag.SelectedIndex = 0;
        }

        private int paginas = 0;

        private Color colorActivo = Color.FromArgb(12, 145, 0);
        private void cargarMesas()
        {
            RepositorioDeMesa repositorioDeMesa = new RepositorioDeMesa();

            foreach (Mesa m in repositorioDeMesa.ObtenerMesasActivas())
            {
                if (!mesas.Contains(m))
                {
                    mesas.Add(m);
                }
            }

            paginas = (int)Math.Ceiling((double) mesas.Count / 6);//Redondeo positivo
            txtPag.Text = 1 + "";
            txtPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            lblTotalPag.Text = paginas + "";
            
        }


        List<IconButton> mesaBotones = new List<IconButton>();
        private void cargarBotones()
        {
            foreach (Mesa mesa in mesas)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("        Mesa        ");
                sb.AppendLine($"No.{mesa.Id}");
                sb.AppendLine($"Asientos.{mesa.Asientos}");
                sb.AppendLine("Estado.Descupada");
                sb.AppendLine($"total.$0.0");
                IconButton button = new IconButton();
                button.Text = sb.ToString();
                button.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
                button.ForeColor = Color.White;
                button.BackColor = colorActivo;
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;
                button.Click += btn_Click;
                mesaBotones.Add(button);
            }
        }



        private void agregarMesas(int pag)
        {
            panelPadre.Controls.Clear();
            int x = 16;
            int y = 17;
            int i = (pag - 1) * 6;
            int control = pag * 6;
            
            if(control > mesas.Count) 
            {

                control = mesas.Count;

            }
            
                while (i < control)
                {
                    panelPadre.Controls.Add(mesaBotones[i]);
                    mesaBotones[i].Location = new System.Drawing.Point(x, y);
                    mesaBotones[i].Size = new System.Drawing.Size(183, 150);
                    x = x + mesaBotones[i].Width + 16;
                    i++;
                    if (i % 3 == 0)
                    {
                        x = 16;
                        y = 32 + mesaBotones[i-1].Height;
                    }
                    
              

                }
           
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            int pag = Convert.ToInt32(txtPag.Text);
            if(pag < paginas && pag >= 1)
            {

                pag = pag + 1;
                txtPag.Text = pag.ToString();
                agregarMesas(pag);
            }
        }

        private void btnAtr_Click(object sender, EventArgs e)
        {
            int pag = Convert.ToInt32(txtPag.Text);
            if (pag <= paginas && pag > 1)
            {

                pag = pag - 1;
                txtPag.Text = pag.ToString();
                agregarMesas(pag);
            }
        }

        private void comboPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(comboPag.SelectedItem.ToString());
            agregarMesas(num);
            txtPag.Text = num.ToString();

        }

        private void btn_Click(object sender, EventArgs e)
        {
         
            IconButton btn = (IconButton)sender;
            int numMesa = Convert.ToInt32(btn.Text.Split('\n')[1].Split('.')[1]);
            if (btn.BackColor == colorActivo)
            {
                

                Mesa mesa = mesas.Where(m => m.Id == numMesa).FirstOrDefault();
                FormOrden formOrden = new FormOrden();
                formOrden.Mesa = mesa;
                formOrden.Productos = productos;
                formOrden.ShowDialog();
                if (formOrden.DataGridView1.Rows.Count > 0)
                {
                    formOrdens.Add(formOrden);
                    btn.BackColor = colorInactivo;
          
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("        Mesa        ");
                    sb.AppendLine($"No.{mesa.Id}");
                    sb.AppendLine($"Asientos.{mesa.Asientos}");
                    sb.AppendLine("Estado.Ocupada");
                    sb.AppendLine($"total.{formOrden.calcularTotal().ToString("c")}.");
                    btn.Text = sb.ToString();
                }
                else
                {
                    formOrden.Dispose();
                }

            }
            else
            {
                FormOrden form = formOrdens.Where(f => f.Mesa.Id == numMesa).FirstOrDefault();  
                form.ShowDialog();

                if(form.DataGridView1.Rows.Count == 0)
                {
                    btn.BackColor = colorActivo;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("        Mesa        ");
                    sb.AppendLine($"No.{form.Mesa.Id}");
                    sb.AppendLine($"Asientos.{form.Mesa.Asientos}");
                    sb.AppendLine("Estado.Descupada");
                    sb.AppendLine($"total.$0.0");
                    btn.Text = sb.ToString() ;
                    int i = 0;
                    bool encontrado = false;
                    while(i < formOrdens.Count && !encontrado)
                    {
                        if (formOrdens[i] == form)
                        {
                            formOrdens.RemoveAt(i);
                            encontrado = true;
                            
                        }
                        else
                        {
                            i++;
                        }
                    }

                    form.Dispose();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("        Mesa        ");
                    sb.AppendLine($"No.{form.Mesa.Id}");
                    sb.AppendLine($"Asientos.{form.Mesa.Asientos}");
                    sb.AppendLine("Estado.Ocupada");
                    sb.AppendLine($"total.{form.calcularTotal().ToString("c")}");
                    btn.Text = sb.ToString();
                }
            }


           

        }

        private Color colorInactivo = Color.FromArgb(160, 18, 52);

        public List<FormOrden> formOrdens = new List<FormOrden>();

        

        private void Facturacion_Load(object sender, EventArgs e)
        {
          
        }

        private void Facturacion_Activated(object sender, EventArgs e)
        {
            int i = 5;
            int b = i + 2;
        }

        private void Facturacion_Load_1(object sender, EventArgs e)
        {

        }
    }
}
