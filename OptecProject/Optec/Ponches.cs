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
    public partial class Ponches : Form
    {
        public Ponches()
        {
            InitializeComponent();
        }

        Metodo metodos = new Metodo();
        DataTable dtPonches = new DataTable();
        string filterField = "ID";

        private void btImportar_Click(object sender, EventArgs e)
        {
            DateTime dat1 = new DateTime(dtpPrimeraFecha.Value.Year, dtpPrimeraFecha.Value.Month, dtpPrimeraFecha.Value.Day, 0, 0, 0);
            DateTime dat2 = new DateTime(dtpSegundaFecha.Value.Year, dtpSegundaFecha.Value.Month, dtpSegundaFecha.Value.Day, 11, 59, 59);

            // dtPonches = metodos.TodosLosPonches(dtpPrimeraFecha.Value, dtpSegundaFecha.Value);
            dtPonches = metodos.TodosLosPonches(dat1, dat2);

           // MessageBox.Show(dat1.ToString());
            dgvNomina.DataSource = dtPonches;
            dgvNomina.AutoResizeColumns();
            dgvNomina.AutoResizeRows();
        }

        private void tbFiltrar_TextChanged(object sender, EventArgs e)
        {
            //dtPonches.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, tbFiltrar.Text);
            try
            {
                (dgvNomina.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID = '{0}'", tbFiltrar.Text);
            }
            catch { }
        }

        private void Ponches_Load(object sender, EventArgs e)
        {

        }
    }
}
