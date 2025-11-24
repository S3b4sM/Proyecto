using BLL;
using ENTITY;
using GUI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UserCEditPedidos : UserControl
    {
        private int idPedido = -1;
        public readonly int Id;
        PedidosService pedidosService = new PedidosService();
        public UserCEditPedidos(int id)
        {
            InitializeComponent();
            this.Id = id;
            RefreshDgv();
            CargarPed(pedidosService.MostrarPedidos(Id));
            LlenarCbxEstado();
            dtFechaI.Value = DateTime.Today;
            dtFechaE.Value = DateTime.Today.AddDays(7);
        }
        #region funcionalidades del form
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormPrincipal FormPrincipal = this.FindForm() as FormPrincipal;
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirUser(() => new UserCPedidos(Id));
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el formulario principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(idPedido == -1)
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
                string TotalS = txtTotal.Text.Replace(',', '.');
                if (!decimal.TryParse(TotalS, NumberStyles.Any, CultureInfo.InvariantCulture, out TotalD) || TotalD <= 0)
                {
                    MessageBox.Show("El valor del total no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotal.Focus();
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
                    fecha_pedido = dtFechaI.Value,
                    fecha_entrega = dtFechaE.Value
                };
                bool resultado = pedidosService.ActualizarPedido(pedido);
                if (resultado)
                {
                    MessageBox.Show("Pedido actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPed(pedidosService.MostrarPedidos(Id));
                    Limpiar();
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
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(idPedido == -1)
                {
                    MessageBox.Show("Seleccione un pedido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea eliminar este Pedido?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messageBoxResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool resultado = pedidosService.EliminarPedido(idPedido);
                    if (resultado)
                    {
                        MessageBox.Show("Pedido eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPed(pedidosService.MostrarPedidos(Id));
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvPedidos.Rows.Count) return;
                DataGridViewRow selectedRow = dgvPedidos.Rows[e.RowIndex];
                if (selectedRow.Cells["ID_PEDIDO"].Value != null)
                {
                    idPedido = Convert.ToInt32(selectedRow.Cells["ID_PEDIDO"].Value);
                }
                txtDescripcion.Text = selectedRow.Cells["Obser"].Value?.ToString() ?? string.Empty;
                var abonoVal = selectedRow.Cells["Abonado"].Value; 
                txtAbono.Text = abonoVal != null
                    ? Convert.ToDecimal(abonoVal).ToString("0.00", CultureInfo.InvariantCulture)
                    : "0.00";

                var totalVal = selectedRow.Cells["Total"].Value; 
                txtTotal.Text = totalVal != null
                    ? Convert.ToDecimal(totalVal).ToString("0.00", CultureInfo.InvariantCulture)
                    : "0.00";

                string estadoGrid = selectedRow.Cells["Estado"].Value?.ToString();
                if (!string.IsNullOrEmpty(estadoGrid))
                {
                    foreach (var item in cbxEstado.Items)
                    {
                        string nombreItem = (string)item.GetType().GetProperty("Nombre").GetValue(item, null);
                        if (nombreItem == estadoGrid)
                        {
                            cbxEstado.SelectedItem = item;
                            break;
                        }
                    }
                }
                if (selectedRow.Cells["Fecha_Entrega"].Value != null)
                {
                    dtFechaE.Value = Convert.ToDateTime(selectedRow.Cells["Fecha_Entrega"].Value);
                }
                if (dgvPedidos.Columns.Contains("fecha_inicio") && selectedRow.Cells["fecha_inicio"].Value != null)
                {
                    dtFechaI.Value = Convert.ToDateTime(selectedRow.Cells["fecha_inicio"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del pedido: " + ex.Message);
                idPedido = -1;
            }
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
        private void RefreshDgv()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.Rows.Clear();
            CargarPed(pedidosService.MostrarPedidos(Id));
            txtAbono.Clear();
            txtTotal.Clear();
            cbxEstado.SelectedIndex = -1;
            idPedido = -1;
            dtFechaI.Value = DateTime.Today;
            dtFechaE.Value = DateTime.Today.AddDays(7);
        }
        private void CargarPed(DataTable detalle)
        {
            if (detalle == null)
            {
                dgvPedidos.DataSource = new DataTable();
                return;
            }
            dgvPedidos.DataSource = detalle;
            Func<string[], DataGridViewColumn> FindColumn = (names) =>
            {
                foreach (DataGridViewColumn col in dgvPedidos.Columns)
                {
                    foreach (var name in names)
                    {
                        if (string.Equals(col.Name, name, StringComparison.OrdinalIgnoreCase))
                            return col;
                    }
                }
                return null;
            };
            var colFecha = FindColumn(new[] { "fecha_entrega", "Fecha_Entrega", "FECHA_ENTREGA", "fechaEntrega", "FechaEntrega" });
            if (colFecha != null)
            {
                colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
                colFecha.HeaderText = "Fecha Entrega";
            }
            var colIdPedido = FindColumn(new[] { "id_pedido", "ID_PEDIDO", "Id_Pedido" });
            if (colIdPedido != null) colIdPedido.Visible = false;
            //var colIdUser = FindColumn(new[] { "id_user", "ID_USER", "Id_User", "ID_USUARIO" });
            //if (colIdUser != null) colIdUser.Visible = false;
            var colTotal = FindColumn(new[] { "Total", "TOTAL", "precio_total", "PRECIO_TOTAL" });
            if (colTotal != null) colTotal.DefaultCellStyle.Format = "C2";
            var colAbonado = FindColumn(new[] { "Abonado", "ABONADO", "abono", "ABONO" });
            if (colAbonado != null) colAbonado.DefaultCellStyle.Format = "C2";
        }
        private void Limpiar()
        {
            txtDescripcion.Clear();
            txtAbono.Text = "0.00";
            txtTotal.Text = "0.00";
            cbxEstado.SelectedIndex = 0;
            dtFechaI.Value = DateTime.Today;
            dtFechaE.Value = DateTime.Today.AddDays(7);
            idPedido = -1;
        }
    }
}
