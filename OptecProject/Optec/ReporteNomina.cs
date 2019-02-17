using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Optec
{
    public partial class ReporteNomina : Form
    {
        public ReporteNomina()
        {
            InitializeComponent();
        }
        Metodo metodos = new Metodo();
        DataTable NominasPorFecha = new DataTable();
        int IdFechaNominas;

        private void cbNominas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdFechaNomina = 0;
            try
            {
                reportes("Nomina");
                IdFechaNomina = int.Parse(cbNominas.SelectedValue.ToString());             
               

            }
            catch { }

            DataTable x = metodos.ContenidoNominaPorFecha(IdFechaNomina);


            NominasPorFecha = x;
            IdFechaNominas = IdFechaNomina;
            CalculoDeNomina();

            //ColoresDeTony();

        }

        public void NominaPorFecha()
        {
            DataTable x = metodos.NominaPorFecha();

            cbNominas.DataSource = x;
            cbNominas.ValueMember = "IdFechaNomina";
            cbNominas.DisplayMember = "FechaDeNomina";

        }


        public void CalculoDeNomina()
        {
            DataTable dtEmpleados = NominasPorFecha;

            DataColumn SalarioSemanal = dtEmpleados.Columns.Add("Salario Semanal", typeof(float));
            SalarioSemanal.Expression = "[Salario] *12/52";

            DataColumn SalarioDiario = dtEmpleados.Columns.Add("Salario Diario", typeof(float));
            SalarioDiario.Expression = "[Salario Semanal] /5";


            DataColumn HorasOrdinarias = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            HorasOrdinarias.DataType = typeof(float);
            HorasOrdinarias.DefaultValue = 0;
            HorasOrdinarias.ColumnName = "Horas Ordinarias";
            HorasOrdinarias.Caption = "Horas Ordinarias";

            DataColumn HorasExtras = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            HorasExtras.DataType = typeof(float);
            HorasExtras.DefaultValue = 0;
            HorasExtras.ColumnName = "Horas Extras";
            HorasExtras.Caption = "Horas Extras";


            DataColumn HorasDobles = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            HorasDobles.DataType = typeof(float);
            HorasDobles.DefaultValue = 0;
            HorasDobles.ColumnName = "Horas Dobles";
            HorasDobles.Caption = "Horas Dobles";

            DataColumn DiasVacaciones = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            DiasVacaciones.DataType = typeof(float);
            DiasVacaciones.DefaultValue = 0;
            DiasVacaciones.ColumnName = "Dias Vacaciones";
            DiasVacaciones.Caption = "Dias Vacaciones";

            DataColumn Comisiones = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            Comisiones.DataType = typeof(float);
            Comisiones.DefaultValue = 0;
            Comisiones.ColumnName = "Comisiones";
            Comisiones.Caption = "Comisiones";
            //  dtEmpleados.Columns.Add(Comisiones);   

            DataColumn MontoHorasOrdinarias = dtEmpleados.Columns.Add("Monto Horas Ordinarias", typeof(float));
            MontoHorasOrdinarias.Expression = "IIf([Igualado] = 'SI',[Salario Diario] * [HorasOrdinarias],[SalarioHora] * [HorasOrdinarias])";

            DataColumn MontoHorasExtras = dtEmpleados.Columns.Add("Monto Horas Extras", typeof(float));
            MontoHorasExtras.Expression = "(1.35*[SalarioHora])*[HorasExtras]";

            DataColumn MontoHorasDobles = dtEmpleados.Columns.Add("Monto Horas Dobles", typeof(float));
            MontoHorasDobles.Expression = "(2*[SalarioHora])*[HorasDobles]";

            DataColumn Vacaciones = dtEmpleados.Columns.Add("Vacaciones", typeof(float));
            Vacaciones.Expression = "([Salario]/23.83)*[DiasVacaciones]";


            DataColumn SueldoBruto = dtEmpleados.Columns.Add("Sueldo Bruto", typeof(float));
            SueldoBruto.Expression = "IIf([Igualado]='SI',[Monto Horas Ordinarias]+[Comisiones],[Monto Horas Ordinarias]+[Monto Horas Extras]+[Monto Horas Dobles]+[Vacaciones]+[Comisiones])";

            DataColumn AFP = dtEmpleados.Columns.Add("AFP", typeof(float));
            AFP.Expression = "IIf([Igualado]='SI',0,([Monto Horas Ordinarias]+[Vacaciones]+[Comisiones])*0.0287)";

            DataColumn ARS = dtEmpleados.Columns.Add("ARS", typeof(float));
            ARS.Expression = "IIf([Igualado]='SI',0,([Monto Horas Ordinarias]+[Vacaciones]+[Comisiones])*0.0304)";

            DataColumn OtrasDeducciones = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            OtrasDeducciones.DataType = typeof(float);
            OtrasDeducciones.DefaultValue = 0;
            OtrasDeducciones.ColumnName = "Otras Deducciones";
            OtrasDeducciones.Caption = "Otras Deducciones";
            OtrasDeducciones.Expression = "[OtrasDeducciones]";
            dtEmpleados.Columns.Add(OtrasDeducciones);


            DataColumn ISR1 = dtEmpleados.Columns.Add("ISR1", typeof(float));
            ISR1.Expression = "IIf(([Salario]+[Comisiones]+[Vacaciones])<34685.01,0,IIF(([Salario]+[Comisiones]+[Vacaciones])<52027.40,(([Salario]+[Comisiones]+[Vacaciones])-34685.01)*0.15, IIF(([Salario]+[Comisiones]+[Vacaciones]) < 72260.25, ((([Salario]+[Comisiones]+[Vacaciones])-52027.40)*0.20)+(17342.42 * 0.15), (((([Salario]+[Comisiones]+[Vacaciones])-72259.95)*0.25)+((20232.83*0.20) + (17342.42 * 0.15))))))";

            DataColumn ISR2 = dtEmpleados.Columns.Add("ISR2", typeof(float));
            ISR2.Expression = "IIf(([Salario]+[Vacaciones])<34685.01,0,IIF(([Salario]+[Vacaciones])<52027.40,(([Salario]+[Vacaciones])-34685.01)*0.15, IIF(([Salario]+[Vacaciones]) < 72260.25, ((([Salario]+[Vacaciones])-52027.40)*0.20)+(17342.42 * 0.15), (((([Salario]+[Vacaciones])-72259.95)*0.25)+((20232.83*0.20) + (17342.42 * 0.15))))))";

            DataColumn ISR3 = dtEmpleados.Columns.Add("ISR3", typeof(float));
            ISR3.Expression = "[ISR1]-[ISR2]";

            DataColumn ISR4 = dtEmpleados.Columns.Add("ISR4", typeof(float));
            ISR4.Expression = "(IIf(([Salario]+[Comisiones]+[Vacaciones])<34685.01,0,IIF(([Salario]+[Comisiones]+[Vacaciones])<52027.40,(([Salario]+[Comisiones]+[Vacaciones])-34685.01)*0.15, IIF(([Salario]+[Comisiones]+[Vacaciones]) < 72260.25, ((([Salario]+[Comisiones]+[Vacaciones])-52027.40)*0.20)+(17342.42 * 0.15), (((([Salario]+[Comisiones]+[Vacaciones])-72259.95)*0.25)+((20232.83*0.20) + (17342.42 * 0.15)))))))*12/52";

            DataColumn ISR = dtEmpleados.Columns.Add("ISR", typeof(float));
            ISR.Expression = "(IIf([Igualado]='SI',0,IIf([HorasOrdinarias]<=0,0,[ISR3]+[ISR4])))";


            DataColumn TotalDeducciones = dtEmpleados.Columns.Add("Total Deducciones", typeof(float));
            TotalDeducciones.Expression = "[AFP]+[ARS]+[Otras Deducciones]+[ISR]";

            DataColumn SueldoNeto = dtEmpleados.Columns.Add("Sueldo Neto", typeof(float));
            SueldoNeto.Expression = "IIf([Igualado]='SI',[Sueldo Bruto]-[Otras Deducciones],[Sueldo Bruto]-[Total Deducciones])";

            DataColumn TSS = dtEmpleados.Columns.Add("TSS", typeof(float));
            TSS.Expression = "[Monto Horas Ordinarias]+[Vacaciones]+[Comisiones]";

            DataColumn Extras = dtEmpleados.Columns.Add("Extras", typeof(float));
            Extras.Expression = "[Monto Horas Extras]+[Monto Horas Dobles]";

            dgvNomina.DataSource = dtEmpleados;
            dgvNomina.Columns[0].Visible = false;
            dgvNomina.AutoResizeColumns();
            dgvNomina.AutoResizeRows();

        }


        private void ReporteNomina_Load(object sender, EventArgs e)
        {
            NominaPorFecha();
            reportes("Nomina");

        }

        public void reportes(string parametro)
        {
            ReportDocument reporteempleado = new ReportDocument();
            reporteempleado.Load(metodos.ruta + "CrystalReportNomina.rpt");
            
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = cbNominas.Text;
            crParameterFieldDefinitions = reporteempleado.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[parametro];
           
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = reporteempleado;
            crystalReportViewer1.Refresh();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();            
            crystalReportViewer1.PrintReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
              
        }

        private string ReturnFixedString(string theValue, int startAt, int legnth)
        {
            string temp = "";
            for (int i = 0; i < legnth; i++)
            {
                if (i == startAt)
                {
                    temp += theValue;
                    i = temp.Length - 1;
                }
                else
                {
                    temp += " ";
                }
            }
            return temp;
        }

        private void btnSaveTxt_Click(object sender, EventArgs e)
        {
            #region Hide this!
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "txt";
                sfd.Filter = "(*.txt)|*.txt";
                sfd.ShowDialog(this);
                StreamWriter sw = new StreamWriter(sfd.FileName, false);
                progressBar1.Visible = true;
                progressBar1.Maximum = dgvNomina.Rows.Count;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                int a = 0;
                foreach (DataGridViewRow rowGrid in dgvNomina.Rows)
                {
                    a++;
                    double  x= double.Parse(rowGrid.Cells["Sueldo Neto"].Value.ToString());
                    DataTable employee = metodos.SelectEmpleado(int.Parse(rowGrid.Cells["Id"].Value.ToString()));
                    //sw.WriteLine(employee.Rows[0]["NumeroCuenta"].ToString() + "\t;\t" + ReturnFixedString(employee.Rows[0]["Apellido"].ToString() + ", " + employee.Rows[0]["Nombre"].ToString(), 0, 50) + "\t;\t" + ReturnFixedString(employee.Rows[0]["Id"].ToString(), 0, 4) + "\t;\t" + ReturnFixedString(rowGrid.Cells["Sueldo Neto"].Value.ToString(), 0, 8) + "\t;\tPAGO NOMINA");
                    //sw.WriteLine(employee.Rows[0]["NumeroCuenta"].ToString() + "\t;\t" + ReturnFixedString(employee.Rows[0]["Apellido"].ToString() + ", " + employee.Rows[0]["Nombre"].ToString(), 0, 50) + "\t;\t" + ReturnFixedString(a.ToString(), 0, 4) + "\t;\t" + ReturnFixedString(rowGrid.Cells["Sueldo Neto"].Value.ToString(), 0, 8) + "\t;\tPAGO NOMINA");
                    sw.WriteLine(employee.Rows[0]["NumeroCuenta"].ToString() + "\t;\t" + ReturnFixedString(employee.Rows[0]["Apellido"].ToString() + ", " + employee.Rows[0]["Nombre"].ToString(), 0, 50) + "\t;\t" + ReturnFixedString(a.ToString(), 0, 4) + "\t;\t" + ReturnFixedString(x.ToString("0.00"),0,8) + "\t;\tPAGO NOMINA");
                    progressBar1.Value++;
                }
                sw.Close();
                progressBar1.Visible = false;
                MessageBox.Show("Exportación completada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion  

            
             
        }

        private void btVolantes_Click(object sender, EventArgs e)
        {
            ReporteVolantes reportevolantes = new ReporteVolantes();
            reportevolantes.ShowDialog();
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            int IdFechaNomina = 0;
            try
            {
                reportes("Nomina");
                IdFechaNomina = int.Parse(cbNominas.SelectedValue.ToString());


            }
            catch { }

            DataTable x = metodos.ContenidoNominaPorFecha(IdFechaNomina);


            NominasPorFecha = x;
            IdFechaNominas = IdFechaNomina;
            CalculoDeNomina();

            //ColoresDeTony();
        }

        private void dgvNomina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
