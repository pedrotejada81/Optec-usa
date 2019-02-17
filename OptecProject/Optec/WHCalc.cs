using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Optec
{
    public class WHCalc
    {
        #region Declarations
        public delegate void ValuesDelegate(int min, int max, int val);
        public event ValuesDelegate setProgressbarValues;
        public delegate void ValueDelegate(int val);
        public event ValueDelegate setProgressbarValue;
        public delegate void VisibleDelegate(bool val);
        public event VisibleDelegate setProgressbarVisible;
        Metodo metodos = new Metodo();
        static DataTable dtEmpleados = new DataTable();
        int cuentatotal;
        string FechaDeNomina;
        string FechaPrimeraNomina;
        string PrimeraFecha;
        string SegundaFecha;
        DataTable TSS = new DataTable();
        DataTable horasTrabajadas = new DataTable();
        DataTable ResumenHorasID = new DataTable();
        DataTable IDgrupo = new DataTable();
        public class HorasTrabajadas
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
                // hola soy goku
            }
        }
        public List<HorasTrabajadas> horaVacana = new List<HorasTrabajadas>();
        public List<HorasTrabajadas> DayHours = new List<HorasTrabajadas>();
        public List<HorasTrabajadas> DayHoursWithOverTimeAndDobles = new List<HorasTrabajadas>();
        public List<HorasTrabajadas> WorkedTime = new List<HorasTrabajadas>();
        public List<HorasTrabajadas> Extras = new List<HorasTrabajadas>();
        public List<HorasTrabajadas> Dobles = new List<HorasTrabajadas>();
        #endregion
        public WHCalc()
        {
            horaVacana = new List<HorasTrabajadas>();
            DayHours = new List<HorasTrabajadas>();
            DayHoursWithOverTimeAndDobles = new List<HorasTrabajadas>();
            WorkedTime = new List<HorasTrabajadas>();
            Extras = new List<HorasTrabajadas>();
            Dobles = new List<HorasTrabajadas>();            
            IDgrupo = metodos.SelectEmpleados();
            setup();
        }
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
                    var EmployeeExtras = Extras.Where(x => x.ID == id).FirstOrDefault();
                    if (EmployeeExtras == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                        Extras.Add(ht);
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
                var EmployeeExtras = Extras.Where(x => x.ID == id).FirstOrDefault();
                if (EmployeeExtras == null)
                {
                    HorasTrabajadas ht = new HorasTrabajadas(id, h, dt);
                    Extras.Add(ht);
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
                }
            }
            #endregion
            #region Friday
            else
            {
                if (h > 8)
                {
                    float delta = h - 8;
                    var EmployeeExtras = Extras.Where(x => x.ID == id).FirstOrDefault();
                    if (EmployeeExtras == null)
                    {
                        HorasTrabajadas ht = new HorasTrabajadas(id, delta, dt);
                        Extras.Add(ht);
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
                        //if (dt.DayOfWeek != DayOfWeek.Friday)
                        //{
                        //    if (h > 9)
                        //    {
                        //        float delta = h - 9;
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
                        //        h = 9;
                        //    }
                        //}
                        //else
                        //{
                        //    if (h > 8)
                        //    {
                        //        float delta = h - 8;
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
                        //        h = 8;
                        //    }
                        //}
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
                //var EmployeeExtras = Extras.Where(x => x.ID == id).FirstOrDefault();
                //if (EmployeeExtras == null)
                //{
                //    HorasTrabajadas ht = new HorasTrabajadas(id, th, dt);
                //    Extras.Add(ht);
                //}
                //else
                //{
                //    EmployeeExtras.HorasT += th;
                //}
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

        public void Horas(int ID)
        {
            string Fecha1 = PrimeraFecha;
            string Fecha2 = SegundaFecha;
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
            ISR1.Expression = "IIf(([Salario]+[Comisiones]+[Vacaciones])<34106.75,0,IIF(([Salario]+[Comisiones]+[Vacaciones])<51160.08,(([Salario]+[Comisiones]+[Vacaciones])-34106.08)*0.15, IIF(([Salario]+[Comisiones]+[Vacaciones]) < 71055.58, ((([Salario]+[Comisiones]+[Vacaciones])-51160.08)*0.20)+(17053.33 * 0.15), (((([Salario]+[Comisiones]+[Vacaciones])-71055.58)*0.25)+(19895.50*0.25) + (17053.33 * 0.15)))))";

            DataColumn ISR2 = dtEmpleados.Columns.Add("ISR2", typeof(float));
            ISR2.Expression = "IIf(([Salario])<34106.75,0,IIF(([Salario])<51160.08,(([Salario])-34106.83)*0.15, IIF(([Salario]) < 71055.58, ((([Salario])-51160.08)*0.20)+(17053.33 * 0.15), (((([Salario])-71055.58)*0.25)+(19895.50*0.25) + (17053.33 * 0.15)))))";

            DataColumn ISR3 = dtEmpleados.Columns.Add("ISR3", typeof(float));
            ISR3.Expression = "[ISR1]-[ISR2]";

            DataColumn ISR4 = dtEmpleados.Columns.Add("ISR4", typeof(float));
            ISR4.Expression = "(IIf(([Salario])<34106.75,0,IIF(([Salario])<51160.08,(([Salario])-34106.08)*0.15, IIF(([Salario]) < 71055.58, ((([Salario])-51160.08)*0.20)+(17053.33 * 0.15), (((([Salario])-71055.58)*0.25)+(19895.50*0.25) + (17053.33 * 0.15))))))*12/52";

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
                //var LaVerdaderaYUnicaHoraExtra = Extras.Where(x => x.ID == Int32.Parse(row["ID"].ToString())).FirstOrDefault();
                //if (LaVerdaderaYUnicaHoraExtra != null)
                //{
                //    row["Horas Extras"] = LaVerdaderaYUnicaHoraExtra.HorasT;
                //}
            }
            #endregion

            //this.dgvNomina.DataSource = dtEmpleados;

            #region Columns setup

            #endregion

        }
        public void LoadData(string f1, string f2)
        {
            PrimeraFecha = f1;
            SegundaFecha = f2;
            #region Clear values
            horasTrabajadas.Clear();
            horaVacana.Clear();
            DayHours.Clear();
            DayHoursWithOverTimeAndDobles.Clear();
            WorkedTime.Clear();
            Extras.Clear();
            Dobles.Clear();
            #endregion
            #region Loads and setups
            DataTable Empleados = metodos.SelectEmpleados();
            //MessageBox.Show(Empleados.Rows.Count.ToString());
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = Empleados.Rows.Count;
            setProgressbarValues(0, Empleados.Rows.Count, 0);
            setProgressbarVisible(true);
            int EmpleadoActual = 0;
           // progressBar1.Visible = true;
            DataView d = new DataView();
            #endregion

            #region Calculate hours
            foreach (DataRow myRow in Empleados.Rows)
            {
                Horas(Int32.Parse(myRow["ID"].ToString()));
                // progressBar1.Value = EmpleadoActual;
                setProgressbarValue(EmpleadoActual);
                EmpleadoActual++;
            }
            #endregion
            #region End block
            //dgvHoras.DataSource = horasTrabajadas; // usar este si quiere mostrar las tandas            
            //progressBar1.Visible = false;
            setProgressbarVisible(false);
            TotalHoras();
            CargarTodos();
            //dgvHoras.DataSource = DayHoursWithOverTimeAndDobles.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT, HorasTrabajadas.Fecha }).ToList();
           // dgvExtras.DataSource = Extras.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT }).ToList();
           // dgvDobles.DataSource = Dobles.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT }).ToList();
           // dgvTotalHoras.DataSource = DayHours.GroupBy(p => p.ID).Select(g => new { ID = g.Key, Horas = g.Sum(s => s.HorasT) }).ToList();//.Select(HorasTrabajadas => new { HorasTrabajadas.ID, HorasTrabajadas.HorasT, HorasTrabajadas.Fecha }).ToList();
            #endregion

            //FechaPrimeraNomina = dtpPrimeraFecha.Value.ToShortDateString();
            //FechaDeNomina = dtpSegundaFecha.Value.ToShortDateString(); //Fecha de la Nomina
        }
        public string getTSSEmployee(int ID)
        {
            DataRow results = dtEmpleados.AsEnumerable().Where(x => x.Field<int>(0) == ID).FirstOrDefault();
            return results["TSS"].ToString();
        }
    }
}
