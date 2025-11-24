namespace GUI.UserControls
{
    partial class UserCClientes
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
            this.newPanel2 = new GUI.NewPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditClientes = new GUI.NewButton();
            this.newPanel1 = new GUI.NewPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAggClientes = new GUI.NewButton();
            this.label1 = new System.Windows.Forms.Label();
            this.newPanel2.SuspendLayout();
            this.newPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newPanel2
            // 
            this.newPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel2.BorderRadius = 20;
            this.newPanel2.BorderSize = 0;
            this.newPanel2.Controls.Add(this.label3);
            this.newPanel2.Controls.Add(this.btnEditClientes);
            this.newPanel2.Location = new System.Drawing.Point(647, 243);
            this.newPanel2.Name = "newPanel2";
            this.newPanel2.Size = new System.Drawing.Size(414, 185);
            this.newPanel2.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(86, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "GESTIONAR CLIENTES";
            // 
            // btnEditClientes
            // 
            this.btnEditClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnEditClientes.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEditClientes.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditClientes.BorderRadius = 20;
            this.btnEditClientes.BorderSize = 0;
            this.btnEditClientes.FlatAppearance.BorderSize = 0;
            this.btnEditClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnEditClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(108)))));
            this.btnEditClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditClientes.ForeColor = System.Drawing.Color.White;
            this.btnEditClientes.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btnEditClientes.IconColor = System.Drawing.Color.Black;
            this.btnEditClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditClientes.IconSize = 64;
            this.btnEditClientes.Location = new System.Drawing.Point(82, 75);
            this.btnEditClientes.Name = "btnEditClientes";
            this.btnEditClientes.Size = new System.Drawing.Size(277, 89);
            this.btnEditClientes.TabIndex = 30;
            this.btnEditClientes.TextColor = System.Drawing.Color.White;
            this.btnEditClientes.UseVisualStyleBackColor = false;
            this.btnEditClientes.Click += new System.EventHandler(this.btnEditClientes_Click);
            // 
            // newPanel1
            // 
            this.newPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel1.BorderRadius = 20;
            this.newPanel1.BorderSize = 0;
            this.newPanel1.Controls.Add(this.label2);
            this.newPanel1.Controls.Add(this.btnAggClientes);
            this.newPanel1.Location = new System.Drawing.Point(104, 243);
            this.newPanel1.Name = "newPanel1";
            this.newPanel1.Size = new System.Drawing.Size(414, 185);
            this.newPanel1.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(87, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "AGREGAR CLIENTES";
            // 
            // btnAggClientes
            // 
            this.btnAggClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnAggClientes.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAggClientes.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAggClientes.BorderRadius = 20;
            this.btnAggClientes.BorderSize = 0;
            this.btnAggClientes.FlatAppearance.BorderSize = 0;
            this.btnAggClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnAggClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(108)))));
            this.btnAggClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAggClientes.ForeColor = System.Drawing.Color.White;
            this.btnAggClientes.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnAggClientes.IconColor = System.Drawing.Color.Black;
            this.btnAggClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAggClientes.IconSize = 64;
            this.btnAggClientes.Location = new System.Drawing.Point(34, 75);
            this.btnAggClientes.Name = "btnAggClientes";
            this.btnAggClientes.Size = new System.Drawing.Size(353, 89);
            this.btnAggClientes.TabIndex = 24;
            this.btnAggClientes.TextColor = System.Drawing.Color.White;
            this.btnAggClientes.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(255, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 47);
            this.label1.TabIndex = 27;
            this.label1.Text = "GESTION Y  ACTUALIZACIÓN DE CLIENTES";
            // 
            // UserCClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.newPanel2);
            this.Controls.Add(this.newPanel1);
            this.Controls.Add(this.label1);
            this.Name = "UserCClientes";
            this.Size = new System.Drawing.Size(1192, 641);
            this.newPanel2.ResumeLayout(false);
            this.newPanel2.PerformLayout();
            this.newPanel1.ResumeLayout(false);
            this.newPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewPanel newPanel2;
        private System.Windows.Forms.Label label3;
        private NewPanel newPanel1;
        private System.Windows.Forms.Label label2;
        private NewButton btnAggClientes;
        private System.Windows.Forms.Label label1;
        private NewButton btnEditClientes;
    }
}
