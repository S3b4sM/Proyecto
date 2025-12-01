using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace GUI
{
    public class NewDateTimePicker : UserControl
    {
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 0;

        private DateTimePicker dateTimePicker1;

        public NewDateTimePicker()
        {
            dateTimePicker1 = new DateTimePicker();
            this.SuspendLayout();

            // Configuración del DTP
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Cursor = Cursors.Hand;
            dateTimePicker1.Font = new Font("Segoe UI", 9.5F);
            // Eventos
            dateTimePicker1.ValueChanged += (s, e) => this.OnValueChanged(e);
            dateTimePicker1.Enter += (s, e) => this.Invalidate();
            dateTimePicker1.Leave += (s, e) => this.Invalidate();

            this.Controls.Add(dateTimePicker1);

            // Configuración del Panel Contenedor
            this.MinimumSize = new Size(0, 35);
            this.Size = new Size(200, 35);
            this.BackColor = Color.Transparent;

            // Padding para crear el "borde" interno
            // Esto empuja el DTP hacia adentro
            this.Padding = new Padding(1);

            this.ResumeLayout(false);
        }

        // Propiedades
        [Category("RJ Code Advance")]
        public Color SkinColor
        {
            get { return skinColor; }
            set { skinColor = value; dateTimePicker1.BackColor = skinColor; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; dateTimePicker1.ForeColor = textColor; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Padding = new Padding(borderSize); this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public DateTime Value
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            // Dibujar el fondo del control (el marco)
            using (Pen penBorder = new Pen(borderColor, borderSize > 0 ? borderSize : 1))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            {
                // Fondo
                graph.FillRectangle(skinBrush, this.ClientRectangle);

                // Borde
                if (borderSize > 0)
                {
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
    }
}