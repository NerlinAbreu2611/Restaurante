using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.componentes;
using System.Runtime.InteropServices;
using Mantenimientos;
using Mantenimientos.Procesos;


namespace WindowsFormsApp2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            personalizarDiseno();
        }

        private void personalizarDiseno()
        {
            panelCxC.Visible = false;
            panelInventario.Visible = false;
            panelRestaurante.Visible = false;
          
           

        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;




        private void ocultarSubMenu()
        {
            panelCxC.Visible = false;
            panelInventario.Visible = false;
            panelRestaurante.Visible = false;

        }

        private void mostrarSubMenus(Panel panelSubmenu)
        {
            if(panelSubmenu.Visible == false) {
            
                ocultarSubMenu();
                panelSubmenu.Visible = true;
            
            }else
            {
                panelSubmenu.Visible = false;
            }

        }




 
        StringBuilder stringBuilder = new StringBuilder();

        
        Dictionary<IconButton,DropDownMenu> botonesConSubMenu = new Dictionary<IconButton,DropDownMenu>();   
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //agregar menus desplegables y submenus al diccionario

            botonesConSubMenu[btnProcesosRestaurante] = dpmProcesosRestaurante;
            botonesConSubMenu[btnMantenimientoRestaurante] = dpmMantenimientoRestaurante;
            botonesConSubMenu[btnMantenimientoInventario] = dpmMantenimientoInventario;
            botonesConSubMenu[btnProcesosInventario] = dpmProcesosInventario;
            botonesConSubMenu[btnConsultasInventario] = dpmConsultasInventario;
            botonesConSubMenu[btnReportesInventario] = dpmReportesInventario;
            botonesConSubMenu[btnMantenimientoCxC] = dpmMantenimientoCxC;
            botonesConSubMenu[btnProcesosCxC] = dpmProcesosCxC;
            botonesConSubMenu[btnReportesCxC] = dpmReportesCxC;

            //recorrer diccionario

            foreach (KeyValuePair<IconButton, DropDownMenu> i in botonesConSubMenu)
            {
                //cerrar menus desplegables
                IconButton button = i.Key;
                button.Click += mostrarMenusDesplegables;
               
                //mostrar menus desplegables
                DropDownMenu menu = i.Value;
                menu.Closed += dropDownMenuClosed;
                //MessageBox.Show(i.Value.Name);
            }

            


        }

        private void btnRestaurante_Click(object sender, EventArgs e)
        {
            mostrarSubMenus(panelRestaurante);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            mostrarSubMenus(panelInventario);
        }

        private ToolStripItem itemAntiguo;
        Form formHijo;
        bool select = true;

     
        

        private void btnCxC_Click(object sender, EventArgs e)
        {
            mostrarSubMenus(panelCxC);
        }

        private Color colorRojo = Color.FromArgb(228, 26, 74);
        private void mostrarMenusDesplegables(object sender, EventArgs e)
        {
            IconButton boton = sender as IconButton;
            DropDownMenu menu = botonesConSubMenu[boton];
            if(menu != null)
            {
                menu.Show(boton, boton.Width, 0);
                boton.BackColor = colorRojo;

            }
           
        }



        private Color colorAnterior = Color.FromArgb(39, 39, 58);


        private void dropDownMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            DropDownMenu menu = sender as DropDownMenu;

            foreach(KeyValuePair<IconButton, DropDownMenu> i in botonesConSubMenu)
            {
                IconButton boton = i.Key;
                if(Object.ReferenceEquals(i.Value,menu))
                {
                    boton.BackColor = colorAnterior;
                    break;
                }
            }
            
        }

        private void panelPadre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void panelPadre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void panelMenuLateral_MouseDown(object sender, MouseEventArgs e)
        {
            
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }else this.WindowState = FormWindowState.Maximized;
        }

        private Form formularioHijo;
        private void agregarFormulario(Form formHijo)
        {
            if(formularioHijo != null)
            {
                formularioHijo.Dispose();
            }
            //limpiar el panel
            panelPadre.Controls.Clear();
            //preparar el formulario hijo
           
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            // Agregar al panel y mostrarlo
            panelPadre.Controls.Add(formHijo);
            formHijo.Show();

            formularioHijo = formHijo;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoMesas());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoClientes());
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoCondicion());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoEmpleado());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoMetodoDePago());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoProveedor());
        }

        private void tiposDeMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new Mantenimiento_tipo_de_movimiento());  
        }

        private void unidadesDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoUnidadDeMedida());
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoCategoriaProducto());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MantenimientoProductos());
        }

        private void registroDeMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new MovimientoInventario());
        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarFormulario(new Facturacion());
        }
    }
}
