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
    public partial class Empleado : Form
    {

        Metodo conexion = new Metodo();
        double salario;
        

        public Empleado()
        {
            InitializeComponent();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            ReporteNuevoEmpleado reportenuevoempleado = new ReporteNuevoEmpleado();
            reportenuevoempleado.ShowDialog();
            reportenuevoempleado.BringToFront();

            this.SendToBack();
          
           
           
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (tbSalario.Text== string.Empty)
            {
                MessageBox.Show("El campo 'Salario Mensual' debe terner un formato válido. (##,###.##)");
               
            }
            else
            {
                DateTime fentrada, fsalida;
                fentrada = DateTime.Parse(dtpfentrada.Text);
                fsalida = DateTime.Parse(dtpfsalida.Text);

                conexion.InsertarEmpleado(tbNombres.Text, tbApellidos.Text, tbDocumento.Text, tbCedula.Text, tbTelefono.Text, tbCelular.Text, tbDireccion.Text, tbContacto.Text, tbContacto2.Text, cbDepartamento.Text, cbSubdepartamento.Text, tbPuesto.Text, cbIgualado.Text, fentrada, fsalida, tbCuenta.Text, chkbHabilitado.Checked, salario);

                DataTable dtempleados = conexion.SelectTodosEmpleados();
                int cuenta = (dtempleados.Rows.Count) - 1;
                int lastId = int.Parse(dtempleados.Rows[cuenta]["Id"].ToString());

                MessageBox.Show("El empleado/a '" + tbNombres.Text + " " + tbApellidos.Text + "' fue registrado correctamente con el Código: '" + lastId + "'", "Información de almacenamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbNombres.Clear(); tbApellidos.Clear(); tbDocumento.Clear(); tbCedula.Clear(); tbTelefono.Clear(); tbCelular.Clear(); tbDireccion.Clear();
                tbContacto.Clear(); tbContacto2.Clear(); tbSalario.Clear(); tbCuenta.Clear(); tbPuesto.Clear();
                cbDepartamento.SelectedValue = 1; cbIgualado.SelectedValue = 1; 
            }
            

        }

        private void Empleado_Load(object sender, EventArgs e)
        {            
            DataTable dtdepartamento = conexion.SelectDepartamento();
            cbDepartamento.DataSource = dtdepartamento;
            cbDepartamento.DisplayMember = "Departamento";
            cbDepartamento.ValueMember = "Id";
            cbIgualado.SelectedIndex = 1;            

            
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtsubdepartamento = conexion.SelectSubdepartamento(int.Parse(cbDepartamento.SelectedValue.ToString()));

                cbSubdepartamento.DataSource = dtsubdepartamento;
                cbSubdepartamento.DisplayMember = "SubDepartamento";
                cbSubdepartamento.ValueMember = "Id";
            }
            catch (Exception)
            {
               
            }
            

        }

       
        private void tbSalario_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbCedula_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCedula.Checked == true)
            {
                label3.Text = "Cédula";
                tbCedula.Mask = "000-0000000-0";
                tbDocumento.Text = "Cedula";
                tbCedula.Focus();
                
            }
            else
            {
                label3.Text = "Pasaporte";
                tbCedula.Mask = "aa0000000";
                tbDocumento.Text = "Pasaporte";
                tbCedula.Focus();
            }
        }

        
        private void textBox2_Enter(object sender, EventArgs e)
        {

            tbSalario.Text = salario.ToString();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                salario = Convert.ToDouble(this.tbSalario.Text.ToString());

                TextBox tb = (TextBox)sender;

                decimal numero = default(decimal);
                bool bln = decimal.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    tb.Text = "0.0";
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.

                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.

                tb.Text = string.Format("{0:C2}", numero);
            }
            catch (Exception)
            {

            }
        }

        private void tbSalario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tbSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btGuardar_Click(null, null);

                tbSalario.Focus();
            }
        }

        private void cbSubdepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
