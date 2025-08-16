using ConsoleApp1;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private void Facturacion_Shown(object sender, EventArgs e)
        {
            cargarMesas();
            agregarMesas(1);
            cargarCombo();
            
        }

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
        

            while(i < control)
            {
       
                
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("        Mesa        ");
                sb.AppendLine($"No.{mesas[i].Id}");
                sb.AppendLine($"Asientos.{mesas[i].Asientos}");
                sb.AppendLine("Estado.Descupada");
                sb.AppendLine($"total.$0.0");


                IconButton button = new IconButton();
                button.Text = sb.ToString();
                button.Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
                button.ForeColor = Color.White;
                button.BackColor = colorActivo;
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;

                button.Location = new System.Drawing.Point(x, y);
                button.Size = new System.Drawing.Size(183, 150);
                x = x + button.Width + 16;
                i++;
                if (i % 3 == 0)
                {
                    x = 16;
                    y = 32 + button.Height;
                }
                panelPadre.Controls.Add(button);
                panelPadre.AutoScroll = true;

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
    }
}
