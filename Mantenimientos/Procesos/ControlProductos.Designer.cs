namespace Mantenimientos.Procesos
{
    partial class ControlProductos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.fotoProducto = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.btnMin = new FontAwesome.Sharp.IconButton();
            this.btnMas = new FontAwesome.Sharp.IconButton();
            this.lblPrecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fotoProducto)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fotoProducto
            // 
            this.fotoProducto.Location = new System.Drawing.Point(14, 3);
            this.fotoProducto.Name = "fotoProducto";
            this.fotoProducto.Size = new System.Drawing.Size(100, 50);
            this.fotoProducto.TabIndex = 0;
            this.fotoProducto.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(11, 56);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Controls.Add(this.btnMas);
            this.panel1.Location = new System.Drawing.Point(14, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 21);
            this.panel1.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCant);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(28, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 21);
            this.panel2.TabIndex = 31;
            // 
            // txtCant
            // 
            this.txtCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCant.Enabled = false;
            this.txtCant.Location = new System.Drawing.Point(0, 0);
            this.txtCant.Multiline = true;
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(38, 21);
            this.txtCant.TabIndex = 38;
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMin.IconColor = System.Drawing.Color.White;
            this.btnMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMin.IconSize = 18;
            this.btnMin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMin.Location = new System.Drawing.Point(0, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(28, 21);
            this.btnMin.TabIndex = 30;
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMas
            // 
            this.btnMas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnMas.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMas.FlatAppearance.BorderSize = 0;
            this.btnMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMas.ForeColor = System.Drawing.Color.White;
            this.btnMas.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnMas.IconColor = System.Drawing.Color.White;
            this.btnMas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMas.IconSize = 18;
            this.btnMas.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMas.Location = new System.Drawing.Point(66, 0);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(28, 21);
            this.btnMas.TabIndex = 29;
            this.btnMas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMas.UseVisualStyleBackColor = false;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(11, 72);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(35, 13);
            this.lblPrecio.TabIndex = 39;
            this.lblPrecio.Text = "label2";
            // 
            // ControlProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.fotoProducto);
            this.Name = "ControlProductos";
            this.Size = new System.Drawing.Size(126, 112);
            this.Load += new System.EventHandler(this.ControlProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fotoProducto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fotoProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCant;
        public FontAwesome.Sharp.IconButton btnMin;
        public FontAwesome.Sharp.IconButton btnMas;
        private System.Windows.Forms.Label lblPrecio;


    }
}
