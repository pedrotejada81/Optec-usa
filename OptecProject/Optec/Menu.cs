using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Optec
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
        
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Empleado formaempleado = new Empleado();
            formaempleado.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Empleado formaempleado = new Empleado();
            formaempleado.ShowDialog();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoDepartamento departamento = new NuevoDepartamento();
            departamento.ShowDialog();
        }

        private void subdepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subdepartamento subdepartamento = new Subdepartamento();
            subdepartamento.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModEmpleado modempleado = new ModEmpleado();
            modempleado.ShowDialog();
        }

        private void nominaActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina nomina = new Nomina();
            nomina.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaTodos consulta = new ConsultaTodos();
            consulta.ShowDialog();
        }

        private void innabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Habilitar habilitar = new Habilitar();
            habilitar.ShowDialog();
        }

        private void departamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModificarDpto modificarDpto = new ModificarDpto();
            modificarDpto.ShowDialog();
        }

        private void departamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EliminarDpto eliminarDpto = new EliminarDpto();
            eliminarDpto.ShowDialog();
        }

        private void subdepartamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModificarSubDpto modificarsubdpto = new ModificarSubDpto();
            modificarsubdpto.ShowDialog();
        }

        private void subdepartamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EliminarSubDpto eliminarsubdpto = new EliminarSubDpto();
            eliminarsubdpto.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReporteNuevoEmpleado reportenuevoempleado = new ReporteNuevoEmpleado();
            reportenuevoempleado.ShowDialog();
        }

        private void habilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteHabilitados reportehabilitados = new ReporteHabilitados();
            reportehabilitados.ShowDialog();
        }

        private void inactivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteInhabilitados reporteinhabilitados = new ReporteInhabilitados();
            reporteinhabilitados.ShowDialog();
        }

        private void activosXDepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteActivosXDpto reporteactivosxdpto = new ReporteActivosXDpto();
            reporteactivosxdpto.ShowDialog();
        }

        private void activosPorSubdepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteActivosSubdpto reporteactivosubdpto = new ReporteActivosSubdpto();
            reporteactivosubdpto.ShowDialog();
        }

        private void tSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TSS tss = new TSS();
            tss.ShowDialog();
        }

        private void nominaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nóminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteNomina reportenomina = new ReporteNomina();
            reportenomina.ShowDialog();
        }

        private void imprimirVolantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVolantes reportevolantes = new ReporteVolantes();
            reportevolantes.ShowDialog();
        }

        private void regalíasAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void regalíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRegalia reporteregalia = new ReporteRegalia();
            reporteregalia.ShowDialog();
        }

        private void regalíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRegalia reporteregalia = new ReporteRegalia();
            reporteregalia.ShowDialog();
        }

        private void imprimirPorDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteNominaDpto reportenominadpto = new ReporteNominaDpto();
            reportenominadpto.ShowDialog();
        }

        private void imprimirPorSubdepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteNominaSubdpto reportenominasub = new ReporteNominaSubdpto();
            reportenominasub.ShowDialog();
        }

        private void nominasAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarNomina modificarnomina = new ModificarNomina();
            modificarnomina.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nomina nomina = new Nomina();
            nomina.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultaTodos consulta = new ConsultaTodos();
            consulta.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModificarNomina modificarnomina = new ModificarNomina();
            modificarnomina.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReporteNomina reportenomina = new ReporteNomina();
            reportenomina.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReporteVolantes reportevolantes = new ReporteVolantes();
            reportevolantes.ShowDialog();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ponchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ponches ponches = new Ponches();
            ponches.ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            
            string pdfPath = Path.Combine(Application.StartupPath, @"U:\Optec\Optec\Manual de usuario\manual.pdf");

            Process.Start(pdfPath);




        }

        private void manualVinculadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, @"U:\Optec\Optec\Optec\Manual de usuario\Manual de usuario.html");

            Process.Start(pdfPath);

        }

        private void btLiquidacion_Click(object sender, EventArgs e)
        {

            Liquidacion liqu = new Liquidacion();
            liqu.ShowDialog();
        }

        private void liquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liquidacion liqu = new Liquidacion();
            liqu.ShowDialog();
        }

        private void liquidacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Liquidacion liq = new Liquidacion();
            liq.ShowDialog();
        }

        private void liquidacionesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReporteLiquidaciones rliq = new ReporteLiquidaciones();
            rliq.ShowDialog();
        }

        private void volantesIndividualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVolantesII  rvolind = new ReporteVolantesII();
            rvolind.ShowDialog();
        }
    }
}
