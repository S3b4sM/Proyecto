namespace GUI.UserControls
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
            this.newPanel2 = new GUI.NewPanel();
            this.btnEditMov = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.newPanel1 = new GUI.NewPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAggMov = new GUI.NewButton();
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
            this.newPanel2.Controls.Add(this.btnEditMov);
            this.newPanel2.Controls.Add(this.label3);
            this.newPanel2.Location = new System.Drawing.Point(647, 243);
            this.newPanel2.Name = "newPanel2";
            this.newPanel2.Size = new System.Drawing.Size(414, 185);
            this.newPanel2.TabIndex = 26;
            // 
            // btnEditMov
            // 
            this.btnEditMov.BackColor = System.Drawing.Color.Transparent;
            this.btnEditMov.FlatAppearance.BorderSize = 0;
            this.btnEditMov.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnEditMov.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(108)))));
            this.btnEditMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMov.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnEditMov.IconColor = System.Drawing.Color.Black;
            this.btnEditMov.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditMov.IconSize = 64;
            this.btnEditMov.Location = new System.Drawing.Point(82, 75);
            this.btnEditMov.Name = "btnEditMov";
            this.btnEditMov.Size = new System.Drawing.Size(277, 89);
            this.btnEditMov.TabIndex = 12;
            this.btnEditMov.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(48, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "GESTIONAR MOVIMIENTOS";
            // 
            // newPanel1
            // 
            this.newPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.newPanel1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.newPanel1.BorderRadius = 20;
            this.newPanel1.BorderSize = 0;
            this.newPanel1.Controls.Add(this.label2);
            this.newPanel1.Controls.Add(this.btnAggMov);
            this.newPanel1.Location = new System.Drawing.Point(104, 243);
            this.newPanel1.Name = "newPanel1";
            this.newPanel1.Size = new System.Drawing.Size(414, 185);
            this.newPanel1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(57, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "AGREGAR MOVIMIENTOS";
            // 
            // btnAggMov
            // 
            this.btnAggMov.BackColor = System.Drawing.Color.Transparent;
            this.btnAggMov.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAggMov.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAggMov.BorderRadius = 20;
            this.btnAggMov.BorderSize = 0;
            this.btnAggMov.FlatAppearance.BorderSize = 0;
            this.btnAggMov.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnAggMov.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(108)))));
            this.btnAggMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAggMov.ForeColor = System.Drawing.Color.White;
            this.btnAggMov.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.btnAggMov.IconColor = System.Drawing.Color.Black;
            this.btnAggMov.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAggMov.IconSize = 64;
            this.btnAggMov.Location = new System.Drawing.Point(34, 75);
            this.btnAggMov.Name = "btnAggMov";
            this.btnAggMov.Size = new System.Drawing.Size(353, 89);
            this.btnAggMov.TabIndex = 24;
            this.btnAggMov.TextColor = System.Drawing.Color.White;
            this.btnAggMov.UseVisualStyleBackColor = false;
            this.btnAggMov.Click += new System.EventHandler(this.btnAggMov_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(203, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(819, 47);
            this.label1.TabIndex = 24;
            this.label1.Text = "GESTION Y  ACTUALIZACIÓN DE MOVIMIENTOS";
            // 
            // UserCMovs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.newPanel2);
            this.Controls.Add(this.newPanel1);
            this.Controls.Add(this.label1);
            this.Name = "UserCMovs";
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
        private FontAwesome.Sharp.IconButton btnEditMov;
        private System.Windows.Forms.Label label3;
        private NewPanel newPanel1;
        private System.Windows.Forms.Label label2;
        private NewButton btnAggMov;
        private System.Windows.Forms.Label label1;
    }
}
