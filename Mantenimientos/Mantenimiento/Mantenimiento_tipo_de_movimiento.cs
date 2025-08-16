using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mantenimientos
{
    public partial class Mantenimiento_tipo_de_movimiento : Mantenimiento
    {
        public Mantenimiento_tipo_de_movimiento()
        {
            InitializeComponent();
        }
        public void actualizar()
        {
            txtBusqueda.Text = "";
            combo.SelectedIndex = 0;
            cargarDataGrid(repositorio.ObtenerDatos());
        }

        private void cargarDataGrid(List<tipo_movimiento> tipo_Movimientos)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            //Sirve para quitar primera columna a la izquiera que solo sirve para seleccionar items
            dataGrid.RowHeadersVisible = false;
            //Sirve para quitar la ultima fila por defecto
            dataGrid.AllowUserToAddRows = false;
            dataGrid.DefaultCellStyle.ForeColor = Color.Black; // Puedes usar cualquier color
            //definir la cabecera de las columnas
            dataGrid.Columns.Add("colId", "id");
            dataGrid.Columns.Add("colDescripcion", "Descripcion");
            dataGrid.Columns.Add("colAfectaStock", "Afecta Stock");


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
            foreach (tipo_movimiento m in tipo_Movimientos)
            {

                if (m.Estado)
                {
                    if (m.Afecta_stock == 1)
                    {
                        dataGrid.Rows.Add(m.Id, m.Descripcion, "Entrada", Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
                    }
                    else
                    {
                        dataGrid.Rows.Add(m.Id, m.Descripcion, "Salida", Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\eye.png"));
                    }

                }
                else
                {
                    if (m.Afecta_stock == 1)
                    {
                        dataGrid.Rows.Add(m.Id, m.Descripcion, "Entrada", Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\hidden.png"));
                    }
                    else
                    {
                        dataGrid.Rows.Add(m.Id, m.Descripcion, "Salida", Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\pen.png"), Image.FromFile("C:\\Users\\elmen\\Desktop\\imagenes\\hidden.png"));
                    }

                }
            }

        }
        Repositorio_tipo_movimiento repositorio = new Repositorio_tipo_movimiento();
        private void Mantenimiento_tipo_de_movimiento_Load(object sender, EventArgs e)
        {
            cargarDataGrid(repositorio.ObtenerDatos());
            combo.Items.AddRange(new String[] { "Todo", "Activos", "Inactivos" });
            combo.SelectedIndex = 0;
            dataGrid.CellDoubleClick += _CellClick;

        }


        private void _CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string valor = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                // MessageBox.Show("Valor clickeado: " + dataGrid.Columns[e.ColumnIndex].HeaderText);
                int id = Convert.ToInt32(dataGrid.Rows[e.RowIndex].Cells["colId"].Value);

                tipo_movimiento tipo = repositorio.buscarPorId(id);



                if (dataGrid.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    Form_tipo_de_movimiento form = new Form_tipo_de_movimiento(this, tipo);
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
                        if (tipo.Estado)
                        {
                            repositorio.desahabilitar(tipo);
                            //cargarDataGridEnFuncionDelaOpcion();
                        }
                        else
                        {
                            repositorio.habilitar(tipo);
                            //cargarDataGridEnFuncionDelaOpcion();
                        }
                        //Dejar seleccionada la celda
                        actualizar();
                        dataGrid.ClearSelection();
                        dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                        dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    }
                }
            }
        }




        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String texto = combo.SelectedItem.ToString();

            if (texto == "Todo")
            {
                cargarDataGrid(repositorio.ObtenerDatos());
            }
            else if (texto == "Activos")
            {
                cargarDataGrid(repositorio.ObtenerPorEstado(true));
            }
            else
            {
                cargarDataGrid(repositorio.ObtenerPorEstado(false));
            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            String texto = combo.SelectedItem.ToString();

            if (texto == "Todo")
            {
                cargarDataGrid(repositorio.obtener_por_descripcion(txtBusqueda.Text));
            }
            else if (texto == "Activos")
            {
                cargarDataGrid(repositorio.obtener_por_descripcion_y_estado(txtBusqueda.Text, true));
            }
            else
            {
                cargarDataGrid(repositorio.obtener_por_descripcion_y_estado(txtBusqueda.Text, false));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form_tipo_de_movimiento form = new Form_tipo_de_movimiento(this);
            form.ShowDialog();
        }
    }
}
