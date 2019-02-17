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
    public partial class Habilitar : Form
    {
        Metodo conexion = new Metodo();
        public Habilitar()
        {
            InitializeComponent();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {

            if (chkbHabilitado.Checked == false)
            {
                DialogResult resultado1 = MessageBox.Show("Está seguro de Inactivar el empleado?",
                                "Inactivar empleado",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                if (resultado1 == DialogResult.Yes)
                {
                    conexion.InhabilitarEmpleado(int.Parse(tbBuscar.Text.ToString()), tbNombres.Text, tbApellidos.Text, tbPuesto.Text, DateTime.Parse(dtpfentrada.Text), DateTime.Parse(dtpfsalida.Text),  chkbHabilitado.Checked);
                    MessageBox.Show(tbNombres.Text + " " + tbApellidos.Text + " ha sido 'Inactivado/a'.");
                }
                else
                {
                    MessageBox.Show(tbNombres.Text + " " + tbApellidos.Text + " no fue 'Inactivado/a'.");
                }

            }
            else
            {
                DialogResult resultado2 = MessageBox.Show("Está seguro de Activar el empleado?",
                               "Activar empleado",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning);

                if (resultado2 == DialogResult.Yes)
                {
                    conexion.InhabilitarEmpleado(int.Parse(tbBuscar.Text.ToString()), tbNombres.Text, tbApellidos.Text, tbPuesto.Text, DateTime.Parse(dtpfentrada.Text), DateTime.Parse(dtpfsalida.Text), chkbHabilitado.Checked);
                    MessageBox.Show(tbNombres.Text + " " + tbApellidos.Text + " ha sido 'Activado/a'.");
                }
                else
                {
                    MessageBox.Show(tbNombres.Text + " " + tbApellidos.Text + " no fue 'Activado/a'.");
                }
            }





            //MessageBox.Show("Empleado Inhabilitado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    int buscar;
                    buscar = int.Parse(tbBuscar.Text);

                    DataTable dtempleado = conexion.SelectEmpleado(buscar);

                    tbNombres.Text = dtempleado.Rows[0]["Nombre"].ToString();
                    tbApellidos.Text = dtempleado.Rows[0]["Apellido"].ToString();
                    
                    tbPuesto.Text = dtempleado.Rows[0]["Puesto"].ToString();
                    dtpfentrada.Text = dtempleado.Rows[0]["FechaEntrada"].ToString();
                    dtpfsalida.Text = dtempleado.Rows[0]["FechaSalida"].ToString();                    

                    chkbHabilitado.Checked = bool.Parse(dtempleado.Rows[0]["Habilitado"].ToString());

                    chkbHabilitado.Enabled = true;
                    dtpfentrada.Enabled = false;
                    dtpfsalida.Enabled = false;

                }
                catch (Exception)
                {


                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chkbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            
                dtpfentrada.Enabled = true;
                dtpfsalida.Enabled = true;
           
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int buscar;
                buscar = int.Parse(tbBuscar.Text);

                DataTable dtempleado = conexion.SelectEmpleado(buscar);

                tbNombres.Text = dtempleado.Rows[0]["Nombre"].ToString();
                tbApellidos.Text = dtempleado.Rows[0]["Apellido"].ToString();

                tbPuesto.Text = dtempleado.Rows[0]["Puesto"].ToString();
                dtpfentrada.Text = dtempleado.Rows[0]["FechaEntrada"].ToString();
                dtpfsalida.Text = dtempleado.Rows[0]["FechaSalida"].ToString();

                chkbHabilitado.Checked = bool.Parse(dtempleado.Rows[0]["Habilitado"].ToString());

                chkbHabilitado.Enabled = true;
                dtpfentrada.Enabled = false;
                dtpfsalida.Enabled = false;

            }
            catch (Exception)
            {


            }
        }

        private void tbBuscar_Click(object sender, EventArgs e)
        {
            tbBuscar.Text = string.Empty;
        }
    }
}
