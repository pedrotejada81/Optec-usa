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
    public partial class NuevoDepartamento : Form
    {
        Metodo conexion = new Metodo();

        public NuevoDepartamento()
        {
            InitializeComponent();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (txbdepartamento.Text != string.Empty)
            {
                conexion.InsertarDepartamento(txbdepartamento.Text);
                txbdepartamento.Clear();

                MessageBox.Show("El departamento fue guardado correctamente", "Información", 
                                MessageBoxButtons.OK,  MessageBoxIcon.Information);

                txbdepartamento.Focus();
            }
            else
            {
                MessageBox.Show("Debe escribir el departamento", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                txbdepartamento.Focus();
               
            }

            txbdepartamento.Text = string.Empty;
            txbdepartamento.Focus();
            
        }

        private void NuevoDepartamento_Load(object sender, EventArgs e)
        {

            
        }
        
    }
}
