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
    public partial class ReporteNominaSubdpto : Form
    {
        public ReporteNominaSubdpto()
        {
            InitializeComponent();
        }
        Metodo metodos = new Metodo();

        private void ReporteNominaSubdpto_Load(object sender, EventArgs e)
        {
            NominaPorFecha();
            cargardpto();

            try
            {
                DataTable dtsubdepartamento = metodos.SelectSubdepartamento(int.Parse(cbDpto.SelectedValue.ToString()));

                cbSubdpto.DataSource = dtsubdepartamento;
                cbSubdpto.DisplayMember = "SubDepartamento";
                cbSubdpto.ValueMember = "Id";
            }
            catch (Exception)
            {

            }

        }

        public void NominaPorFecha()
        {
            DataTable x = metodos.NominaPorFecha();

            cbNominas.DataSource = x;
            cbNominas.ValueMember = "IdFechaNomina";
            cbNominas.DisplayMember = "FechaDeNomina";
        }

        public void cargardpto()
        {
            cbDpto.DataSource = metodos.SelectDepartamento();
            cbDpto.DisplayMember = "Departamento";
            cbDpto.ValueMember = "Id";

        }

        private void cbDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubdepartamento = metodos.SelectSubdepartamento(int.Parse(cbDpto.SelectedValue.ToString()));

                cbSubdpto.DataSource = dtsubdepartamento;
                cbSubdpto.DisplayMember = "SubDepartamento";
                cbSubdpto.ValueMember = "Id";
            }
            catch (Exception)
            {

            }

        }

        public void reportes(string fecha1, string fecha2)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(metodos.ruta+"CrystalReportNominaSubdpto.rpt");


            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = cbNominas.Text;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[fecha1];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = cbSubdpto.Text;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[fecha2];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();


        }

        private void cbSubdpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportes("Nomina", "Subdepartamento");
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.Refresh();
            crystalReportViewer1.PrintReport();
        }
    }
}
