using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class MantenimientoUnidadDeMedida : Mantenimiento
    {
        public MantenimientoUnidadDeMedida()
        {
            InitializeComponent();
        }

        private void _CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string valor = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                // MessageBox.Show("Valor clickeado: " + dataGrid.Columns[e.ColumnIndex].HeaderText);
                int id = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["colId"].Value);
                Unidades_de_medida unidad = repo.buscar_por_id(id);

                if (dataGrid.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    FormUnidadDeMedida form = new FormUnidadDeMedida(this, unidad);
                    form.ShowDialog();

                    limpiar();
                    dataGrid.ClearSelection();
                    cargarDataGrid(repo.ObtenerDatos());
                    dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

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
                        if (unidad.Estado)
                        {
                            repo.desahabilitar(unidad);
                        }
                        else
                        {
                            repo.habilitar(unidad);
                        }
                        //Dejar seleccionada la celda

                        dataGrid.ClearSelection();
                        cargarDataGrid(repo.ObtenerDatos());
                        dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    }

                }
            }
        }

        private void Form_unidad_de_medida_Load(object sender, EventArgs e)
        {
            combo.Items.AddRange(new String[] { "Todo", "Inactivos", "Activos" });
            combo.SelectedIndex = 0;
            cargarDataGrid(repo.ObtenerDatos());
            dataGrid.CellDoubleClick += _CellClick;
        }
        Repositorio_de_unidad_de_medida repo = new Repositorio_de_unidad_de_medida();
        private void cargarDataGrid(List<Unidades_de_medida> un)
        {

            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            //Sirve para quitar primera columna a la izquiera que solo sirve para seleccionar items
            dataGrid.RowHeadersVisible = false;
            //Sirve para quitar la ultima fila por defecto
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black; // Puedes usar cualquier color
            //definir la cabecera de las columnas
            dataGrid.Columns.Add("colId", "Id");
            dataGrid.Columns.Add("colNombre", "Nombre");





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
            foreach (Unidades_de_medida u in un)
            {

                if (u.Estado)
                {
                    dataGrid.Rows.Add(u.Id, u.Nombre, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
                }
                else
                {
                    dataGrid.Rows.Add(u.Id, u.Nombre, Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\hidden.png"));
                }
            }

        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo.SelectedItem.ToString() == "Todo")
            {

                cargarDataGrid(repo.ObtenerDatos());

            }
            else if (combo.SelectedItem.ToString() == "Activos")
            {
                cargarDataGrid(repo.listar_por_estado(true));
            }
            else
            {
                cargarDataGrid(repo.listar_por_estado(false));
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (combo.SelectedItem.ToString() == "Todo")
            {

                cargarDataGrid(repo.buscar_por_nombre(txtBusqueda.Text));

            }
            else if (combo.SelectedItem.ToString() == "Activos")
            {
                cargarDataGrid(repo.listar_por_nombre_y_estado(txtBusqueda.Text, true));
            }
            else
            {
                cargarDataGrid(repo.listar_por_nombre_y_estado(txtBusqueda.Text, false));
            }

        }


        private void limpiar()
        {
            txtBusqueda.Text = "";
            combo.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormUnidadDeMedida form = new FormUnidadDeMedida();
            form.ShowDialog();
            cargarDataGrid(repo.ObtenerDatos());
            limpiar();
        }
    }
}
