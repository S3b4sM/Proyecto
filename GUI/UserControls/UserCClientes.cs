using BLL;
using ENTITY;
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
        private int documento = -1;
        private string nombreCliente = "";
        ClientesService clientesService = new ClientesService();
        public UserCClientes(int id)
        {
            InitializeComponent();
            this.id = id;
            llenarClientes(clientesService.ObtenerClientes(this.id));
            PanelAgg.Visible = true;
            btnAggCliente.Visible = false;
        }
        public void llenarClientes(DataTable detalleClientes)
        {
            if(detalleClientes == null)
            {
                dgvClientes.DataSource = new DataTable();
                return;
            }
            dgvClientes.DataSource = detalleClientes;
            Func<string[], DataGridViewColumn> FindColumn = (names) =>
            {
                foreach (DataGridViewColumn col in dgvClientes.Columns)
                {
                    foreach (var name in names)
                    {
                        if (string.Equals(col.Name, name, StringComparison.OrdinalIgnoreCase))
                            return col;
                    }
                }
                return null;
            };
            var colId = FindColumn(new string[] { "Id_usuario", "ID", "Id" });
            if (colId != null) colId.Visible = false;
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (dgvClientes.DataSource is DataTable dt)
            {
                string busqueda = txtFiltro.Text.Trim().Replace("'", "''");
                string textoActual = txtFiltro.Text;
                if (textoActual == "Buscar por nombre o documento" || string.IsNullOrWhiteSpace(busqueda))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter = $"(NOMBRE LIKE '%{busqueda}%' OR Convert(DOCUMENTO, 'System.String') LIKE '%{busqueda}%' OR Convert(TELEFONO, 'System.String') LIKE '%{busqueda}%')";
                }
            }
        }
        private void txtFiltro_Enter(object sender, EventArgs e)
        {
            if (txtFiltro.Text == "Buscar por nombre o documento")
            {
                txtFiltro.Text = "";
                txtFiltro.ForeColor = Color.Black;
            }
        }
        private void txtFiltro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                txtFiltro.Text = "Buscar por nombre o documento";
                txtFiltro.ForeColor = Color.DimGray;
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvClientes.SelectedRows[0];
                documento = Convert.ToInt32(fila.Cells["DOCUMENTO"].Value);
                nombreCliente = fila.Cells["NOMBRE"].Value.ToString();
                txtDoc.Text = fila.Cells["DOCUMENTO"].Value.ToString();
                txtNombre.Text = fila.Cells["NOMBRE"].Value.ToString();
                txtTel.Text = fila.Cells["TELEFONO"].Value.ToString();
                txtDireccion.Text = fila.Cells["DIRECCION"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #region editar clietnes
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (documento == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var resultado = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                int docEliminar = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["DOCUMENTO"].Value);
                bool exito = clientesService.EliminarCliente(docEliminar);
                if (exito)
                {
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarClientes(clientesService.ObtenerClientes(this.id));
                    documento = -1;
                    txtNombre.Clear();
                    txtTel.Clear();
                    txtDireccion.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente. Puede que esté asociado a pedidos existentes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (documento == -1)
                {
                    MessageBox.Show("Por favor, seleccione un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var resultado = MessageBox.Show("¿Está seguro de que desea actualizar este cliente?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    string docActualizar = txtDoc.Text.Trim();
                    string nuevoNombre = txtNombre.Text.Trim();
                    string nuevoTel = txtTel.Text.Trim();
                    string nuevaDireccion = txtDireccion.Text.Trim();
                    Clientes clientes = new Clientes
                    {
                        documento = docActualizar,
                        nombre = nuevoNombre,
                        telefono = nuevoTel,
                        id_user = this.id,
                        direccion = nuevaDireccion
                    };
                    bool exito = clientesService.ActualizarCliente(clientes);
                    if (exito)
                    {
                        MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        llenarClientes(clientesService.ObtenerClientes(this.id));
                        LimpiarActu();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LimpiarActu()
        {
            documento = -1;
            txtDoc.Clear();
            txtNombre.Clear();
            txtTel.Clear();
            txtDireccion.Clear();
        }
        private void txtNotas_Enter(object sender, EventArgs e)
        {
            if(txtNotas.Text == "Añadir notas sobre el cliente...")
            {
                txtNotas.Text = "";
                txtNotas.ForeColor = Color.Black;
            }
        }
        private void txtNotas_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotas.Text))
            {
                txtNotas.Text = "Añadir notas sobre el cliente...";
                txtNotas.ForeColor = Color.DimGray;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            documento = -1;
            txtNombre.Clear();
            txtTel.Clear();
            txtDireccion.Clear();
            txtNotas.Text = "Añadir notas sobre el cliente...";
            txtNotas.ForeColor = Color.DimGray;
        }
        #endregion
        public void CambiarModo(bool modoEdicion)
        {
            if (modoEdicion)
            {
                PanelAgg.Visible = false;
                PanelEdit.Visible = true;
                btnAggCliente.Visible = true;

            }
            else
            {
                PanelAgg.Visible = true;
                PanelEdit.Visible = false;
            }
        }
        private void btnAggCliente_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            PanelAgg.Visible = true;
            PanelEdit.Visible = false;
            btnAggCliente.Visible = false;
        }
        #region agregar cliente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            { 
                if (string.IsNullOrWhiteSpace(txtDocumento.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtTele.Text) || 
                string.IsNullOrWhiteSpace(txtDir.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios (Documento, Nombre, Apellido, Teléfono).", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Clientes nuevoCliente = new Clientes
                {
                    id_user = this.id,
                    documento = txtDocumento.Text.Trim(),
                    nombre = txtName.Text.Trim(),
                    telefono = txtTele.Text.Trim(),
                    direccion = txtDir.Text.Trim()
                };
                bool exito = clientesService.AggClientes(nuevoCliente);
                if (exito)
                {
                    MessageBox.Show("Cliente registrado correctamente. Ahora puede agregar las medidas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    llenarClientes(clientesService.ObtenerClientes(this.id));
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-00001") || ex.Message.Contains("unique constraint"))
                {
                    MessageBox.Show("Ya existe un cliente registrado con ese número de documento.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Limpiar()
        {
            txtDocumento.Clear();
            txtName.Clear();
            txtTele.Clear();
            txtDir.Clear();
            txtNots.Text = "Añadir notas sobre el cliente...";
            txtNots.ForeColor = Color.DimGray;
        }   
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion
        public void Recargar()
        {
            var dt = clientesService.ObtenerClientes(this.id);
            llenarClientes(dt);
        }
        private void btnMedidas_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = this.FindForm() as FormPrincipal;
            if (formPrincipal != null)
            {
                if (documento <= 0)
                {
                    MessageBox.Show("Por favor, seleccione un cliente para agregar medidas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UserCMedidas controlAgregar = new UserCMedidas(documento, this.Recargar, nombreCliente);
                formPrincipal.MostrarModal(controlAgregar);
            }
        }
    }
}
