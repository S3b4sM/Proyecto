using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPrincipal : Form
    {
        public readonly Usuario usuario;
        public FormPrincipal(Usuario username)
        {
            InitializeComponent();
            this.usuario = username;
            AbrirForm(() => new FormHome(username.Id));
            lblName.Text = $"Hola, {usuario.FirstName} {usuario.LastName}";
        }
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        #region Funcionalidades del Form 
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir del programa?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }
        int lx, ly;
        int sw, sh;
        private void btnMax_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMax.Visible = false;
            btnRestart.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMax.Visible = true;
            btnRestart.Visible = false;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnHome_Click(object sender, EventArgs e)
        {   
            AbrirForm(() => new FormHome(usuario.Id));
            
        }
        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            AbrirForm(() => new FormAgg(usuario.Id));
        }
        private void ibtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar sesion?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void ibtnUpdate_Click(object sender, EventArgs e)
        {
            AbrirUser(() => new UserCUpdate());
        }
        #endregion
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AbrirForm<T>(Func<T> formFactory) where T : Form
        {
            Form formulario = panelForms.Controls.OfType<T>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = formFactory();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                this.panelForms.Controls.Clear();
                formulario.Dock = DockStyle.Fill;
                panelForms.Controls.Add(formulario);
                panelForms.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }
        public void AbrirUser<T>(Func<T> formFactory) where T : System.Windows.Forms.UserControl
        {
            System.Windows.Forms.UserControl user = panelForms.Controls.OfType<T>().FirstOrDefault();

            if (user == null)
            {
                user = formFactory();
                user.BorderStyle = BorderStyle.None;
                this.panelForms.Controls.Clear();
                user.Dock = DockStyle.Fill;
                panelForms.Controls.Add(user);
                panelForms.Tag = user;
                user.Show();
                user.BringToFront();
            }
            else
            {
                user.BringToFront();
            }
        }
    }
}
