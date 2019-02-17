using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Optec
{
    
    public partial class Login : Form
    {
        Metodo conexion = new Metodo();

        public Login()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.Refresh();
            pictureBox1.Left += 5; pictureBox3.Left -= 5;

            if (pictureBox1.Left >= 416.5 - pictureBox1.Width)
                pictureBox1.Left = 0;

            if (pictureBox3.Left <= 527.5 - pictureBox3.Width)
                pictureBox3.Left = 722;


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //timer1.Start();

            DataTable usuarios = new DataTable();
            usuarios = conexion.SelectUsuario();
            this.comboBoxUsuarios.DataSource = usuarios;
            this.comboBoxUsuarios.DisplayMember = "Usuario";
            this.comboBoxUsuarios.ValueMember = "Id";
        
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tabla = conexion.SelectLogin(comboBoxUsuarios.Text, textBoxContraseña.Text);
            if (tabla.Rows.Count > 0)
            {
                Menu menu = new Menu();
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("'Usuario' o 'Contraseña' incorrectos, intente nuevamente", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxContraseña_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxContraseña_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBoxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)

            {
                DataTable tabla = conexion.SelectLogin(comboBoxUsuarios.Text, textBoxContraseña.Text);
                if (tabla.Rows.Count > 0)
                {
                    Menu menu = new Menu();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("'Usuario' o 'Contraseña' incorrectos, intente nuevamente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

            //CopiarArchivo();
            Application.Exit();
        }


        public void CopiarArchivo()
        {
            try
            {

                string fileName = "Optec.mdb";
                string sourcePath = @"U:\Optec\Optec";
                string targetPath = @"\\DR0FR-PC\Optec\Optec";

                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                System.IO.File.Copy(sourceFile, destFile, true);

                string fileName2 = "Att2000.mdb";
                string sourcePath2 = @"U:\Optec\Optec\Att";
                string targetPath2 = @"\\DR0FR-PC\Optec\Optec";


                string sourceFile2 = System.IO.Path.Combine(sourcePath2, fileName2);
                string destFile2 = System.IO.Path.Combine(targetPath2, fileName2);

                System.IO.File.Copy(sourceFile2, destFile2, true);
            }

            catch
            {
                MessageBox.Show("La red no esta disponible");
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
