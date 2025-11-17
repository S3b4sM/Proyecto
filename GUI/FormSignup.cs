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

namespace GUI
{
    public partial class FormSignup : Form
    {
        public FormSignup()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MsgError(string Msg)
        {
            lblErrorMsg.Text = "     " + Msg;
            lblErrorMsg.Visible = true;
        }
        #region funcionalidades del Form
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "Username" || txtpass.Text == "Password" || txtname.Text == "Primer Nombre" || txtlastname.Text == "Primer Apellido" || txtDoc.Text == "Documento")
            {
                MsgError("Por favor rellena todos los campos");
                return;
            }
            UserService userRepository = new UserService();
            var newUser = userRepository.RegisterUser(
                txtuser.Text.Trim(),
                txtpass.Text,
                txtname.Text.Trim(),
                txtlastname.Text.Trim(),
                txtDoc.Text.Trim().Length > 0 ? Convert.ToInt32(txtDoc.Text.Trim()) : 0
            );
            if (newUser != null)
            {
                MessageBox.Show("Usuario registrado con exito", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MsgError("Username/documento ya registrado en la base de datos.");
                txtpass.Text = "Password";
                txtpass.UseSystemPasswordChar = false;
                txtuser.Focus();
            }
        }
        private void FormSignup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == "Username" || textBox.Text == "Password" || textBox.Text == "Primer Nombre" || textBox.Text == "Primer Apellido" || textBox.Text == "Documento")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.LightGray;

                if (textBox == txtpass)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }
        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtuser) textBox.Text = "Username";
                if (textBox == txtpass)
                {
                    textBox.Text = "Password";
                    textBox.UseSystemPasswordChar = false;
                }
                if (textBox == txtname) textBox.Text = "Primer Nombre";
                if (textBox == txtlastname) textBox.Text = "Primer Apellido";
                if (textBox == txtDoc) textBox.Text = "Documento";

                textBox.ForeColor = Color.DimGray;
            }
        }       
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
