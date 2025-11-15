using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Microsoft.VisualBasic;

namespace GUI
{
    public partial class FormAgg : Form
    {
        public readonly int Id;
        MovService movService = new MovService();
        CategoriaService catService = new CategoriaService();
        public FormAgg(int Id)
        {
            InitializeComponent();
            this.Id = Id;
            LlenarCbxTipo();
            CargarCat(true);
            dtFecha.Value = DateTime.Today;
        }
        #region Funcionalidades del Form
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbxTipo.SelectedValue) == 0)
                {
                    MessageBox.Show("Por favor, seleccione un Tipo de movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt32(cbxRazon.SelectedValue) == 0)
                {
                    MessageBox.Show("Por favor, seleccione una Categoría para el movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal montoD;
                string montoS = txtMonto.Text.Replace(',', '.');
                if (!decimal.TryParse(montoS, NumberStyles.Any, CultureInfo.InvariantCulture, out montoD) || montoD <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string descripcion = txtDescripcion.Text.Trim();
                int idTipo = Convert.ToInt32(cbxTipo.SelectedValue);
                int idCategoria = Convert.ToInt32(cbxRazon.SelectedValue);
                DateTime fecha = dtFecha.Value;
                int idUsuario = this.Id;
                string desc = descripcion;
                movService.AgregarMov(
                    fecha: fecha,
                    monto: montoD,
                    tipo: idTipo,
                    id_cat: idCategoria,
                    id_user: idUsuario,
                    desc: descripcion
                );
                MessageBox.Show("Movimiento registrado con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Clear();
                txtDescripcion.Clear();
                dtFecha.Value = DateTime.Today;
                cbxTipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al registrar movimiento: " + ex.ToString());
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
        #endregion
        private void LlenarCbxTipo()
        {
            DataTable tipos = catService.CargarTipos();
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
        private void CargarCat(bool esIngreso)
        {
            DataTable categorias = catService.CatPorTipo(esIngreso);
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
    }
}
