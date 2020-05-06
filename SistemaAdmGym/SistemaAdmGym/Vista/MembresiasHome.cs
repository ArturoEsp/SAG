using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaAdmGym.Controlador;

namespace SistemaAdmGym.Vista
{
    public partial class MembresiasHome : Form
    {
        public MembresiasHome()
        {
            InitializeComponent();
                   
        }

        private void btnNuevaMem_Click(object sender, EventArgs e)
        {
            MembresiaNueva oNueva = new MembresiaNueva();
            oNueva.ShowDialog();
            dgvMembresias.DataSource = MembresiaController.ListarMembresias();
        }

        private void MembresiasHome_Load(object sender, EventArgs e)
        {
            dgvMembresias.DataSource = MembresiaController.ListarMembresias();
        }
    }
}
