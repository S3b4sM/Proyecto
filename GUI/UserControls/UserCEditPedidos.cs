using BLL;
using ENTITY;
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
    public partial class UserCEditPedidos : UserControl
    {
        PedidosService pedidosService = new PedidosService();
        ClientesService clientesService = new ClientesService();
        public readonly int Id;
        public int idPedido = -1;
        private Action onPedidoGuardado;
        public UserCEditPedidos(int id, Action onGuardado)
        {
            InitializeComponent();
            this.Id = id;
            LlenarCbxEstado();
            LlenarcbxCliente();
            onPedidoGuardado = onGuardado;
        }
        #region Funcionalidades del Form
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
                if (!txtPrecioT.Text.Contains(e.KeyChar.ToString()) && txtPrecioT.Text.Length > 0)
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
            string textoLimpio = txtPrecioT.Text.Trim().Replace(',', '.');

            decimal monto;
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
            {
                txtPrecioT.Text = monto.ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtPrecioT.Text = "0.00";
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
                if (idPedido == -1)
                {
                    MessageBox.Show("Seleccione un pedido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal AbonoD;
                string AbonoS = txtAbono.Text.Replace(',', '.');
                if (!decimal.TryParse(AbonoS, NumberStyles.Any, CultureInfo.InvariantCulture, out AbonoD) || AbonoD <= 0)
                {
                    MessageBox.Show("El valor del abono no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAbono.Focus();
                    return;
                }
                decimal TotalD;
                string TotalS = txtPrecioT.Text.Replace(',', '.');
                if (!decimal.TryParse(TotalS, NumberStyles.Any, CultureInfo.InvariantCulture, out TotalD) || TotalD <= 0)
                {
                    MessageBox.Show("El valor del total no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioT.Focus();
                    return;
                }
                if (AbonoD > TotalD)
                {
                    MessageBox.Show("El monto del abono no puede superar el precio total del pedido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAbono.Focus();
                    return;
                }
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea actualizar este Pedido?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBoxResult == DialogResult.No)
                {
                    return;
                }
                string estadoSeleccionado = cbxEstado.Text;
                var pedido = new Pedidos
                {
                    id_pedido = idPedido,
                    id_usuario = this.Id,
                    descripcion = txtDescripcion.Text,
                    abono = AbonoD,
                    precio_total = TotalD,
                    estado = estadoSeleccionado,
                    fecha_pedido = dtPedido.Value,
                    fecha_entrega = dtEntrega.Value
                };
                bool resultado = pedidosService.ActualizarPedido(pedido);
                if (resultado)
                {
                    MessageBox.Show("Pedido actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    onPedidoGuardado?.Invoke();
                    Limpiar();
                    btnCerrar.PerformClick();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el pedido. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error crítico: " + ex.Message);
                MessageBox.Show("No se puede actualizar: El monto del abono supera al precio total del pedido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception x)
            {
                Console.WriteLine("Error crítico: " + x.Message);
                MessageBox.Show("Ocurrió un error inesperado al actualizar: " + x.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Cerrar()
        {
            FormPrincipal formPrincipal = this.FindForm() as FormPrincipal;
            if (formPrincipal != null)
            {
                formPrincipal.CerrarModal();
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }
        private void Limpiar()
        {
            txtDescripcion.Clear();
            txtAbono.Text = "0.00";
            txtPrecioT.Text = "0.00";
            cbxEstado.SelectedIndex = 0;
            dtPedido.Value = DateTime.Today;
            dtEntrega.Value = DateTime.Today.AddDays(7);
        }
        private void LlenarcbxCliente()
        {
            DataTable dtClientes = clientesService.ObtenerlistaClientes(Id);
            if (dtClientes != null && dtClientes.Rows.Count > 0)
            {
                DataRow row = dtClientes.NewRow();
                row["DOCUMENTO"] = 0;
                row["NOMBRE"] = "Seleccione un Cliente...";
                dtClientes.Rows.InsertAt(row, 0);
                cbxCliente.DataSource = dtClientes;
                cbxCliente.DisplayMember = "NOMBRE";
                cbxCliente.ValueMember = "DOCUMENTO";
                cbxCliente.SelectedIndex = 0;
            }
            else
            {
                cbxCliente.DataSource = null;
                cbxCliente.Items.Clear();
                cbxCliente.Items.Add("No hay clientes registrados");
                cbxCliente.SelectedIndex = 0;
            }
        }

    }
}
