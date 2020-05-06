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
    public partial class SociosBuscar : Form
    {
        public SociosBuscar()
        {
            InitializeComponent();
            
        }

        private void tbBuscar_Enter(object sender, EventArgs e)
        {
            if (tbBuscar.Text == "Buscar...")
            {
                tbBuscar.Text = "";
            }
        }

        private void SociosBuscar_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
