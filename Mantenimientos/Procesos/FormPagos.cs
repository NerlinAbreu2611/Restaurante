using ConsoleApp1;
using ConsoleApp1.Modelo;
using ConsoleApp1.Proceso;
using ConsoleApp1.ReporteModelo;
using Mantenimientos.Consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Mantenimientos.Procesos
{
    public partial class FormPagos : Form
    {
        public FormPagos()
        {
            InitializeComponent();
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            cargarMetodoDePago();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtPago.Text = "$0.0";
        }

        private string nota;


        private bool validar()
        {
            if(indicesDeOrdenes.Count == 0)
            {
                MessageBox.Show(this, "Debe seleccionar por lo menos un pago", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
       
        private void cargarMetodoDePago()
        {
           comboMetPago.Items.Clear();
           RepositorioDeMetodoDePago repositorio = new RepositorioDeMetodoDePago();
           repositorio.ObtenerDatosPorEstado(true).ForEach(m => comboMetPago.Items.Add(m.Descripcion)); 
           comboMetPago.SelectedIndex = 0;
           metodo = repositorio.buscarPorDescripcion(comboMetPago.SelectedItem.ToString())[0];
        }

        private Cliente cliente;

        private decimal calcularPago()
        {
            if(indicesDeOrdenes.Count > 0)
            {
              POrden pOrden = new POrden();
              List<Orden> ordenes = pOrden.ordenes_Por_Cliente(cliente.Id);
              decimal sumatoria = 0;
              ordenes.ForEach(o =>  { 
                 indicesDeOrdenes.ForEach(i => { if (o.Id_orden == i) { sumatoria += o.Saldo_pendiente;} });
              });
              txtPago.Text = sumatoria.ToString("c");
                return sumatoria;
            }
            else
            {
                txtPago.Text = "$0.0";
                return 0;
            }
        }
        private MetodoDePago metodo;
        private void btnSig_Click(object sender, EventArgs e)
        {

           dataGridView1.Rows.Clear();
           ConsultaCliente consulta = new ConsultaCliente();
           RepositorioDeCliente repositorio = new RepositorioDeCliente();
           consulta.cargarDatagrid(repositorio.clientes_Con_Ordenes_Pendientes());
           consulta.ShowDialog();

            if (consulta.C != null)
            {
                POrden orden = new POrden();
                dataGridView1.ForeColor = Color.Black;
                cargarDataGrid(orden.ordenes_Por_Cliente(consulta.C.Id));
                cliente = consulta.C;
                txtCliente.Text = consulta.C.Nombre;
                indicesDeOrdenes.Clear();
                txtPago.Text = "$0.0";

            }
            dataGridView1.ClearSelection();
        }

        private void limpiar()
        {
            dataGridView1.Rows.Clear();
            txtPago.Text = string.Empty;
            txtCliente.Text= "";
            txtPago.Text = "$0.0";
            cliente = null;
        
            indicesDeOrdenes.Clear();            
        }
        private void cargarDataGrid(List<Orden> ordenes)
        {

            foreach(Orden orden in ordenes)
            {
                RepositorioCondicion repositorioCondicion = new RepositorioCondicion();
                Condicion condicion = repositorioCondicion.buscarPorId(orden.Id_condicion);
                RepositorioDeEmpleado repositorioDeEmpleado = new RepositorioDeEmpleado();
                Empleado empleado = repositorioDeEmpleado.buscarPorId(orden.Id_empleado);
               
                dataGridView1.Rows.Add(orden.Id_orden,orden.Id_cliente,orden.Id_mesa,empleado.Nombre + " " + empleado.Apellido,
                    condicion.Descripcion,orden.Fecha_hora.ToString("d"),
                    orden.Fecha_vencimiento.ToString("d"),orden.Total.ToString("c"),orden.Saldo_pendiente.ToString("c"));
            }

        }
        List<int> indicesDeOrdenes = new List<int>();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ColId"].Value);
                
                if (dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor == dataGridView1.DefaultCellStyle.SelectionBackColor)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    int n = indicesDeOrdenes.IndexOf(i);
                    indicesDeOrdenes.RemoveAt(n);
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.SelectionBackColor;
                    indicesDeOrdenes.Add(i);
                }
                dataGridView1.ClearSelection();
                calcularPago();
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                //Crear pago
                Pago pago = new Pago();
                pago.Fecha_pago = DateTime.Now;
                pago.Monto_total = calcularPago();
                pago.Id_metodo_pago = metodo.Id;
                if(nota != null && nota.Length > 0)
                {
                    pago.Nota = nota;
                }
                else
                {
                    pago.Nota = "";
                }
                pago.Estado = true;
                List<Detalle_pago> detalles = new List<Detalle_pago>();
                //Crear detalle de pago
                
                POrden pOrden = new POrden();
                List<Orden> ordenes = new List<Orden>();
                foreach(int i in indicesDeOrdenes)
                {
                    Orden orden = pOrden.buscarPorId(i);
                    Detalle_pago detalle = new Detalle_pago();
                    detalle.Id_orden = orden.Id_orden;
                    detalle.Monto_aplicado = orden.Saldo_pendiente;
                    orden.Saldo_pendiente = 0;
                    orden.Procesada = true;
                    ordenes.Add(orden);
                    detalles.Add(detalle);  
                }

                PDetalle_Pago pDetalle_Pago = new PDetalle_Pago();

                if (pDetalle_Pago.procesarPago(pago, detalles, ordenes))
                {
                    MessageBox.Show(this,"Proceso exitoso","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Reporte.ClientePago = cliente;
                    Reporte.Pago1 = pago;
                    pago.Id_pago = PDetalle_Pago.ultimoPago();
                 
                    Reporte.MetodoDePago = metodo;
                    PDetalle_Pago detalle_Pago = new PDetalle_Pago();
                    List<Detalle_pago> dt = detalle_Pago.detalles_Por_Pago(pago.Id_pago);
                    Reporte.Detalle_Pagos = dt;
                    FormPDF form = new FormPDF();
                    form.Path = Reporte.generarPago();
                    form.ShowDialog();
                    limpiar();
                
                }
                else
                {
                    MessageBox.Show(this, "Ocurrio un error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void comboMetPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositorioDeMetodoDePago repositorioDeMetodoDePago = new RepositorioDeMetodoDePago();
            metodo = repositorioDeMetodoDePago.buscarPorDescripcion(comboMetPago.SelectedItem.ToString())[0];
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            FormNota nota = new FormNota();
            nota.ShowDialog();
            if (nota.Nota != null && nota.Nota.Length > 0) {
                this.nota = nota.Nota;
            }
        }
    }
}
