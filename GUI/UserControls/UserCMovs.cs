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

namespace GUI.UserControls
{
    public partial class UserCMovs : UserControl
    {
        MovService movService = new MovService();
        CategoriaService categoryServices = new CategoriaService();
        private DataTable detalleMov;
        private readonly int id;
        public UserCMovs(int id)
        {
            InitializeComponent();
            this.id = id;
            CargarCat(true);
            LlenarCbxTipo();
            dtFecha.Value = DateTime.Now;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Datos service = new Datos();
            Datos datosCalculados = movService.ObtenerDatos(this.id);
            e.Result = datosCalculados;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
                return;
            }
            Datos data = e.Result as Datos;
            if (data != null)
            {
                lblIngresos.Text = data.TotalIngresos.ToString("C2");
                lblEgresos.Text = data.TotalEgresos.ToString("C2");
                lblBalance.Text = data.Balance.ToString("C2");
                lblIngresos1.Text = $"↑ {data.PorcentajeIngresos:0.0}% vs mes anterior";
                if (data.PorcentajeIngresos >= 0)
                    lblIngresos1.ForeColor = Color.Green;
                else
                {
                    lblIngresos1.ForeColor = Color.Red;
                    lblIngresos1.Text = $"↓{data.PorcentajeIngresos:0.0}% vs mes anterior";
                }
                lblEgresos1.Text = $"↑ {data.PorcentajeEgresos:0.0}% vs mes anterior";
                if (data.PorcentajeEgresos > 0)
                {
                    lblEgresos1.ForeColor = Color.Red;
                    lblEgresos1.Text = $"↓ {data.PorcentajeEgresos:0.0}% vs mes anterior";
                }
                else
                    lblEgresos1.ForeColor = Color.Green;
                lblBalance1.Text = $"↑ {data.Balance:0.0}% vs mes anterior";
                if (data.Balance >= 0)
                {
                    lblBalance1.ForeColor = Color.Green;
                }
                else
                {
                    lblBalance1.ForeColor = Color.Red;
                    lblBalance1.Text = $"↓ {data.Balance:0.0}% vs mes anterior";
                }
                detalleMov = data.DetalleMov;
                llenardgvMovs(detalleMov);
            }
        }
        private void UserCMovs_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
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
                string descripcion = txtDescrip.Text.Trim();
                int idTipo = Convert.ToInt32(cbxTipo.SelectedValue);
                int idCategoria = Convert.ToInt32(cbxRazon.SelectedValue);
                DateTime fecha = dtFecha.Value;
                int idUsuario = this.id;
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
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al registrar movimiento: " + ex.ToString());
            }
        }
        private void txtDescrip_Enter(object sender, EventArgs e)
        {
            if (txtDescrip.Text == "Detalle del movimineto")
            {
                txtDescrip.Text = "";
                txtDescrip.ForeColor = Color.Black;
            }
        }
        private void txtDescrip_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescrip.Text))
            {
                txtDescrip.Text = "Detalle del movimineto";
                txtDescrip.ForeColor = Color.DimGray;
            }
        }
        private void txtMonto_Enter(object sender, EventArgs e)
        {
            if (txtMonto.Text == "$ 0.00")
            {
                txtMonto.Text = "";
                txtMonto.ForeColor = Color.Black;
            }
        }
        private void txtMonto_Leave(object sender, EventArgs e)
        {
            string textoLimpio = txtMonto.Text.Trim().Replace(',', '.');
            decimal monto;
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                txtMonto.Text = "$ 0.00";
                txtMonto.ForeColor = Color.DimGray;
            }
            if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
            {
                txtMonto.Text = monto.ToString("$ 0.00", CultureInfo.CurrentCulture);
            }
            else
            {
                txtMonto.ForeColor = Color.DimGray;
                txtMonto.Text = "$ 0.00";
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void RefreshDgv()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void Limpiar()
        {
            cbxTipo.SelectedIndex = 0;
            cbxRazon.SelectedIndex = 0;
            dtFecha.Value = DateTime.Now;
            txtMonto.Text = "$ 0.00";
            txtMonto.ForeColor = Color.DimGray;
            txtDescrip.Text = "Detalle del movimineto";
            llenardgvMovs(detalleMov);
            RefreshDgv();
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
        private void llenardgvMovs(DataTable detalleMov)
        {
            try
            {
                dgvMovs.DataSource = detalleMov;
                dgvMovs.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMovs.Columns["id_movimiento"].Visible = false;
                dgvMovs.Columns["monto"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al llenar el DataGridView de movimientos: " + e.Message);
                MessageBox.Show("Error al cargar los movimientos.");
            }
        }
    }
}
