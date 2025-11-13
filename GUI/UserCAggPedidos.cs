using BLL;
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
    public partial class UserCAggPedidos : UserControl
    {
        PedidosService pedidosService = new PedidosService();
        public readonly int Id;
        public UserCAggPedidos(int id)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int tst = txt1.Text.Length;
            decimal pp = Convert.ToDecimal(txt3.Text);
            decimal txt41 = Convert.ToDecimal(txt4.Text);
            DateTime fh1 = txt5.Value;
            DateTime ph11 = txt6.Value;
            pedidosService.AggPedido(tst, txt2.Text, pp, txt41, txt8.Text, fh1, ph11);
        }
    }
}
