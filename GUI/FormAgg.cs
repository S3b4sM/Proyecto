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
        private List<string> registros = new List<string>();
        public readonly int Id;
        MovService movService = new MovService();
        public FormAgg(int Id)
        {
            InitializeComponent();
            this.Id = Id;
            LlenarCbxRazon();
            LlenarCbxTipo();
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try {
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
                //int idTipo = Convert.ToInt32(cbxTipo.SelectedValue);
                //int idCategoria = Convert.ToInt32(cbxRazon.SelectedValue);
                //string razonTexto = cbxRazon.Text;
                var movimiento = movService.AgregarMov(
                    fecha: dtFecha.Value,
                    monto: montoD, 
                    tipo: Convert.ToInt32(cbxTipo.SelectedValue),       
                    id_user: Id,
                    id_cat: Convert.ToInt32(cbxRazon.SelectedValue)
                );
                MessageBox.Show("Registro Exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string registro = ($"Id: {Id} | Monto: {montoD:C2} | Tipo: {cbxTipo.Text} | Razón: {cbxRazon.Text} | Fecha: {dtFecha.Value:dd/MM/yyyy}");
                registros.Add(registro); 
                RefreshLbx(); 
                txtMonto.Clear();
                cbxTipo.SelectedIndex = -1;
                cbxRazon.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error registrar movimiento " + ex.Message);
            }
            
        }

        private void FormAgg_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = registros;
        }
        #endregion
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
        private void RefreshLbx()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = registros;
        }
    }
}
