namespace Mantenimientos.Procesos
{
    partial class FormOrden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrden));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnMinimizar = new FontAwesome.Sharp.IconButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnPrecuenta = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.lblTotalPag = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboPag = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtPag = new System.Windows.Forms.TextBox();
            this.btnAtr = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSig = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNota = new FontAwesome.Sharp.IconButton();
            this.comboMetodoDePago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(18)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 32);
            this.panel1.TabIndex = 13;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.btnMinimizar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(823, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(55, 32);
            this.panel2.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnCerrar.IconColor = System.Drawing.Color.White;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 21;
            this.btnCerrar.Location = new System.Drawing.Point(25, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 32);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimizar.IconColor = System.Drawing.Color.White;
            this.btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimizar.IconSize = 21;
            this.btnMinimizar.Location = new System.Drawing.Point(0, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 32);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.lblTitulo.Location = new System.Drawing.Point(413, 44);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(98, 24);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Mesa no.3";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.lblTotalPag);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboPag);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.txtBusqueda);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panelProducto);
            this.panel3.Location = new System.Drawing.Point(525, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(345, 435);
            this.panel3.TabIndex = 15;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.btnPrecuenta);
            this.panel12.Controls.Add(this.iconButton5);
            this.panel12.Controls.Add(this.iconButton4);
            this.panel12.Location = new System.Drawing.Point(22, 374);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(305, 50);
            this.panel12.TabIndex = 43;
            // 
            // btnPrecuenta
            // 
            this.btnPrecuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnPrecuenta.FlatAppearance.BorderSize = 0;
            this.btnPrecuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrecuenta.ForeColor = System.Drawing.Color.White;
            this.btnPrecuenta.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnPrecuenta.IconColor = System.Drawing.Color.White;
            this.btnPrecuenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrecuenta.IconSize = 24;
            this.btnPrecuenta.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPrecuenta.Location = new System.Drawing.Point(106, 9);
            this.btnPrecuenta.Name = "btnPrecuenta";
            this.btnPrecuenta.Size = new System.Drawing.Size(91, 31);
            this.btnPrecuenta.TabIndex = 46;
            this.btnPrecuenta.Text = "Precuenta";
            this.btnPrecuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrecuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrecuenta.UseVisualStyleBackColor = false;
            this.btnPrecuenta.Click += new System.EventHandler(this.btnPrecuenta_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.ForeColor = System.Drawing.Color.White;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.iconButton5.IconColor = System.Drawing.Color.White;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 24;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.iconButton5.Location = new System.Drawing.Point(9, 8);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(91, 31);
            this.iconButton5.TabIndex = 45;
            this.iconButton5.Text = "Limpiar";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = false;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.ForeColor = System.Drawing.Color.White;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.iconButton4.IconColor = System.Drawing.Color.White;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 24;
            this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.iconButton4.Location = new System.Drawing.Point(205, 8);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(91, 31);
            this.iconButton4.TabIndex = 44;
            this.iconButton4.Text = "Procesar";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = false;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // lblTotalPag
            // 
            this.lblTotalPag.AutoSize = true;
            this.lblTotalPag.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPag.Location = new System.Drawing.Point(136, 338);
            this.lblTotalPag.Name = "lblTotalPag";
            this.lblTotalPag.Size = new System.Drawing.Size(35, 13);
            this.lblTotalPag.TabIndex = 42;
            this.lblTotalPag.Text = "label3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(111, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "de";
            // 
            // comboPag
            // 
            this.comboPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPag.FormattingEnabled = true;
            this.comboPag.Location = new System.Drawing.Point(63, 338);
            this.comboPag.Name = "comboPag";
            this.comboPag.Size = new System.Drawing.Size(42, 21);
            this.comboPag.TabIndex = 40;
            this.comboPag.SelectedIndexChanged += new System.EventHandler(this.comboPag_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(17, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Pagina";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Buscar Producto";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.btnAtr);
            this.panel10.Controls.Add(this.iconButton2);
            this.panel10.Location = new System.Drawing.Point(233, 337);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(94, 21);
            this.panel10.TabIndex = 38;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtPag);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(28, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(38, 21);
            this.panel11.TabIndex = 31;
            // 
            // txtPag
            // 
            this.txtPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPag.Enabled = false;
            this.txtPag.Location = new System.Drawing.Point(0, 0);
            this.txtPag.Multiline = true;
            this.txtPag.Name = "txtPag";
            this.txtPag.Size = new System.Drawing.Size(38, 21);
            this.txtPag.TabIndex = 38;
            // 
            // btnAtr
            // 
            this.btnAtr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnAtr.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAtr.FlatAppearance.BorderSize = 0;
            this.btnAtr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtr.ForeColor = System.Drawing.Color.White;
            this.btnAtr.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnAtr.IconColor = System.Drawing.Color.White;
            this.btnAtr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAtr.IconSize = 18;
            this.btnAtr.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAtr.Location = new System.Drawing.Point(0, 0);
            this.btnAtr.Name = "btnAtr";
            this.btnAtr.Size = new System.Drawing.Size(28, 21);
            this.btnAtr.TabIndex = 30;
            this.btnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtr.UseVisualStyleBackColor = false;
            this.btnAtr.Click += new System.EventHandler(this.btnAtr_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 18;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.iconButton2.Location = new System.Drawing.Point(66, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(28, 21);
            this.iconButton2.TabIndex = 29;
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Location = new System.Drawing.Point(22, 50);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(305, 20);
            this.txtBusqueda.TabIndex = 37;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label4.Location = new System.Drawing.Point(132, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "Productos";
            // 
            // panelProducto
            // 
            this.panelProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProducto.Location = new System.Drawing.Point(22, 76);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(305, 255);
            this.panelProducto.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCantidad,
            this.ColProducto,
            this.ColPrecio,
            this.ColSubTotal,
            this.ColEliminar});
            this.dataGridView1.Location = new System.Drawing.Point(26, 234);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(493, 269);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // ColProducto
            // 
            this.ColProducto.HeaderText = "Producto";
            this.ColProducto.Name = "ColProducto";
            // 
            // ColPrecio
            // 
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.Name = "ColPrecio";
            // 
            // ColSubTotal
            // 
            this.ColSubTotal.HeaderText = "Subtotal";
            this.ColSubTotal.Name = "ColSubTotal";
            // 
            // ColEliminar
            // 
            this.ColEliminar.HeaderText = "Eliminar";
            this.ColEliminar.Image = ((System.Drawing.Image)(resources.GetObject("ColEliminar.Image")));
            this.ColEliminar.Name = "ColEliminar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(370, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Detalle de orden";
            // 
            // btnSig
            // 
            this.btnSig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnSig.FlatAppearance.BorderSize = 0;
            this.btnSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSig.ForeColor = System.Drawing.Color.White;
            this.btnSig.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnSig.IconColor = System.Drawing.Color.White;
            this.btnSig.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSig.IconSize = 24;
            this.btnSig.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSig.Location = new System.Drawing.Point(262, 21);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(34, 31);
            this.btnSig.TabIndex = 30;
            this.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSig.UseVisualStyleBackColor = false;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnNota);
            this.panel4.Controls.Add(this.comboMetodoDePago);
            this.panel4.Controls.Add(this.lblMetodoPago);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtCondicion);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtEmpleado);
            this.panel4.Controls.Add(this.iconButton1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtCliente);
            this.panel4.Controls.Add(this.btnSig);
            this.panel4.Location = new System.Drawing.Point(26, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(312, 190);
            this.panel4.TabIndex = 0;
            // 
            // btnNota
            // 
            this.btnNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnNota.FlatAppearance.BorderSize = 0;
            this.btnNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNota.ForeColor = System.Drawing.Color.White;
            this.btnNota.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.btnNota.IconColor = System.Drawing.Color.White;
            this.btnNota.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNota.IconSize = 24;
            this.btnNota.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNota.Location = new System.Drawing.Point(179, 140);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(34, 31);
            this.btnNota.TabIndex = 41;
            this.btnNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNota.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnNota, "Agregar nota");
            this.btnNota.UseVisualStyleBackColor = false;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // comboMetodoDePago
            // 
            this.comboMetodoDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMetodoDePago.FormattingEnabled = true;
            this.comboMetodoDePago.Location = new System.Drawing.Point(21, 150);
            this.comboMetodoDePago.Name = "comboMetodoDePago";
            this.comboMetodoDePago.Size = new System.Drawing.Size(141, 21);
            this.comboMetodoDePago.TabIndex = 40;
            this.comboMetodoDePago.SelectedIndexChanged += new System.EventHandler(this.comboMetodoDePago_SelectedIndexChanged);
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(18, 134);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(85, 13);
            this.lblMetodoPago.TabIndex = 39;
            this.lblMetodoPago.Text = "Metodo de pago";
            this.lblMetodoPago.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Condicion";
            // 
            // txtCondicion
            // 
            this.txtCondicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCondicion.Enabled = false;
            this.txtCondicion.Location = new System.Drawing.Point(21, 111);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(235, 20);
            this.txtCondicion.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Empleado";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpleado.Enabled = false;
            this.txtEmpleado.Location = new System.Drawing.Point(21, 72);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(235, 20);
            this.txtEmpleado.TabIndex = 34;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 24;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.iconButton1.Location = new System.Drawing.Point(262, 61);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(34, 31);
            this.iconButton1.TabIndex = 33;
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(21, 32);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(235, 20);
            this.txtCliente.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 506);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(454, 506);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(65, 20);
            this.txtTotal.TabIndex = 20;
            // 
            // FormOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 542);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFactura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrden_FormClosing);
            this.Load += new System.EventHandler(this.FormOrden_Load);
            this.Shown += new System.EventHandler(this.FormOrden_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnMinimizar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        public FontAwesome.Sharp.IconButton btnSig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpleado;
        public FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtPag;
        public FontAwesome.Sharp.IconButton btnAtr;
        public FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblTotalPag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboPag;
        private System.Windows.Forms.Label label8;
        public FontAwesome.Sharp.IconButton iconButton5;
        public FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubTotal;
        private System.Windows.Forms.DataGridViewImageColumn ColEliminar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox comboMetodoDePago;
        public FontAwesome.Sharp.IconButton btnNota;
        private System.Windows.Forms.ToolTip toolTip1;
        public FontAwesome.Sharp.IconButton btnPrecuenta;
    }
}