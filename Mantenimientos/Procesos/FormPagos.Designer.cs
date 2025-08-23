namespace Mantenimientos.Procesos
{
    partial class FormPagos
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
            this.label = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMetPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.btnSig = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCondicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaldoPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNota = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label.Location = new System.Drawing.Point(320, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(63, 24);
            this.label.TabIndex = 12;
            this.label.Text = "Pagos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColCliente,
            this.ColMesa,
            this.ColEmpleado,
            this.ColCondicion,
            this.ColFecha,
            this.ColFechaVencimiento,
            this.ColTotal,
            this.ColSaldoPendiente});
            this.dataGridView1.Location = new System.Drawing.Point(17, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(651, 254);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Location = new System.Drawing.Point(17, 72);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(121, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(184, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Metodo de pago";
            // 
            // comboMetPago
            // 
            this.comboMetPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMetPago.FormattingEnabled = true;
            this.comboMetPago.Location = new System.Drawing.Point(184, 72);
            this.comboMetPago.Name = "comboMetPago";
            this.comboMetPago.Size = new System.Drawing.Size(121, 21);
            this.comboMetPago.TabIndex = 17;
            this.comboMetPago.SelectedIndexChanged += new System.EventHandler(this.comboMetPago_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total";
            // 
            // txtPago
            // 
            this.txtPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPago.Location = new System.Drawing.Point(51, 358);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(100, 20);
            this.txtPago.TabIndex = 19;
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
            this.btnSig.Location = new System.Drawing.Point(144, 61);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(34, 31);
            this.btnSig.TabIndex = 31;
            this.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSig.UseVisualStyleBackColor = false;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label4.Location = new System.Drawing.Point(493, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "Ordenes del cliente";
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
            this.iconButton4.Location = new System.Drawing.Point(577, 358);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(91, 31);
            this.iconButton4.TabIndex = 45;
            this.iconButton4.Text = "Procesar";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = false;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
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
            this.iconButton5.Location = new System.Drawing.Point(480, 358);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(91, 31);
            this.iconButton5.TabIndex = 46;
            this.iconButton5.Text = "Limpiar";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = false;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "id orden";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // ColCliente
            // 
            this.ColCliente.HeaderText = "Id cliente";
            this.ColCliente.Name = "ColCliente";
            this.ColCliente.ReadOnly = true;
            this.ColCliente.Visible = false;
            // 
            // ColMesa
            // 
            this.ColMesa.HeaderText = "No.Mesa";
            this.ColMesa.Name = "ColMesa";
            this.ColMesa.ReadOnly = true;
            // 
            // ColEmpleado
            // 
            this.ColEmpleado.HeaderText = "Atendido por";
            this.ColEmpleado.Name = "ColEmpleado";
            this.ColEmpleado.ReadOnly = true;
            // 
            // ColCondicion
            // 
            this.ColCondicion.HeaderText = "Condicion";
            this.ColCondicion.Name = "ColCondicion";
            this.ColCondicion.ReadOnly = true;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            // 
            // ColFechaVencimiento
            // 
            this.ColFechaVencimiento.HeaderText = "Fecha de vencimiento";
            this.ColFechaVencimiento.Name = "ColFechaVencimiento";
            this.ColFechaVencimiento.ReadOnly = true;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            // 
            // ColSaldoPendiente
            // 
            this.ColSaldoPendiente.HeaderText = "SaldoPendiente";
            this.ColSaldoPendiente.Name = "ColSaldoPendiente";
            this.ColSaldoPendiente.ReadOnly = true;
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
            this.btnNota.Location = new System.Drawing.Point(311, 62);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(34, 31);
            this.btnNota.TabIndex = 47;
            this.btnNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNota.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNota.UseVisualStyleBackColor = false;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // FormPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 412);
            this.Controls.Add(this.btnNota);
            this.Controls.Add(this.iconButton5);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSig);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboMetPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label);
            this.Name = "FormPagos";
            this.Text = "FormPagos";
            this.Load += new System.EventHandler(this.FormPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMetPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPago;
        public FontAwesome.Sharp.IconButton btnSig;
        private System.Windows.Forms.Label label4;
        public FontAwesome.Sharp.IconButton iconButton4;
        public FontAwesome.Sharp.IconButton iconButton5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaldoPendiente;
        public FontAwesome.Sharp.IconButton btnNota;
    }
}