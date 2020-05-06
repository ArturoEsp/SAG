using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaAdmGym.Configuracion;
using SistemaAdmGym.Modelo;
using SistemaAdmGym.Controlador;

namespace SistemaAdmGym.Vista
{
    public partial class MembresiaNueva : Form
    {
        Membresia oMembresia;

        public MembresiaNueva()
        {
            InitializeComponent();
            oMembresia = new Membresia();
        }

        private void tbDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidateNumber(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbInscripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidateDoubles(e,tbInscripcion.Text);
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidateDoubles(e, tbPrecio.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbDescripcion.Text == string.Empty || tbDias.Text == string.Empty || tbPrecio.Text == string.Empty
                || tbInscripcion.Text == string.Empty)
            {
                MessageBox.Show("Existen campos vacios, por favor llena la información correctamente",
                    "Sistema Adminisstrativo de Gimnasios",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
               oMembresia.IdMembresia = tbDescripcion.Text;
                oMembresia.Descripcion = tbDescripcion.Text;
                oMembresia.Dias = Convert.ToInt32(tbDias.Text);
                oMembresia.Inscripcion = Convert.ToDouble(tbInscripcion.Text);
                oMembresia.Precio = Convert.ToDouble(tbPrecio.Text);
                oMembresia.Estado = cbEstado.Text;
                MembresiaController.NuevaMembresia(oMembresia);
                MessageBox.Show("Membresia agregada xd");
            }
        }
    }
}
