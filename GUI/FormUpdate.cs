using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormUpdate : Form
    {
        private int idMovimiento = -1;
        public readonly int Id;
        private List<string> registros = new List<string>();
        MovService movService = new MovService();
        public FormUpdate(int id)
        {
            InitializeComponent();
            this.Id = id;
            LlenarCbxRazon();
            LlenarCbxTipo();
            CargarMov();
        }
        #region Funcionalidades
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var messageBoxResult = MessageBox.Show("¿Está seguro de que desea actualizar este movimiento?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBoxResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (idMovimiento == -1)
                    {
                        MessageBox.Show("Por favor, seleccione un moviento para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal montoD;
                    string montoS = txtMonto.Text.Replace(',', '.');
                    if (!decimal.TryParse(montoS, NumberStyles.Any, CultureInfo.InvariantCulture, out montoD) || montoD <= 0)
                    {
                        MessageBox.Show("Por favor, ingrese un monto numérico válido y mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Por favor, seleccione un moviento para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void FormUpdate_Load(object sender, EventArgs e)
        {

        }
        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMovimientos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMovimientos.SelectedRows[0];
                idMovimiento = Convert.ToInt32(selectedRow.Cells["id_movimiento"].Value);
                dtFecha.Value = Convert.ToDateTime(selectedRow.Cells["fecha"].Value);
                txtMonto.Text = selectedRow.Cells["monto"].Value.ToString();
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
        private void RefreshDgv()
        {
            dgvMovimientos.DataSource = null;
            dgvMovimientos.Rows.Clear();
            CargarMov();
            txtMonto.Clear();
            cbxTipo.SelectedIndex = -1;
            cbxRazon.SelectedIndex = -1;
            idMovimiento = -1;
        }
        private void LlenarCbxRazon()
        {
            CategoriaService categoryServices = new CategoriaService();
            DataTable categorias = categoryServices.CargarRazon();
            if (categorias != null && categorias.Rows.Count > 0)
            {
                categorias = categoryServices.CargarRazon();
                cbxRazon.DataSource = categorias;
                cbxRazon.DisplayMember = "NOMBRE";
                cbxRazon.ValueMember = "ID_CATEGORIA";
                cbxRazon.SelectedIndex = 0;
                this.ActiveControl = null;
            }
            else
            {
                MessageBox.Show("Error al cargar las categorías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarCbxTipo()
        {
            CategoriaService categoryServices = new CategoriaService();
            DataTable tipos = categoryServices.CargarTipos();
            if (tipos != null && tipos.Rows.Count > 0)
            {
                tipos = categoryServices.CargarTipos();
                cbxTipo.DataSource = tipos;
                cbxTipo.DisplayMember = "NOMBRE";
                cbxTipo.ValueMember = "ID_TIPO";
                cbxTipo.SelectedIndex = 0;
                this.ActiveControl = null;
            }
            else
            {
                MessageBox.Show("Error al cargar los tipos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarMov()
        {
            dgvMovimientos.DataSource = movService.MostrarMovimientos(this.Id);
            dgvMovimientos.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovimientos.Columns["id_movimiento"].Visible = false;
            dgvMovimientos.Columns["monto"].DefaultCellStyle.Format = "C2";
        }
        #endregion
    }
}
