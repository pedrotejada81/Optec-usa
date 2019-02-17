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
    public partial class ReporteRegalia : Form
    {
        public ReporteRegalia()
        {
            InitializeComponent();
        }
        Metodo conexiones = new Metodo();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            reportes("Fecha1", "Fecha2");
            

        }

        public void reportes(string fecha1, string fecha2)
        {
             ReportDocument cryRpt = new ReportDocument();
             cryRpt.Load(conexiones.ruta+"CrystalReportRegalia.rpt");


             ParameterFieldDefinitions crParameterFieldDefinitions;
             ParameterFieldDefinition crParameterFieldDefinition;
             ParameterValues crParameterValues = new ParameterValues();
             ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = dtpInicio.Value.ToShortDateString();
             crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
             crParameterFieldDefinition = crParameterFieldDefinitions[fecha1];
             crParameterValues = crParameterFieldDefinition.CurrentValues;

             crParameterValues.Clear();
             crParameterValues.Add(crParameterDiscreteValue);
             crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = dtpFinal.Value.ToShortDateString();
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
             crParameterFieldDefinition = crParameterFieldDefinitions[fecha2];
             crParameterValues = crParameterFieldDefinition.CurrentValues;

             crParameterValues.Add(crParameterDiscreteValue);
             crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);           

             crystalReportViewer1.ReportSource = cryRpt;
             crystalReportViewer1.Update();
             crystalReportViewer1.Refresh();
            

        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();
            crystalReportViewer1.PrintReport();
        }

        private void ReporteRegalia_Load(object sender, EventArgs e)
        {

        }
    }
}
