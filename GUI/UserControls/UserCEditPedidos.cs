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
        private int idPedido = -1;
        public readonly int Id;
        private Action onPedidoGuardado;
        PedidosService pedidosService = new PedidosService();
        ClientesService clientesService = new ClientesService();
        public UserCEditPedidos(int id, Action onGuardado, int idPedidoEdit = -1)
        {
            InitializeComponent();
            Id = id;
            onPedidoGuardado = onGuardado;
            LlenarCbxEstado();
            LlenarcbxCliente();
            dtEntrega.Value = DateTime.Today;
            dtPedido.Value = DateTime.Today.AddDays(7);
            if (idPedidoEdit > 0)
            {
                CargarDatos(idPedidoEdit);
            }
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
                    MessageBox.Show("No se ha cargado ningún pedido para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToInt32(cbxEstado.SelectedValue) == 0)
                {
                    MessageBox.Show("Por favor, seleccione un Estado válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToInt32(cbxCliente.SelectedValue) == 0) 
                {
                    MessageBox.Show("Por favor, seleccione un Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal precioT;
                string precioTS = txtPrecioT.Text.Replace(',', '.');
                if (!decimal.TryParse(precioTS, NumberStyles.Any, CultureInfo.InvariantCulture, out precioT) || precioT <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio total válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal abono;
                string abonoS = txtAbono.Text.Replace(',', '.');
                if (!decimal.TryParse(abonoS, NumberStyles.Any, CultureInfo.InvariantCulture, out abono) || abono < 0)
                {
                    MessageBox.Show("Por favor, ingrese un abono válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (abono > precioT)
                {
                    MessageBox.Show("El abono no puede ser mayor que el precio total del pedido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea actualizar este Pedido?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBoxResult == DialogResult.No) return;
                string estadoTexto = "";
                foreach (var item in cbxEstado.Items)
                {
                    if (item == cbxEstado.SelectedItem)
                    {
                        estadoTexto = (string)item.GetType().GetProperty("Nombre").GetValue(item, null);
                        break;
                    }
                }
                Pedidos pedidoEditado = new Pedidos
                {
                    id_pedido = this.idPedido,
                    id_usuario = this.Id,
                    id_cliente = Convert.ToInt32(cbxCliente.SelectedValue),
                    descripcion = txtDescripcion.Text,
                    precio_total = precioT,
                    abono = abono,
                    estado = estadoTexto, 
                    fecha_pedido = dtPedido.Value,
                    fecha_entrega = dtEntrega.Value
                };
                bool exito = pedidosService.ActualizarPedido(pedidoEditado);

                if (exito)
                {
                    MessageBox.Show("Pedido actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    onPedidoGuardado?.Invoke(); 
                    Cerrar(); 
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void LlenarcbxCliente()
        {
            DataTable dtClientes = clientesService.ObtenerlistaClientes(Id);
            if (dtClientes != null && dtClientes.Rows.Count > 0)
            {
                DataRow row = dtClientes.NewRow();
                if (dtClientes.Columns["DOCUMENTO"].DataType == typeof(string))
                    row["DOCUMENTO"] = "0";
                else
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
        private void CargarDatos(int idPedidoEdit)
        {
            DataTable dt = pedidosService.PedidoPorId(idPedidoEdit);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                this.idPedido = idPedidoEdit;
                txtDescripcion.Text = row["OBSERVACIONES"].ToString();
                decimal abono = Convert.ToDecimal(row["ABONO"]);
                decimal total = Convert.ToDecimal(row["PRECIO_TOTAL"]);
                txtAbono.Text = abono.ToString("0.00", CultureInfo.InvariantCulture);
                txtAbono.ForeColor = Color.Black;
                txtPrecioT.Text = total.ToString("0.00", CultureInfo.InvariantCulture);
                txtPrecioT.ForeColor = Color.Black;
                if (row["FECHA_INICIO"] != DBNull.Value)
                    dtPedido.Value = Convert.ToDateTime(row["FECHA_INICIO"]);
                if (row["FECHA_ENTREGA"] != DBNull.Value)
                    dtEntrega.Value = Convert.ToDateTime(row["FECHA_ENTREGA"]);
                string estadoDB = row["ESTADO"].ToString();
                cbxEstado.SelectedIndex = -1;
                foreach (var item in cbxEstado.Items)
                {
                    string nombreItem = "";
                    if (item.GetType().GetProperty("Nombre") != null)
                        nombreItem = item.GetType().GetProperty("Nombre").GetValue(item, null).ToString();

                    if (nombreItem == estadoDB)
                    {
                        cbxEstado.SelectedItem = item;
                        break;
                    }
                }
                if (row.Table.Columns.Contains("ID_CLIENTE") && row["ID_CLIENTE"] != DBNull.Value)
                {
                    var idCliente = row["ID_CLIENTE"]; 
                    cbxCliente.SelectedValue = idCliente;
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPedido == -1)
                {
                    MessageBox.Show("No hay pedido seleccionado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este pedido permanentemente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes)
                {
                    bool exito = pedidosService.EliminarPedido(idPedido);
                    if (exito)
                    {
                        MessageBox.Show("Pedido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        onPedidoGuardado?.Invoke();
                        Cerrar(); 
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
