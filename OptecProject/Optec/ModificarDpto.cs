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
    public partial class ModificarDpto : Form
    {
        Metodo conexion = new Metodo();
        public ModificarDpto()
        {
            InitializeComponent();
        }

        private void ModificarDpto_Load(object sender, EventArgs e)
        {
            DataTable dtDpto = conexion.SelectDepartamento();
            lbDpto.DataSource = dtDpto;
            lbDpto.DisplayMember = "Departamento";
            lbDpto.ValueMember = "Id";
        }

        private void lbDpto_DoubleClick(object sender, EventArgs e)
        {  
            
        }       

        private void lbDpto_MouseHover(object sender, EventArgs e)
        {

        }

        private void lbDpto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbDpto.IndexFromPoint(e.X, e.Y) >= 0)
            {
                tbModificar.Enabled = true;
                tbModificar.Text=(lbDpto.Text.ToString());
                tbID.Text = (lbDpto.SelectedValue.ToString());
            }

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            DialogResult resultado1 = MessageBox.Show("Está seguro de Modificar el Departamento "+"'"+lbDpto.Text.ToString()+"'?",
                                "Modificar Departamento",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (resultado1 == DialogResult.Yes)
            {
                conexion.ModificarDepartamento(int.Parse(tbID.Text), tbModificar.Text);
                MessageBox.Show("El departamento '"+lbDpto.Text.ToString() + "' ha sido 'Modificado' a: "+tbModificar.Text);
                lbDpto.DataSource = conexion.SelectDepartamento();
                lbDpto.DisplayMember = "Departamento";
                lbDpto.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("El departamento '"+lbDpto.Text.ToString() + "' no fue 'Modificado'.");
            }

            tbID.Text = string.Empty;
            tbModificar.Text = string.Empty;
            tbModificar.Enabled = false;
            
        }
    }
}
