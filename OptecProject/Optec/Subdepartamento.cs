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
    public partial class Subdepartamento : Form
    {
        Metodo conexion = new Metodo();

        public Subdepartamento()
        {
            InitializeComponent();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (cbdepartamento.Text == "Seleccionar")
            {
                MessageBox.Show("Seleccione el Departamento", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbdepartamento.Focus();
            }

            else if (txbsubdepartamento.Text == string.Empty)
            {
                MessageBox.Show("Debe escribir el Subdepartamento", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbsubdepartamento.Focus();
            }            
            else
            {
                conexion.InsertarSubdepartamento(txbsubdepartamento.Text, int.Parse(cbdepartamento.SelectedValue.ToString()));
            
                MessageBox.Show("El Subdepartamento fue guardado correctamente", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                txbsubdepartamento.Text = string.Empty;
                cbdepartamento.Focus();
            }            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            
            DataTable tbdepartamento = conexion.SelectDepartamento();
            cbdepartamento.DataSource = tbdepartamento;
            cbdepartamento.DisplayMember = "Departamento";
            cbdepartamento.ValueMember = "Id";
            txbsubdepartamento.Enabled = false;
            

        }

        private void cbdepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbdepartamento.Text=="Seleccionar")
            {
                txbsubdepartamento.Enabled = false;                
            }
            else
            {
                txbsubdepartamento.Enabled = true;                
            }


        }
    }
}
