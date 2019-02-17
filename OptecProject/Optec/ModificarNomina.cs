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

namespace Optec
{
    public partial class ModificarNomina : Form
    {
        public ModificarNomina()
        {
            InitializeComponent();
        }

        Metodo metodos = new Metodo();
        DataTable NominasPorFecha = new DataTable();
        int IdFechaNominas;

        private void ModificarNomina_Load(object sender, EventArgs e)
        {
            try
            {
                NominaPorFecha();
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

        private void btUpdate_Click(object sender, EventArgs e)
        {
            int IdFechaNomina = IdFechaNominas;

            int IdEmpleado;
            string Nombre = "";
            string Apellido;
            string Cedula;
            string IdRow, Salario, SalarioSemanal, SalarioHora, HorasOrdinarias, HorasExtras, HorasDobles, DiasVacaciones, MontoHorasOrdinarias, MontoHorasExtras, MontoHorasDobles, Vacaciones, Comisiones, SueldoBruto, AFP, ARS, OtrasDeducciones, ISR, TotalDeducciones, SueldoNeto, TSS, Extras;


            progressBar1.Minimum = 0;
            progressBar1.Maximum = dgvNomina.Rows.Count;
            int EmpleadoActual = 0;
            progressBar1.Visible = true;


            foreach (DataGridViewRow rowGrid in dgvNomina.Rows)
            {
                IdEmpleado = int.Parse(rowGrid.Cells["Id"].Value.ToString());
                Nombre = rowGrid.Cells["Nombre"].Value.ToString();

                //MessageBox.Show(IdEmpleado.ToString() + Nombre.ToString()+IdFechaNomina.ToString());
                IdRow = rowGrid.Cells["RowID"].Value.ToString();
                Apellido = rowGrid.Cells["Apellido"].Value.ToString();
                Cedula = rowGrid.Cells["Cedula"].Value.ToString();
                Salario = rowGrid.Cells["Salario"].Value.ToString();
                SalarioSemanal = rowGrid.Cells["Salario Semanal"].Value.ToString();
                SalarioHora = rowGrid.Cells["SalarioHora"].Value.ToString();
                HorasOrdinarias = rowGrid.Cells["HorasOrdinarias"].Value.ToString();
                HorasExtras = rowGrid.Cells["HorasExtras"].Value.ToString();
                HorasDobles = rowGrid.Cells["HorasDobles"].Value.ToString();
                DiasVacaciones = rowGrid.Cells["DiasVacaciones"].Value.ToString();
                MontoHorasOrdinarias = rowGrid.Cells["Monto Horas Ordinarias"].Value.ToString();
                MontoHorasExtras = rowGrid.Cells["Monto Horas Extras"].Value.ToString();
                MontoHorasDobles = rowGrid.Cells["Monto Horas Dobles"].Value.ToString();
                Vacaciones = rowGrid.Cells["Vacaciones"].Value.ToString();
                Comisiones = rowGrid.Cells["Comisiones"].Value.ToString();
                SueldoBruto = rowGrid.Cells["Sueldo Bruto"].Value.ToString();
                AFP = rowGrid.Cells["AFP"].Value.ToString();
                ARS = rowGrid.Cells["ARS"].Value.ToString();
                OtrasDeducciones = rowGrid.Cells["Otras Deducciones"].Value.ToString();
                ISR = rowGrid.Cells["ISR"].Value.ToString();
                TotalDeducciones = rowGrid.Cells["Total Deducciones"].Value.ToString();
                SueldoNeto = rowGrid.Cells["Sueldo Neto"].Value.ToString();
                TSS = rowGrid.Cells["TSS"].Value.ToString();
                Extras = rowGrid.Cells["Extras"].Value.ToString();


                //metodos.ActualizarNomina(IdFechaNomina, IdEmpleado, Nombre); //Apellido, Cedula, Salario, SalarioSemanal, SalarioHora, HorasOrdinarias, HorasExtras, HorasDobles, DiasVacaciones, MontoHorasOrdinarias, MontoHorasExtras, MontoHorasDobles, Vacaciones, Comisiones, SueldoBruto, AFP, ARS, OtrasDeducciones, ISR, TotalDeducciones, SueldoNeto, TSS, Extras);
                metodos.ActualizarNomina(IdRow, IdFechaNomina, IdEmpleado, Nombre, Apellido, Cedula, Salario, SalarioSemanal, SalarioHora, HorasOrdinarias, HorasExtras, HorasDobles, DiasVacaciones, MontoHorasOrdinarias, MontoHorasExtras, MontoHorasDobles, Vacaciones, Comisiones, SueldoBruto, AFP, ARS, OtrasDeducciones, ISR, TotalDeducciones, SueldoNeto, TSS, Extras);

                progressBar1.Value = EmpleadoActual;
                EmpleadoActual++;

            }
            progressBar1.Visible = false;
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
                    DataTable employee = metodos.SelectEmpleado(int.Parse(rowGrid.Cells["Id"].Value.ToString()));
                    //sw.WriteLine(employee.Rows[0]["NumeroCuenta"].ToString() + "\t;\t" + ReturnFixedString(employee.Rows[0]["Apellido"].ToString() + ", " + employee.Rows[0]["Nombre"].ToString(), 0, 50) + "\t;\t" + ReturnFixedString(employee.Rows[0]["Id"].ToString(), 0, 4) + "\t;\t" + ReturnFixedString(rowGrid.Cells["Sueldo Neto"].Value.ToString(), 0, 8) + "\t;\tPAGO NOMINA");
                    sw.WriteLine(employee.Rows[0]["NumeroCuenta"].ToString() + "\t;\t" + ReturnFixedString(employee.Rows[0]["Apellido"].ToString() + ", " + employee.Rows[0]["Nombre"].ToString(), 0, 50) + "\t;\t" + ReturnFixedString(a.ToString(), 0, 4) + "\t;\t" + ReturnFixedString(rowGrid.Cells["Sueldo Neto"].Value.ToString(), 0, 8) + "\t;\tPAGO NOMINA");
                    progressBar1.Value++;
                }
                sw.Close();
                progressBar1.Visible = false;
                MessageBox.Show("Completado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion            
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

        private void btEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult resultado1 = MessageBox.Show("Está seguro de Eliminar la Nómina del " + "'" + cbNominas.Text.ToString() + "'?",
                               "Eliminar Nómina",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning);

            if (resultado1 == DialogResult.Yes)
            {
                metodos.BorrarNomina(IdFechaNominas);
                MessageBox.Show("Nómina Eliminada Correctamente");
                cbNominas_SelectedIndexChanged(null, null);
                NominaPorFecha();

                }
            else
            {
                MessageBox.Show("La Nómina '" + cbNominas.Text.ToString() + "' no fue 'Eliminada'.");
            }
            

            }
            catch { MessageBox.Show("La Nomina no fue Eliminada."); }
        }

        private void cbNominas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdFechaNomina = 0;
            try
            {
                IdFechaNomina = int.Parse(cbNominas.SelectedValue.ToString());

            }
            catch { }

            // MessageBox.Show(IdFechaNomina.ToString());
            DataTable x = metodos.ContenidoNominaPorFecha(IdFechaNomina);


            NominasPorFecha = x;
            IdFechaNominas = IdFechaNomina;
            CalculoDeNomina();
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

        private void cbNominas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int IdFechaNomina = 0;
            try
            {
                IdFechaNomina = int.Parse(cbNominas.SelectedValue.ToString());

            }
            catch { }

            // MessageBox.Show(IdFechaNomina.ToString());
            DataTable x = metodos.ContenidoNominaPorFecha(IdFechaNomina);


            NominasPorFecha = x;
            IdFechaNominas = IdFechaNomina;
            CalculoDeNomina();

            ColoresDeTony();
        }

        public void ColoresDeTony()
        {
            try
            {
                dgvNomina.Columns["OtrasDeducciones"].Visible = true;
                dgvNomina.Columns["Otras Deducciones"].Visible = false;
                dgvNomina.Columns[0].Visible = false;
                dgvNomina.Columns[1].Visible = false;
                dgvNomina.Columns[2].DefaultCellStyle.BackColor = Color.Coral;
                dgvNomina.Columns[3].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[4].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[5].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[6].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[7].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[8].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[14].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["AFP"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["Total Deducciones"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;

                // dgvNomina.Columns[13].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[14].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[15].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[16].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[17].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[18].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[19].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[20].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[21].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //dgvNomina.Columns[22].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[23].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[24].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[25].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[26].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[27].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[28].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[29].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["Sueldo Neto"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["ARS"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["Otras Deducciones"].DefaultCellStyle.BackColor = Color.White;
                dgvNomina.Columns["OtrasDeducciones"].DefaultCellStyle.BackColor = Color.White;

                // dgvNomina.Columns["TSS"].Visible = false;
                dgvNomina.Columns["Igualado"].Visible = false;
                dgvNomina.Columns["Extras"].Visible = false;
                dgvNomina.Columns["TSS"].Visible = false;
                dgvNomina.Columns["ISR1"].Visible = false;
                dgvNomina.Columns["ISR2"].Visible = false;
                dgvNomina.Columns["ISR3"].Visible = false;
                dgvNomina.Columns["ISR4"].Visible = false;

                dgvNomina.Columns["Salario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["SalarioHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["SalarioHora"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["HorasOrdinarias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvNomina.Columns["HorasOrdinarias"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["HorasExtras"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvNomina.Columns["HorasExtras"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["HorasDobles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvNomina.Columns["HorasDobles"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["DiasVacaciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                dgvNomina.Columns["Salario Semanal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Salario Semanal"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Monto Horas Ordinarias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Monto Horas Ordinarias"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Monto Horas Extras"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Monto Horas Extras"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Monto Horas Dobles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Monto Horas Dobles"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Vacaciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Vacaciones"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["OtrasDeducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["OtrasDeducciones"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Sueldo Bruto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Sueldo Bruto"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["AFP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["AFP"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["ARS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["ARS"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Otras Deducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                dgvNomina.Columns["ISR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["ISR"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Total Deducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Total Deducciones"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Sueldo Neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Sueldo Neto"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Comisiones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                dgvNomina.Columns["TSS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Salario Diario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Salario Diario"].DefaultCellStyle.Format = "0.00";

                dgvNomina.Columns["Id"].ReadOnly = true;
                dgvNomina.Columns["Salario"].ReadOnly = true;
                dgvNomina.Columns["Cedula"].ReadOnly = true;
                dgvNomina.Columns["Nombre"].ReadOnly = true;


                dgvNomina.Columns["Horas Dobles"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Horas Extras"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Horas Ordinarias"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Salario Por Hora"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Salario Semanal"].DefaultCellStyle.Format = "0.00";
                

                dgvNomina.Columns["Monto Horas Extras"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Monto Horas Dobles"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Vacaciones"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Sueldo Bruto"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["AFP"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["ARS"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["ISR"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Total Deducciones"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Sueldo Neto"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["TSS"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Extras"].DefaultCellStyle.Format = "0.00";


                dgvNomina.AutoResizeColumns();
                dgvNomina.AutoResizeRows();

            }

            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteNomina reportenomina = new ReporteNomina();
            reportenomina.ShowDialog();
        }
    }
}
