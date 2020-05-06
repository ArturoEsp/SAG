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
    public partial class SocioEditar : Form
    {
        Modelo.Socio oSocio;
        private int _Id;

        public SocioEditar(string nombreSocio, int idSocio)
        {
            InitializeComponent();
            cxFlatStatusBar1.Text = "Editar socio: "+nombreSocio;
            _Id = idSocio;
            lblMsg.Text = string.Empty;
            oSocio = Controlador.SocioController.getDatosSocio(idSocio);
            setAtributos();
        }

        private void setAtributos()
        {
            tbNombre.Text = oSocio.Nombre;
            tbEdad.Text = oSocio.Edad.ToString();
            cbTipo.Text = oSocio.Sexo;
            tbTelefono.Text = oSocio.Telefono;
            tbCorreoE.Text = oSocio.Email;
            tbObservaciones.Text = oSocio.Observaciones;
            tbFechaCreacion.Text = oSocio.FechaAlta.ToString();
            cbEstado.Text = oSocio.Estado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Configuracion.Validar.ValidateNumber(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == string.Empty)
            {
                lblMsg.Text = "No puedes dejar vacio el Nombre.";
                pictureBox.Image = Properties.Resources.advertencia;
                lblMsg.ForeColor = Color.FromArgb(241, 196, 15);
            }
            else
            {
                oSocio = new Modelo.Socio();
                oSocio.Id = _Id;
                oSocio.Nombre = tbNombre.Text;
                oSocio.Edad = Convert.ToInt32(tbEdad.Text);
                oSocio.Sexo = cbTipo.Text;
                oSocio.Telefono = tbTelefono.Text;
                oSocio.Email = tbCorreoE.Text;
                oSocio.Estado = cbEstado.Text;
                oSocio.Observaciones = tbObservaciones.Text;

                if (Controlador.SocioController.UpdateSocio(oSocio))
                {
                    pictureBox.Image = Properties.Resources.bien;
                    lblMsg.Text = "Actualización correcta.";
                    lblMsg.ForeColor = Color.FromArgb(18, 121, 74);

                }

                else
                {
                    pictureBox.Image = Properties.Resources.error;
                    lblMsg.Text = "Error fatal. Comunicate con el desarrollador.";
                    lblMsg.ForeColor = Color.FromArgb(231, 55, 55);
                }
                    



            }
        }
    }
}
