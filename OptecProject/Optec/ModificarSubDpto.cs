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
    public partial class ModificarSubDpto : Form
    {
        Metodo conexiones = new Metodo();

        public ModificarSubDpto()
        {
            InitializeComponent();
        }

        private void ModificarSubDpto_Load(object sender, EventArgs e)
        {
            DataTable dtDpto = conexiones.SelectDepartamento();
            cbDepartamento.DataSource = dtDpto;
            cbDepartamento.DisplayMember = "Departamento";
            cbDepartamento.ValueMember = "Id";


        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubdepartamento = conexiones.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));

                lbSubdpto.DataSource = dtsubdepartamento;
                lbSubdpto.DisplayMember = "SubDepartamento";
                lbSubdpto.ValueMember = "Id";
            }
            catch (Exception)
            {

            }
        }

        private void lbSubdpto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbSubdpto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbSubdpto.IndexFromPoint(e.X, e.Y) >= 0)
            {
                tbModificar.Enabled = true;
                tbModificar.Text = (lbSubdpto.Text.ToString());
                tbID.Text = (lbSubdpto.SelectedValue.ToString());
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
           
            DialogResult resultado1 = MessageBox.Show("Está seguro de Modificar el Subdepartamento " + "'" + lbSubdpto.Text.ToString() + "'?",
                                "Modificar Subdepartamento",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (resultado1 == DialogResult.Yes)
            {
                conexiones.ModificarSubdepartamento(int.Parse(tbID.Text), tbModificar.Text);
                MessageBox.Show("El Subdepartamento '" + lbSubdpto.Text.ToString() + "' ha sido 'Modificado' a: " + tbModificar.Text);
                lbSubdpto.DataSource = conexiones.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));
                lbSubdpto.DisplayMember = "SubDepartamento";
                lbSubdpto.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("El Subdepartamento '" + lbSubdpto.Text.ToString() + "' no fue 'Modificado'.");
            }

            tbID.Text = string.Empty;
            tbModificar.Text = string.Empty;
            tbModificar.Enabled = false;

        }
    
    }
}
