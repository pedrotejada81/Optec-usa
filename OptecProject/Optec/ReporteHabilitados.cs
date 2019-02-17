using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Optec
{
    public partial class ReporteHabilitados : Form
    {
        public ReporteHabilitados()
        {
            InitializeComponent();
        }
        Metodo conexion = new Metodo();

        private void ReporteHabilitados_Load(object sender, EventArgs e)
        {
            ReportDocument reporteempleado = new ReportDocument();
            reporteempleado.Load(conexion.ruta + "CrystalReportHabilitados.rpt");
            crystalReportViewer1.ReportSource = reporteempleado;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
