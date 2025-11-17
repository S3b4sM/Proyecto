using BLL;
using ENTITY;
using OfficeOpenXml;
using System;
using System.Collections;
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

namespace GUI
{
    public partial class FormHome : Form
    {
        public readonly int Id;
        MovService movService = new MovService();
        PedidosService pedidosService = new PedidosService();
        private DataTable detalleMov; 
        public FormHome(int Id)
        {
            InitializeComponent();
            this.Id = Id;
            Llenarlbls();
            CPI.MouseClick += Chart_MouseClick;
            CPE.MouseClick += Chart_MouseClick;
        }
        #region funcionalidades del form
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtIngresos = movService.CPI(Id);
            DataTable dtEgresos = movService.CPE(Id);
            DataTable DetalleMov = movService.MostrarMovimientos(Id);
            DataTable DetallePed = pedidosService.MostrarPedidos(Id);
            Datos datos = new Datos
            {
                dIngresos = dtIngresos,
                dEgresos = dtEgresos,
                DetalleMov = DetalleMov,
                DetallePed = DetallePed
            };
            e.Result = datos;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error al cargar los datos: " + e.Error.Message);
                return;
            }
            Datos datos = e.Result as Datos;
            if (datos != null)
            {
                cpi(datos.dIngresos);
                cpe(datos.dEgresos);
                detalleMov = datos.DetalleMov;
                llenardgvMovs(detalleMov);
                llenardgvPed(datos.DetallePed);
            }
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
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
                    if(dtPed.Columns.Contains("ID_PEDIDO"))
                    {
                        dtPed.Columns.Remove("ID_PEDIDO");
                        dtPed.Columns.Remove("ID_USER");
                    }
                    //abre la vista para guardar el archivo
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Archivo de Excel (*.xlsx)|*.xlsx",
                        Title = "Guardar Reporte de Movimientos/Pedidos",
                        FileName = $"Movimientos&Pedidos_{DateTime.Now:yyyyMMdd}.xlsx" 
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            //crea el archivo de Excel
                            ExcelPackage.License.SetNonCommercialOrganization("Flowence");
                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Movimientos");
                                ws.Cells["A1"].LoadFromDataTable(dtMov, true);
                                ws.Column(1).Style.Numberformat.Format = "dd/MM/yyyy";
                                ws.Column(2).Style.Numberformat.Format = "$ #,##0.00";
                                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                                ExcelWorksheet ws2 = pck.Workbook.Worksheets.Add("Pedidos");
                                ws2.Cells["A1"].LoadFromDataTable(dtPed, true);
                                ws2.Column(1).Style.Numberformat.Format = "$ #,##0.00";
                                ws2.Column(2).Style.Numberformat.Format = "$ #,##0.00";
                                ws2.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";
                                ws2.Column(5).Style.Numberformat.Format = "dd/MM/yyyy";
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
        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            Chart clickedChart = sender as Chart;
            if (clickedChart == null) 
                return;
            HitTestResult result = clickedChart.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint clickedPoint = clickedChart.Series[result.Series.Name].Points[result.PointIndex];
                string catClick = clickedPoint.AxisLabel;
                DataView dv = detalleMov.DefaultView;
                dv.RowFilter = $"CATEGORIA = '{catClick}'";
                dgvMov.DataSource = dv.ToTable();
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            dgvMov.Columns.Clear();
            dgvMov.DataSource = movService.MostrarMovimientos(Id);
            dgvMov.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMov.Columns["id_movimiento"].Visible = false;
            //dgvMov.Columns["NOMBRE_CLIENTE"].Visible = false;
            //dgvMov.Columns["APELLIDO_CLIENTE"].Visible = false;
            //dgvMov.Columns["id_user"].Visible = false;
            dgvMov.Columns["monto"].DefaultCellStyle.Format = "C2";
        }
        #endregion
        public void Llenarlbls()
        {
            decimal SumIngresos = movService.SumIngresos(this.Id);
            lblIngresos.Text = SumIngresos.ToString("C2");
            decimal SumEgresos = movService.SumEgresos(this.Id);
            lblEgresos.Text = SumEgresos.ToString("C2");
            decimal Balance = SumIngresos - SumEgresos;
            lblBalance.Text = Balance.ToString("C2");
        }
        private void llenardgvMovs(DataTable detalleMov)
        {
            dgvMov.DataSource = detalleMov;
            dgvMov.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMov.Columns["id_movimiento"].Visible = false;
            //dgvMov.Columns["NOMBRE_CLIENTE"].Visible = false;
            //dgvMov.Columns["APELLIDO_CLIENTE"].Visible = false;
            //dgvMov.Columns["id_user"].Visible = false;
            dgvMov.Columns["monto"].DefaultCellStyle.Format = "C2";
        }
        private void llenardgvPed(DataTable detallePed)
        {
            dgvPedidos.DataSource = detallePed;
            dgvPedidos.Columns["inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPedidos.Columns["entrega"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPedidos.Columns["id_pedido"].Visible = false;
            dgvPedidos.Columns["id_user"].Visible = false;
            dgvPedidos.Columns["precio_total"].DefaultCellStyle.Format = "C2";
            dgvPedidos.Columns["precio_total"].HeaderText = "TOTAL";
            dgvPedidos.Columns["descripcion"].HeaderText = "DESCRIP";
            dgvPedidos.Columns["abono"].DefaultCellStyle.Format = "C2";
        }
        public void cpi(DataTable dt)
        {
            DataTable dtIngresos = movService.CPI(this.Id);
            CPI.Series.Clear();
            CPI.DataSource = dtIngresos;
            Series sIngreso = new Series("INGRESOS")
            {
                ChartType = SeriesChartType.Pie
            };
            sIngreso.XValueMember = "NOMBRE";
            sIngreso.YValueMembers = "TOTAL";
            CPI.Series.Add(sIngreso);
            CPI.DataBind();
            CPI.Series["INGRESOS"].IsValueShownAsLabel = false;
            CPI.Series["INGRESOS"].Label = " ";
            CPI.Series["INGRESOS"].LegendText = "#VALX (#PERCENT{P2})";
        }
        public void cpe(DataTable dt)
        {
            DataTable dtEgresos = movService.CPE(this.Id);
            CPE.Series.Clear();
            CPE.DataSource = dtEgresos;
            Series sEgreso = new Series("EGRESOS")
            {
                ChartType = SeriesChartType.Pie
            };
            sEgreso.XValueMember = "NOMBRE";
            sEgreso.YValueMembers = "TOTAL";
            CPE.Series.Add(sEgreso);
            CPE.DataBind();
            CPE.Series["EGRESOS"].IsValueShownAsLabel = true;
            CPE.Series["EGRESOS"].Label = " ";
            CPE.Series["EGRESOS"].LegendText = "#VALX (#PERCENT{P2})";
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
