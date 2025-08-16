namespace Mantenimientos.Procesos
{
    partial class Facturacion
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
            this.panelPadre = new System.Windows.Forms.Panel();
            this.btnSig = new FontAwesome.Sharp.IconButton();
            this.btnAtr = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPag = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPag = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label.Location = new System.Drawing.Point(286, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(209, 24);
            this.label.TabIndex = 11;
            this.label.Text = "Facturacion de pedidos";
            // 
            // panelPadre
            // 
            this.panelPadre.AutoScroll = true;
            this.panelPadre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPadre.Location = new System.Drawing.Point(49, 36);
            this.panelPadre.Name = "panelPadre";
            this.panelPadre.Size = new System.Drawing.Size(626, 357);
            this.panelPadre.TabIndex = 12;
            // 
            // btnSig
            // 
            this.btnSig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnSig.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSig.FlatAppearance.BorderSize = 0;
            this.btnSig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSig.ForeColor = System.Drawing.Color.White;
            this.btnSig.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnSig.IconColor = System.Drawing.Color.White;
            this.btnSig.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSig.IconSize = 18;
            this.btnSig.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSig.Location = new System.Drawing.Point(66, 0);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(28, 21);
            this.btnSig.TabIndex = 29;
            this.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSig.UseVisualStyleBackColor = false;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(46, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Pagina";
            // 
            // comboPag
            // 
            this.comboPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPag.FormattingEnabled = true;
            this.comboPag.Location = new System.Drawing.Point(92, 396);
            this.comboPag.Name = "comboPag";
            this.comboPag.Size = new System.Drawing.Size(42, 21);
            this.comboPag.TabIndex = 34;
            this.comboPag.SelectedIndexChanged += new System.EventHandler(this.comboPag_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(140, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "de";
            // 
            // lblTotalPag
            // 
            this.lblTotalPag.AutoSize = true;
            this.lblTotalPag.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPag.Location = new System.Drawing.Point(165, 396);
            this.lblTotalPag.Name = "lblTotalPag";
            this.lblTotalPag.Size = new System.Drawing.Size(35, 13);
            this.lblTotalPag.TabIndex = 36;
            this.lblTotalPag.Text = "label3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnAtr);
            this.panel1.Controls.Add(this.btnSig);
            this.panel1.Location = new System.Drawing.Point(581, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 21);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPag);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(28, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 21);
            this.panel2.TabIndex = 31;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label3.Location = new System.Drawing.Point(45, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "Mesas";
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotalPag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboPag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPadre);
            this.Controls.Add(this.label);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.Shown += new System.EventHandler(this.Facturacion_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panelPadre;
        public FontAwesome.Sharp.IconButton btnSig;
        public FontAwesome.Sharp.IconButton btnAtr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPag;
        private System.Windows.Forms.Label label3;
    }
}