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
    public partial class UserCClientes : UserControl
    {
        private readonly int id;
        public UserCClientes(int id)
        {
            InitializeComponent();
            this.id = id;
        }
    }
}
