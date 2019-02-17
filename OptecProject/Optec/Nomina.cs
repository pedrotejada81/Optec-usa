using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Optec
{
    public partial class Nomina : Form
    {
        public Nomina()
        {
            InitializeComponent();
        }
        #region Declarations
        WHCalc TSSCalc = new WHCalc();
        bool addTSS = false;
        bool substractTSS = false;
        int cuentatotal;
        string FechaDeNomina;
        string FechaPrimeraNomina;
        DataTable TSS = new DataTable();
        DataTable horasTrabajadas = new DataTable();
        DataTable ResumenHorasID = new DataTable();
        DataTable IDgrupo = new DataTable();
        class HorasTrabajadas
        {

            public int ID;
            [Display(Name = "Horas Trabajadas")]
            public float HorasT;
            public DateTime Fecha;
            public HorasTrabajadas(int id, float horas)
            {
                ID = id;
                HorasT = horas;
            }
            public HorasTrabajadas(int id, float horas, DateTime fecha)
            {
                ID = id;
                HorasT = horas;
                Fecha = fecha;
            }
        }
        List<HorasTrabajadas> horaVacana = new List<HorasTrabajadas>();
        List<HorasTrabajadas> DayHours = new List<HorasTrabajadas>();
        List<HorasTrabajadas> DayHoursWithOverTimeAndDobles = new List<HorasTrabajadas>();
        List<HorasTrabajadas> WorkedTime = new List<HorasTrabajadas>();
        List<HorasTrabajadas> lstExtras = new List<HorasTrabajadas>();
        List<HorasTrabajadas> Dobles = new List<HorasTrabajadas>();
        #endregion
        

        private void AddDoubleHours(int id, float h, DateTime dt)
        {
            var EmployeeDobleHours = Dobles.Where(x => x.ID == id).FirstOrDefault();
            if (EmployeeDobleHours == null)
            {
                HorasTrabajadas ht = new HorasTrabajadas(id, h, dt);
                Dobles.Add(ht);
            }
            else
            {
                EmployeeDobleHours.HorasT += h;
            }
        }

        private float AddOT(int id, float h, DateTime dt)
        {
            #region Monday to Thursday
            if (dt.DayOfWeek != DayOfWeek.Friday && dt.DayOfWeek != DayOfWeek.Saturday)
            {
                if (h > 9)
                {
                    float delta = h - 9;
                    var EmployeeExtras = lstExtras.Where(x => x.ID == id).FirstOrDefault();
                    if (EmployeeExtras == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                        lstExtras.Add(ht);
                    }
                    else
                    {
                        #region Horas extras > 24hrs
                        float tempTime = EmployeeExtras.HorasT + delta;
                        if (tempTime > 24)
                        {
                            float delta2 = tempTime - 24;
                            EmployeeExtras.HorasT = 24;
                            AddDoubleHours(id, delta2, dt);
                        }
                        #endregion
                        else
                        {
                            EmployeeExtras.HorasT += delta;
                        }
                    }
                    h = 9;
                }
            }
            #endregion
            #region Saturday
            else if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
              /*  var EmployeeExtras = lstExtras.Where(x => x.ID == id).FirstOrDefault();
                if (EmployeeExtras == null)
                {
                    HorasTrabajadas ht = new HorasTrabajadas(id, h, dt);
                    lstExtras.Add(ht);
                }
                else
                {
                    #region Horas extras > 24hrs
                    float tempTime = EmployeeExtras.HorasT + h;
                    if (tempTime > 24)
                    {
                        float delta2 = tempTime - 24;
                        EmployeeExtras.HorasT = 24;
                        AddDoubleHours(id, delta2, dt);
                    }
                    #endregion
                    else
                    {
                        EmployeeExtras.HorasT += h;
                    }
                }*/
                
            }
            #endregion
            #region Friday
            else
            {
                if (h > 8)
                {
                    float delta = h - 8;
                    var EmployeeExtras = lstExtras.Where(x => x.ID == id).FirstOrDefault();
                    if (EmployeeExtras == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                        lstExtras.Add(ht);
                    }
                    else
                    {
                        #region Horas extras > 24hrs
                        float tempTime = EmployeeExtras.HorasT + delta;
                        if (tempTime > 24)
                        {
                            float delta2 = tempTime - 24;
                            EmployeeExtras.HorasT = 24;
                            AddDoubleHours(id, delta2, dt);
                        }
                        #endregion
                        else
                        {
                            EmployeeExtras.HorasT += delta;
                        }
                    }
                    h = 8;
                }
            }
            #endregion
            return h;
        }
        private void AddHoras(int id, string fecha, string horas)
        {
            #region Tandas por cada empleado
            if (!metodos.EsDiaFeriado(fecha))
            {
                DataRow r = horasTrabajadas.NewRow();
                r["ID"] = id;
                r["Fecha"] = fecha;
                r["horasT"] = horas;
                horasTrabajadas.Rows.Add(r);
                horasTrabajadas.AcceptChanges();
            }
            #endregion
            DateTime dt = DateTime.Parse(fecha);
            float th = (float)TimeSpan.Parse(horas).TotalHours;
            #region Day of the week
            if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
            {
                #region Display day hours

                HorasTrabajadas dhwoad = new HorasTrabajadas(id, th, dt);
                DayHoursWithOverTimeAndDobles.Add(dhwoad);

                #endregion
                #region Dias Feriados
                if (metodos.EsDiaFeriado(fecha))
                {
                    var EmployeeDobleHours = Dobles.Where(x => x.ID == id).FirstOrDefault();
                    if (EmployeeDobleHours == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(id, th, dt);
                        Dobles.Add(ht);
                    }
                    else
                    {
                        EmployeeDobleHours.HorasT += th;
                    }
                }
                #endregion

                #region Total de horas por empleado
                if (!metodos.EsDiaFeriado(fecha))
                {
                    var EmployeeHours = WorkedTime.Where(x => x.ID == id).FirstOrDefault();
                    if (EmployeeHours == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(id, th, dt);
                        WorkedTime.Add(ht);
                    }
                    else
                    {
                        EmployeeHours.HorasT += th;
                    }
                }
                #endregion
                #region Total de horas diarias por empleados
                if (!metodos.EsDiaFeriado(fecha))
                {
                    var DayExist = DayHours.Where(x => x.ID == id && x.Fecha.ToShortDateString().Equals(dt.ToShortDateString())).FirstOrDefault();
                    var LaHoraVacana = horaVacana.Where(x => x.ID == id).FirstOrDefault();
                    if (DayExist != null)
                    {
                        float h = DayExist.HorasT + th;
                        #region TheOverTime
                        if (dt.DayOfWeek != DayOfWeek.Friday)
                        {
                            if (h > 9)
                            {
                                float delta = h - 9;
                                var EmployeeExtras = lstExtras.Where(x => x.ID == id).FirstOrDefault();
                                if (EmployeeExtras == null)
                                {
                                    HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                                    lstExtras.Add(ht);
                                }
                                else
                                {
                                    EmployeeExtras.HorasT += delta;
                                }
                                h = 9;
                            }
                        }
                        else
                        {
                            if (h > 8)
                            {
                                float delta = h - 8;
                                var EmployeeExtras = lstExtras.Where(x => x.ID == id).FirstOrDefault();
                                if (EmployeeExtras == null)
                                {
                                    HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                                    lstExtras.Add(ht);
                                }
                                else
                                {
                                    EmployeeExtras.HorasT += delta;
                                }
                                h = 8;
                            }
                        }
                        #endregion
                        h = AddOT(id, h, dt);
                        DayExist.HorasT = h;
                        if (LaHoraVacana != null)
                        {
                            LaHoraVacana.HorasT += h;
                        }
                        else
                        {
                            HorasTrabajadas hv = new HorasTrabajadas(id, h, dt);
                            horaVacana.Add(hv);
                        }
                    }
                    else
                    {
                        #region TheOverTime
                        //if (dt.DayOfWeek != DayOfWeek.Friday)
                        //{
                        //    if (th > 9)
                        //    {
                        //        float delta = th - 9;
                        //        var EmployeeExtras = Extras.Where(x => x.ID == id).FirstOrDefault();
                        //        if (EmployeeExtras == null)
                        //        {
                        //            HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                        //            Extras.Add(ht);
                        //        }
                        //        else
                        //        {
                        //            EmployeeExtras.HorasT += delta;
                        //        }
                        //        th = 9;
                        //    }
                        //}
                        //else
                        //{
                        //    if (th > 8)
                        //    {
                        //        float delta = th - 8;
                        //        var EmployeeExtras = Extras.Where(x => x.ID == id).FirstOrDefault();
                        //        if (EmployeeExtras == null)
                        //        {
                        //            HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                        //            Extras.Add(ht);
                        //        }
                        //        else
                        //        {
                        //            EmployeeExtras.HorasT += delta;
                        //        }
                        //        th = 8;
                        //    }
                        //}
                        #endregion
                        th = AddOT(id, th, dt);
                        if (LaHoraVacana != null)
                        {
                            LaHoraVacana.HorasT += th;
                        }
                        else
                        {
                            HorasTrabajadas hv = new HorasTrabajadas(id, th, dt);
                            horaVacana.Add(hv);
                        }
                        HorasTrabajadas dh = new HorasTrabajadas(id, th, dt);
                        DayHours.Add(dh);
                    }
                }
                #endregion
            }
            #endregion
            #region SabadoDomingo
            else if (dt.DayOfWeek == DayOfWeek.Saturday)
            {
                AddOT(id, th, dt);
                var EmployeeExtras = lstExtras.Where(x => x.ID == id).FirstOrDefault();
                if (EmployeeExtras == null)
                {
                    HorasTrabajadas ht = new HorasTrabajadas(id, th, dt);
                    lstExtras.Add(ht);
                }
                else
                {
                    EmployeeExtras.HorasT += th;
                }
            } 
            else
            {
                var EmployeeDobleHours = Dobles.Where(x => x.ID == id).FirstOrDefault();
                if (EmployeeDobleHours == null)
                {
                    HorasTrabajadas ht = new HorasTrabajadas(id, th, dt);
                    Dobles.Add(ht);
                }
                else
                {
                    EmployeeDobleHours.HorasT += th;
                }
            }
            #endregion

        }
        private void setup()
        {
            DataColumn h = new DataColumn("horasT");
            DataColumn u = new DataColumn("ID");
            DataColumn f = new DataColumn("Fecha");
            horasTrabajadas.Columns.Add(h);
            horasTrabajadas.Columns.Add(u);
            horasTrabajadas.Columns.Add(f);
            
        }


        Metodo metodos = new Metodo();
        static DataTable dtEmpleados = new DataTable();

        private void Nomina_Load(object sender, EventArgs e)
        {
            // CargarTodos();
            IDgrupo = metodos.SelectEmpleados();
            setup();
            TSSCalc.setProgressbarValue += new WHCalc.ValueDelegate(setProgressbarValue);
            TSSCalc.setProgressbarValues += new WHCalc.ValuesDelegate(setProgressbarValues);
            TSSCalc.setProgressbarVisible += new WHCalc.VisibleDelegate(setProgressbarVisible);
        }

        public void ColoresDeTony()
        {
            try
            {
                dgvNomina.Columns[0].DefaultCellStyle.BackColor = Color.Coral;
                dgvNomina.Columns[1].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[2].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[3].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[4].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[5].Visible = false;
                dgvNomina.Columns[6].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[7].DefaultCellStyle.BackColor = Color.DeepSkyBlue;


                dgvNomina.Columns["Salario Diario"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["ARS"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["Comisiones"].DefaultCellStyle.BackColor = Color.White;
                //dgvNomina.Columns[13].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[14].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[15].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[16].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[17].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[18].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[19].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //dgvNomina.Columns[20].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[21].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[22].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[23].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[24].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[26].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[27].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns[28].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["ISR"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                dgvNomina.Columns["Otras Deducciones"].DefaultCellStyle.BackColor = Color.White;

                // dgvNomina.Columns["TSS"].Visible = false;
                dgvNomina.Columns["Extras"].Visible = false;
                dgvNomina.Columns["ISR1"].Visible = false;
                dgvNomina.Columns["ISR2"].Visible = false;
                dgvNomina.Columns["ISR3"].Visible = false;
                dgvNomina.Columns["ISR4"].Visible = false;

                dgvNomina.Columns["Salario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Salario Semanal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Salario Diario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Salario Por Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Monto Horas Ordinarias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Monto Horas Extras"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Monto Horas Dobles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Vacaciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Comisiones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Sueldo Bruto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["AFP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["ARS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Otras Deducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["ISR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Total Deducciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["Sueldo Neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                dgvNomina.Columns["TSS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                dgvNomina.Columns["Id"].ReadOnly = true;
                dgvNomina.Columns["Salario"].ReadOnly = true;
                dgvNomina.Columns["Cedula"].ReadOnly = true;
                dgvNomina.Columns["Nombre"].ReadOnly = true;

                dgvNomina.Columns["Horas Dobles"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Horas Extras"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Horas Ordinarias"].DefaultCellStyle.Format = "0.0";
                dgvNomina.Columns["Salario Por Hora"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Salario Semanal"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Salario Diario"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Monto Horas Ordinarias"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Monto Horas Extras"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Monto Horas Dobles"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Vacaciones"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Sueldo Bruto"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["AFP"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["ARS"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["ISR"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Total Deducciones"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Sueldo Neto"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["TSS"].DefaultCellStyle.Format = "0.00";
                dgvNomina.Columns["Extras"].DefaultCellStyle.Format = "0.00";

                dgvExtras.Columns[1].DefaultCellStyle.Format = "0.0";

                //  dgvHoras.Columns[1].DefaultCellStyle.Format = "0.0";

                dgvTotalHoras.Columns[1].DefaultCellStyle.Format = "0.0";

                dgvDobles.Columns[1].DefaultCellStyle.Format = "0.0";

                dgvNomina.Columns["TSS"].Visible = false;


                dgvNomina.AutoResizeColumns();
                dgvNomina.AutoResizeRows();



            }

            catch { }
        }

        public void Horas()
        {
            string Fecha1 = dtpPrimeraFecha.Value.ToShortDateString();
            string Fecha2 = dtpSegundaFecha.Value.ToShortDateString();
            TimeSpan dias = DateTime.Parse(Fecha2) - DateTime.Parse(Fecha1);

            for (int i = 0; dias.Days >= i; i++)
            {
                DateTime NuevaFecha = DateTime.Parse(Fecha1);

                NuevaFecha = NuevaFecha.AddDays(i);

                DataTable UsuariosSeleccionados = metodos.HorasTrabajadasEmpleados(1, NuevaFecha.ToShortDateString());
                int count = UsuariosSeleccionados.Rows.Count;


                TimeSpan horasT = new TimeSpan();
                int ret = 0;
                Math.DivRem(count, 2, out ret);
                if (ret != 0)
                {
                    DataRow r = UsuariosSeleccionados.NewRow();
                    r["USERID"] = UsuariosSeleccionados.Rows[count - 1]["USERID"];
                    r["CHECKTIME"] = UsuariosSeleccionados.Rows[count - 1]["CHECKTIME"];
                    UsuariosSeleccionados.Rows.Add(r);
                    UsuariosSeleccionados.AcceptChanges();
                    //ponche huerfano
                }
                for (int Z = 0; Z < count; Z += 2)
                {
                    if ((Z + 1) < count)
                    {
                        DateTime dateFrom = DateTime.Parse(UsuariosSeleccionados.Rows[Z]["CHECKTIME"].ToString());
                        DateTime dateTo = DateTime.Parse(UsuariosSeleccionados.Rows[Z + 1]["CHECKTIME"].ToString());
                        horasT = (horasT + (dateTo.TimeOfDay - dateFrom.TimeOfDay));
                    }
                }
                this.Text = horasT.ToString();
            }

        }

        public void Horas(int ID)
        {
            string Fecha1 = dtpPrimeraFecha.Value.ToShortDateString();
            string Fecha2 = dtpSegundaFecha.Value.ToShortDateString();
            TimeSpan dias = DateTime.Parse(Fecha2) - DateTime.Parse(Fecha1);

            for (int i = 0; dias.Days >= i; i++)
            {
                #region Local variables
                DateTime NuevaFecha = DateTime.Parse(Fecha1);

                NuevaFecha = NuevaFecha.AddDays(i);
                #region Dia feriado pa to el mundo
                if (metodos.EsDiaFeriado(NuevaFecha.ToShortDateString()))
                {
                    float th = 9;
                    if (NuevaFecha.DayOfWeek == DayOfWeek.Friday)
                    {
                        th = 8;
                    }
                    var EmployeeHours = WorkedTime.Where(x => x.ID == ID).FirstOrDefault();
                    if (EmployeeHours == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(ID, th, NuevaFecha);
                        WorkedTime.Add(ht);
                    }
                    else
                    {
                        EmployeeHours.HorasT += th;
                    }
                    var DayExist = DayHours.Where(x => x.ID == ID && x.Fecha.ToShortDateString().Equals(NuevaFecha.ToShortDateString())).FirstOrDefault();
                    if (DayExist == null)
                    {
                        HorasTrabajadas dh = new HorasTrabajadas(ID, th, NuevaFecha);
                        DayHours.Add(dh);
                    }
                }
                #endregion

                DataTable UsuariosSeleccionados = metodos.HorasTrabajadasEmpleados(ID, NuevaFecha.ToShortDateString());
                int count = UsuariosSeleccionados.Rows.Count;

                //TimeSpan horasT = new TimeSpan(); //no used anymore 
                #endregion

                #region Ponches de menos de 2 minutos
                //another for, a neccesary evil
                for (int Z = 0; Z < count; Z++) // removes checktimes with less than 2 minutes timespan
                {
                    if ((Z + 1) < count)
                    {
                        DateTime dateFrom = DateTime.Parse(UsuariosSeleccionados.Rows[Z]["CHECKTIME"].ToString());
                        DateTime dateTo = DateTime.Parse(UsuariosSeleccionados.Rows[Z + 1]["CHECKTIME"].ToString());
                        if ((dateTo - dateFrom).TotalMinutes < 2)
                        {
                            UsuariosSeleccionados.Rows.RemoveAt(Z + 1);
                            count--;
                        }
                    }
                }
                #endregion
                int ret = 0;
                Math.DivRem(count, 2, out ret);
                #region Ponches huerfanos
                if (ret != 0)
                {
                    DataRow r = UsuariosSeleccionados.NewRow();
                    r["USERID"] = UsuariosSeleccionados.Rows[count - 1]["USERID"];
                    r["CHECKTIME"] = UsuariosSeleccionados.Rows[count - 1]["CHECKTIME"];
                    UsuariosSeleccionados.Rows.Add(r);
                    UsuariosSeleccionados.AcceptChanges();
                    //ponche huerfano
                }
                #endregion
                #region La suma
                //sums stuff up
                for (int Z = 0; Z < count; Z += 2)
                {
                    if ((Z + 1) < count)
                    {
                        DateTime dateFrom = DateTime.Parse(UsuariosSeleccionados.Rows[Z]["CHECKTIME"].ToString());
                        DateTime dateTo = DateTime.Parse(UsuariosSeleccionados.Rows[Z + 1]["CHECKTIME"].ToString());
                        //horasT = (horasT + (dateTo.TimeOfDay - dateFrom.TimeOfDay));
                        //horasT = (horasT + (dateFrom.TimeOfDay - dateTo.TimeOfDay));
                        TimeSpan ts = (dateTo.TimeOfDay - dateFrom.TimeOfDay); //añadimos las horas separadas ya que estas seran divididas en dayHours y WorkedTime
                        AddHoras(ID, NuevaFecha.ToShortDateString(), ts.ToString()); // tambien siempre es bueno mantener las tandas separadas, las tandas estaran guardadas en horasTrabajadas

                    }
                }
                #endregion
                //AddHoras(ID, NuevaFecha.ToShortDateString(), horasT.ToString());

            }

        }
        public void CargarTodos()
        {
            #region Adds extra columns to grid
            dtEmpleados = metodos.TodosEmpleados();


            //dtEmpleados.Columns.Add("Cantidad", typeof(Decimal));
            // dtEmpleados.Columns.Add("Precio", typeof(Decimal));
            DataColumn SalarioSemanal = dtEmpleados.Columns.Add("Salario Semanal", typeof(float));
            SalarioSemanal.Expression = "[Salario] *12/52";
            DataColumn SalarioXHora = dtEmpleados.Columns.Add("Salario Por Hora", typeof(float));
            SalarioXHora.Expression = "[Salario Semanal] /44";

            DataColumn SalarioDiario = dtEmpleados.Columns.Add("Salario Diario", typeof(float));
            SalarioDiario.Expression = "[Salario Semanal] /5";


            DataColumn HorasOrdinarias = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            HorasOrdinarias.DataType = typeof(float);
            HorasOrdinarias.DefaultValue = 0;
            HorasOrdinarias.ColumnName = "Horas Ordinarias";
            HorasOrdinarias.Caption = "Horas Ordinarias";
            dtEmpleados.Columns.Add(HorasOrdinarias);

            DataColumn HorasExtras = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            HorasExtras.DataType = typeof(float);
            HorasExtras.DefaultValue = 0;
            HorasExtras.ColumnName = "Horas Extras";
            HorasExtras.Caption = "Horas Extras";
            dtEmpleados.Columns.Add(HorasExtras);
            //DataColumn HorasExtras = dtEmpleados.Columns.Add("Horas Extras", typeof(float));

            DataColumn HorasDobles = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            HorasDobles.DataType = typeof(float);
            HorasDobles.DefaultValue = 0;
            HorasDobles.ColumnName = "Horas Dobles";
            HorasDobles.Caption = "Horas Dobles";
            dtEmpleados.Columns.Add(HorasDobles);
            // DataColumn HorasDobles = dtEmpleados.Columns.Add("Horas Dobles", typeof(float));

            DataColumn DiasVacaciones = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            DiasVacaciones.DataType = typeof(float);
            DiasVacaciones.DefaultValue = 0;
            DiasVacaciones.ColumnName = "Dias Vacaciones";
            DiasVacaciones.Caption = "Dias Vacaciones";
            dtEmpleados.Columns.Add(DiasVacaciones);
            //DataColumn DiasVacaciones = dtEmpleados.Columns.Add("Dias Vacaciones", typeof(float));

            DataColumn Comisiones = new DataColumn();  //Solo para que ponga el valor 0 por defecto, ofrezcome!!!
            Comisiones.DataType = typeof(float);
            Comisiones.DefaultValue = 0;
            Comisiones.ColumnName = "Comisiones";
            Comisiones.Caption = "Comisiones";
            dtEmpleados.Columns.Add(Comisiones);
            //DataColumn Comisiones = dtEmpleados.Columns.Add("Comisiones", typeof(float));



            DataColumn MontoHorasOrdinarias = dtEmpleados.Columns.Add("Monto Horas Ordinarias", typeof(float));
            MontoHorasOrdinarias.Expression = "IIf([Igualado] = 'SI',[Salario Diario] * [Horas Ordinarias],[Salario Por Hora] * [Horas Ordinarias])";

            DataColumn MontoHorasExtras = dtEmpleados.Columns.Add("Monto Horas Extras", typeof(float));
            MontoHorasExtras.Expression = "(1.35*[Salario Por Hora])*[Horas Extras]";
            DataColumn MontoHorasDobles = dtEmpleados.Columns.Add("Monto Horas Dobles", typeof(float));
            MontoHorasDobles.Expression = "(2*[Salario Por Hora])*[Horas Dobles]";
            DataColumn Vacaciones = dtEmpleados.Columns.Add("Vacaciones", typeof(float));
            Vacaciones.Expression = "([Salario]/23.83)*[Dias Vacaciones]";



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
            dtEmpleados.Columns.Add(OtrasDeducciones);
            //DataColumn OtrasDeducciones = dtEmpleados.Columns.Add("Otras Deducciones", typeof(float));


            DataColumn ISR1 = dtEmpleados.Columns.Add("ISR1", typeof(float));
            ISR1.Expression = "IIf(([Salario]+[Comisiones]+[Vacaciones])<34685.01,0,IIF(([Salario]+[Comisiones]+[Vacaciones])<52027.40,(([Salario]+[Comisiones]+[Vacaciones])-34685.01)*0.15, IIF(([Salario]+[Comisiones]+[Vacaciones]) < 72260.25, ((([Salario]+[Comisiones]+[Vacaciones])-52027.40)*0.20)+(17342.42 * 0.15), (((([Salario]+[Comisiones]+[Vacaciones])-72259.95)*0.25)+((20232.83*0.20) + (17342.42 * 0.15))))))";

            DataColumn ISR2 = dtEmpleados.Columns.Add("ISR2", typeof(float));
            ISR2.Expression = "IIf(([Salario]+[Vacaciones])<34685.01,0,IIF(([Salario]+[Vacaciones])<52027.40,(([Salario]+[Vacaciones])-34685.01)*0.15, IIF(([Salario]+[Vacaciones]) < 72260.25, ((([Salario]+[Vacaciones])-52027.40)*0.20)+(17342.42 * 0.15), (((([Salario]+[Vacaciones])-72259.95)*0.25)+((20232.83*0.20) + (17342.42 * 0.15))))))";

            DataColumn ISR3 = dtEmpleados.Columns.Add("ISR3", typeof(float));
            ISR3.Expression = "[ISR1]-[ISR2]";

            DataColumn ISR4 = dtEmpleados.Columns.Add("ISR4", typeof(float));
            ISR4.Expression = "(IIf(([Salario]+[Comisiones]+[Vacaciones])<34685.01,0,IIF(([Salario]+[Comisiones]+[Vacaciones])<52027.40,(([Salario]+[Comisiones]+[Vacaciones])-34685.01)*0.15, IIF(([Salario]+[Comisiones]+[Vacaciones]) < 72260.25, ((([Salario]+[Comisiones]+[Vacaciones])-52027.40)*0.20)+(17342.42 * 0.15), (((([Salario]+[Comisiones]+[Vacaciones])-72259.95)*0.25)+((20232.83*0.20) + (17342.42 * 0.15)))))))*12/52";

            DataColumn ISR = dtEmpleados.Columns.Add("ISR", typeof(float));
            ISR.Expression = "(IIf([Igualado]='SI',0,IIf([Horas Ordinarias]<=0,0,[ISR3]+[ISR4])))";


            DataColumn TotalDeducciones = dtEmpleados.Columns.Add("Total Deducciones", typeof(float));
            TotalDeducciones.Expression = "[AFP]+[ARS]+[Otras Deducciones]+[ISR]";


            DataColumn SueldoNeto = dtEmpleados.Columns.Add("Sueldo Neto", typeof(float));
            SueldoNeto.Expression = "IIf([Igualado]='SI',[Sueldo Bruto]-[Otras Deducciones],[Sueldo Bruto]-[Total Deducciones])";

            DataColumn TSS = dtEmpleados.Columns.Add("TSS", typeof(float));
            TSS.Expression = "[Monto Horas Ordinarias]+[Vacaciones]+[Comisiones]";

            DataColumn Extras = dtEmpleados.Columns.Add("Extras", typeof(float));
            Extras.Expression = "[Monto Horas Extras]+[Monto Horas Dobles]";




            // De aqui en adelante el codigo para las horas de los empleados
            DataColumn Resumen = ResumenHorasID.Columns["HORA"];
            #endregion
            #region Display Hours into grid
            foreach (DataRow row in dtEmpleados.Rows)
            {
                var LaVerdaderaYUnicaHoraDoble = Dobles.Where(x => x.ID == Int32.Parse(row["ID"].ToString())).FirstOrDefault();
                if (LaVerdaderaYUnicaHoraDoble != null)
                {
                    row["Horas Dobles"] = LaVerdaderaYUnicaHoraDoble.HorasT;
                }
                var t = DayHours.GroupBy(n => n.ID).Select(g => new { ID = g.Key, HorasT = g.Sum(s => s.HorasT) }).ToList();
                var tp = t.Where(x => x.ID == Int32.Parse(row["ID"].ToString())).FirstOrDefault();
                if (tp != null)
                {
                    if (tp.HorasT > 0)
                    {
                        row["Horas Ordinarias"] = tp.HorasT;
                    }
                }
                
                var LaVerdaderaYUnicaHoraExtra = lstExtras.Where(x => x.ID == Int32.Parse(row["ID"].ToString())).FirstOrDefault();
                if (LaVerdaderaYUnicaHoraExtra != null)
                {
                  row["Horas Extras"] = LaVerdaderaYUnicaHoraExtra.HorasT;
                }
            }
            #endregion

            this.dgvNomina.DataSource = dtEmpleados;

            #region Columns setup

            #endregion

        }
        private bool EndBeginMothOverlap(DateTime date1, DateTime date2, out bool end)
        {
            //the easy one, comes at the end of the months that overlaps with the next one
            end = false;
            if (date1.Month != date2.Month)
            {
                end = true;
                return true;
            }
            DateTime prevDate1 = date1.AddDays(-7);
            DateTime prevDate2 = date2.AddDays(-7);
            if (prevDate1.Month != prevDate2.Month)
            {
                return true;
            }
            return false;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            dgvNomina.AutoResizeColumns();
            dgvNomina.AutoResizeRows();
        }

        private void dgvNomina_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress); //esta basura hace que no se escriban letras
            if (dgvNomina.CurrentCell.ColumnIndex == 6) //Desired Column

            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        public void Column1_KeyPress(object sender, KeyPressEventArgs e) //esto acompaña a la basura
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void TotalHoras()
        {
            //Variable donde almacenaremos el resultado de la sumatoria.
            TimeSpan sumatoria = new TimeSpan();
            //Método con el que recorreremos todas las filas de nuestro Datagridview
            //DataTable IDgrupo = metodos.SelectEmpleadoPrueba();
            DataTable HoraTotal = new DataTable();
            HoraTotal.Columns.Add("ID");
            HoraTotal.Columns.Add("HORA");
            int id = int.Parse(IDgrupo.Rows[0]["ID"].ToString());
            int count = horasTrabajadas.Rows.Count;
            int c = 0;

            foreach (DataRow fila in IDgrupo.Rows)
            {

                id = int.Parse(IDgrupo.Rows[c++]["ID"].ToString());

                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        if (id == int.Parse(horasTrabajadas.Rows[i]["ID"].ToString()))
                        {
                            TimeSpan horas = TimeSpan.Parse(horasTrabajadas.Rows[i]["horasT"].ToString());
                            sumatoria = (sumatoria + (horas));
                        }
                    }
                    catch
                    {// MessageBox.Show("hola");
                    }

                }


                //float Horas = sumatoria.Hours * 60;
                //float Minutos = sumatoria.Minutes;

                float HorasMinutos = (float)sumatoria.TotalHours;

                HoraTotal.Rows.Add(id, HorasMinutos);
                //HorasTrabajadas t = new HorasTrabajadas(id, HorasMinutos);
                //horaVacana.Add(t);
                sumatoria = sumatoria - sumatoria;
                HorasMinutos = HorasMinutos - HorasMinutos;

                //c++;
            }
            ResumenHorasID = HoraTotal;

            //dgvTotalHoras.DataSource = HoraTotal;

        }

        public void GuardarNomina() //Este metodo guarda la nomina
        {


            int cuenta = 0;

            //DateTime v2 = new DateTime(2016, 01, 04);
            //int x = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(v2, CalendarWeekRule.FirstDay, v2.DayOfWeek);


            //MessageBox.Show(x.ToString());
            int IdFechaNomina = metodos.GuardarNominaPorFecha(FechaDeNomina, "Hola", "10", FechaPrimeraNomina);





            int IdEmpleado;
            string Nombre;
            string Apellido;
            string Cedula;
            string Igualado;
            string Salario, SalarioSemanal, SalarioHora, HorasOrdinarias, HorasExtras, HorasDobles, DiasVacaciones, MontoHorasOrdinarias, MontoHorasExtras, MontoHorasDobles, Vacaciones, Comisiones, SueldoBruto, AFP, ARS, OtrasDeducciones, ISR, TotalDeducciones, SueldoNeto, TSS, Extras;



            progressBar1.Minimum = 0;
            progressBar1.Maximum = dgvNomina.Rows.Count;
            int EmpleadoActual = 0;
            progressBar1.Visible = true;


            foreach (DataGridViewRow rowGrid in dgvNomina.Rows)
            {
                IdEmpleado = int.Parse(rowGrid.Cells["Id"].Value.ToString());
                Nombre = rowGrid.Cells["Nombre"].Value.ToString();
                Apellido = rowGrid.Cells["Apellido"].Value.ToString();
                Cedula = rowGrid.Cells["Cedula"].Value.ToString();
                Igualado = rowGrid.Cells["Igualado"].Value.ToString();
                Salario = rowGrid.Cells["Salario"].Value.ToString();
                SalarioSemanal = rowGrid.Cells["Salario Semanal"].Value.ToString();
                SalarioHora = rowGrid.Cells["Salario Por Hora"].Value.ToString();
                HorasOrdinarias = rowGrid.Cells["Horas Ordinarias"].Value.ToString();
                HorasExtras = rowGrid.Cells["Horas Extras"].Value.ToString();
                HorasDobles = rowGrid.Cells["Horas Dobles"].Value.ToString();
                DiasVacaciones = rowGrid.Cells["Dias Vacaciones"].Value.ToString();
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

                if (substractTSS) // if substract the return value contains only data for the current month without any values for the next month from the current query
                {
                    TSS = TSSCalc.getTSSEmployee(IdEmpleado);
                }
                else if(addTSS) // if add the return value contains only the values from the current month that are not part of the current query but that need to be included in the tss calculations
                {
                    float addedTSS = float.Parse(TSS);
                    addedTSS += float.Parse(TSSCalc.getTSSEmployee(IdEmpleado));
                    TSS = addedTSS.ToString();
                }

                double Monto_SalarioSemanal = double.Parse(SalarioSemanal.ToString()); //
                double Monto_SalarioHora = double.Parse(SalarioHora.ToString()); //
                double Monto_HorasExtras = double.Parse(MontoHorasExtras.ToString()); //
                double Monto_HorasDobles = double.Parse(MontoHorasDobles.ToString()); //

                double PruebaHorasOrdinarias = double.Parse(HorasOrdinarias.ToString()); //
                double Monto_HorasOrdinarias = double.Parse(MontoHorasOrdinarias.ToString()); //

                double Monto_Vacaciones = double.Parse(Vacaciones.ToString()); //
                double Monto_Comisiones = double.Parse(Comisiones.ToString()); //
                double Monto_SueldoBruto = double.Parse(SueldoBruto.ToString());
                double Monto_AFP = double.Parse(AFP.ToString());
                double Monto_ARS = double.Parse(ARS.ToString());
                double Monto_OtrasDeducciones = double.Parse(OtrasDeducciones.ToString());
                double Monto_ISR = double.Parse(ISR.ToString());
                double Monto_TotalDeducciones = double.Parse(TotalDeducciones.ToString());
                double Monto_SueldoNeto = double.Parse(SueldoNeto.ToString());
                double Monto_TSS = double.Parse(TSS.ToString());
                double Monto_Extras = double.Parse(Extras.ToString());

                //MessageBox.Show(PruebaHorasOrdinarias.ToString("N2"));
                metodos.GuardarNomina(IdFechaNomina, FechaPrimeraNomina, FechaDeNomina, IdEmpleado, Nombre, Apellido, Cedula, Igualado, Salario, Monto_SalarioSemanal.ToString("N1"), Monto_SalarioHora.ToString("N1"), PruebaHorasOrdinarias.ToString("N1"), HorasExtras.ToString(), HorasDobles.ToString(), DiasVacaciones, Monto_HorasOrdinarias.ToString("N2"), Monto_HorasExtras.ToString("N1"), Monto_HorasDobles.ToString("N1"), Monto_Vacaciones.ToString("N2"), Monto_Comisiones.ToString("N2"), Monto_SueldoBruto.ToString("N2"), Monto_AFP.ToString("N2"), Monto_ARS.ToString("N2"), Monto_OtrasDeducciones.ToString("N2"), Monto_ISR.ToString("N2"), Monto_TotalDeducciones.ToString("N2"), Monto_SueldoNeto.ToString("N2"), Monto_TSS.ToString("N2"), Monto_Extras.ToString("N2"));


                progressBar1.Value = EmpleadoActual;
                EmpleadoActual++;
                cuenta++;
                cuentatotal = cuenta;


            }
            progressBar1.Visible = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            DiasFestivos df = new DiasFestivos();
            df.ShowDialog(this);
        }

        private void btGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int empleados = dgvNomina.Rows.Count;
                DialogResult result = MessageBox.Show("Reviso Usted los días Festivos?", "Confimación", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (dgvNomina.Rows.Count < 1)
                    {
                        MessageBox.Show("Debe hacer una Importación de ponches antes de Guardar");
                    }

                    else
                    {
                        string x = metodos.ChekeoFecha(FechaDeNomina);
                        if (x == "Correcto")
                        {
                            GuardarNomina();
                            MessageBox.Show("Se guardaron registros " + cuentatotal + " de " + empleados);

                        }
                        else
                        {
                            MessageBox.Show(x);
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    //...
                }
                else
                {
                    //...
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            #region TSS limit to month
            bool end = false; // used to check if overlapped happened at the end of the month
            addTSS = false;
            substractTSS = false;
            if (EndBeginMothOverlap(dtpPrimeraFecha.Value, dtpSegundaFecha.Value, out end))
            {
                DateTime prevDate1 = DateTime.Parse(dtpPrimeraFecha.Value.ToShortDateString());
                DateTime prevDate2 = DateTime.Parse(dtpPrimeraFecha.Value.ToShortDateString());
                if (!end)
                {

                    int daysToRemove = 1 - prevDate1.Day;
                    prevDate1 = prevDate1.AddDays(daysToRemove);
                    prevDate2 = prevDate2.AddDays(-1);
                    MessageBox.Show("¡ESTA BUSQUEDA TARDARA MAS DE LO USUAL! \n Se detecto que se debe calcular la TSS *sumando* los valores de la fecha " + prevDate1.ToShortDateString() + " hasta " + prevDate2.ToShortDateString());
                    addTSS = true;
                    substractTSS = false;
                }
                else
                {
                    int daysToRemove = 0 - prevDate2.Day;
                    prevDate2 = prevDate2.AddDays(daysToRemove);
                    addTSS = false;
                    substractTSS = true;
                    MessageBox.Show("¡ESTA BUSQUEDA TARDARA MAS DE LO USUAL! \n Se detecto que se debe calcular la TSS *solamente usando* los valores de la fecha " + prevDate1.ToShortDateString() + " hasta " + prevDate2.ToShortDateString());
                }
                TSSCalc.LoadData(prevDate1.ToShortDateString(), prevDate2.ToShortDateString());
            }
            #endregion
            #region Clear values
            horasTrabajadas.Clear();
            horaVacana.Clear();
            DayHours.Clear();
            DayHoursWithOverTimeAndDobles.Clear();
            WorkedTime.Clear();
            lstExtras.Clear();
            Dobles.Clear();
            #endregion
            #region Loads and setups
            DataTable Empleados = metodos.SelectEmpleados();
            //MessageBox.Show(Empleados.Rows.Count.ToString());
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Empleados.Rows.Count;
            int EmpleadoActual = 0;
            progressBar1.Visible = true;
            DataView d = new DataView();
            #endregion

            #region Calculate hours
            foreach (DataRow myRow in Empleados.Rows)
            {
                Horas(Int32.Parse(myRow["ID"].ToString()));
                progressBar1.Value = EmpleadoActual;
                EmpleadoActual++;
            }
            #endregion
            #region End block
            dgvHoras.DataSource = horasTrabajadas; // usar este si quiere mostrar las tandas            
            progressBar1.Visible = false;

            TotalHoras();
            CargarTodos();
            //dgvHoras.DataSource = DayHoursWithOverTimeAndDobles.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT, HorasTrabajadas.Fecha }).ToList();
            dgvExtras.DataSource = lstExtras.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT }).ToList();
            dgvDobles.DataSource = Dobles.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT }).ToList();
            dgvTotalHoras.DataSource = DayHours.GroupBy(p => p.ID).Select(g => new { ID = g.Key, Horas = g.Sum(s => s.HorasT) }).ToList();//.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT, HorasTrabajadas.Fecha }).ToList();
            #endregion

            FechaPrimeraNomina = dtpPrimeraFecha.Value.ToShortDateString();
            FechaDeNomina = dtpSegundaFecha.Value.ToShortDateString(); //Fecha de la Nomina



            dgvTotalHoras.AutoResizeColumns();

            ColoresDeTony();

            //  MessageBox.Show(IGUALADO);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReporteNomina reportenomina = new ReporteNomina();
            reportenomina.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ponches ponches = new Ponches();
            ponches.ShowDialog();
        }
        public void setProgressbarValues(int min, int max, int val)
        {
            progressBar1.Minimum = min;
            progressBar1.Maximum = max;
            progressBar1.Value = val;
        }
        public void setProgressbarValue(int val)
        {
            progressBar1.Value = val;
        }
        public void setProgressbarVisible(bool val)
        {
            progressBar1.Visible = val;
        }
    } 
}
