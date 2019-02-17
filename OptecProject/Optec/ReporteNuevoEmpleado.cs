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
    public partial class ReporteNuevoEmpleado : Form
    {

        Metodo conexion = new Metodo();

        public ReporteNuevoEmpleado()
        {
            InitializeComponent();
        }

        private void ReporteNuevoEmpleado_Load(object sender, EventArgs e)
        {                     


        }

        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
             if ((int)e.KeyChar == (int)Keys.Enter)
             {
                 try
                 {
                     reportes("NuevoEmpleado");

                 }
                 catch
                 {

                 }


              }

        }

        public void reportes(string parametro)
        {
            ReportDocument reporteempleado = new ReportDocument();
            reporteempleado.Load(conexion.ruta+"CrystalReportEmpleado.rpt");
            
            //crystalReportViewer1.ReportSource = reporteempleado;
            //crystalReportViewer1.Refresh();

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = tbBuscar.Text;
            crParameterFieldDefinitions = reporteempleado.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[parametro];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = reporteempleado;
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();

        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();
            crystalReportViewer1.PrintReport();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                reportes("NuevoEmpleado");

            }
            catch
            {

            }
        }
    }
}
