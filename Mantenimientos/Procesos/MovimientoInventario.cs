using ConsoleApp1;
using ConsoleApp1.Proceso;
using Mantenimientos.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mantenimientos.Procesos
{
    public partial class MovimientoInventario : Form
    {
        public MovimientoInventario()
        {
            InitializeComponent();
            cargarColumnas();
        }



        private Repositorio_tipo_movimiento repositorio_Tipo_Movimiento = new Repositorio_tipo_movimiento();
        private void MovimientoInventario_Load(object sender, EventArgs e)
        {

            repositorio_Tipo_Movimiento.ObtenerPorEstado(true).ForEach(r =>
            {
                comboTipoDeMovimiento.Items.Add(r.Descripcion);
            });
            comboTipoDeMovimiento.SelectedIndex = 0;

        }

        private Producto producto;


        private Proveedor proveedor;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ConsultaProveedor consulta = new ConsultaProveedor();
            consulta.ShowDialog();
            if (consulta.Proveedor != null)
            {
                proveedor = consulta.Proveedor;
                txtNombreProveedor.Text = proveedor.Nombre;
                txtTelefono.Text = proveedor.Telefono;
                txtDireccion.Text = proveedor.Direccion;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        List<Producto> productos = new List<Producto>();

        private void cargarColumnas()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns.Add("ColProducto", "Producto");
            dataGridView1.Columns["ColProducto"].ReadOnly = true;
            dataGridView1.Columns.Add("ColCantidad", "Cantidad");
            dataGridView1.Columns["ColCantidad"].ReadOnly = false;
            DataGridViewImageColumn imgSuma = new DataGridViewImageColumn();
            imgSuma.Name = "colPlus";
            imgSuma.HeaderText = "Sumar";
            DataGridViewImageColumn imgResta = new DataGridViewImageColumn();
            imgResta.Name = "colRes";
            imgResta.HeaderText = "Restar";
            DataGridViewImageColumn imgEliminar = new DataGridViewImageColumn();
            imgEliminar.Name = "colEliminar";
            imgEliminar.HeaderText = "Eliminar";

            dataGridView1.Columns.Add(imgSuma);
            dataGridView1.Columns.Add(imgResta);
            dataGridView1.Columns.Add(imgEliminar);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void agregarProducto(Producto producto)
        {
            if (!productos.Contains(producto))
            {
                productos.Add(producto);
                dataGridView1.Rows.Add(producto.Nombre, 1, System.Drawing.Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\mas.png"), System.Drawing.Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\menos.png"), System.Drawing.Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eliminar.png"));
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ColProducto"].Value.ToString() == producto.Nombre)
                    {
                        cantidadAnterior = Convert.ToDecimal(row.Cells["ColCantidad"].Value) + 1;
                        row.Cells["ColCantidad"].Value = cantidadAnterior;

                    }
                }
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ConsultaProducto consulta = new ConsultaProducto(this);
            consulta.ShowDialog();

            if (consulta.Producto != null)
            {
                agregarProducto(consulta.Producto);
            }

        }

        private int indiceDeProducto;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            indiceDeProducto = dataGridView1.CurrentCell.RowIndex;



            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["ColCantidad"].Index)
            {
                // Quita eventos anteriores para evitar duplicados
                e.Control.KeyPress -= SoloNumeros_KeyPress;
                // Asigna el evento KeyPress
                e.Control.KeyPress += SoloNumeros_KeyPress;
            }
            else
            {
                // Quita el evento si no es esa columna
                e.Control.KeyPress -= SoloNumeros_KeyPress;
            }

            string nombre = dataGridView1.Rows[indiceDeProducto].Cells["ColProducto"].Value.ToString();
            decimal cantidad = Convert.ToDecimal(dataGridView1.Rows[indiceDeProducto].Cells["ColCantidad"].Value);






        }

        private decimal cantidadAnterior;
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

            // Permitir control (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir un solo punto y no al inicio
            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains('.') || txt.SelectionStart == 0)
                {
                    e.Handled = true; // Bloquea si ya hay punto o es el primer carácter
                }
                return;
            }





            // Bloquear todo lo demás
            e.Handled = true;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceDeProducto = e.RowIndex;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Sumar")
                {
                    
                    cantidadAnterior = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["ColCantidad"].Value) + 1;
                    dataGridView1.Rows[e.RowIndex].Cells["ColCantidad"].Value = cantidadAnterior;
                 
                }
                else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Restar")
                {
                    decimal val = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["ColCantidad"].Value);
                    if (val <= 1)
                    {
                        dataGridView1.CellStateChanged -= dataGridView1_CellStateChanged;
                        dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
                        string nombre = dataGridView1.Rows[e.RowIndex].Cells["ColProducto"].Value.ToString();
                        removerProductoDeLista(nombre);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        dataGridView1.CellStateChanged += dataGridView1_CellStateChanged;
                        dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                    }
                    else
                    {
                        cantidadAnterior = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["ColCantidad"].Value) - 1;
                        dataGridView1.Rows[e.RowIndex].Cells["ColCantidad"].Value = cantidadAnterior;
                    }

                }
                else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    dataGridView1.CellStateChanged -= dataGridView1_CellStateChanged;
                    dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
                    string nombre = dataGridView1.Rows[e.RowIndex].Cells["ColProducto"].Value.ToString();
                    removerProductoDeLista(nombre);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    dataGridView1.CellStateChanged += dataGridView1_CellStateChanged;
                    dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                }
            }
        }


        private void removerProductoDeLista(string nombre)
        {
            int i = 0;
            bool encontrado = false;

            while (!encontrado)
            {
                if (productos[i].Nombre == nombre)
                {
                    encontrado = true;
                    productos.RemoveAt(i);

                }
                else
                {
                    i++;
                }
            }
        }

        private void comboTipoDeMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo_movimiento tipo = repositorio_Tipo_Movimiento.obtener_por_descripcion(comboTipoDeMovimiento.SelectedItem.ToString())[0];

            if (tipo.Afecta_stock == 1)
            {
                btnEntrada.Checked = true;
                gbProveedor.Enabled = true;
            }
            else
            {
                btnSalida.Checked = true;
                gbProveedor.Enabled = false;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (Producto p in productos) { actualizarStock(p); }
                crearMovimientos();
                if (PMovimientoInventario.crearMovimiento(movimientos, productos))
                {
                    MessageBox.Show(this, "Movimiento Exitoso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show(this, "Ocurrio un error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                liberarRecuros();
            }
            else
            {
                MessageBox.Show(this, "Error, debe ingresar producto para realizar movimientos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void crearMovimientos()
        {
            foreach (Producto p in productos)
            {
                ConsoleApp1.Modelo.MovimientoInventario movimiento = new ConsoleApp1.Modelo.MovimientoInventario();
                tipo_movimiento tipo = repositorio_Tipo_Movimiento.obtener_por_descripcion(comboTipoDeMovimiento.SelectedItem.ToString())[0];
                movimiento.Id_tipo_mov = tipo.Id;
                movimiento.Id_producto = p.Id_producto;
                Producto otroProducto = repositorioDeProductos.buscarPorId(p.Id_producto);
                if (tipo.Afecta_stock == 1)
                {
                    movimiento.Cantidad = p.Stock_actual - otroProducto.Stock_actual;
                }
                else
                {
                    movimiento.Cantidad = otroProducto.Stock_actual - p.Stock_actual;
                }

                movimiento.Fecha = dtpFecha.Value;
                if (proveedor != null)
                {
                    movimiento.Id_proveedor = proveedor.Id;
                }
                movimiento.Observaciones = txtObservaciones.Text;

                movimientos.Add(movimiento);

            }


        }

        RepositorioDeProductos repositorioDeProductos = new RepositorioDeProductos();


        List<ConsoleApp1.Modelo.MovimientoInventario> movimientos = new List<ConsoleApp1.Modelo.MovimientoInventario>();

        private void liberarRecuros()
        {
            productos.Clear();
            movimientos.Clear();
            proveedor = null;
            producto = null;
            dataGridView1.CellStateChanged -= dataGridView1_CellStateChanged;
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            dataGridView1.Rows.Clear();
            dataGridView1.CellStateChanged += dataGridView1_CellStateChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            txtDireccion.Clear();
            txtNombreProveedor.Clear();
            txtObservaciones.Clear();
            txtTelefono.Clear();
            comboTipoDeMovimiento.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;

        }

        private void actualizarStock(Producto p)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string nombre = row.Cells["ColProducto"].Value.ToString();
                decimal num = Convert.ToDecimal(row.Cells["ColCantidad"].Value);

                if (nombre == p.Nombre)
                {
                    if (btnEntrada.Checked) { p.Stock_actual = p.Stock_actual + num; }
                    else { p.Stock_actual = p.Stock_actual - num; }

                    break;
                }

            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            liberarRecuros();
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            validarSalida();

        }


        private void validarSalidas()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string nombre = row.Cells["ColProducto"].Value.ToString();
                Producto p = repositorioDeProductos.listarNombre(nombre)[0];
                decimal cantidad = Convert.ToDecimal(row.Cells["ColCantidad"].Value);
                if (cantidad > p.Stock_actual)
                {
                    row.Cells["ColCantidad"].Value = p.Stock_actual - 1;
                }
            }
        }

        private void validarSalida()
        {

            int indice = dataGridView1.CurrentRow.Index;
            string nombre = dataGridView1.Rows[indice].Cells["ColProducto"].Value.ToString();
            decimal cantidad = Convert.ToDecimal(dataGridView1.Rows[indice].Cells["ColCantidad"].Value);



            if (btnSalida.Checked)
            {
                Producto p = repositorioDeProductos.listarNombre(nombre)[0];
                if (cantidad > p.Stock_actual)
                {
                    MessageBox.Show(this, $"Error, la salida no puede superar el stock total {p.Stock_actual}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[indice].Cells["ColCantidad"].Value = p.Stock_actual - 1;
                }

            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            validarSalida();
        }

        private void btnSalida_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.CellStateChanged -= dataGridView1_CellStateChanged;
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            validarSalidas();
            dataGridView1.CellStateChanged += dataGridView1_CellStateChanged;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
    }
}
