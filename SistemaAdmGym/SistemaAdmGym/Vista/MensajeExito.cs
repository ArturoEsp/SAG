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
    public partial class MensajeExito : Form
    {
        private int _Count;
        private int _Stop;

        public MensajeExito(string msg, int time)
        {
            InitializeComponent();
            _Stop = time;
            lblMensaje.Text = msg;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _Count++;
            if (_Count == _Stop)
                this.Close();

        }
    }
}
