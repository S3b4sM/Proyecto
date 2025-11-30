namespace GUI.UserControls
{
    partial class UserCHome
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.newPanel7 = new GUI.NewPanel();
            this.dgvUltimosMovs = new System.Windows.Forms.DataGridView();
            this.dgvUltimosPedidos = new System.Windows.Forms.DataGridView();
            this.lblTabMovs = new System.Windows.Forms.Label();
            this.lblTabPedidos = new System.Windows.Forms.Label();
            this.newPanel6 = new GUI.NewPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.cpee = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label17 = new System.Windows.Forms.Label();
            this.newPanel5 = new GUI.NewPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.newPanel4 = new GUI.NewPanel();
            this.lblClientes1 = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.newPanel3 = new GUI.NewPanel();
            this.lblEgresos1 = new System.Windows.Forms.Label();
            this.lblEgresos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.newPanel2 = new GUI.NewPanel();
            this.lblIngresos1 = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.newPanel1 = new GUI.NewPanel();
            this.lblPedidos1 = new System.Windows.Forms.Label();
            this.lblPedidos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReport = new GUI.NewButton();
            this.newPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosMovs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosPedidos)).BeginInit();
            this.newPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpee)).BeginInit();
            this.newPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cp)).BeginInit();
            this.newPanel4.SuspendLayout();
            this.newPanel3.SuspendLayout();
            this.newPanel2.SuspendLayout();
            this.newPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard Principal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(522, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Resumen de la actividad reciente de tu negocio";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // newPanel7
            // 
            this.newPanel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.newPanel7.BackColor = System.Drawing.Color.White;
            this.newPanel7.BackgroundColor = System.Drawing.Color.White;
            this.newPanel7.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel7.BorderRadius = 20;
            this.newPanel7.BorderSize = 0;
            this.newPanel7.Controls.Add(this.dgvUltimosMovs);
            this.newPanel7.Controls.Add(this.dgvUltimosPedidos);
            this.newPanel7.Controls.Add(this.lblTabMovs);
            this.newPanel7.Controls.Add(this.lblTabPedidos);
            this.newPanel7.Location = new System.Drawing.Point(26, 552);
            this.newPanel7.Name = "newPanel7";
            this.newPanel7.Size = new System.Drawing.Size(1141, 172);
            this.newPanel7.TabIndex = 13;
            // 
            // dgvUltimosMovs
            // 
            this.dgvUltimosMovs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUltimosMovs.BackgroundColor = System.Drawing.Color.White;
            this.dgvUltimosMovs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUltimosMovs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUltimosMovs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUltimosMovs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUltimosMovs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUltimosMovs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUltimosMovs.EnableHeadersVisualStyles = false;
            this.dgvUltimosMovs.Location = new System.Drawing.Point(21, 46);
            this.dgvUltimosMovs.Name = "dgvUltimosMovs";
            this.dgvUltimosMovs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUltimosMovs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUltimosMovs.RowHeadersVisible = false;
            this.dgvUltimosMovs.Size = new System.Drawing.Size(1105, 123);
            this.dgvUltimosMovs.TabIndex = 3;
            this.dgvUltimosMovs.Visible = false;
            // 
            // dgvUltimosPedidos
            // 
            this.dgvUltimosPedidos.AllowUserToAddRows = false;
            this.dgvUltimosPedidos.AllowUserToDeleteRows = false;
            this.dgvUltimosPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUltimosPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvUltimosPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUltimosPedidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUltimosPedidos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUltimosPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUltimosPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUltimosPedidos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUltimosPedidos.EnableHeadersVisualStyles = false;
            this.dgvUltimosPedidos.Location = new System.Drawing.Point(21, 46);
            this.dgvUltimosPedidos.Name = "dgvUltimosPedidos";
            this.dgvUltimosPedidos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUltimosPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUltimosPedidos.RowHeadersVisible = false;
            this.dgvUltimosPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUltimosPedidos.Size = new System.Drawing.Size(1105, 123);
            this.dgvUltimosPedidos.TabIndex = 2;
            // 
            // lblTabMovs
            // 
            this.lblTabMovs.AutoSize = true;
            this.lblTabMovs.Font = new System.Drawing.Font("Montserrat Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabMovs.Location = new System.Drawing.Point(223, 13);
            this.lblTabMovs.Name = "lblTabMovs";
            this.lblTabMovs.Size = new System.Drawing.Size(238, 30);
            this.lblTabMovs.TabIndex = 1;
            this.lblTabMovs.Text = "Últimos Movimientos";
            this.lblTabMovs.Click += new System.EventHandler(this.lblTabMovs_Click);
            // 
            // lblTabPedidos
            // 
            this.lblTabPedidos.AutoSize = true;
            this.lblTabPedidos.Font = new System.Drawing.Font("Montserrat Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabPedidos.Location = new System.Drawing.Point(16, 13);
            this.lblTabPedidos.Name = "lblTabPedidos";
            this.lblTabPedidos.Size = new System.Drawing.Size(187, 30);
            this.lblTabPedidos.TabIndex = 0;
            this.lblTabPedidos.Text = "Últimos Pedidos";
            this.lblTabPedidos.Click += new System.EventHandler(this.lblTabPedidos_Click);
            // 
            // newPanel6
            // 
            this.newPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newPanel6.BackColor = System.Drawing.Color.White;
            this.newPanel6.BackgroundColor = System.Drawing.Color.White;
            this.newPanel6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel6.BorderRadius = 20;
            this.newPanel6.BorderSize = 0;
            this.newPanel6.Controls.Add(this.label16);
            this.newPanel6.Controls.Add(this.cpee);
            this.newPanel6.Controls.Add(this.label17);
            this.newPanel6.Location = new System.Drawing.Point(620, 329);
            this.newPanel6.Name = "newPanel6";
            this.newPanel6.Size = new System.Drawing.Size(547, 204);
            this.newPanel6.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label16.Location = new System.Drawing.Point(15, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "Ultimos 30 días";
            // 
            // cpee
            // 
            chartArea1.Name = "ChartArea1";
            this.cpee.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cpee.Legends.Add(legend1);
            this.cpee.Location = new System.Drawing.Point(188, 57);
            this.cpee.Name = "cpee";
            this.cpee.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cpee.Series.Add(series1);
            this.cpee.Size = new System.Drawing.Size(300, 144);
            this.cpee.TabIndex = 3;
            this.cpee.Text = "chart1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(210, 25);
            this.label17.TabIndex = 3;
            this.label17.Text = "Distribucion de Egresos";
            // 
            // newPanel5
            // 
            this.newPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newPanel5.BackColor = System.Drawing.Color.White;
            this.newPanel5.BackgroundColor = System.Drawing.Color.White;
            this.newPanel5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel5.BorderRadius = 20;
            this.newPanel5.BorderSize = 0;
            this.newPanel5.Controls.Add(this.label15);
            this.newPanel5.Controls.Add(this.label14);
            this.newPanel5.Controls.Add(this.cp);
            this.newPanel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.newPanel5.Location = new System.Drawing.Point(26, 329);
            this.newPanel5.Name = "newPanel5";
            this.newPanel5.Size = new System.Drawing.Size(541, 204);
            this.newPanel5.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label15.Location = new System.Drawing.Point(14, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Ultimos 30 días";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(215, 25);
            this.label14.TabIndex = 1;
            this.label14.Text = "Distribucion de Ingresos";
            // 
            // cp
            // 
            chartArea2.Name = "ChartArea1";
            this.cp.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.cp.Legends.Add(legend2);
            this.cp.Location = new System.Drawing.Point(117, 57);
            this.cp.Name = "cp";
            this.cp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.cp.Series.Add(series2);
            this.cp.Size = new System.Drawing.Size(300, 144);
            this.cp.TabIndex = 0;
            this.cp.Text = "chart1";
            // 
            // newPanel4
            // 
            this.newPanel4.BackColor = System.Drawing.Color.White;
            this.newPanel4.BackgroundColor = System.Drawing.Color.White;
            this.newPanel4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel4.BorderRadius = 20;
            this.newPanel4.BorderSize = 0;
            this.newPanel4.Controls.Add(this.lblClientes1);
            this.newPanel4.Controls.Add(this.lblClientes);
            this.newPanel4.Controls.Add(this.label13);
            this.newPanel4.Location = new System.Drawing.Point(919, 130);
            this.newPanel4.Name = "newPanel4";
            this.newPanel4.Size = new System.Drawing.Size(248, 129);
            this.newPanel4.TabIndex = 10;
            // 
            // lblClientes1
            // 
            this.lblClientes1.AutoSize = true;
            this.lblClientes1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes1.ForeColor = System.Drawing.Color.Green;
            this.lblClientes1.Location = new System.Drawing.Point(12, 95);
            this.lblClientes1.Name = "lblClientes1";
            this.lblClientes1.Size = new System.Drawing.Size(108, 25);
            this.lblClientes1.TabIndex = 8;
            this.lblClientes1.Text = "+3 este mes";
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.Location = new System.Drawing.Point(10, 43);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(53, 42);
            this.lblClientes.TabIndex = 8;
            this.lblClientes.Text = "45";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label13.Location = new System.Drawing.Point(12, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(168, 30);
            this.label13.TabIndex = 8;
            this.label13.Text = "Clientes Activos";
            // 
            // newPanel3
            // 
            this.newPanel3.BackColor = System.Drawing.Color.White;
            this.newPanel3.BackgroundColor = System.Drawing.Color.White;
            this.newPanel3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel3.BorderRadius = 20;
            this.newPanel3.BorderSize = 0;
            this.newPanel3.Controls.Add(this.lblEgresos1);
            this.newPanel3.Controls.Add(this.lblEgresos);
            this.newPanel3.Controls.Add(this.label10);
            this.newPanel3.Location = new System.Drawing.Point(620, 130);
            this.newPanel3.Name = "newPanel3";
            this.newPanel3.Size = new System.Drawing.Size(248, 129);
            this.newPanel3.TabIndex = 9;
            // 
            // lblEgresos1
            // 
            this.lblEgresos1.AutoSize = true;
            this.lblEgresos1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgresos1.ForeColor = System.Drawing.Color.Red;
            this.lblEgresos1.Location = new System.Drawing.Point(14, 95);
            this.lblEgresos1.Name = "lblEgresos1";
            this.lblEgresos1.Size = new System.Drawing.Size(57, 25);
            this.lblEgresos1.TabIndex = 8;
            this.lblEgresos1.Text = "+5.2%";
            // 
            // lblEgresos
            // 
            this.lblEgresos.AutoSize = true;
            this.lblEgresos.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgresos.Location = new System.Drawing.Point(10, 43);
            this.lblEgresos.Name = "lblEgresos";
            this.lblEgresos.Size = new System.Drawing.Size(62, 42);
            this.lblEgresos.TabIndex = 8;
            this.lblEgresos.Text = "$12";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label10.Location = new System.Drawing.Point(12, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 30);
            this.label10.TabIndex = 8;
            this.label10.Text = "Egresos del Mes";
            // 
            // newPanel2
            // 
            this.newPanel2.BackColor = System.Drawing.Color.White;
            this.newPanel2.BackgroundColor = System.Drawing.Color.White;
            this.newPanel2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel2.BorderRadius = 20;
            this.newPanel2.BorderSize = 0;
            this.newPanel2.Controls.Add(this.lblIngresos1);
            this.newPanel2.Controls.Add(this.lblIngresos);
            this.newPanel2.Controls.Add(this.label7);
            this.newPanel2.Location = new System.Drawing.Point(319, 130);
            this.newPanel2.Name = "newPanel2";
            this.newPanel2.Size = new System.Drawing.Size(248, 129);
            this.newPanel2.TabIndex = 9;
            // 
            // lblIngresos1
            // 
            this.lblIngresos1.AutoSize = true;
            this.lblIngresos1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos1.ForeColor = System.Drawing.Color.Green;
            this.lblIngresos1.Location = new System.Drawing.Point(14, 95);
            this.lblIngresos1.Name = "lblIngresos1";
            this.lblIngresos1.Size = new System.Drawing.Size(63, 25);
            this.lblIngresos1.TabIndex = 8;
            this.lblIngresos1.Text = "+15.5%";
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.Location = new System.Drawing.Point(10, 43);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(62, 42);
            this.lblIngresos.TabIndex = 8;
            this.lblIngresos.Text = "$12";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(12, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 30);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ingresos del Mes";
            // 
            // newPanel1
            // 
            this.newPanel1.BackColor = System.Drawing.Color.White;
            this.newPanel1.BackgroundColor = System.Drawing.Color.White;
            this.newPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel1.BorderRadius = 20;
            this.newPanel1.BorderSize = 0;
            this.newPanel1.Controls.Add(this.lblPedidos1);
            this.newPanel1.Controls.Add(this.lblPedidos);
            this.newPanel1.Controls.Add(this.label3);
            this.newPanel1.Location = new System.Drawing.Point(26, 130);
            this.newPanel1.Name = "newPanel1";
            this.newPanel1.Size = new System.Drawing.Size(248, 129);
            this.newPanel1.TabIndex = 7;
            // 
            // lblPedidos1
            // 
            this.lblPedidos1.AutoSize = true;
            this.lblPedidos1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidos1.ForeColor = System.Drawing.Color.Green;
            this.lblPedidos1.Location = new System.Drawing.Point(14, 95);
            this.lblPedidos1.Name = "lblPedidos1";
            this.lblPedidos1.Size = new System.Drawing.Size(139, 25);
            this.lblPedidos1.TabIndex = 8;
            this.lblPedidos1.Text = "+2 esta semana";
            // 
            // lblPedidos
            // 
            this.lblPedidos.AutoSize = true;
            this.lblPedidos.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidos.Location = new System.Drawing.Point(10, 43);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Size = new System.Drawing.Size(45, 42);
            this.lblPedidos.TabIndex = 8;
            this.lblPedidos.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pedidos Pendientes";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(236)))), ((int)(((byte)(200)))));
            this.btnReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(236)))), ((int)(((byte)(200)))));
            this.btnReport.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReport.BorderRadius = 15;
            this.btnReport.BorderSize = 0;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(245)))), ((int)(((byte)(238)))));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnReport.IconColor = System.Drawing.Color.Black;
            this.btnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReport.Location = new System.Drawing.Point(990, 38);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(186, 42);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Generar Reporte";
            this.btnReport.TextColor = System.Drawing.Color.Black;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // UserCHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.newPanel7);
            this.Controls.Add(this.newPanel6);
            this.Controls.Add(this.newPanel5);
            this.Controls.Add(this.newPanel4);
            this.Controls.Add(this.newPanel3);
            this.Controls.Add(this.newPanel2);
            this.Controls.Add(this.newPanel1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserCHome";
            this.Size = new System.Drawing.Size(1192, 727);
            this.Load += new System.EventHandler(this.UserCHome_Load);
            this.newPanel7.ResumeLayout(false);
            this.newPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosMovs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosPedidos)).EndInit();
            this.newPanel6.ResumeLayout(false);
            this.newPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpee)).EndInit();
            this.newPanel5.ResumeLayout(false);
            this.newPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cp)).EndInit();
            this.newPanel4.ResumeLayout(false);
            this.newPanel4.PerformLayout();
            this.newPanel3.ResumeLayout(false);
            this.newPanel3.PerformLayout();
            this.newPanel2.ResumeLayout(false);
            this.newPanel2.PerformLayout();
            this.newPanel1.ResumeLayout(false);
            this.newPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private NewButton btnReport;
        private NewPanel newPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPedidos;
        private NewPanel newPanel2;
        private System.Windows.Forms.Label lblIngresos1;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label label7;
        private NewPanel newPanel3;
        private System.Windows.Forms.Label lblEgresos1;
        private System.Windows.Forms.Label lblEgresos;
        private System.Windows.Forms.Label label10;
        private NewPanel newPanel4;
        private System.Windows.Forms.Label lblClientes1;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label label13;
        private NewPanel newPanel5;
        private NewPanel newPanel6;
        private NewPanel newPanel7;
        private System.Windows.Forms.DataVisualization.Charting.Chart cp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataVisualization.Charting.Chart cpee;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvUltimosPedidos;
        private System.Windows.Forms.Label lblTabMovs;
        private System.Windows.Forms.Label lblTabPedidos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvUltimosMovs;
        private System.Windows.Forms.Label lblPedidos1;
    }
}
