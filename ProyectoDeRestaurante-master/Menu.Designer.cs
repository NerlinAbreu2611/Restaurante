namespace WindowsFormsApp2
{
    partial class Menu
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnMaximizar = new FontAwesome.Sharp.IconButton();
            this.btnMinimizar = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelCxC = new System.Windows.Forms.Panel();
            this.btnReportesCxC = new FontAwesome.Sharp.IconButton();
            this.btnMantenimientoCxC = new FontAwesome.Sharp.IconButton();
            this.btnProcesosCxC = new FontAwesome.Sharp.IconButton();
            this.btnCxC = new FontAwesome.Sharp.IconButton();
            this.panelInventario = new System.Windows.Forms.Panel();
            this.btnReportesInventario = new FontAwesome.Sharp.IconButton();
            this.btnConsultasInventario = new FontAwesome.Sharp.IconButton();
            this.btnMantenimientoInventario = new FontAwesome.Sharp.IconButton();
            this.btnProcesosInventario = new FontAwesome.Sharp.IconButton();
            this.btnInventario = new FontAwesome.Sharp.IconButton();
            this.panelRestaurante = new System.Windows.Forms.Panel();
            this.btnMantenimientoRestaurante = new FontAwesome.Sharp.IconButton();
            this.btnProcesosRestaurante = new FontAwesome.Sharp.IconButton();
            this.btnRestaurante = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelPadre = new System.Windows.Forms.Panel();
            this.dpmProcesosRestaurante = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmMantenimientoRestaurante = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmMantenimientoInventario = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesDeMedidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeMovimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmProcesosInventario = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.registroDeMovimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmReportesInventario = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.stockActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasYSalidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmMantenimientoCxC = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmProcesosCxC = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmReportesCxC = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.dpmConsultasInventario = new WindowsFormsApp2.componentes.DropDownMenu(this.components);
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelCxC.SuspendLayout();
            this.panelInventario.SuspendLayout();
            this.panelRestaurante.SuspendLayout();
            this.dpmProcesosRestaurante.SuspendLayout();
            this.dpmMantenimientoRestaurante.SuspendLayout();
            this.dpmMantenimientoInventario.SuspendLayout();
            this.dpmProcesosInventario.SuspendLayout();
            this.dpmReportesInventario.SuspendLayout();
            this.dpmMantenimientoCxC.SuspendLayout();
            this.dpmProcesosCxC.SuspendLayout();
            this.dpmReportesCxC.SuspendLayout();
            this.dpmConsultasInventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 32);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.btnMaximizar);
            this.panel2.Controls.Add(this.btnMinimizar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(846, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 32);
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
            this.btnCerrar.Location = new System.Drawing.Point(50, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 32);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.IconChar = FontAwesome.Sharp.IconChar.SquareFull;
            this.btnMaximizar.IconColor = System.Drawing.Color.White;
            this.btnMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximizar.IconSize = 21;
            this.btnMaximizar.Location = new System.Drawing.Point(25, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(25, 32);
            this.btnMaximizar.TabIndex = 1;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
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
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel3.Controls.Add(this.panelCxC);
            this.panel3.Controls.Add(this.btnCxC);
            this.panel3.Controls.Add(this.panelInventario);
            this.panel3.Controls.Add(this.btnInventario);
            this.panel3.Controls.Add(this.panelRestaurante);
            this.panel3.Controls.Add(this.btnRestaurante);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 451);
            this.panel3.TabIndex = 9;
            // 
            // panelCxC
            // 
            this.panelCxC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelCxC.Controls.Add(this.btnReportesCxC);
            this.panelCxC.Controls.Add(this.btnMantenimientoCxC);
            this.panelCxC.Controls.Add(this.btnProcesosCxC);
            this.panelCxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCxC.Location = new System.Drawing.Point(0, 508);
            this.panelCxC.Name = "panelCxC";
            this.panelCxC.Size = new System.Drawing.Size(183, 135);
            this.panelCxC.TabIndex = 16;
            // 
            // btnReportesCxC
            // 
            this.btnReportesCxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportesCxC.FlatAppearance.BorderSize = 0;
            this.btnReportesCxC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnReportesCxC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportesCxC.ForeColor = System.Drawing.Color.White;
            this.btnReportesCxC.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.btnReportesCxC.IconColor = System.Drawing.Color.White;
            this.btnReportesCxC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReportesCxC.IconSize = 32;
            this.btnReportesCxC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportesCxC.Location = new System.Drawing.Point(0, 90);
            this.btnReportesCxC.Name = "btnReportesCxC";
            this.btnReportesCxC.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReportesCxC.Size = new System.Drawing.Size(183, 45);
            this.btnReportesCxC.TabIndex = 6;
            this.btnReportesCxC.Text = "Reportes";
            this.btnReportesCxC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportesCxC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportesCxC.UseVisualStyleBackColor = true;
            // 
            // btnMantenimientoCxC
            // 
            this.btnMantenimientoCxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMantenimientoCxC.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoCxC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnMantenimientoCxC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoCxC.ForeColor = System.Drawing.Color.White;
            this.btnMantenimientoCxC.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.btnMantenimientoCxC.IconColor = System.Drawing.Color.White;
            this.btnMantenimientoCxC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMantenimientoCxC.IconSize = 32;
            this.btnMantenimientoCxC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimientoCxC.Location = new System.Drawing.Point(0, 45);
            this.btnMantenimientoCxC.Name = "btnMantenimientoCxC";
            this.btnMantenimientoCxC.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnMantenimientoCxC.Size = new System.Drawing.Size(183, 45);
            this.btnMantenimientoCxC.TabIndex = 4;
            this.btnMantenimientoCxC.Text = "Mantenimiento";
            this.btnMantenimientoCxC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMantenimientoCxC.UseVisualStyleBackColor = true;
            // 
            // btnProcesosCxC
            // 
            this.btnProcesosCxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcesosCxC.FlatAppearance.BorderSize = 0;
            this.btnProcesosCxC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnProcesosCxC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesosCxC.ForeColor = System.Drawing.Color.White;
            this.btnProcesosCxC.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnProcesosCxC.IconColor = System.Drawing.Color.White;
            this.btnProcesosCxC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesosCxC.IconSize = 32;
            this.btnProcesosCxC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesosCxC.Location = new System.Drawing.Point(0, 0);
            this.btnProcesosCxC.Name = "btnProcesosCxC";
            this.btnProcesosCxC.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProcesosCxC.Size = new System.Drawing.Size(183, 45);
            this.btnProcesosCxC.TabIndex = 3;
            this.btnProcesosCxC.Text = "Procesos";
            this.btnProcesosCxC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesosCxC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesosCxC.UseVisualStyleBackColor = true;
            // 
            // btnCxC
            // 
            this.btnCxC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCxC.FlatAppearance.BorderSize = 0;
            this.btnCxC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCxC.ForeColor = System.Drawing.Color.White;
            this.btnCxC.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.btnCxC.IconColor = System.Drawing.Color.White;
            this.btnCxC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCxC.IconSize = 32;
            this.btnCxC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCxC.Location = new System.Drawing.Point(0, 463);
            this.btnCxC.Name = "btnCxC";
            this.btnCxC.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCxC.Size = new System.Drawing.Size(183, 45);
            this.btnCxC.TabIndex = 15;
            this.btnCxC.Text = "Cuentas por Cobrar";
            this.btnCxC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCxC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCxC.UseVisualStyleBackColor = true;
            this.btnCxC.Click += new System.EventHandler(this.btnCxC_Click);
            // 
            // panelInventario
            // 
            this.panelInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelInventario.Controls.Add(this.btnReportesInventario);
            this.panelInventario.Controls.Add(this.btnConsultasInventario);
            this.panelInventario.Controls.Add(this.btnMantenimientoInventario);
            this.panelInventario.Controls.Add(this.btnProcesosInventario);
            this.panelInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInventario.Location = new System.Drawing.Point(0, 283);
            this.panelInventario.Name = "panelInventario";
            this.panelInventario.Size = new System.Drawing.Size(183, 180);
            this.panelInventario.TabIndex = 14;
            // 
            // btnReportesInventario
            // 
            this.btnReportesInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportesInventario.FlatAppearance.BorderSize = 0;
            this.btnReportesInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnReportesInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportesInventario.ForeColor = System.Drawing.Color.White;
            this.btnReportesInventario.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.btnReportesInventario.IconColor = System.Drawing.Color.White;
            this.btnReportesInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReportesInventario.IconSize = 32;
            this.btnReportesInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportesInventario.Location = new System.Drawing.Point(0, 135);
            this.btnReportesInventario.Name = "btnReportesInventario";
            this.btnReportesInventario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReportesInventario.Size = new System.Drawing.Size(183, 45);
            this.btnReportesInventario.TabIndex = 6;
            this.btnReportesInventario.Text = "Reportes";
            this.btnReportesInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportesInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportesInventario.UseVisualStyleBackColor = true;
            // 
            // btnConsultasInventario
            // 
            this.btnConsultasInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultasInventario.FlatAppearance.BorderSize = 0;
            this.btnConsultasInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnConsultasInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultasInventario.ForeColor = System.Drawing.Color.White;
            this.btnConsultasInventario.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnConsultasInventario.IconColor = System.Drawing.Color.White;
            this.btnConsultasInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsultasInventario.IconSize = 32;
            this.btnConsultasInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultasInventario.Location = new System.Drawing.Point(0, 90);
            this.btnConsultasInventario.Name = "btnConsultasInventario";
            this.btnConsultasInventario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnConsultasInventario.Size = new System.Drawing.Size(183, 45);
            this.btnConsultasInventario.TabIndex = 5;
            this.btnConsultasInventario.Text = "Consultas";
            this.btnConsultasInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultasInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultasInventario.UseVisualStyleBackColor = true;
            // 
            // btnMantenimientoInventario
            // 
            this.btnMantenimientoInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMantenimientoInventario.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnMantenimientoInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoInventario.ForeColor = System.Drawing.Color.White;
            this.btnMantenimientoInventario.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.btnMantenimientoInventario.IconColor = System.Drawing.Color.White;
            this.btnMantenimientoInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMantenimientoInventario.IconSize = 32;
            this.btnMantenimientoInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimientoInventario.Location = new System.Drawing.Point(0, 45);
            this.btnMantenimientoInventario.Name = "btnMantenimientoInventario";
            this.btnMantenimientoInventario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnMantenimientoInventario.Size = new System.Drawing.Size(183, 45);
            this.btnMantenimientoInventario.TabIndex = 4;
            this.btnMantenimientoInventario.Text = "Mantenimiento";
            this.btnMantenimientoInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMantenimientoInventario.UseVisualStyleBackColor = true;
            // 
            // btnProcesosInventario
            // 
            this.btnProcesosInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcesosInventario.FlatAppearance.BorderSize = 0;
            this.btnProcesosInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnProcesosInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesosInventario.ForeColor = System.Drawing.Color.White;
            this.btnProcesosInventario.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnProcesosInventario.IconColor = System.Drawing.Color.White;
            this.btnProcesosInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesosInventario.IconSize = 32;
            this.btnProcesosInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesosInventario.Location = new System.Drawing.Point(0, 0);
            this.btnProcesosInventario.Name = "btnProcesosInventario";
            this.btnProcesosInventario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProcesosInventario.Size = new System.Drawing.Size(183, 45);
            this.btnProcesosInventario.TabIndex = 3;
            this.btnProcesosInventario.Text = "Procesos";
            this.btnProcesosInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesosInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesosInventario.UseVisualStyleBackColor = true;
            // 
            // btnInventario
            // 
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnInventario.IconColor = System.Drawing.Color.White;
            this.btnInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInventario.IconSize = 32;
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Location = new System.Drawing.Point(0, 238);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInventario.Size = new System.Drawing.Size(183, 45);
            this.btnInventario.TabIndex = 13;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // panelRestaurante
            // 
            this.panelRestaurante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelRestaurante.Controls.Add(this.btnMantenimientoRestaurante);
            this.panelRestaurante.Controls.Add(this.btnProcesosRestaurante);
            this.panelRestaurante.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRestaurante.Location = new System.Drawing.Point(0, 148);
            this.panelRestaurante.Name = "panelRestaurante";
            this.panelRestaurante.Size = new System.Drawing.Size(183, 90);
            this.panelRestaurante.TabIndex = 12;
            // 
            // btnMantenimientoRestaurante
            // 
            this.btnMantenimientoRestaurante.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMantenimientoRestaurante.FlatAppearance.BorderSize = 0;
            this.btnMantenimientoRestaurante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnMantenimientoRestaurante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimientoRestaurante.ForeColor = System.Drawing.Color.White;
            this.btnMantenimientoRestaurante.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.btnMantenimientoRestaurante.IconColor = System.Drawing.Color.White;
            this.btnMantenimientoRestaurante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMantenimientoRestaurante.IconSize = 32;
            this.btnMantenimientoRestaurante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenimientoRestaurante.Location = new System.Drawing.Point(0, 45);
            this.btnMantenimientoRestaurante.Name = "btnMantenimientoRestaurante";
            this.btnMantenimientoRestaurante.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnMantenimientoRestaurante.Size = new System.Drawing.Size(183, 45);
            this.btnMantenimientoRestaurante.TabIndex = 4;
            this.btnMantenimientoRestaurante.Text = "Mantenimiento";
            this.btnMantenimientoRestaurante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMantenimientoRestaurante.UseVisualStyleBackColor = true;
            // 
            // btnProcesosRestaurante
            // 
            this.btnProcesosRestaurante.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcesosRestaurante.FlatAppearance.BorderSize = 0;
            this.btnProcesosRestaurante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.btnProcesosRestaurante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesosRestaurante.ForeColor = System.Drawing.Color.White;
            this.btnProcesosRestaurante.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnProcesosRestaurante.IconColor = System.Drawing.Color.White;
            this.btnProcesosRestaurante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesosRestaurante.IconSize = 32;
            this.btnProcesosRestaurante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesosRestaurante.Location = new System.Drawing.Point(0, 0);
            this.btnProcesosRestaurante.Name = "btnProcesosRestaurante";
            this.btnProcesosRestaurante.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProcesosRestaurante.Size = new System.Drawing.Size(183, 45);
            this.btnProcesosRestaurante.TabIndex = 3;
            this.btnProcesosRestaurante.Text = "Procesos";
            this.btnProcesosRestaurante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesosRestaurante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesosRestaurante.UseVisualStyleBackColor = true;
            // 
            // btnRestaurante
            // 
            this.btnRestaurante.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRestaurante.FlatAppearance.BorderSize = 0;
            this.btnRestaurante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurante.ForeColor = System.Drawing.Color.White;
            this.btnRestaurante.IconChar = FontAwesome.Sharp.IconChar.Utensils;
            this.btnRestaurante.IconColor = System.Drawing.Color.White;
            this.btnRestaurante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestaurante.IconSize = 32;
            this.btnRestaurante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurante.Location = new System.Drawing.Point(0, 103);
            this.btnRestaurante.Name = "btnRestaurante";
            this.btnRestaurante.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRestaurante.Size = new System.Drawing.Size(183, 45);
            this.btnRestaurante.TabIndex = 11;
            this.btnRestaurante.Text = "Restaurante";
            this.btnRestaurante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurante.UseVisualStyleBackColor = true;
            this.btnRestaurante.Click += new System.EventHandler(this.btnRestaurante_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 103);
            this.panel4.TabIndex = 10;
            // 
            // panelPadre
            // 
            this.panelPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPadre.Location = new System.Drawing.Point(200, 32);
            this.panelPadre.Name = "panelPadre";
            this.panelPadre.Size = new System.Drawing.Size(721, 451);
            this.panelPadre.TabIndex = 10;
            // 
            // dpmProcesosRestaurante
            // 
            this.dpmProcesosRestaurante.IsMainMenu = true;
            this.dpmProcesosRestaurante.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.holaToolStripMenuItem});
            this.dpmProcesosRestaurante.MenuItemHeaderSize = null;
            this.dpmProcesosRestaurante.MenuItemHeight = 25;
            this.dpmProcesosRestaurante.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmProcesosRestaurante.Name = "dropDownMenu1";
            this.dpmProcesosRestaurante.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmProcesosRestaurante.Size = new System.Drawing.Size(137, 26);
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            this.holaToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.holaToolStripMenuItem.Text = "Facturacion";
            // 
            // dpmMantenimientoRestaurante
            // 
            this.dpmMantenimientoRestaurante.IsMainMenu = true;
            this.dpmMantenimientoRestaurante.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.dpmMantenimientoRestaurante.MenuItemHeaderSize = null;
            this.dpmMantenimientoRestaurante.MenuItemHeight = 25;
            this.dpmMantenimientoRestaurante.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmMantenimientoRestaurante.Name = "dpmMantenimientoRestaurante";
            this.dpmMantenimientoRestaurante.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmMantenimientoRestaurante.Size = new System.Drawing.Size(133, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem1.Text = "Mesas";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem2.Text = "Empleados";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // dpmMantenimientoInventario
            // 
            this.dpmMantenimientoInventario.IsMainMenu = true;
            this.dpmMantenimientoInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.unidadesDeMedidaToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.tiposDeMovimientoToolStripMenuItem});
            this.dpmMantenimientoInventario.MenuItemHeaderSize = null;
            this.dpmMantenimientoInventario.MenuItemHeight = 25;
            this.dpmMantenimientoInventario.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmMantenimientoInventario.Name = "dropDownMenu1";
            this.dpmMantenimientoInventario.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmMantenimientoInventario.Size = new System.Drawing.Size(188, 114);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // unidadesDeMedidaToolStripMenuItem
            // 
            this.unidadesDeMedidaToolStripMenuItem.Name = "unidadesDeMedidaToolStripMenuItem";
            this.unidadesDeMedidaToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.unidadesDeMedidaToolStripMenuItem.Text = "Unidades de Medida";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // tiposDeMovimientoToolStripMenuItem
            // 
            this.tiposDeMovimientoToolStripMenuItem.Name = "tiposDeMovimientoToolStripMenuItem";
            this.tiposDeMovimientoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.tiposDeMovimientoToolStripMenuItem.Text = "Tipos de Movimiento";
            // 
            // dpmProcesosInventario
            // 
            this.dpmProcesosInventario.IsMainMenu = true;
            this.dpmProcesosInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroDeMovimientoToolStripMenuItem});
            this.dpmProcesosInventario.MenuItemHeaderSize = null;
            this.dpmProcesosInventario.MenuItemHeight = 25;
            this.dpmProcesosInventario.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmProcesosInventario.Name = "dpmProcesosInventario";
            this.dpmProcesosInventario.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmProcesosInventario.Size = new System.Drawing.Size(202, 26);
            // 
            // registroDeMovimientoToolStripMenuItem
            // 
            this.registroDeMovimientoToolStripMenuItem.Name = "registroDeMovimientoToolStripMenuItem";
            this.registroDeMovimientoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.registroDeMovimientoToolStripMenuItem.Text = "Registro de Movimiento";
            // 
            // dpmReportesInventario
            // 
            this.dpmReportesInventario.IsMainMenu = true;
            this.dpmReportesInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockActualToolStripMenuItem,
            this.entradasYSalidasToolStripMenuItem});
            this.dpmReportesInventario.MenuItemHeaderSize = null;
            this.dpmReportesInventario.MenuItemHeight = 25;
            this.dpmReportesInventario.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmReportesInventario.Name = "dpmReportesInventario";
            this.dpmReportesInventario.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmReportesInventario.Size = new System.Drawing.Size(168, 48);
            // 
            // stockActualToolStripMenuItem
            // 
            this.stockActualToolStripMenuItem.Name = "stockActualToolStripMenuItem";
            this.stockActualToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.stockActualToolStripMenuItem.Text = "Stock Actual";
            // 
            // entradasYSalidasToolStripMenuItem
            // 
            this.entradasYSalidasToolStripMenuItem.Name = "entradasYSalidasToolStripMenuItem";
            this.entradasYSalidasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.entradasYSalidasToolStripMenuItem.Text = "Entradas y Salidas";
            // 
            // dpmMantenimientoCxC
            // 
            this.dpmMantenimientoCxC.IsMainMenu = true;
            this.dpmMantenimientoCxC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.dpmMantenimientoCxC.MenuItemHeaderSize = null;
            this.dpmMantenimientoCxC.MenuItemHeight = 25;
            this.dpmMantenimientoCxC.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmMantenimientoCxC.Name = "dpmMantenimientoCxC";
            this.dpmMantenimientoCxC.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmMantenimientoCxC.Size = new System.Drawing.Size(187, 92);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem3.Text = "Clientes";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem4.Text = "Condiciones de pago";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem5.Text = "Metodos de pago";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // dpmProcesosCxC
            // 
            this.dpmProcesosCxC.IsMainMenu = true;
            this.dpmProcesosCxC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.dpmProcesosCxC.MenuItemHeaderSize = null;
            this.dpmProcesosCxC.MenuItemHeight = 25;
            this.dpmProcesosCxC.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmProcesosCxC.Name = "dpmProcesosCxC";
            this.dpmProcesosCxC.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmProcesosCxC.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem6.Text = "Registros de pagos";
            // 
            // dpmReportesCxC
            // 
            this.dpmReportesCxC.IsMainMenu = true;
            this.dpmReportesCxC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.dpmReportesCxC.MenuItemHeaderSize = null;
            this.dpmReportesCxC.MenuItemHeight = 25;
            this.dpmReportesCxC.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmReportesCxC.Name = "dpmReportesCxC";
            this.dpmReportesCxC.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmReportesCxC.Size = new System.Drawing.Size(238, 92);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem7.Text = "Cuentas por Cobrar";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem8.Text = "Estado de Cuenta";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem9.Text = "Cuentas Vencidas ";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(237, 22);
            this.toolStripMenuItem10.Text = "Resumen de Deuda por Cliente";
            // 
            // dpmConsultasInventario
            // 
            this.dpmConsultasInventario.IsMainMenu = true;
            this.dpmConsultasInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem1});
            this.dpmConsultasInventario.MenuItemHeaderSize = null;
            this.dpmConsultasInventario.MenuItemHeight = 25;
            this.dpmConsultasInventario.MenuItemTextColor = System.Drawing.Color.DimGray;
            this.dpmConsultasInventario.Name = "dpmConsultasInventario";
            this.dpmConsultasInventario.PrimaryColor = System.Drawing.Color.MediumSlateBlue;
            this.dpmConsultasInventario.Size = new System.Drawing.Size(129, 26);
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.productosToolStripMenuItem1.Text = "Productos";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 483);
            this.Controls.Add(this.panelPadre);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelCxC.ResumeLayout(false);
            this.panelInventario.ResumeLayout(false);
            this.panelRestaurante.ResumeLayout(false);
            this.dpmProcesosRestaurante.ResumeLayout(false);
            this.dpmMantenimientoRestaurante.ResumeLayout(false);
            this.dpmMantenimientoInventario.ResumeLayout(false);
            this.dpmProcesosInventario.ResumeLayout(false);
            this.dpmReportesInventario.ResumeLayout(false);
            this.dpmMantenimientoCxC.ResumeLayout(false);
            this.dpmProcesosCxC.ResumeLayout(false);
            this.dpmReportesCxC.ResumeLayout(false);
            this.dpmConsultasInventario.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private componentes.DropDownMenu dpmProcesosRestaurante;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private componentes.DropDownMenu dpmMantenimientoRestaurante;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesDeMedidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeMovimientoToolStripMenuItem;
        private componentes.DropDownMenu dpmMantenimientoInventario;
        private componentes.DropDownMenu dpmProcesosInventario;
        private System.Windows.Forms.ToolStripMenuItem registroDeMovimientoToolStripMenuItem;
        private componentes.DropDownMenu dpmReportesInventario;
        private System.Windows.Forms.ToolStripMenuItem stockActualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradasYSalidasToolStripMenuItem;
        private componentes.DropDownMenu dpmMantenimientoCxC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private componentes.DropDownMenu dpmProcesosCxC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private componentes.DropDownMenu dpmReportesCxC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private componentes.DropDownMenu dpmConsultasInventario;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private FontAwesome.Sharp.IconButton btnMaximizar;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnMinimizar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelInventario;
        private FontAwesome.Sharp.IconButton btnReportesInventario;
        private FontAwesome.Sharp.IconButton btnConsultasInventario;
        private FontAwesome.Sharp.IconButton btnMantenimientoInventario;
        private FontAwesome.Sharp.IconButton btnProcesosInventario;
        private FontAwesome.Sharp.IconButton btnInventario;
        private System.Windows.Forms.Panel panelRestaurante;
        private FontAwesome.Sharp.IconButton btnMantenimientoRestaurante;
        private FontAwesome.Sharp.IconButton btnProcesosRestaurante;
        private System.Windows.Forms.Panel panelCxC;
        private FontAwesome.Sharp.IconButton btnReportesCxC;
        private FontAwesome.Sharp.IconButton btnMantenimientoCxC;
        private FontAwesome.Sharp.IconButton btnProcesosCxC;
        private FontAwesome.Sharp.IconButton btnCxC;
        private FontAwesome.Sharp.IconButton btnRestaurante;
        private System.Windows.Forms.Panel panelPadre;
    }
}

