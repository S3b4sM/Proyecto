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

        public FormHome(int Id)
        {
            InitializeComponent();
            this.Id = Id;
            Llenarlbls();

        }
        private void CPI_Click(object sender, EventArgs e)
        {

        }

        private void CPI_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Id}");
            movService.SumIngresos(Id);
            MessageBox.Show("Ingreso sumado");
            MessageBox.Show($"{movService.SumIngresos(Id)}");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtIngresos = movService.CPI(Id);
            DataTable dtEgresos = movService.CPE(Id);
            Datos datos = new Datos
            {
                dIngresos = dtIngresos,
                dEgresos = dtEgresos
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
            }
        }
        public void cpi (DataTable dt)
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
            CPI.Titles.Add("Distribución de Ingresos");
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
        private void FormHome_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
