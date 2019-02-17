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
    public partial class EliminarDpto : Form
    {
        Metodo conexion = new Metodo();

        public EliminarDpto()
        {
            InitializeComponent();
        }

        private void EliminarDpto_Load(object sender, EventArgs e)
        {
            DataTable dtDpto = conexion.SelectDepartamento();
            lbDpto.DataSource = dtDpto;
            lbDpto.DisplayMember = "Departamento";
            lbDpto.ValueMember = "Id";

        }

        private void EliminarDpto_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbDpto.IndexFromPoint(e.X, e.Y) >= 0)
            {
               
                textBox1.Text = lbDpto.Text;
                
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado1 = MessageBox.Show("Está seguro de Eliminar el Departamento " + "'" + lbDpto.Text.ToString() + "'?",
                               "Eliminar Departamento",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning);

            if (resultado1 == DialogResult.Yes)
            {
                conexion.EliminarDepartamento(int.Parse(lbDpto.SelectedValue.ToString()));
                MessageBox.Show("El departamento '"+lbDpto.Text.ToString() + "' ha sido 'Eliminado'.");
                lbDpto.DataSource = conexion.SelectDepartamento();
                lbDpto.DisplayMember = "Departamento";
                lbDpto.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("El departamento '"+lbDpto.Text.ToString() + "' no fue 'Eliminado'.");
            }

            textBox1.Text = string.Empty;
        }
    }
}
