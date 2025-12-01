using BLL;
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
    public partial class UserCPedidos : UserControl
    {
        private readonly int id;
        private PedidosService pedidosService = new PedidosService();
        private DataTable dtPedidos;
        public UserCPedidos(int id)
        {
            InitializeComponent();
            this.id = id;
            ConfigurarFiltros();
            CargarPed(pedidosService.MostrarPedidos(id));
            dtDesde.Value = DateTime.Today.AddMonths(-1);
            dtHasta.Value = DateTime.Today;
        }
        private void ConfigurarFiltros()
        {
            cbxFiltro.Items.Add("Todos");
            cbxFiltro.Items.Add("Pendiente");
            cbxFiltro.Items.Add("En Proceso");
            cbxFiltro.Items.Add("Listo");
            cbxFiltro.Items.Add("Entregado");
            cbxFiltro.Items.Add("Cancelado");
            cbxFiltro.SelectedIndex = 0; 
            dtDesde.Value = DateTime.Today.AddMonths(-1);
            dtHasta.Value = DateTime.Today;
            chkFecha.Checked = false; 
        }
        private void CargarPed(DataTable detalle)
        {
            if (detalle == null)
            {
                dgvPedidos.DataSource = new DataTable();
                return;
            }
            dtPedidos = detalle;
            dgvPedidos.DataSource = dtPedidos;
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
            if (colIdPedido != null) colIdPedido.HeaderText = "Numero Pedido";
            var coldocCliente = FindColumn(new[] { "doc_cliente", "DOC_CLIENTE", "Doc_Cliente" });
            if (coldocCliente != null) coldocCliente.Visible = false;
            var colTotal = FindColumn(new[] { "Total", "TOTAL", "precio_total", "PRECIO_TOTAL" });
            if (colTotal != null) colTotal.DefaultCellStyle.Format = "C2";
            var colAbonado = FindColumn(new[] { "Abonado", "ABONADO", "abono", "ABONO" });
            if (colAbonado != null) colAbonado.DefaultCellStyle.Format = "C2";
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
        private void AplicarFiltros()
        {
            if (dtPedidos == null) return;
            string filtro = "";
            if (cbxFiltro.SelectedIndex > 0) 
            {
                string estadoSeleccionado = cbxFiltro.Text;
                filtro += $"ESTADO = '{estadoSeleccionado}'";
            }
            if (chkFecha.Checked)
            {
                string fechaDesde = dtDesde.Value.ToString("yyyy-MM-dd");
                string fechaHasta = dtHasta.Value.ToString("yyyy-MM-dd");
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"FECHA_ENTREGA >= #{dtDesde.Value:MM/dd/yyyy}# AND FECHA_ENTREGA <= #{dtHasta.Value:MM/dd/yyyy}#";
            }
            try
            {
                dtPedidos.DefaultView.RowFilter = filtro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbxFiltro.SelectedIndex = 0;
            chkFecha.Checked = false;
            dtDesde.Value = DateTime.Today.AddMonths(-1);
            dtHasta.Value = DateTime.Today;
            if (dtPedidos != null)
                dtPedidos.DefaultView.RowFilter = "";
        }
    }
}
