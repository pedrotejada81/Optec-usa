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
    public partial class TSS : Form
    {
        public TSS()
        {
            InitializeComponent();
            
        }
        Metodo conexion = new Metodo();
        static DataTable dtFechas = new DataTable();

        private void btImportar_Click(object sender, EventArgs e)
        {
            try
            {
                ImportarFechas();

            }
            catch (Exception)
            {

                
            }            

        }

        public void ImportarFechas()
        {
            dtFechas.Clear();
            dtFechas = conexion.TSSPorFecha(dtpInicio.Text, dtpFinal.Text);
            conexion.EliminarTSS();

            if (dtFechas.Rows.Count < 1)
            {
                reportesencillo();
                MessageBox.Show("No se encontraron registros con esta selección, revise las fechas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                guardartss();
                reportesencillo();
                conexion.EliminarTSS();
            }                   
        }

        public void guardartss ()
        {
            
            int IdEmpleado;
            string Nombre, Apellido, Cedula, MontoGlobal, Extras;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dtFechas.Rows.Count;
            int EmpleadoActual = 0;
            progressBar1.Visible = true;

            for (int i = 0; i < dtFechas.Rows.Count; i++)
            {
                IdEmpleado = int.Parse(dtFechas.Rows[i]["IdEmpleado"].ToString());
                Nombre = Convert.ToString(dtFechas.Rows[i]["Nombre"].ToString());
                Apellido = Convert.ToString(dtFechas.Rows[i]["Apellido"].ToString());
                Cedula = Convert.ToString(dtFechas.Rows[i]["Cedula"].ToString());
                MontoGlobal = Convert.ToString(dtFechas.Rows[i]["SumaDeTSS"].ToString());
                Extras = Convert.ToString(dtFechas.Rows[i]["SumaDeExtras"].ToString());

                conexion.GuardarTSS(IdEmpleado, Nombre, Apellido, Cedula, MontoGlobal, Extras);
                progressBar1.Value = EmpleadoActual;
                EmpleadoActual++;
            }
            progressBar1.Visible = false;

          }


        public void LlenarReport()

        {
         /*   try
            {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"U:\Optec\Optec\Optec\CrystalReportTSS.rpt");

                DataSet1 dataset = new DataSet1();

                // Agrego el registro con la info del cliente

                foreach (DataGridViewRow row in dgvTSS.Rows)
                {
                    DataSet1.DataTable1Row rowDataTable1 = dataset.DataTable1.NewDataTable1Row();
                    rowDataTable1.Id = Convert.ToString(row.Cells["IdEmpleado"].Value);
                    rowDataTable1.Id = Convert.ToString(row.Cells["Nombre"].Value);
                    rowDataTable1.Id = Convert.ToString(row.Cells["Apellido"].Value);
                    rowDataTable1.Id = Convert.ToString(row.Cells["Cedula"].Value);
                    rowDataTable1.Id = Convert.ToString(row.Cells["SumaDeTSS"].Value);
                    rowDataTable1.Id = Convert.ToString(row.Cells["SumaDeExtras"].Value);

                    dataset.DataTable1.AddDataTable1Row(rowDataTable1);
                }

                cryRpt.SetDataSource(dataset);
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            catch
            {

            } */                 
        }



        public void reportes(string fecha1, string fecha2)
        {
           /* ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"U:\Optec\Optec\Optec\CrystalReportTSS.rpt");
           

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
            crystalReportViewer1.Refresh();*/

        }

        
        public void reportesencillo()
        {
            
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"U:\Optec\Optec\Optec\CrystalReportTSS.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Update();
            crystalReportViewer1.RefreshReport();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();
            crystalReportViewer1.PrintReport();
        }

        private void TSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TSS_Load(object sender, EventArgs e)
        {
            
        }

        private void btImportar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ImportarFechas();
        }
    }
}
