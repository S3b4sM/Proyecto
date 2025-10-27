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
    public partial class FormUpdate : Form
    {
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTipo.SelectedIndex <= 0 || cbxRazon.SelectedIndex <= 0 || string.IsNullOrEmpty(txtMonto.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                    {
                        MessageBox.Show("Por favor, ingrese valor valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                decimal montoD;
                string montoS = txtMonto.Text.Replace(',', '.');
                if (!decimal.TryParse(montoS, NumberStyles.Any, CultureInfo.InvariantCulture, out montoD) || montoD <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un monto numérico válido y mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dtMov = movService.MostrarMovimientos(this.Id);
                dgvMovimientos.Rows.Clear();
                dgvMovimientos.DataSource = dtMov;
                var movimiento = new Movimiento
                {
                    id = this.Id,
                    fecha = dtFecha.Value,
                    monto = montoD,
                    tipo = Convert.ToInt32(cbxTipo.SelectedValue),
                    razon = cbxRazon.Text,
                    id_categoria = Convert.ToInt32(cbxRazon.SelectedValue)
                };
                MessageBox.Show("Actualización Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movService.Actualizar(movimiento);
                string registro = ($"Id: {Id} | Monto: {montoD:C2} | Tipo: {cbxTipo.Text} | Razón: {cbxRazon.Text} | Fecha: {dtFecha.Value:dd/MM/yyyy}");
                dgvMovimientos.Rows.Clear();
                dgvMovimientos.Rows.Add(registro);
                RefreshDgv();
                txtMonto.Clear();
                cbxTipo.SelectedIndex = -1;
                cbxRazon.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void RefreshDgv()
        {
            throw new NotImplementedException();
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
    }
}
