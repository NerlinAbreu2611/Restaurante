using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class MantenimientoMesas : Mantenimiento
    {
        public MantenimientoMesas()
        {
            InitializeComponent();
        }

        public void actualizarFormulario()
        {
            combo.SelectedItem = "Todo";
            cargarDataGrid(RepositorioDeMesa.ObtenerDatos());
        }
        private void cargarDataGridEnFuncionDelaOpcion()
        {
            String opcion = combo.SelectedItem as String;

            if (opcion == "Todo")
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerDatos());
            }
            else if (opcion == "Activas")
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerMesasActivas());
            }
            else
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerMesasInactivas());
            }
        }

        private void MantenimientoMesas_Load(object sender, EventArgs e)
        {
            combo.Items.Clear(); // Opcional, por si ya tenía algo
            combo.Items.Add("Activas");
            combo.Items.Add("Inactivas");
            combo.Items.Add("Todo");
            combo.SelectedItem = "Todo";
            cargarDataGrid(RepositorioDeMesa.ObtenerDatos());
            dataGrid.CellDoubleClick += _CellClick;
        }
        private RepositorioDeMesa RepositorioDeMesa = new RepositorioDeMesa();
        private void cargarDataGrid(List<Mesa> mesas)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            //Sirve para quitar primera columna a la izquiera que solo sirve para seleccionar items
            dataGrid.RowHeadersVisible = false;
            //Sirve para quitar la ultima fila por defecto
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black; // Puedes usar cualquier color
            //definir la cabecera de las columnas
            dataGrid.Columns.Add("colId", "numMesa");
            dataGrid.Columns.Add("colAsientos", "Asientos");
            dataGrid.Columns.Add("colDescripcion", "Descripcion");
            dataGrid.Columns.Add("colFecha", "Fecha");

            //definir la columna de tipo imagen para la edicion de la entidad
            DataGridViewImageColumn imgEdit = new DataGridViewImageColumn();
            imgEdit.Name = "colEdit";//nombre de la columna
            imgEdit.HeaderText = "Editar";//Nombre del header de la columna
            dataGrid.Columns.Add(imgEdit);//agregar columna de tipo imagen 
                                               //imgEdit.Width = 50;

            //definir la columna de tipo imagen de estado
            DataGridViewImageColumn imgEstado = new DataGridViewImageColumn();
            imgEstado.Name = "colEstado"; //nombre de la columna
            imgEstado.HeaderText = "Estado"; //Nombre del header de la columna
                                             // imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; //para que la imagen se ajuste
                                             //imgEstado.Width = 50;
            dataGrid.Columns.Add(imgEstado);//agregar la columna de tipo imagen al data grid
            //ajusta el ancho de las columnas al datagrid
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traer la lista de elementos para agregar el data grid
          
            //Cambiar el ancho de las columna

            //dataGridView1.Columns[0].Width = dataGridView1.Width / 8;
            //dataGridView1.Columns[1].Width = dataGridView1.Width / 8;
            //dataGridView1.Columns[2].Width = dataGridView1.Width / 4;
            //dataGridView1.Columns[3].Width = dataGridView1.Width / 4;
            //dataGridView1.Columns[4].Width = dataGridView1.Width / 12;
            //dataGridView1.Columns[5].Width = dataGridView1.Width / 12;

            //Cargar el data grid con la lista secuencialmente
            //dataGridView1.Columns["colEstado"].DefaultCellStyle.BackColor = Color.LightBlue; //cambiar color a una columna especificada
            foreach (Mesa m in mesas)
            {

                if (m.Estado)
                {
                    dataGrid.Rows.Add(m.Id, m.Asientos, m.Descripcion,m.Fecha.ToString("dd/MM/yyyy"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
                }
                else
                {
                    dataGrid.Rows.Add(m.Id, m.Asientos, m.Descripcion, m.Fecha.ToString("dd/MM/yyyy"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\hidden.png"));
                }
            }

        }

        

        private void _CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string valor = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                // MessageBox.Show("Valor clickeado: " + dataGrid.Columns[e.ColumnIndex].HeaderText);
                int id = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["colId"].Value);
                 Mesa mesa = RepositorioDeMesa.obtenerPorId(id);



                if (dataGrid.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                   FormMesa formMesa = new FormMesa(this,mesa);
                   formMesa.ShowDialog();
                }
                else if (dataGrid.Columns[e.ColumnIndex].HeaderText == "Estado")
                {


                    DialogResult resultado = MessageBox.Show(this,
                                                            "¿Deseas actualizar el estado?",// Texto del mensaje
                                                            "Confirmación",          // Título de la ventana
                                                            MessageBoxButtons.YesNo, // Botones Yes y No
                                                            MessageBoxIcon.Question  // Icono de pregunta
                                                        );

                    if (resultado == DialogResult.Yes)
                    {
                        if (mesa.Estado)
                        {
                            RepositorioDeMesa.DesactivarMesa(id);
                            cargarDataGridEnFuncionDelaOpcion();
                        }
                        else
                        {
                            RepositorioDeMesa.ActivarMesa(id);
                            cargarDataGridEnFuncionDelaOpcion();
                        }
                        //Dejar seleccionada la celda
                        dataGrid.ClearSelection();
                        dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    }

                    

                }
            }
        }



        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String opcion = combo.SelectedItem as String;

            if(opcion == "Todo")
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerDatos());
            }
            else if (opcion == "Activas")
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerMesasActivas());
            }
            else
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerMesasInactivas());
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormMesa formMesa = new FormMesa(this);
            formMesa.ShowDialog();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            String opcion = combo.SelectedItem as String;

            if (opcion == "Todo")
            {
                cargarDataGrid(RepositorioDeMesa.ObtenerPorDescripcion(txtBusqueda.Text));
            }
            else if (opcion == "Activas")
            {
                cargarDataGrid(RepositorioDeMesa.obtenerMesasActivasPorDescripcion(txtBusqueda.Text));
            }
            else
            {
                cargarDataGrid(RepositorioDeMesa.obtenerMesasInactivasPorDescripcion(txtBusqueda.Text));
            }
        }
    }
}
