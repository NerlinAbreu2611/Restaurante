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
    public partial class MantenimientoCondicion : Mantenimiento
    {
        public MantenimientoCondicion()
        {
            InitializeComponent();

        }

        public void actualizarDatagrid()
        {
            cargarDataGrid(repositorioCondicion.ObtenerDatos());
        }
        
        private void MantenimientoCondicion_Load(object sender, EventArgs e)
        {
            cargarDataGrid(repositorioCondicion.ObtenerDatos());
            combo.Items.AddRange(new String[] {"Todo","Activos","Inactivos"});
            combo.SelectedIndex = 0;
            dataGrid.CellDoubleClick += _CellClick;
        }

        private RepositorioCondicion repositorioCondicion = new RepositorioCondicion();
        
         private void _CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string valor = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                // MessageBox.Show("Valor clickeado: " + dataGrid.Columns[e.ColumnIndex].HeaderText);
                int id = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["colId"].Value);
                Condicion condicion = repositorioCondicion.buscarPorId(id);

                if (dataGrid.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    FormCondicion form = new FormCondicion(condicion,this);
                    form.ShowDialog();
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
                        if (condicion.Estado)
                        {
                            repositorioCondicion.desahabilitar(condicion);
                        }
                        else
                        {
                            repositorioCondicion.habilitar(condicion);
                        }
                        //Dejar seleccionada la celda
                        cargarDataGrid(repositorioCondicion.ObtenerDatos());
                        dataGrid.ClearSelection();
                        
                        dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        
                    }

                }
            }
        }


        private void cargarDataGrid(List<Condicion> condiciones)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            //Sirve para quitar primera columna a la izquiera que solo sirve para seleccionar items
            dataGrid.RowHeadersVisible = false;
            //Sirve para quitar la ultima fila por defecto
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black; // Puedes usar cualquier color
            //definir la cabecera de las columnas
            dataGrid.Columns.Add("colId", "Id condicion");
            dataGrid.Columns.Add("colDescripcion", "descripcion");
            dataGrid.Columns.Add("colAutopago", "autopago");
            dataGrid.Columns.Add("colFecha", "dias de credito");

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
            foreach (Condicion con in condiciones)
            {

                if (con.Estado)
                {
                    dataGrid.Rows.Add(con.Id, con.Descripcion, con.EsAutopago, con.DiasDeCredito, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
                }
                else
                {
                    dataGrid.Rows.Add(con.Id, con.Descripcion, con.EsAutopago, con.DiasDeCredito, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\hidden.png"));
                }
            }

        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)

        {
            if(combo.SelectedItem.ToString() == "Todo")
            {
                cargarDataGrid(repositorioCondicion.ObtenerDatos());
            }
            else if(combo.SelectedItem.ToString() == "Activos")
            {
                cargarDataGrid(repositorioCondicion.obtenerCondicionesPorEstado(true));
            }
            else
            {
                cargarDataGrid(repositorioCondicion.obtenerCondicionesPorEstado(false));
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (combo.SelectedItem.ToString() == "Todo")
            {
                cargarDataGrid(repositorioCondicion.BuscarPorDescripcion(txtBusqueda.Text));
            }
            else if (combo.SelectedItem.ToString() == "Activos")
            {
                cargarDataGrid(repositorioCondicion.BuscarPorDescripcionSegunElEstado(txtBusqueda.Text,true));
            }
            else
            {
                cargarDataGrid(repositorioCondicion.BuscarPorDescripcionSegunElEstado(txtBusqueda.Text, false));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormCondicion form = new FormCondicion(this);
            form.ShowDialog();
        }
    }
}
