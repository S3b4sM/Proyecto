namespace GUI
{
    partial class UserCMovs
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
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxRazon = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(72, 86);
            this.dtFecha.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(133, 23);
            this.dtFecha.TabIndex = 27;
            this.dtFecha.Value = new System.DateTime(2025, 10, 11, 12, 40, 46, 0);
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.BackColor = System.Drawing.Color.White;
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(78, 86);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(92, 23);
            this.txtMonto.TabIndex = 26;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxTipo
            // 
            this.cbxTipo.AutoCompleteCustomSource.AddRange(new string[] {
            "INGRESO",
            "EGRESO"});
            this.cbxTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.cbxTipo.BackColor = System.Drawing.SystemColors.Window;
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipo.Location = new System.Drawing.Point(78, 68);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(92, 24);
            this.cbxTipo.TabIndex = 24;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.cbxTipo_SelectedIndexChanged);
            this.cbxTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(246)))));
            this.dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(12, 463);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(911, 141);
            this.dgvMovimientos.TabIndex = 22;
            this.dgvMovimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnBack.IconColor = System.Drawing.Color.Black;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.Location = new System.Drawing.Point(12, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(76, 48);
            this.btnBack.TabIndex = 33;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbxTipo);
            this.panel4.Location = new System.Drawing.Point(94, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(257, 130);
            this.panel4.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 33);
            this.label3.TabIndex = 9;
            this.label3.Text = "TIPO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxRazon);
            this.panel1.Location = new System.Drawing.Point(632, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 120);
            this.panel1.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "RAZON";
            // 
            // cbxRazon
            // 
            this.cbxRazon.AutoCompleteCustomSource.AddRange(new string[] {
            "INGRESO",
            "EGRESO"});
            this.cbxRazon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.cbxRazon.BackColor = System.Drawing.SystemColors.Window;
            this.cbxRazon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRazon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cbxRazon.Location = new System.Drawing.Point(72, 68);
            this.cbxRazon.Name = "cbxRazon";
            this.cbxRazon.Size = new System.Drawing.Size(133, 24);
            this.cbxRazon.TabIndex = 25;
            this.cbxRazon.SelectionChangeCommitted += new System.EventHandler(this.cbxRazon_SelectionChangeCommitted);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtMonto);
            this.panel2.Location = new System.Drawing.Point(94, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 133);
            this.panel2.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "MONTO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtFecha);
            this.panel3.Location = new System.Drawing.Point(632, 147);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 133);
            this.panel3.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 33);
            this.label2.TabIndex = 12;
            this.label2.Text = "FECHA";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.txtDescripcion);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(245, 299);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(487, 158);
            this.panel5.TabIndex = 37;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(47, 50);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(394, 90);
            this.txtDescripcion.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(140, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 33);
            this.label7.TabIndex = 9;
            this.label7.Text = "DESCRIPCION";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton1.Location = new System.Drawing.Point(94, 372);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(111, 67);
            this.iconButton1.TabIndex = 38;
            this.iconButton1.Text = "Actualizar";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton2.Location = new System.Drawing.Point(778, 372);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(111, 67);
            this.iconButton2.TabIndex = 39;
            this.iconButton2.Text = "Eliminar";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // UserCMovs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvMovimientos);
            this.Name = "UserCMovs";
            this.Size = new System.Drawing.Size(935, 610);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private FontAwesome.Sharp.IconButton btnBack;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxRazon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}
