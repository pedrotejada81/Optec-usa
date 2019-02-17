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
    public partial class EliminarSubDpto : Form
    {
        Metodo conexion = new Metodo();

        public EliminarSubDpto()
        {
            InitializeComponent();
        }

        private void EliminarSubDpto_Load(object sender, EventArgs e)
        {
            DataTable dtDpto = conexion.SelectDepartamento();
            cbDepartamento.DataSource = dtDpto;
            cbDepartamento.DisplayMember = "Departamento";
            cbDepartamento.ValueMember = "Id";

        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubdepartamento = conexion.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));

                lbSubdpto.DataSource = dtsubdepartamento;
                lbSubdpto.DisplayMember = "SubDepartamento";
                lbSubdpto.ValueMember = "Id";
            }
            catch (Exception)
            {

            }
        }

        private void lbSubdpto_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbSubdpto.IndexFromPoint(e.X, e.Y) >= 0)
            {

                tbID.Text = lbSubdpto.Text;

            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado1 = MessageBox.Show("Está seguro de Eliminar el Subdepartamento " + "'" + lbSubdpto.Text.ToString() + "'?",
                               "Eliminar Subdepartamento",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning);

            if (resultado1 == DialogResult.Yes)
            {
                conexion.EliminarSubdepartamento(int.Parse(lbSubdpto.SelectedValue.ToString()));
                MessageBox.Show("El subdepartamento '" + lbSubdpto.Text.ToString() + "' ha sido 'Eliminado'.");
                lbSubdpto.DataSource = conexion.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));
                lbSubdpto.DisplayMember = "SubDepartamento";
                lbSubdpto.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("El subdepartamento '" + lbSubdpto.Text.ToString() + "' no fue 'Eliminado'.");
            }

            tbID.Text = string.Empty;
        }
    }
}
