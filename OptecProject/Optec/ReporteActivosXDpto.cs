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
    public partial class ReporteActivosXDpto : Form
    {
        Metodo conexion = new Metodo();

        public ReporteActivosXDpto()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
           
        }

        public void reportes(string parametro)
        {
            ReportDocument reporteempleado = new ReportDocument();
            reporteempleado.Load(conexion.ruta + "CrystalReportxDepartamento.rpt");
            
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = cbBuscar.Text;
            crParameterFieldDefinitions = reporteempleado.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[parametro];
            
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = reporteempleado;
            crystalReportViewer1.Refresh();

        }

        private void ReporteActivosXDpto_Load(object sender, EventArgs e)
        {
            cbBuscar.DataSource = conexion.SelectDepartamento();
            cbBuscar.DisplayMember = "Departamento";
            cbBuscar.ValueMember = "Id";
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                reportes("departamento");

            }
            catch
            {

            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.PrintReport();
        }
    }
}
