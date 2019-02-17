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
    public partial class DiasFestivos : Form
    {
        Metodo metodos = new Metodo();
        DataTable ListaFeriados = new DataTable();

        void CargarFeriados()
        {
            ListaFeriados.Clear();
            ListaFeriados = metodos.ListaDeFeriados();
            FeriadoLista.Items.Clear();
            foreach (DataRow r in ListaFeriados.Rows)
            {
                FeriadoLista.Items.Add(DateTime.Parse(r["Fecha"].ToString()).ToShortDateString());
            }
        }

        public DiasFestivos()
        {
            InitializeComponent();
        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(metodos.AgregarFeriado(SeleccionFeriado.Text));
            CargarFeriados();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (FeriadoLista.SelectedIndex >= 0)
            {
                metodos.BorrarFeriado(FeriadoLista.SelectedItem.ToString());
                CargarFeriados();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un feriado de la lista");
            }
        }

        private void DiasFestivos_Load(object sender, EventArgs e)
        {
            CargarFeriados();
        }
    }
}
