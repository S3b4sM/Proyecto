namespace GUI
{
    partial class UserCUpdate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPedidos = new FontAwesome.Sharp.IconButton();
            this.btnMovs = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTION Y ACTUALIZACION";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnMovs);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(14, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 185);
            this.panel1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "GESTIONAR MOVIMIENTOS";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnPedidos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(544, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 185);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "GESTIONAR PEDIDOS";
            // 
            // btnPedidos
            // 
            this.btnPedidos.BackColor = System.Drawing.Color.Transparent;
            this.btnPedidos.FlatAppearance.BorderSize = 0;
            this.btnPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            this.btnPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnPedidos.IconColor = System.Drawing.Color.Black;
            this.btnPedidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPedidos.IconSize = 64;
            this.btnPedidos.Location = new System.Drawing.Point(50, 67);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(277, 89);
            this.btnPedidos.TabIndex = 12;
            this.btnPedidos.UseVisualStyleBackColor = false;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnMovs
            // 
            this.btnMovs.BackColor = System.Drawing.Color.Transparent;
            this.btnMovs.FlatAppearance.BorderSize = 0;
            this.btnMovs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            this.btnMovs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnMovs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovs.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.btnMovs.IconColor = System.Drawing.Color.Black;
            this.btnMovs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMovs.IconSize = 64;
            this.btnMovs.Location = new System.Drawing.Point(26, 57);
            this.btnMovs.Name = "btnMovs";
            this.btnMovs.Size = new System.Drawing.Size(353, 89);
            this.btnMovs.TabIndex = 11;
            this.btnMovs.UseVisualStyleBackColor = false;
            this.btnMovs.Click += new System.EventHandler(this.btnMovs_Click);
            // 
            // UserCUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UserCUpdate";
            this.Size = new System.Drawing.Size(935, 610);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelForms;
        private FontAwesome.Sharp.IconButton btnMovs;
        private FontAwesome.Sharp.IconButton btnPedidos;
    }
}
