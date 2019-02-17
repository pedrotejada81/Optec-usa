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
    public partial class ModEmpleado : Form
    {
        Metodo conexion = new Metodo();

        public ModEmpleado()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbSalarious.Visible = false;
            tbTasa.Visible = false;
            label13.Visible = false;
            label20.Visible = false;

            if (tbBuscar.Text == string.Empty)
            {

            }
            else
            { 
                try
                {
                    int buscar;
                    buscar = int.Parse(tbBuscar.Text);

                    DataTable dtempleado = conexion.SelectEmpleado(buscar);

                    tbNombres.Text = dtempleado.Rows[0]["Nombre"].ToString();
                    tbApellidos.Text = dtempleado.Rows[0]["Apellido"].ToString();
                    tbCedula.Text = dtempleado.Rows[0]["Cedula"].ToString();
                    tbTelefono.Text = dtempleado.Rows[0]["Telefono"].ToString();
                    tbCelular.Text = dtempleado.Rows[0]["Celular"].ToString();
                    tbSalario.Text = dtempleado.Rows[0]["SalarioMensual"].ToString();
                    tbDireccion.Text = dtempleado.Rows[0]["Direccion"].ToString();
                    tbContacto.Text = dtempleado.Rows[0]["Contacto"].ToString();
                    tbContacto2.Text = dtempleado.Rows[0]["Contacto2"].ToString();

                    DataTable dtdepartamento = conexion.SelectDepartamento();
                    cbDepartamento.DataSource = dtdepartamento;
                    cbDepartamento.DisplayMember = "Departamento";
                    cbDepartamento.ValueMember = "Id";
                    cbDepartamento.Text = dtempleado.Rows[0]["Departamento"].ToString();

                    //cbDepartamento.Text = dtempleado.Rows[0]["Departamento"].ToString();
                    cbSubdepartamento.Text = dtempleado.Rows[0]["SubDepartamento"].ToString();
                    tbPuesto.Text = dtempleado.Rows[0]["Puesto"].ToString();
                    dtpfentrada.Text = dtempleado.Rows[0]["FechaEntrada"].ToString();
                    dtpfsalida.Text = dtempleado.Rows[0]["FechaSalida"].ToString();
                    tbCuenta.Text = dtempleado.Rows[0]["NumeroCuenta"].ToString();

                    //chkbHabilitado.Checked = bool.Parse(dtempleado.Rows[0]["Habilitado"].ToString());
                    
                }
                catch (Exception)
                {


                }

            }

          


        }

        public int buscar(int buscar)
         {            
            
            tbBuscar.Text = buscar.ToString();
            Form1_Load(null, null);
            return buscar;

         }

        private void tbBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            
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
                    
                    //Llenar los TextBox
                    tbNombres.Text = dtempleado.Rows[0]["Nombre"].ToString();
                    tbApellidos.Text = dtempleado.Rows[0]["Apellido"].ToString();

                    if (dtempleado.Rows[0]["Documento"].ToString()=="Cedula")
                    {
                        rbCedula.Checked = true;
                        rbPasaporte.Checked = false;
                        label3.Text = "Cédula";
                        tbCedula.Mask = "000-0000000-0";
                        tbDocumento.Text = "Cedula";
                    }
                    else if ((dtempleado.Rows[0]["Documento"].ToString() == "Pasaporte"))
                    {
                        rbCedula.Checked = false;
                        rbPasaporte.Checked = true;
                        label3.Text = "Pasaporte";
                        tbCedula.Mask = "aa0000000";
                        tbDocumento.Text = "Pasaporte";
                    }

                    tbCedula.Text = dtempleado.Rows[0]["Cedula"].ToString();
                    tbTelefono.Text = dtempleado.Rows[0]["Telefono"].ToString();
                    tbCelular.Text = dtempleado.Rows[0]["Celular"].ToString();                    
                    tbDireccion.Text = dtempleado.Rows[0]["Direccion"].ToString();
                    tbContacto.Text = dtempleado.Rows[0]["Contacto"].ToString();
                    tbContacto2.Text = dtempleado.Rows[0]["Contacto2"].ToString();

                    DataTable dtdepartamento = conexion.SelectDepartamento();
                    cbDepartamento.DataSource = dtdepartamento;
                    cbDepartamento.DisplayMember = "Departamento";
                    cbDepartamento.ValueMember = "Id";
                    cbDepartamento.Text = dtempleado.Rows[0]["Departamento"].ToString();
                    
                    cbSubdepartamento.Text = dtempleado.Rows[0]["SubDepartamento"].ToString();
                    tbPuesto.Text = dtempleado.Rows[0]["Puesto"].ToString();
                    cbIgualado.Text = dtempleado.Rows[0]["Igualado"].ToString();
                    dtpfentrada.Text = dtempleado.Rows[0]["FechaEntrada"].ToString();
                    dtpfsalida.Text = dtempleado.Rows[0]["FechaSalida"].ToString();
                    tbCuenta.Text = dtempleado.Rows[0]["NumeroCuenta"].ToString();
                    tbSalario.Text = dtempleado.Rows[0]["SalarioMensual"].ToString();
                    tbSalarious.Text = dtempleado.Rows[0]["Salarious"].ToString();
                    tbTasa.Text = dtempleado.Rows[0]["Tasa"].ToString();

                    //Activar los textbox para modificar
                    tbNombres.Enabled = true;
                    tbApellidos.Enabled = true;
                    rbCedula.Enabled = true;
                    rbPasaporte.Enabled = true;
                    tbCedula.Enabled = true;
                    tbTelefono.Enabled = true;
                    tbCelular.Enabled = true;
                    tbDireccion.Enabled = true;
                    tbContacto.Enabled = true;
                    tbContacto2.Enabled = true;
                    cbDepartamento.Enabled = true;
                    cbSubdepartamento.Enabled = true;
                    tbPuesto.Enabled = true;
                    cbIgualado.Enabled = true;
                    dtpfentrada.Enabled = true;
                    dtpfsalida.Enabled = true;
                    tbCuenta.Enabled = true;
                    tbSalario.Enabled = true;
                    tbSalarious.Enabled = true;
                    tbTasa.Enabled = true;

                    btImprimir.Enabled = true;
                    btGuardar.Enabled = true;

                    // activar o desactivar los campos SalarioUS y TASA US
                    if (int.Parse(tbBuscar.Text) == 123)
                    {
                        tbSalarious.Visible = true;
                        tbTasa.Visible = true;
                        label13.Visible = true;
                        label20.Visible = true;
                    }
                    else
                    {
                        tbSalarious.Visible = false;
                        tbTasa.Visible = false;
                        label13.Visible = false;
                        label20.Visible = false;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Código no encontrado, verifique");

                    tbNombres.Enabled = false; tbApellidos.Enabled = false; rbCedula.Enabled = false; rbPasaporte.Enabled = false;
                    tbCedula.Enabled = false; tbTelefono.Enabled = false; tbCelular.Enabled = false; tbDireccion.Enabled = false;
                    tbContacto.Enabled = false; tbContacto2.Enabled = false; cbDepartamento.Enabled = false; cbSubdepartamento.Enabled = false;
                    tbPuesto.Enabled = false; cbIgualado.Enabled = false; dtpfentrada.Enabled = false; dtpfsalida.Enabled = false; tbCuenta.Enabled = false;
                    tbSalario.Enabled = false; btImprimir.Enabled = false; btGuardar.Enabled = false;

                    tbSalarious.Visible = false;
                    tbTasa.Visible = false;
                    label13.Visible = false;
                    label20.Visible = false;
                }

            }

            
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

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBuscar_Click(object sender, EventArgs e)
        {
            tbBuscar.Text = string.Empty;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                double salario = Convert.ToDouble(tbSalario.Text);
                double salarious = Convert.ToDouble(tbSalarious.Text);
                double tasa = Convert.ToDouble(tbTasa.Text);

                DateTime fentrada, fsalida;
                fentrada = DateTime.Parse(dtpfentrada.Text);
                fsalida = DateTime.Parse(dtpfsalida.Text);

                conexion.ModificarEmpleado(int.Parse(tbBuscar.Text.ToString()), tbNombres.Text, tbApellidos.Text, tbDocumento.Text, tbCedula.Text, tbTelefono.Text, tbCelular.Text, tbDireccion.Text, tbContacto.Text, tbContacto2.Text, cbDepartamento.Text, cbSubdepartamento.Text, tbPuesto.Text, cbIgualado.Text, fentrada, fsalida, tbCuenta.Text, salario, salarious, tasa);

                MessageBox.Show("El Empleado/a '"+tbNombres.Text+" "+tbApellidos.Text+"' fue modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbNombres.Enabled = false; tbApellidos.Enabled = false; rbCedula.Enabled = false; rbPasaporte.Enabled = false;
                tbCedula.Enabled = false; tbTelefono.Enabled = false; tbCelular.Enabled = false; tbDireccion.Enabled = false;
                tbContacto.Enabled = false; tbContacto2.Enabled = false; cbDepartamento.Enabled = false; cbSubdepartamento.Enabled = false;
                tbPuesto.Enabled = false; cbIgualado.Enabled = false; dtpfentrada.Enabled = false; dtpfsalida.Enabled = false; tbCuenta.Enabled = false;
                tbSalario.Enabled = false; btImprimir.Enabled = false; btGuardar.Enabled = false;
            }

            catch
            {
                MessageBox.Show("Complete los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void btImprimir_Click(object sender, EventArgs e)
        {
            ReporteNuevoEmpleado reportenuevoempleado = new ReporteNuevoEmpleado();
            reportenuevoempleado.ShowDialog();

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int buscar;
                buscar = int.Parse(tbBuscar.Text);

                DataTable dtempleado = conexion.SelectEmpleado(buscar);

                //Llenar los TextBox
                tbNombres.Text = dtempleado.Rows[0]["Nombre"].ToString();
                tbApellidos.Text = dtempleado.Rows[0]["Apellido"].ToString();

                if (dtempleado.Rows[0]["Documento"].ToString() == "Cedula")
                {
                    rbCedula.Checked = true;
                    rbPasaporte.Checked = false;
                    label3.Text = "Cédula";
                    tbCedula.Mask = "000-0000000-0";
                    tbDocumento.Text = "Cedula";
                }
                else if ((dtempleado.Rows[0]["Documento"].ToString() == "Pasaporte"))
                {
                    rbCedula.Checked = false;
                    rbPasaporte.Checked = true;
                    label3.Text = "Pasaporte";
                    tbCedula.Mask = "aa0000000";
                    tbDocumento.Text = "Pasaporte";
                }

                tbCedula.Text = dtempleado.Rows[0]["Cedula"].ToString();
                tbTelefono.Text = dtempleado.Rows[0]["Telefono"].ToString();
                tbCelular.Text = dtempleado.Rows[0]["Celular"].ToString();
                tbDireccion.Text = dtempleado.Rows[0]["Direccion"].ToString();
                tbContacto.Text = dtempleado.Rows[0]["Contacto"].ToString();
                tbContacto2.Text = dtempleado.Rows[0]["Contacto2"].ToString();

                DataTable dtdepartamento = conexion.SelectDepartamento();
                cbDepartamento.DataSource = dtdepartamento;
                cbDepartamento.DisplayMember = "Departamento";
                cbDepartamento.ValueMember = "Id";
                cbDepartamento.Text = dtempleado.Rows[0]["Departamento"].ToString();

                cbSubdepartamento.Text = dtempleado.Rows[0]["SubDepartamento"].ToString();
                tbPuesto.Text = dtempleado.Rows[0]["Puesto"].ToString();
                cbIgualado.Text = dtempleado.Rows[0]["Igualado"].ToString();
                dtpfentrada.Text = dtempleado.Rows[0]["FechaEntrada"].ToString();
                dtpfsalida.Text = dtempleado.Rows[0]["FechaSalida"].ToString();
                tbCuenta.Text = dtempleado.Rows[0]["NumeroCuenta"].ToString();
                tbSalario.Text = dtempleado.Rows[0]["SalarioMensual"].ToString();
                tbSalarious.Text= dtempleado.Rows[0]["Salarious"].ToString();
                tbTasa.Text= dtempleado.Rows[0]["Tasa"].ToString();

                //Activar los textbox para modificar
                tbNombres.Enabled = true;
                tbApellidos.Enabled = true;
                rbCedula.Enabled = true;
                rbPasaporte.Enabled = true;
                tbCedula.Enabled = true;
                tbTelefono.Enabled = true;
                tbCelular.Enabled = true;
                tbDireccion.Enabled = true;
                tbContacto.Enabled = true;
                tbContacto2.Enabled = true;
                cbDepartamento.Enabled = true;
                cbSubdepartamento.Enabled = true;
                tbPuesto.Enabled = true;
                cbIgualado.Enabled = true;
                dtpfentrada.Enabled = true;
                dtpfsalida.Enabled = true;
                tbCuenta.Enabled = true;
                tbSalario.Enabled = true;
                tbSalarious.Enabled = true;
                tbTasa.Enabled = true;

                btImprimir.Enabled = true;
                btGuardar.Enabled = true;

                if (int.Parse(tbBuscar.Text) == 123)
                {
                    tbSalarious.Visible = true;
                    tbTasa.Visible = true;
                    label13.Visible = true;
                    label20.Visible = true;
                }
                else
                {
                    tbSalarious.Visible = false;
                    tbTasa.Visible = false;
                    label13.Visible = false;
                    label20.Visible = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Código no encontrado, verifique");

                tbNombres.Enabled = false; tbApellidos.Enabled = false; rbCedula.Enabled = false; rbPasaporte.Enabled = false;
                tbCedula.Enabled = false; tbTelefono.Enabled = false; tbCelular.Enabled = false; tbDireccion.Enabled = false;
                tbContacto.Enabled = false; tbContacto2.Enabled = false; cbDepartamento.Enabled = false; cbSubdepartamento.Enabled = false;
                tbPuesto.Enabled = false; cbIgualado.Enabled = false; dtpfentrada.Enabled = false; dtpfsalida.Enabled = false; tbCuenta.Enabled = false;
                tbSalario.Enabled = false; btImprimir.Enabled = false; btGuardar.Enabled = false;

                tbSalarious.Visible = false;
                tbTasa.Visible = false;
                label13.Visible = false;
                label20.Visible = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tbTasa_Leave(object sender, EventArgs e)
        {
            if (int.Parse(tbBuscar.Text) == 123)
            {
                double a;
                a = (double.Parse(tbSalarious.Text) * double.Parse(tbTasa.Text));
                tbSalario.Text = Convert.ToString(a);
            }
        }

        private void tbSalarious_Leave(object sender, EventArgs e)
        {
            if (int.Parse(tbBuscar.Text) == 123)
            {
                double a;
                a = (double.Parse(tbSalarious.Text) * double.Parse(tbTasa.Text));
                tbSalario.Text = Convert.ToString(a);
            }
        }
    }
}
