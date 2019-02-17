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
    public partial class ReporteVolantes : Form
    {
        public ReporteVolantes()
        {
            InitializeComponent();
        }

        Metodo metodos = new Metodo();

        private void ReporteVolantes_Load(object sender, EventArgs e)
        {
            NominaPorFecha();
            reportes("Nomina");
        }

        private void cbNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                reportes("Nomina");

            }
            catch { }
        }

        public void NominaPorFecha()
        {
            DataTable x = metodos.NominaPorFecha();

            cbNomina.DataSource = x;
            cbNomina.ValueMember = "IdFechaNomina";
            cbNomina.DisplayMember = "FechaDeNomina";

        }

        public void reportes(string parametro)
        {
            ReportDocument reporteempleado = new ReportDocument();
            reporteempleado.Load(metodos.ruta+"CrystalReportVolantes.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = cbNomina.Text;
            crParameterFieldDefinitions = reporteempleado.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[parametro];

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = reporteempleado;
            crystalReportViewer1.Refresh();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.PrintReport();
        }
    }
}
