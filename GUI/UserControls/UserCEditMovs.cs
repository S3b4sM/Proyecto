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
    public partial class UserCEditMovs : UserControl
    {
        private int idMovimiento = -1;
        public readonly int Id;
        MovService movService = new MovService();
        CategoriaService categoryServices = new CategoriaService();
        public UserCEditMovs(int id)
        {
            InitializeComponent();
            this.Id = id;
            CargarCat(true);
            LlenarCbxTipo();
            CargarMov();
        }
        #region Funcionalidades
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idMovimiento == -1)
                {
                    MessageBox.Show("Por favor, seleccione un moviento para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea actualizar este movimiento?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBoxResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    decimal montoD;
                    string montoS = txtMonto.Text.Replace(',', '.');
                    if (!decimal.TryParse(montoS, NumberStyles.Any, CultureInfo.InvariantCulture, out montoD) || montoD <= 0)
                    {
                        MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var movimiento = new Movimiento
                    {
                        id = idMovimiento,
                        fecha = dtFecha.Value,
                        monto = montoD,
                        tipo = Convert.ToInt32(cbxTipo.SelectedValue),
                        razon = cbxRazon.Text,
                        id_categoria = Convert.ToInt32(cbxRazon.SelectedValue),
                        descripcion = txtDescripcion.Text.Trim(),
                        id_user = this.Id
                    };
                    bool exito = movService.Actualizar(movimiento);
                    if (exito)
                    {
                        MessageBox.Show("Movimiento actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDgv();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el Movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error al actualizar el movimiento: " + x.Message);
                MessageBox.Show("Ocurrió un error inesperado al eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idMovimiento == -1)
                {
                    MessageBox.Show("Por favor, seleccione un moviento para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea eliminar este movimiento?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (messageBoxResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int idEliminar = Convert.ToInt32(dgvMovimientos.SelectedRows[0].Cells["id_movimiento"].Value);
                    bool exito = movService.Eliminar(idEliminar);
                    if (exito)
                    {
                        MessageBox.Show("Movimiento eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDgv();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al elimiar el movimiento: " + ex.Message);
                MessageBox.Show("Ocurrió un error inesperado al eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxTipo.SelectionLength = 0;
            this.ActiveControl = null;
        }
        private void cbxRazon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxRazon.SelectionLength = 0;
            this.ActiveControl = null;
        }
        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMovimientos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMovimientos.SelectedRows[0];
                idMovimiento = Convert.ToInt32(selectedRow.Cells["id_movimiento"].Value);
                dtFecha.Value = Convert.ToDateTime(selectedRow.Cells["fecha"].Value);
                txtMonto.Text = selectedRow.Cells["monto"].Value.ToString();
                txtDescripcion.Text = selectedRow.Cells["descripcion"].Value.ToString();
                string tipo = selectedRow.Cells["tipo"].Value.ToString();
                foreach (var item in cbxTipo.Items)
                {
                    if (item is DataRowView drv && drv["Nombre"].ToString() == tipo)
                    {
                        cbxTipo.SelectedValue = drv["Id_Tipo"];
                        break;
                    }
                    else if (item.ToString() == tipo)
                    {
                        cbxTipo.SelectedItem = item;
                        break;
                    }
                }
                string razon = selectedRow.Cells["categoria"].Value.ToString();
                foreach (var item in cbxRazon.Items)
                {
                    if (item is DataRowView drv && drv["Nombre"].ToString() == razon)
                    {
                        cbxRazon.SelectedValue = drv["Id_Categoria"];
                        break;
                    }
                    else if (item.ToString() == razon)
                    {
                        cbxRazon.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LlenarCbxTipo()
        {
            DataTable tipos = categoryServices.CargarTipos();
            if (tipos != null && tipos.Rows.Count > 0)
            {
                DataRow defaultRow = tipos.NewRow();
                defaultRow["ID_TIPO"] = 0;
                defaultRow["NOMBRE"] = "Tipos";
                tipos.Rows.InsertAt(defaultRow, 0);
                cbxTipo.DataSource = tipos;
                cbxTipo.DisplayMember = "NOMBRE";
                cbxTipo.ValueMember = "ID_TIPO";
                cbxTipo.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Error al cargar los tipos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxTipo.DataSource = null;
                cbxTipo.Items.Clear();
                cbxTipo.Items.Add(new { ID_TIPO = 0, NOMBRE = "No hay tipos disponibles" });
                cbxTipo.DisplayMember = "NOMBRE";
                cbxTipo.ValueMember = "ID_TIPO";
                cbxTipo.SelectedIndex = 0;
            }
        }
        #endregion
        private void CargarMov()
        {
            dgvMovimientos.DataSource = movService.MostrarMovimientos(this.Id);
            dgvMovimientos.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovimientos.Columns["id_movimiento"].Visible = false;
            dgvMovimientos.Columns["monto"].DefaultCellStyle.Format = "C2";
        }
        private void RefreshDgv()
        {
            dgvMovimientos.DataSource = null;
            dgvMovimientos.Rows.Clear();
            CargarMov();
            txtMonto.Clear();
            cbxTipo.SelectedIndex = 0;
            cbxRazon.SelectedIndex = 0;
            idMovimiento = -1;
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

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbxTipo.SelectedValue.ToString(), out int idTipoSeleccionado))
            {
                if (idTipoSeleccionado == 0)
                {
                    cbxRazon.DataSource = null;
                    cbxRazon.Items.Clear();
                    cbxRazon.Items.Add(new { ID_CATEGORIA = 0, NOMBRE = "Razon" });
                    cbxRazon.DisplayMember = "NOMBRE";
                    cbxRazon.ValueMember = "ID_CATEGORIA";
                    cbxRazon.SelectedIndex = 0;

                }
                else
                {
                    bool esIngreso = (idTipoSeleccionado == 1);
                    CargarCat(esIngreso);
                }
            }
            else
            {
                cbxRazon.DataSource = null;
                cbxRazon.Items.Clear();
                cbxRazon.Items.Add(new { ID_CATEGORIA = 0, NOMBRE = "Razon" });
                cbxRazon.DisplayMember = "NOMBRE";
                cbxRazon.ValueMember = "ID_CATEGORIA";
                cbxRazon.SelectedIndex = 0;
            }
        }
        private void CargarCat(bool esIngreso)
        {
            DataTable categorias = categoryServices.CatPorTipo(esIngreso);
            cbxRazon.DataSource = null;
            cbxRazon.Items.Clear();
            if (categorias != null && categorias.Rows.Count > 0)
            {
                DataRow defaultRow = categorias.NewRow();
                defaultRow["ID_CATEGORIA"] = 0;
                defaultRow["NOMBRE"] = "Razon";
                categorias.Rows.InsertAt(defaultRow, 0);
                cbxRazon.DataSource = categorias;
                cbxRazon.DisplayMember = "NOMBRE";
                cbxRazon.ValueMember = "ID_CATEGORIA";
                cbxRazon.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show($"No hay categorías disponibles para el tipo {(esIngreso ? "Ingreso" : "Egreso")}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxRazon.Items.Add(new { ID_CATEGORIA = 0, NOMBRE = "Razon" });
                cbxRazon.DisplayMember = "NOMBRE";
                cbxRazon.ValueMember = "ID_CATEGORIA";
                cbxRazon.SelectedIndex = 0;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtMonto.Text.Contains(e.KeyChar.ToString()) && txtMonto.Text.Length > 0)
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

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            string textoLimpio = txtMonto.Text.Trim().Replace(',', '.');

            decimal monto;
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
            {
                txtMonto.Text = monto.ToString("0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtMonto.Text = "0.00";
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
