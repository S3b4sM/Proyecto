namespace GUI
{
    partial class UserCAggPedidos
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
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btn = new FontAwesome.Sharp.IconButton();
            this.txt6 = new System.Windows.Forms.DateTimePicker();
            this.txt5 = new System.Windows.Forms.DateTimePicker();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt8 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(98, 161);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(153, 20);
            this.txt2.TabIndex = 1;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(98, 243);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(153, 20);
            this.txt3.TabIndex = 3;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(98, 85);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(153, 20);
            this.txt1.TabIndex = 5;
            // 
            // btn
            // 
            this.btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn.IconColor = System.Drawing.Color.Black;
            this.btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn.Location = new System.Drawing.Point(326, 217);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(172, 46);
            this.btn.TabIndex = 7;
            this.btn.Text = "iconButton1";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // txt6
            // 
            this.txt6.Location = new System.Drawing.Point(568, 243);
            this.txt6.Name = "txt6";
            this.txt6.Size = new System.Drawing.Size(151, 20);
            this.txt6.TabIndex = 9;
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(568, 161);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(151, 20);
            this.txt5.TabIndex = 10;
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(568, 85);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(153, 20);
            this.txt4.TabIndex = 6;
            // 
            // txt8
            // 
            this.txt8.Location = new System.Drawing.Point(391, 295);
            this.txt8.Name = "txt8";
            this.txt8.Size = new System.Drawing.Size(153, 20);
            this.txt8.TabIndex = 11;
            // 
            // UserCAggPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.txt8);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Name = "UserCAggPedidos";
            this.Size = new System.Drawing.Size(935, 610);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt1;
        private FontAwesome.Sharp.IconButton btn;
        private System.Windows.Forms.DateTimePicker txt6;
        private System.Windows.Forms.DateTimePicker txt5;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt8;
    }
}
