using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        private Point startPoint = new Point(280, 70);
        private Point endPoint = new Point(600, 70);

        private bool isDragging = false;
        private Point dragOffset;
        private int lineDeltaX;
        private int lineDeltaY;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 105, 105, 105));
            {
                e.Graphics.DrawLine(pen, startPoint, endPoint);
            }
        }
    }
}
