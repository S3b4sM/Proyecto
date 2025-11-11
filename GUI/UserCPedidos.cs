using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UserCPedidos : UserControl
    {
        public UserCPedidos(int id)
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormPrincipal FormPrincipal = this.FindForm() as FormPrincipal;
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirUser(() => new UserCUpdate());
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el formulario principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
