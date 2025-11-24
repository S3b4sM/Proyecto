using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UserCPedidos : UserControl
    {
        private readonly int id;
        public UserCPedidos(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnAggPed_Click(object sender, EventArgs e)
        {
            FormPrincipal FormPrincipal = this.FindForm() as FormPrincipal;
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirUser(() => new UserCAggPedidos(id));
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el formulario principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
