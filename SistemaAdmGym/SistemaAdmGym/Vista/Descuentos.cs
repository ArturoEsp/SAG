using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAdmGym.Vista
{
    public partial class Descuentos : Form
    {
        public Descuentos()
        {
            InitializeComponent();
        }

        public double Descuento;

        private void cbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Descuento = 50;
            this.Close();
        }
    }
}
