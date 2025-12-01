namespace GUI
{
    partial class UserCEditMovs
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
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.newPanel2 = new GUI.NewPanel();
            this.btnCancel = new GUI.NewButton();
            this.btnEliminar = new GUI.NewButton();
            this.btnActualizar = new GUI.NewButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cbxRazon = new System.Windows.Forms.ComboBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newPanel1 = new GUI.NewPanel();
            this.dgvMovs = new System.Windows.Forms.DataGridView();
            this.newPanel4 = new GUI.NewPanel();
            this.lblBalance1 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.newPanel3 = new GUI.NewPanel();
            this.lblEgresos1 = new System.Windows.Forms.Label();
            this.lblEgresos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.newPanel5 = new GUI.NewPanel();
            this.lblIngresos1 = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.newPanel2.SuspendLayout();
            this.newPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovs)).BeginInit();
            this.newPanel4.SuspendLayout();
            this.newPanel3.SuspendLayout();
            this.newPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 49);
            this.label1.TabIndex = 25;
            this.label1.Text = "Gestión de Movimientos";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // newPanel2
            // 
            this.newPanel2.BackColor = System.Drawing.Color.White;
            this.newPanel2.BackgroundColor = System.Drawing.Color.White;
            this.newPanel2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel2.BorderRadius = 20;
            this.newPanel2.BorderSize = 0;
            this.newPanel2.Controls.Add(this.btnCancel);
            this.newPanel2.Controls.Add(this.btnEliminar);
            this.newPanel2.Controls.Add(this.btnActualizar);
            this.newPanel2.Controls.Add(this.txtDescripcion);
            this.newPanel2.Controls.Add(this.dtFecha);
            this.newPanel2.Controls.Add(this.txtMonto);
            this.newPanel2.Controls.Add(this.cbxRazon);
            this.newPanel2.Controls.Add(this.cbxTipo);
            this.newPanel2.Controls.Add(this.label8);
            this.newPanel2.Controls.Add(this.label6);
            this.newPanel2.Controls.Add(this.label5);
            this.newPanel2.Controls.Add(this.label4);
            this.newPanel2.Controls.Add(this.label3);
            this.newPanel2.Controls.Add(this.label2);
            this.newPanel2.Location = new System.Drawing.Point(806, 78);
            this.newPanel2.Name = "newPanel2";
            this.newPanel2.Size = new System.Drawing.Size(334, 597);
            this.newPanel2.TabIndex = 35;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderSize = 1;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.Location = new System.Drawing.Point(22, 551);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(241, 32);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnEliminar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnEliminar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEliminar.BorderRadius = 10;
            this.btnEliminar.BorderSize = 0;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.Red;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.Location = new System.Drawing.Point(22, 511);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(241, 32);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar Movimiento";
            this.btnEliminar.TextColor = System.Drawing.Color.Red;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(236)))), ((int)(((byte)(200)))));
            this.btnActualizar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(236)))), ((int)(((byte)(200)))));
            this.btnActualizar.BorderColor = System.Drawing.Color.PapayaWhip;
            this.btnActualizar.BorderRadius = 10;
            this.btnActualizar.BorderSize = 0;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnActualizar.IconColor = System.Drawing.Color.Black;
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.Location = new System.Drawing.Point(22, 473);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(241, 32);
            this.btnActualizar.TabIndex = 20;
            this.btnActualizar.Text = "Actualizar Movimiento";
            this.btnActualizar.TextColor = System.Drawing.Color.Black;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(22, 367);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(241, 90);
            this.txtDescripcion.TabIndex = 19;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(21, 291);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(242, 20);
            this.dtFecha.TabIndex = 18;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(22, 219);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(241, 20);
            this.txtMonto.TabIndex = 17;
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // cbxRazon
            // 
            this.cbxRazon.FormattingEnabled = true;
            this.cbxRazon.Location = new System.Drawing.Point(21, 153);
            this.cbxRazon.Name = "cbxRazon";
            this.cbxRazon.Size = new System.Drawing.Size(242, 21);
            this.cbxRazon.TabIndex = 16;
            this.cbxRazon.SelectionChangeCommitted += new System.EventHandler(this.cbxRazon_SelectionChangeCommitted);
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(22, 88);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(241, 21);
            this.cbxTipo.TabIndex = 15;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.cbxTipo_SelectedIndexChanged);
            this.cbxTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label8.Location = new System.Drawing.Point(17, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label6.Location = new System.Drawing.Point(16, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label5.Location = new System.Drawing.Point(16, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Monto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label4.Location = new System.Drawing.Point(16, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Razón / Categoría";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "Editar Movimiento";
            // 
            // newPanel1
            // 
            this.newPanel1.BackColor = System.Drawing.Color.White;
            this.newPanel1.BackgroundColor = System.Drawing.Color.White;
            this.newPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel1.BorderRadius = 20;
            this.newPanel1.BorderSize = 0;
            this.newPanel1.Controls.Add(this.dgvMovs);
            this.newPanel1.Location = new System.Drawing.Point(24, 260);
            this.newPanel1.Name = "newPanel1";
            this.newPanel1.Size = new System.Drawing.Size(738, 415);
            this.newPanel1.TabIndex = 34;
            // 
            // dgvMovs
            // 
            this.dgvMovs.AllowUserToAddRows = false;
            this.dgvMovs.AllowUserToDeleteRows = false;
            this.dgvMovs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovs.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMovs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMovs.EnableHeadersVisualStyles = false;
            this.dgvMovs.Location = new System.Drawing.Point(17, 18);
            this.dgvMovs.Name = "dgvMovs";
            this.dgvMovs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMovs.RowHeadersVisible = false;
            this.dgvMovs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovs.Size = new System.Drawing.Size(702, 383);
            this.dgvMovs.TabIndex = 0;
            this.dgvMovs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovs_CellClick);
            // 
            // newPanel4
            // 
            this.newPanel4.BackColor = System.Drawing.Color.White;
            this.newPanel4.BackgroundColor = System.Drawing.Color.White;
            this.newPanel4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel4.BorderRadius = 20;
            this.newPanel4.BorderSize = 0;
            this.newPanel4.Controls.Add(this.lblBalance1);
            this.newPanel4.Controls.Add(this.lblBalance);
            this.newPanel4.Controls.Add(this.label13);
            this.newPanel4.Location = new System.Drawing.Point(549, 78);
            this.newPanel4.Name = "newPanel4";
            this.newPanel4.Size = new System.Drawing.Size(213, 139);
            this.newPanel4.TabIndex = 33;
            // 
            // lblBalance1
            // 
            this.lblBalance1.AutoSize = true;
            this.lblBalance1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance1.ForeColor = System.Drawing.Color.Green;
            this.lblBalance1.Location = new System.Drawing.Point(12, 95);
            this.lblBalance1.Name = "lblBalance1";
            this.lblBalance1.Size = new System.Drawing.Size(108, 25);
            this.lblBalance1.TabIndex = 8;
            this.lblBalance1.Text = "+3 este mes";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Montserrat", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(10, 43);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(53, 42);
            this.lblBalance.TabIndex = 8;
            this.lblBalance.Text = "45";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label13.Location = new System.Drawing.Point(12, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 30);
            this.label13.TabIndex = 8;
            this.label13.Text = "Balance";
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
            this.newPanel3.Location = new System.Drawing.Point(282, 78);
            this.newPanel3.Name = "newPanel3";
            this.newPanel3.Size = new System.Drawing.Size(226, 139);
            this.newPanel3.TabIndex = 31;
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
            // newPanel5
            // 
            this.newPanel5.BackColor = System.Drawing.Color.White;
            this.newPanel5.BackgroundColor = System.Drawing.Color.White;
            this.newPanel5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel5.BorderRadius = 20;
            this.newPanel5.BorderSize = 0;
            this.newPanel5.Controls.Add(this.lblIngresos1);
            this.newPanel5.Controls.Add(this.lblIngresos);
            this.newPanel5.Controls.Add(this.label7);
            this.newPanel5.Location = new System.Drawing.Point(24, 78);
            this.newPanel5.Name = "newPanel5";
            this.newPanel5.Size = new System.Drawing.Size(225, 139);
            this.newPanel5.TabIndex = 32;
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
            // UserCEditMovs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.newPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPanel1);
            this.Controls.Add(this.newPanel4);
            this.Controls.Add(this.newPanel3);
            this.Controls.Add(this.newPanel5);
            this.Name = "UserCEditMovs";
            this.Size = new System.Drawing.Size(1192, 727);
            this.Load += new System.EventHandler(this.UserCEditMovs_Load);
            this.newPanel2.ResumeLayout(false);
            this.newPanel2.PerformLayout();
            this.newPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovs)).EndInit();
            this.newPanel4.ResumeLayout(false);
            this.newPanel4.PerformLayout();
            this.newPanel3.ResumeLayout(false);
            this.newPanel3.PerformLayout();
            this.newPanel5.ResumeLayout(false);
            this.newPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewPanel newPanel1;
        private System.Windows.Forms.DataGridView dgvMovs;
        private NewPanel newPanel4;
        private System.Windows.Forms.Label lblBalance1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label13;
        private NewPanel newPanel3;
        private System.Windows.Forms.Label lblEgresos1;
        private System.Windows.Forms.Label lblEgresos;
        private System.Windows.Forms.Label label10;
        private NewPanel newPanel5;
        private System.Windows.Forms.Label lblIngresos1;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private NewPanel newPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbxTipo;
        private NewButton btnCancel;
        private NewButton btnEliminar;
        private NewButton btnActualizar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cbxRazon;
    }
}
