namespace GUI.UserControls
{
    partial class UserCPedidos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newPanel1 = new GUI.NewPanel();
            this.btnAggPed = new GUI.NewButton();
            this.newPanel2 = new GUI.NewPanel();
            this.btnEditPedidos = new GUI.NewButton();
            this.newPanel1.SuspendLayout();
            this.newPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(264, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(716, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "GESTION Y  ACTUALIZACIÓN DE PEDIDOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(85, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "GESTIONAR PEDIDOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(96, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "AGREGAR PEDIDOS";
            // 
            // newPanel1
            // 
            this.newPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel1.BorderRadius = 20;
            this.newPanel1.BorderSize = 0;
            this.newPanel1.Controls.Add(this.label2);
            this.newPanel1.Controls.Add(this.btnAggPed);
            this.newPanel1.Location = new System.Drawing.Point(104, 243);
            this.newPanel1.Name = "newPanel1";
            this.newPanel1.Size = new System.Drawing.Size(414, 185);
            this.newPanel1.TabIndex = 22;
            // 
            // btnAggPed
            // 
            this.btnAggPed.BackColor = System.Drawing.Color.Transparent;
            this.btnAggPed.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAggPed.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAggPed.BorderRadius = 20;
            this.btnAggPed.BorderSize = 0;
            this.btnAggPed.FlatAppearance.BorderSize = 0;
            this.btnAggPed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnAggPed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(108)))));
            this.btnAggPed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAggPed.ForeColor = System.Drawing.Color.White;
            this.btnAggPed.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnAggPed.IconColor = System.Drawing.Color.Black;
            this.btnAggPed.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAggPed.IconSize = 64;
            this.btnAggPed.Location = new System.Drawing.Point(34, 75);
            this.btnAggPed.Name = "btnAggPed";
            this.btnAggPed.Size = new System.Drawing.Size(353, 89);
            this.btnAggPed.TabIndex = 24;
            this.btnAggPed.TextColor = System.Drawing.Color.White;
            this.btnAggPed.UseVisualStyleBackColor = false;
            this.btnAggPed.Click += new System.EventHandler(this.btnAggPed_Click);
            // 
            // newPanel2
            // 
            this.newPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel2.BorderRadius = 20;
            this.newPanel2.BorderSize = 0;
            this.newPanel2.Controls.Add(this.label3);
            this.newPanel2.Controls.Add(this.btnEditPedidos);
            this.newPanel2.Location = new System.Drawing.Point(647, 243);
            this.newPanel2.Name = "newPanel2";
            this.newPanel2.Size = new System.Drawing.Size(414, 185);
            this.newPanel2.TabIndex = 23;
            // 
            // btnEditPedidos
            // 
            this.btnEditPedidos.BackColor = System.Drawing.Color.Transparent;
            this.btnEditPedidos.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEditPedidos.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditPedidos.BorderRadius = 20;
            this.btnEditPedidos.BorderSize = 0;
            this.btnEditPedidos.FlatAppearance.BorderSize = 0;
            this.btnEditPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnEditPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(108)))));
            this.btnEditPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPedidos.ForeColor = System.Drawing.Color.White;
            this.btnEditPedidos.IconChar = FontAwesome.Sharp.IconChar.PencilRuler;
            this.btnEditPedidos.IconColor = System.Drawing.Color.Black;
            this.btnEditPedidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditPedidos.IconSize = 64;
            this.btnEditPedidos.Location = new System.Drawing.Point(82, 75);
            this.btnEditPedidos.Name = "btnEditPedidos";
            this.btnEditPedidos.Size = new System.Drawing.Size(277, 89);
            this.btnEditPedidos.TabIndex = 24;
            this.btnEditPedidos.TextColor = System.Drawing.Color.White;
            this.btnEditPedidos.UseVisualStyleBackColor = false;
            this.btnEditPedidos.Click += new System.EventHandler(this.btnEditPedidos_Click);
            // 
            // UserCPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.newPanel2);
            this.Controls.Add(this.newPanel1);
            this.Controls.Add(this.label1);
            this.Name = "UserCPedidos";
            this.Size = new System.Drawing.Size(1192, 641);
            this.newPanel1.ResumeLayout(false);
            this.newPanel1.PerformLayout();
            this.newPanel2.ResumeLayout(false);
            this.newPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private NewPanel newPanel1;
        private NewPanel newPanel2;
        private NewButton btnAggPed;
        private NewButton btnEditPedidos;
    }
}
