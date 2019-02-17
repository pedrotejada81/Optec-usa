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
    public partial class ConsultaTodos : Form
    {
        public int Id;

        Metodo conexion = new Metodo();
        DataTable dttodo = new DataTable();
        string filterField = "Nombre";

        public ConsultaTodos()
        {
            InitializeComponent();
           

        }

        private void ConsultaTodos_Load(object sender, EventArgs e)
        {
            dttodo = conexion.SelectHabilitado(chkHabilitado.Checked);
            dgvconsulta.DataSource = dttodo;
            dgvconsulta.AutoResizeColumns();
            dgvconsulta.AutoResizeRows();

        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dttodo = conexion.SelectHabilitado(chkHabilitado.Checked);
            dgvconsulta.DataSource = dttodo;
        }

        private void dgvconsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            ModEmpleado forma = new ModEmpleado();

            forma.buscar(int.Parse(dgvconsulta.CurrentRow.Cells["Id"].Value.ToString()));
            forma.ShowDialog();          

        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            DataTable dttodo = conexion.SelectHabilitado(chkHabilitado.Checked);
            dgvconsulta.DataSource = dttodo;
            dgvconsulta.AutoResizeColumns();
            dgvconsulta.AutoResizeRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteNuevoEmpleado reporte = new ReporteNuevoEmpleado();
            reporte.ShowDialog();
        }

        private void tbFiltrar_TextChanged(object sender, EventArgs e)
        {
            dttodo.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, tbFiltrar.Text);
        }
    }
}
