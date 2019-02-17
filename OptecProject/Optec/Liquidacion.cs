using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optec
{
    public partial class Liquidacion : Form
    {
        public Liquidacion()
        {
            InitializeComponent();
        }

        Metodo metodos = new Metodo();
        private void Liquidacion_Load(object sender, EventArgs e)
        {
            todosEmpleados();
            cbListaEmpleados_SelectedIndexChanged(null, null);

        }

        public void todosEmpleados()
        {
            DataTable x = metodos.TodosEmpleados();
            BindingSource bing = new BindingSource();
            DataTable dtFiltrada = new DataTable();

            dtFiltrada.Columns.Add("Id");
            dtFiltrada.Columns.Add("Nombre");
            dtFiltrada.Columns.Add("Cedula");

            foreach (DataRow fila in x.Rows)
            {
                int Id = 0;
                string Nombre;
                string Apellido;
                string Cedula;
                string NombreCompleto;
                Id = int.Parse(fila["Id"].ToString());
                Nombre = fila["Nombre"].ToString();
                Apellido = fila["Apellido"].ToString();
                Cedula = fila["Cedula"].ToString();
                NombreCompleto = Id + "-" + Nombre + " " + Apellido;

                dtFiltrada.Rows.Add(fila["Id"], NombreCompleto, Cedula);
                //MessageBox.Show(Id.ToString()+" "+Nombre + " " + Apellido.ToString());
                //MessageBox.Show(dtFiltrada.Rows.Count.ToString());
            }


            bing.DataSource = dtFiltrada;

            cbListaEmpleados.DataSource = bing;
            cbListaEmpleados.DisplayMember = "Nombre";
            cbListaEmpleados.ValueMember = "Id";

            tbCedula.DataBindings.Add("text", bing, "Cedula");


        }

        public void NominasSemanales(int IdEmpleado)
        {
            DataTable x = metodos.LiquidacionPorEmpleado(IdEmpleado);
            dgvNominasSemanales.DataSource = x;
            dgvNominasSemanales.AutoResizeColumns();
            dgvNominasSemanales.AutoResizeRows();
            dgvNominasSemanales.Columns["Salario"].DefaultCellStyle.Format = "0.00";
            dgvNominasSemanales.Columns["SalarioSemanal"].DefaultCellStyle.Format = "0.00";
            dgvNominasSemanales.Columns["Comisiones"].DefaultCellStyle.Format = "0.00";

        }

        private void cbListaEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(cbListaEmpleados.SelectedValue.ToString());
                int IdEmpleado = int.Parse(cbListaEmpleados.SelectedValue.ToString());
                NominasSemanales(IdEmpleado);
                Suma();
            }
            catch { }
            //  int IdEmpleado = int.Parse(cbListaEmpleados.SelectedValue.ToString());
            //  MessageBox.Show(IdEmpleado.ToString());
            //      NominasSemanales(IdEmpleado);
            //NominasSemanales(1);

        }

        public void Suma()
        {
            double Salario = 0;
            double SalarioSemanal = 0;
            double Comision = 0;
            double SalComision = 0; //salario mas la comision

            foreach (DataGridViewRow fila in dgvNominasSemanales.Rows)
            {
                Salario += double.Parse(fila.Cells["Salario"].Value.ToString());
                SalarioSemanal += double.Parse(fila.Cells["SalarioSemanal"].Value.ToString());
                Comision += double.Parse(fila.Cells["Comisiones"].Value.ToString());
            }
            tbtotalSalarioSemanal.Text = SalarioSemanal.ToString("c");
            tbTotalComisiones.Text = Comision.ToString("c");

            SalComision = Comision + SalarioSemanal;
            tbSalComisiones.Text = SalComision.ToString("c");

        }

        private void tbFiltrar_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReporteLiquidaciones liq = new ReporteLiquidaciones();
            liq.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
