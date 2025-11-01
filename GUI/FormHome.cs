using BLL;
using ENTITY;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private DataTable detalleMov; 
        public FormHome(int Id)
        {
            InitializeComponent();
            this.Id = Id;
            Llenarlbls();
            CPI.MouseClick += Chart_MouseClick;
            CPE.MouseClick += Chart_MouseClick;

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtIngresos = movService.CPI(Id);
            DataTable dtEgresos = movService.CPE(Id);
            DataTable DetalleMov = movService.DetalleMov(Id);
            Datos datos = new Datos
            {
                dIngresos = dtIngresos,
                dEgresos = dtEgresos,
                DetalleMov = DetalleMov
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
                llenardgv(detalleMov);
            }
        }
        private void llenardgv(DataTable detalleMov)
        {
            dgvMov.DataSource = detalleMov;
            dgvMov.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMov.Columns["id_movimiento"].Visible = false;
            dgvMov.Columns["monto"].DefaultCellStyle.Format = "C2";
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
                var mesage = MessageBox.Show("¿Desea generar el reporte en Excel?", "Generar Reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mesage == DialogResult.Yes)
                {
                    //movService.GenerarExcel(this.Id);
                    MessageBox.Show("Reporte generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar reporte: " + ex.Message);
                return;
            }
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
            CPI.Series["INGRESOS"].IsValueShownAsLabel = true;
            CPI.Series["INGRESOS"].Label = "#PERCENT{P2}";
            CPI.Series["INGRESOS"].LegendText = "#VALX";
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
            //CPE.Titles.Add("Distribución de Egresos");
            CPE.Series["EGRESOS"].IsValueShownAsLabel = true;
            CPE.Series["EGRESOS"].Label = "#PERCENT{P2}";
            CPE.Series["EGRESOS"].LegendText = "#VALX";
        }
        public void cpt(DataTable dt)
        {

        }
        public void Llenarlbls()
        {
            decimal SumIngresos = movService.SumIngresos(this.Id);
            lblIngresos.Text = SumIngresos.ToString("C2");
            decimal SumEgresos = movService.SumEgresos(this.Id);
            lblEgresos.Text = SumEgresos.ToString("C2");
            decimal Balance = SumIngresos - SumEgresos;
            lblBalance.Text = Balance.ToString("C2");
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
            dgvMov.DataSource = movService.DetalleMov(Id);
            dgvMov.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMov.Columns["id_movimiento"].Visible = false;
            dgvMov.Columns["monto"].DefaultCellStyle.Format = "C2";
        }
    }
}
