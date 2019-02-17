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
    public partial class ReporteLiquidaciones : Form
    {
        public ReporteLiquidaciones()
        {
            InitializeComponent();
        }

        private void ReporteLiquidaciones_Load(object sender, EventArgs e)
        {
            CrystalReportLiquidaciones rpt = new CrystalReportLiquidaciones();
           
            rpt.SetParameterValue("ID", int.Parse(tbCodigo.Text));
            crystalReportViewer1.ReportSource = rpt;

           /* DialogResult resultado = MessageBox.Show("Desea Imprimir la Orden?", "Imprimir", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                crystalReportViewer1.PrintReport();
            }
            else
            {
                //MessageBox.Show("No se Imprime nada");
            }*/




        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            CrystalReportLiquidaciones rpt = new CrystalReportLiquidaciones();

            rpt.SetParameterValue("ID", int.Parse(tbCodigo.Text));
            crystalReportViewer1.ReportSource = rpt;
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
            {
                CrystalReportLiquidaciones rpt = new CrystalReportLiquidaciones();

                rpt.SetParameterValue("ID", int.Parse(tbCodigo.Text));
                crystalReportViewer1.ReportSource = rpt;
            }

            catch { } 
            }
           
        }
    }
}
