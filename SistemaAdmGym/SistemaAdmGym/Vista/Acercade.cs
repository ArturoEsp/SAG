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
    public partial class Acercade : Form
    {
        public Acercade()
        {
            InitializeComponent();
        }

        private void VisitLink()
        {
           
            lblPagina.LinkVisited = true;         
            System.Diagnostics.Process.Start("www.arturoespinoza.com.mx");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPagina_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisitLink();
        }
    }
}
