using BLL;
using ENTITY;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.UserControls
{
    public partial class UserCHome : UserControl
    {
        MovService movService = new MovService();
        PedidosService pedidosService = new PedidosService();
        ClientesService clientesService = new ClientesService();
        private readonly int Id;
        private DataTable detalleMov;
        public UserCHome(int id)
        {
            InitializeComponent();
            this.Id = id;
            CambiarPestaña(true);
            Llenarlbls();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Datos service = new Datos();
            Datos datosCalculados = movService.ObtenerDatos(this.Id);
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
                lblIngresos1.Text = $"↑ {data.PorcentajeIngresos:0.0}%";
                if (data.PorcentajeIngresos >= 0)
                    lblIngresos1.ForeColor = Color.Green;
                else
                {
                    lblIngresos1.ForeColor = Color.Red;
                    lblIngresos1.Text = $"↓ {data.PorcentajeIngresos:0.0}%";
                }
                lblEgresos1.Text = $"↑ {data.PorcentajeEgresos:0.0}%";
                if (data.PorcentajeEgresos > 0)
                {
                    lblEgresos1.ForeColor = Color.Red;
                    lblEgresos1.Text = $"↓ {data.PorcentajeEgresos:0.0}%";
                }
                else
                    lblEgresos1.ForeColor = Color.Green;
                cpi(data.dIngresos);
                cpe(data.dEgresos);
                detalleMov = data.DetalleMov;
                llenardgvMovs(detalleMov);
                llenardgvPed(data.DetallePed);
            }
        }
        private void UserCHome_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void lblTabPedidos_Click(object sender, EventArgs e)
        {
            CambiarPestaña(true);
        }
        private void lblTabMovs_Click(object sender, EventArgs e)
        {
            CambiarPestaña(false);
        }
        public void cpe(DataTable dt)
        {
            DataTable dtEgresos = movService.CPE(this.Id);
            cpee.Series.Clear();
            cpee.DataSource = dtEgresos;
            Series sEgreso = new Series("EGRESOS")
            {
                ChartType = SeriesChartType.Pie
            };
            sEgreso.XValueMember = "NOMBRE";
            sEgreso.YValueMembers = "TOTAL";
            cpee.Series.Add(sEgreso);
            cpee.DataBind();
            cpee.Series["EGRESOS"].IsValueShownAsLabel = true;
            cpee.Series["EGRESOS"].Label = " ";
            cpee.Series["EGRESOS"].LegendText = "#VALX (#PERCENT{P2})";
        }
        public void cpi(DataTable dt)
        {
            DataTable dtIngresos = movService.CPI(this.Id);
            cp.Series.Clear();
            cp.DataSource = dtIngresos;
            Series sIngreso = new Series("INGRESOS")
            {
                ChartType = SeriesChartType.Pie
            };
            sIngreso.XValueMember = "NOMBRE";
            sIngreso.YValueMembers = "TOTAL";
            cp.Series.Add(sIngreso);
            cp.DataBind();
            cp.Series["INGRESOS"].IsValueShownAsLabel = false;
            cp.Series["INGRESOS"].Label = " ";
            cp.Series["INGRESOS"].LegendText = "#VALX (#PERCENT{P2})";
        }
        private void CambiarPestaña(bool mostrarMovimientos)
        {
            Color colorActivo = Color.FromArgb(19, 236, 200); 
            Color colorInactivo = Color.Gray; 

            if (mostrarMovimientos)
            {
                dgvUltimosMovs.Visible = false;
                dgvUltimosPedidos.Visible = true;

                lblTabMovs.ForeColor = colorInactivo;
                lblTabPedidos.ForeColor = colorActivo;
            }
            else
            {
                dgvUltimosMovs.Visible = true;
                dgvUltimosPedidos.Visible = false;

                lblTabMovs.ForeColor = colorActivo;
                lblTabPedidos.ForeColor = colorInactivo;
            }
        }
        private void llenardgvMovs(DataTable detalleMov)
        {
            try
            {
                dgvUltimosMovs.DataSource = detalleMov;
                dgvUltimosMovs.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvUltimosMovs.Columns["id_movimiento"].Visible = false;
                //dgvMov.Columns["NOMBRE_CLIENTE"].Visible = false;
                //dgvMov.Columns["APELLIDO_CLIENTE"].Visible = false;
                //dgvMov.Columns["id_user"].Visible = false;
                dgvUltimosMovs.Columns["monto"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al llenar el DataGridView de movimientos: " + e.Message);
                MessageBox.Show("Error al cargar los movimientos.");
            }
        }
        private void llenardgvPed(DataTable detallePed)
        {
            if (detallePed == null)
            {
                dgvUltimosPedidos.DataSource = new DataTable();
                return;
            }
            dgvUltimosPedidos.DataSource = detallePed;
            Func<string[], DataGridViewColumn> FindColumn = (names) =>
            {
                foreach (DataGridViewColumn col in dgvUltimosPedidos.Columns)
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
            var colDocCliente = FindColumn(new[] { "doc_cliente", "Doc_Cliente", "DOC_CLIENTE", "documento_cliente", "Documento_Cliente" });
            if (colDocCliente != null) colDocCliente.Visible = false;
            var colIdPedido = FindColumn(new[] { "id_pedido", "ID_PEDIDO", "Id_Pedido" });
            if (colIdPedido != null)
            {
                colIdPedido.HeaderText = "Numero Pedido";
            }
            var colFechaInicio = FindColumn(new[] { "fecha_inicio", "Fecha_Inicio", "FECHA_INICIO", "fechaInicio", "FechaInicio" });
            if (colFechaInicio != null) colFechaInicio.Visible = false;
            var colTotal = FindColumn(new[] { "Total", "TOTAL", "precio_total", "PRECIO_TOTAL" });
            if (colTotal != null) colTotal.DefaultCellStyle.Format = "C2";
            var colAbonado = FindColumn(new[] { "Abonado", "ABONADO", "abono", "ABONO" });
            if (colAbonado != null) colAbonado.DefaultCellStyle.Format = "C2";
        }
        private void Llenarlbls()
        {
            int TotalPedidos = pedidosService.PedPendientes(Id);
            lblPedidos.Text = TotalPedidos.ToString();
            int TotalClientes = clientesService.ContarClientes(Id);
            lblClientes.Text = TotalClientes.ToString();
            int ClientesMes = clientesService.ClientesMes(Id);
            lblClientes1.Text = $"+{ClientesMes.ToString()} este mes";
            int PedidosSemana = pedidosService.PedidosSemanal(Id);
            lblPedidos1.Text = $"+{PedidosSemana.ToString()} esta semana";
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMov = movService.MostrarMovimientos(Id);
                DataTable dtPed = pedidosService.MostrarPedidos(Id);
                if (dtMov == null || dtMov.Rows.Count == 0)
                {
                    MessageBox.Show("No hay movimientos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var mesage = MessageBox.Show("¿Desea generar el reporte en Excel?", "Generar Reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mesage == DialogResult.Yes)
                {
                    if (dtMov.Columns.Contains("ID_MOVIMIENTO"))
                    {
                        dtMov.Columns.Remove("ID_MOVIMIENTO");
                    }
                    if (dtPed.Columns.Contains("ID_PEDIDO"))
                    {
                        dtPed.Columns.Remove("DOC_CLIENTE");
                        dtPed.Columns["ID_PEDIDO"].ColumnName = "Numero Pedido";
                    }
                    //abre la vista para guardar el archivo
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Archivo de Excel (*.xlsx)|*.xlsx",
                        Title = "Guardar Reporte de Movimientos/Pedidos",
                        FileName = $"MiTallerPro_{DateTime.Now:yyyyMMdd}.xlsx"
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //crea el archivo de Excel
                            ExcelPackage.License.SetNonCommercialOrganization("MiTallerPro");
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Movimientos");
                                ws.Cells["A1"].LoadFromDataTable(dtMov, true);
                                ws.Column(1).Style.Numberformat.Format = "dd/MM/yyyy";
                                ws.Column(2).Style.Numberformat.Format = "$ #,##0.00";
                                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                                ExcelWorksheet ws2 = pck.Workbook.Worksheets.Add("Pedidos");
                                ws2.Cells["A1"].LoadFromDataTable(dtPed, true);
                                ws2.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";
                                ws2.Column(5).Style.Numberformat.Format = "$ #,##0.00";
                                ws2.Column(6).Style.Numberformat.Format = "dd/MM/yyyy";
                                ws2.Column(7).Style.Numberformat.Format = "$ #,##0.00";
                                ws2.Column(8).Style.Numberformat.Format = "$ #,##0.00";
                                ws2.Cells[ws2.Dimension.Address].AutoFitColumns();
                                FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                                pck.SaveAs(fileInfo);
                            }
                            MessageBox.Show("¡Reporte de Excel generado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al generar el archivo de Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine("Error EPPlus: " + ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general del reporte: " + ex.Message);
                return;
            }
        }
    }
}
