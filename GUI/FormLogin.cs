using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #region Funcionalidades del Form
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "Username" || string.IsNullOrWhiteSpace(txtuser.Text) || txtpass.Text == "Password" || string.IsNullOrEmpty(txtpass.Text))
            {
                MsgError("Por favor ingresa un usuario y/o una contraseña");
                return;
            }
            UserService user = new UserService();
            var username = user.ValidateUser(txtuser.Text, txtpass.Text);
            if (username != null)
            {
                FormPrincipal main = new FormPrincipal(username);
                this.Hide();
                main.FormClosed += Logout;
                main.Show();
            }
            else
            {
                MsgError("Usuario o contraseña invalidos");
                txtpass.Text = "Password";
                txtpass.UseSystemPasswordChar = false;
                txtuser.Focus();
            }
        }

        private void MsgError (string Msg)
        {
            lblErrorMsg.Text = "     " + Msg;
            lblErrorMsg.Visible = true;
        }   

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtuser.Text = "Username";
            txtpass.Text = "Password";
            txtpass.UseSystemPasswordChar = false;
            lblErrorMsg.Visible = false;
            this.Show();    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if  (txtuser.Text == "Username")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Username";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Password")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Password";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnregistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSignup main = new FormSignup();
            this.Hide();
            main.FormClosed += Logout;
            main.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¿Haz Olvidado tu Usuario/Contraseña?" +
                            "\n Por favor Contacte con un administrador", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
