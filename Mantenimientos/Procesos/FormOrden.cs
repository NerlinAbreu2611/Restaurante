using ConsoleApp1;
using ConsoleApp1.Modelo;
using ConsoleApp1.Proceso;
using ConsoleApp1.ReporteModelo;
using Mantenimientos.Consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Mantenimientos.Procesos
{
    public partial class FormOrden : Form
    {
        public FormOrden()
        {
            InitializeComponent();
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


        private void cargarMetodosDePago()
        {
            comboMetodoDePago.Items.Clear();
            RepositorioDeMetodoDePago repositorio = new RepositorioDeMetodoDePago();
            repositorio.ObtenerDatosPorEstado(true).ForEach(m =>
            {
                comboMetodoDePago.Items.Add(m.Descripcion);
            } );

            comboMetodoDePago.SelectedIndex = 0;
            lblMetodoPago.Visible = false;
            comboMetodoDePago.Visible = false;
            btnNota.Visible = false;
        }


        private List<Producto> productos;
        private Mesa mesa;
        private Cliente cliente;
        private Empleado empleado;

        public List<Producto> Productos { get => productos; set => productos = value; }
        public Mesa Mesa { get => mesa; set => mesa = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Empleado Empleado { get => empleado; set => empleado = value; }

        private void FormOrden_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Mesa no.{mesa.Id}";

        }

        public DataGridView DataGridView1 { get => dataGridView1; set => dataGridView1 = value; }
        public MetodoDePago Metodo { get => metodo; set => metodo = value; }

        private void cargarDatagrid()
        {

        }

        private void FormOrden_Shown(object sender, EventArgs e)
        {
            
            cargarControles();
            cargarMetodosDePago();
            cargarProductos(1,controlProductos);
            paginas = (int)Math.Ceiling((double)controlProductos.Count / 4);
            txtPag.Text = 1 + "";
            lblTotalPag.Text = paginas + "";
            txtPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            cargarCombo();
        }


        private void cargarControles()
        {
            if(controlProductos.Count == 0)
            {
                foreach(Producto p in productos)
                {
                    ControlProductos c = new ControlProductos();
                    c._lblNombre.Text = p.Nombre;
                    c._lblPrecio.Text = p.Precio_venta.ToString("c");
                    c._txtCant.Text = p.Stock_actual + "";
                    if (p.Url_imagen.Length < 1) { c._fotoProducto.Image = Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\no-fotos.png"); }
                    else { c._fotoProducto.Image = Image.FromFile(p.Url_imagen); }
                    c._fotoProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    c.Producto = p;
                    c.dataGrid = this.dataGridView1;
                    controlProductos.Add(c);
                }
                controlesAux = controlProductos;
            }
        }

       

        private void cargarCombo()
        {
            this.SuspendLayout();
            comboPag.Items.Clear();
            for (int i = 1; i <= paginas; i++) { comboPag.Items.Add(i); }
            comboPag.SelectedIndexChanged -= comboPag_SelectedIndexChanged;
            comboPag.SelectedIndex = 0;
            comboPag.SelectedIndexChanged += comboPag_SelectedIndexChanged;
            this.ResumeLayout();
            this.Refresh();
        }

        int paginas = 0;

        private List<ControlProductos> controlProductos = new List<ControlProductos>();
        private void cargarProductos(int pag,List<ControlProductos> controles)
        {
            panelProducto.Controls.Clear();
            int x = 21;
            int y = 13;
            int i = (pag - 1) * 4;
            int control = pag * 4;

            if(control > controles.Count)
            {
                control = controles.Count;
            }

            while (i < control) 
            { 
                string nombre = controles[i].Producto.Nombre;
                
                controles[i].Size = new System.Drawing.Size(126, 112);
                controles[i].Location = new System.Drawing.Point(x, y); 
           

                x = x + controles[i].Width + x;
                i++;
                if(i % 2 == 0)
                {
                    x = 21;
                    y = y + controles[i - 1].Height + y;
                }

                panelProducto.Controls.Add(controles[i-1]);
                panelProducto.AutoScroll = true;

            }

        }

        private void comboPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(comboPag.SelectedItem);
            if(controlesAux.Count > 0) cargarProductos(num, controlesAux);

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(txtPag.Text);
            num += 1;

            if(num <= paginas)
            {
                txtPag.Text = num.ToString();
                if(controlesAux.Count > 0) cargarProductos(num, controlesAux);

            }
        }

        private void btnAtr_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(txtPag.Text);
            num -= 1;
            if(num >= 1)
            {
                txtPag.Text = num.ToString();
                if (controlesAux.Count > 0) cargarProductos(num, controlesAux);
            }
        }

        List<ControlProductos> controlesAux;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            List<ControlProductos> controles = new List<ControlProductos>();
            foreach(ControlProductos c in controlProductos)
            {
                if(c.Producto.Nombre.ToUpper().StartsWith(txtBusqueda.Text.ToUpper()))
                {
                    controles.Add(c);
                }
            }
            controlesAux = controles;
            int num = controles.Count;
            paginas = (int)Math.Ceiling((double)controles.Count / 4);
            lblTotalPag.Text = paginas.ToString();
            if(controles.Count > 0)
            {
             
                cargarProductos(1, controles);
                cargarCombo();
            }
            this.ResumeLayout();
            this.Refresh();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string column = dataGridView1.Columns[e.ColumnIndex].Name;

                if (column == "ColEliminar")
                {   RepositorioDeProductos repositorio = new RepositorioDeProductos();
                    ControlProductos co = controlProductos.Where(c => c.Producto.Nombre == dataGridView1.Rows[e.RowIndex].Cells["ColProducto"].Value.ToString()).First();
                    co.Producto.Stock_actual = co.Producto.Stock_actual
                        + Convert.ToDecimal(
                        dataGridView1.Rows[e.RowIndex].Cells["ColCantidad"].Value
                        );
                    co.CantidadPro = 0;
                    co._txtCant.Text = co.Producto.Stock_actual.ToString();
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    repositorio.Actualizar(co.Producto);

                }

            }
        }

        private void FormOrden_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) 
            { 
                e.Cancel = true;
            }
            this.Hide();
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            ConsultaCliente consulta = new ConsultaCliente();
            consulta.ShowDialog();

            if(consulta.C != null)
            {
                 txtCliente.Text = consulta.C.Nombre;
                cliente = consulta.C;
                txtCondicion.Text = consulta.Con.Descripcion;
                condicion = consulta.Con;   
                if(condicion.Descripcion == "Contado inmediato")
                {
                    lblMetodoPago.Visible = true;
                    comboMetodoDePago.Visible=true;
                    btnNota.Visible = true;
                }
                else
                {
                    lblMetodoPago.Visible = false;
                    comboMetodoDePago.Visible = false;
                    btnNota.Visible = false;
                }
               
            }
        }

        public decimal calcularTotal()
        {
            decimal acumulador = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    acumulador = acumulador + (Convert.ToDecimal(row.Cells["ColCantidad"].Value) * Convert.ToDecimal(row.Cells["ColPrecio"].Value));
                }
            }
            return acumulador;
        }

        private Condicion condicion;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ConsultaEmpleado consulta = new ConsultaEmpleado(); 

            consulta.ShowDialog();

            if (consulta.Empleado != null)
            {
                this.empleado = consulta.Empleado;
                txtEmpleado.Text = empleado.Nombre;
            }

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            txtTotal.Text = calcularTotal().ToString("C");
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            txtBusqueda.Text = "";
            txtCliente.Text = "";
            txtEmpleado.Text = "";
            txtCondicion.Text = "";
           
            for(int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                eliminar(i);
            }
            dataGridView1.Rows.Clear();

        }

        private void eliminar(int rowIndex)
        {
           
        RepositorioDeProductos repositorio = new RepositorioDeProductos();
        ControlProductos co = controlProductos.Where(c => c.Producto.Nombre == dataGridView1.Rows[rowIndex].Cells["ColProducto"].Value.ToString()).First();
        co.Producto.Stock_actual = co.Producto.Stock_actual
            + Convert.ToDecimal(
            dataGridView1.Rows[rowIndex].Cells["ColCantidad"].Value
            );
        co.CantidadPro = 0;
        co._txtCant.Text = co.Producto.Stock_actual.ToString();
        dataGridView1.Rows.RemoveAt(rowIndex);
            repositorio.Actualizar(co.Producto);
        
        }

        private bool validar()
        {
            if(cliente == null)
            {
                System.Windows.Forms.MessageBox.Show(this,"Error, debe ingresar un cliente","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if(mesa == null)
            {
                System.Windows.Forms.MessageBox.Show(this, "Error, debe ingresar una mesa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(empleado == null) 
            {
                System.Windows.Forms.MessageBox.Show(this, "Error, debe ingresar un empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dataGridView1.Rows.Count == 0) 
            {
                System.Windows.Forms.MessageBox.Show(this, "Error, debe ingresar  por lo menos un producto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (validar()) {
                procesarOrden();
            }
        }

        private MetodoDePago metodo;
        private void procesarOrden()
        {
            Orden orden = new Orden();
            orden.Id_cliente = cliente.Id;
            orden.Id_mesa = mesa.Id;
            orden.Id_empleado = empleado.Id;
            orden.Id_condicion = cliente.Id_condicion;
            orden.Fecha_hora = DateTime.Now;
            orden.Fecha_vencimiento = DateTime.Now;
            orden.Total = calcularTotal();
            orden.Estado = true;        
            
            if(txtCondicion.Text == "Contado inmediato")
            {
                OrdenContado(orden);
            }
            else
            {
                OrdenCredito(orden);
            }
        }


        //Crear detalle de orden
        private List<Detalle_de_orden> crearDetalle(Orden orden)
        {
            List<Detalle_de_orden> detalles = new List<Detalle_de_orden>();
            RepositorioDeProductos repositorio = new RepositorioDeProductos();  
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                Producto p = repositorio.listarNombreEstado(row.Cells["ColProducto"].Value.ToString(),true)[0];
                Detalle_de_orden detalle = new Detalle_de_orden();
                detalle.Id_orden = orden.Id_orden;
                detalle.Id_producto = p.Id_producto;
                detalle.Cantidad = Convert.ToDecimal(row.Cells["ColCantidad"].Value);
                detalle.Precio_unitario = p.Precio_venta;
                detalle.Sub_total = detalle.Cantidad * detalle.Precio_unitario;
                detalle.Estado = true;
                detalles.Add(detalle);
            }

            return detalles;
        }
        private void OrdenContado(Orden orden)
        {
            orden.Procesada = true;
            List<Detalle_de_orden> detalles = crearDetalle(orden);
            Pago pago = new Pago();
            pago.Fecha_pago = DateTime.Now;
            pago.Monto_total = calcularTotal();
            pago.Id_metodo_pago = metodo.Id;
            if(nota != null) { pago.Nota = nota; }
            pago.Estado = true;
            Detalle_pago detalle = new Detalle_pago();
            detalle.Id_orden = orden.Id_orden;
            detalle.Id_pago = pago.Id_pago;
            detalle.Monto_aplicado = calcularTotal();
            orden.Saldo_pendiente = 0;

            POrden proceso = new POrden();

            if (proceso.procesarOrdenContado(orden, detalles, detalle, pago))
            {
                System.Windows.Forms.MessageBox.Show(this, "Proceso exitoso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                orden.Id_orden = POrden.ultimoID();
                Reporte.MetodoDePago = metodo;
                Reporte.Orden = orden;
                
                limpiarProceso();
                FormPDF form = new FormPDF();
                form.Path = Reporte.generarFacturar();
                form.ShowDialog();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, "Ocurrio un error en el proceso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }

        }

        private void limpiarProceso()
        {
            txtBusqueda.Text = "";
            txtCliente.Text = "";
            txtEmpleado.Text = "";
            txtCondicion.Text = "";
            empleado = null;
            cliente = null;
            dataGridView1.Rows.Clear();

        }

        private void OrdenCredito(Orden orden)
        {
            orden.Saldo_pendiente = orden.Total;
            orden.Procesada = false;
            orden.Fecha_vencimiento = orden.Fecha_hora.AddDays(condicion.DiasDeCredito);
            List<Detalle_de_orden> detalles = crearDetalle(orden);
            POrden proceso = new POrden();
            if (proceso.procesarOrdenCredito(orden, detalles))
            {
                System.Windows.Forms.MessageBox.Show(this, "Proceso exitoso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarProceso();
                orden.Id_orden = POrden.ultimoID();
                Reporte.Orden = orden;

                limpiarProceso();
                FormPDF form = new FormPDF();
                form.Path = Reporte.generarFacturar();
                form.ShowDialog();

            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, "Ocurrio un error en el proceso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboMetodoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositorioDeMetodoDePago repositorio = new RepositorioDeMetodoDePago();
            Metodo = repositorio.buscarPorDescripcion(comboMetodoDePago.SelectedItem.ToString())[0];
          
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            FormNota form = new FormNota();
            form.ShowDialog();
            if (form.Nota != null)
            { 
                nota = form.Nota;
            
            }
        }

        private string nota;

        private void btnPrecuenta_Click(object sender, EventArgs e)
        {
            Precuenta precuenta = new Precuenta();
            if (validar())
            {
                precuenta.DataGridView = dataGridView1;
                precuenta.Cliente = cliente;
                precuenta.Empleado = empleado;
                precuenta.Mesa = mesa;
                precuenta.Total = calcularTotal();

                precuenta.ShowDialog();
            }
            
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            FormPDF f = new FormPDF();
            f.ShowDialog();
        }
    }
}
