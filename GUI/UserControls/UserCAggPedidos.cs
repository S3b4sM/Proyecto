using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            dtFechaI.Value = DateTime.Today;
            dtFechaE.Value = DateTime.Today.AddDays(7);
            LlenarCbxEstado();
        }
        #region Funcionalidades del Form
        private void UserCAggPedidos_Load(object sender, EventArgs e)
        {

        }
        private void cbxEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxEstado.SelectionLength = 0;
            this.ActiveControl = null;
        }
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtTotal.Text.Contains(e.KeyChar.ToString()) && txtTotal.Text.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtTotal_Leave(object sender, EventArgs e)
        {
            string textoLimpio = txtTotal.Text.Trim().Replace(',', '.');

            decimal monto;
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
            {
                txtTotal.Text = monto.ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtTotal.Text = "0.00";
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtAbono.Text.Contains(e.KeyChar.ToString()) && txtAbono.Text.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtAbono_Leave(object sender, EventArgs e)
        {
            string textoLimpio = txtAbono.Text.Trim().Replace(',', '.');

            decimal monto;
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
            {
                txtAbono.Text = monto.ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtAbono.Text = "0.00";
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if((Convert.ToInt32(cbxEstado.SelectedValue) == 0)
                     || string.IsNullOrWhiteSpace(txtTotal.Text)
                     || string.IsNullOrWhiteSpace(txtAbono.Text))
                 {
                      MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                }
                decimal precioT;
                string precioTS = txtTotal.Text.Replace(',', '.');
                if (!decimal.TryParse(precioTS, NumberStyles.Any, CultureInfo.InvariantCulture, out precioT) || precioT <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal abono;
                string abonoS = txtAbono.Text.Replace(',', '.');
                if (!decimal.TryParse(abonoS, NumberStyles.Any, CultureInfo.InvariantCulture, out abono) || abono < 0 /*|| abono > precioT*/)
                {
                    MessageBox.Show("Por favor, ingrese un abono válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string descripcion = txtDescripcion.Text.Trim();
                int estado = Convert.ToInt32(cbxEstado.SelectedValue);
                int id_user = this.Id;
                pedidosService.AggPedido(
                    id_user: id_user,
                    desc: descripcion,
                    precioT: precioT,
                    abono: abono,
                    estado: cbxEstado.Text,
                    fecha_inicio: dtFechaI.Value,
                    fecha_entrega: dtFechaE.Value
                );
                MessageBox.Show("Pedido agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotal.Text = "0.00";
                txtAbono.Text = "0.00";
                txtDescripcion.Clear();
                dtFechaI.Value = DateTime.Today;
                dtFechaE.Value = DateTime.Today.AddDays(7);
                cbxEstado.SelectedIndex = 0;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error crítico: " + ex.Message);
                MessageBox.Show("El monto del abono supera al precio total del pedido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception x)
            {
                Console.WriteLine("Error crítico: " + x.Message);
                MessageBox.Show("Ocurrió un error inesperado al actualizar: " + x.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Descripción del pedido...")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.Black;
            }
        }
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                txtDescripcion.Text = "Descripción del pedido...";
                txtDescripcion.ForeColor = Color.Gray;
            }
        }
        #endregion
        private void LlenarCbxEstado()
        {
            var estado = new List<object>
            {
                    
                new { Valor = 0, Nombre = "Estado" }, 
                new { Valor = 1, Nombre = "Pendiente" },
                new { Valor = 2, Nombre = "En Proceso" },
                new { Valor = 3, Nombre = "Listo" },
                new { Valor = 4, Nombre = "Entregado" }
            };
            cbxEstado.DataSource = estado;
            cbxEstado.DisplayMember = "Nombre";
            cbxEstado.ValueMember = "Valor";
            cbxEstado.SelectedIndex = 0;
        }
    }
}
