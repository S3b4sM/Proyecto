using BLL;
using ENTITY;
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
    public partial class UserCPedidos : UserControl
    {
        private int idPedido = -1;
        public readonly int Id;
        PedidosService pedidosService = new PedidosService();
        public UserCPedidos(int id)
        {
            InitializeComponent();
            this.Id = id;
            RefreshDgv();
            CargarPed();
            LlenarCbxEstado();
            dtFechaI.Value = DateTime.Today;
            dtFechaE.Value = DateTime.Today.AddDays(7);
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
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(idPedido == -1)
                {
                    MessageBox.Show("Seleccione un pedido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea actualizar este Pedido?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBoxResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    decimal AbonoD;
                    string AbonoS = txtAbono.Text.Replace(',', '.');
                    if (!decimal.TryParse(AbonoS, NumberStyles.Any, CultureInfo.InvariantCulture, out AbonoD) || AbonoD <= 0)
                    {
                        MessageBox.Show("El valor del abono no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal TotalD;
                    string TotalS = txtTotal.Text.Replace(',', '.');
                    if (!decimal.TryParse(TotalS, NumberStyles.Any, CultureInfo.InvariantCulture, out TotalD) || TotalD <= 0)
                    {
                        MessageBox.Show("El valor del total no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        CargarPed();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception x)
            {
                Console.WriteLine("Error al actualizar el movimiento: " + x.Message);
                MessageBox.Show("Error al actualizar el pedido: " + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void CargarPed()
        {
            try
            {
                dgvPedidos.DataSource = pedidosService.MostrarPedidos(this.Id);
                dgvPedidos.Columns["inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPedidos.Columns["entrega"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPedidos.Columns["id_pedido"].Visible = false;
                dgvPedidos.Columns["id_user"].Visible = false;
                dgvPedidos.Columns["precio_total"].DefaultCellStyle.Format = "C2";
                dgvPedidos.Columns["precio_total"].HeaderText = "TOTAL";
                dgvPedidos.Columns["abono"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        CargarPed();
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
            CargarPed();
            txtAbono.Clear();
            txtTotal.Clear();
            cbxEstado.SelectedIndex = -1;
            idPedido = -1;
            dtFechaI.Value = DateTime.Today;
            dtFechaE.Value = DateTime.Today.AddDays(7);
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                DataGridViewRow selectedRow = dgvPedidos.Rows[e.RowIndex];
                idPedido = Convert.ToInt32(selectedRow.Cells["id_pedido"].Value);
                txtDescripcion.Text = selectedRow.Cells["descripcion"].Value?.ToString() ?? string.Empty;
                var abonoVal = selectedRow.Cells["abono"].Value;
                var totalVal = selectedRow.Cells["precio_total"].Value;
                txtAbono.Text = abonoVal != null ? Convert.ToDecimal(abonoVal).ToString(CultureInfo.InvariantCulture) : string.Empty;
                txtTotal.Text = totalVal != null ? Convert.ToDecimal(totalVal).ToString(CultureInfo.InvariantCulture) : string.Empty;
                cbxEstado.Text = selectedRow.Cells["estado"].Value?.ToString() ?? string.Empty;
                dtFechaI.Value = Convert.ToDateTime(selectedRow.Cells["inicio"].Value);
                dtFechaE.Value = Convert.ToDateTime(selectedRow.Cells["entrega"].Value);
            }
            catch (Exception ex)
            {
                return;
            }
            
        }
    }
}
