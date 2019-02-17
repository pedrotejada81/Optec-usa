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
    public partial class ReporteActivosSubdpto : Form
    {
        Metodo conexion = new Metodo();

        public ReporteActivosSubdpto()
        {
            InitializeComponent();
        }

        private void ReporteActivosSubdpto_Load(object sender, EventArgs e)
        {
            cbDepartamento.DataSource = conexion.SelectDepartamento();
            cbDepartamento.DisplayMember = "Departamento";
            cbDepartamento.ValueMember = "Id";

            try
            {
                DataTable dtsubdepartamento = conexion.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));

                cbSubdepartamento.DataSource = dtsubdepartamento;
                cbSubdepartamento.DisplayMember = "SubDepartamento";
                cbSubdepartamento.ValueMember = "Id";
            }
            catch (Exception)
            {

            }
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubdepartamento = conexion.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));

                cbSubdepartamento.DataSource = dtsubdepartamento;
                cbSubdepartamento.DisplayMember = "SubDepartamento";
                cbSubdepartamento.ValueMember = "Id";
            }
            catch (Exception)
            {

            }

        }

        public void reportes(string parametro)
        {
            ReportDocument reporteempleado = new ReportDocument();
            reporteempleado.Load(conexion.ruta + "CrystalReportxSubdepartamentos.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = cbSubdepartamento.Text;
            crParameterFieldDefinitions = reporteempleado.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[parametro];

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = reporteempleado;
            crystalReportViewer1.Refresh();

        }

        private void cbSubdepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportes("subdpto");
        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();
            crystalReportViewer1.PrintReport();
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            reportes("subdpto");
        }
    }
}
