using System;
using System.Collections;
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
    public partial class SociosNuevo : Form
    {
        private string _idMembresia;

        public SociosNuevo()
        {
            InitializeComponent();
            lblMsg.Text = string.Empty;
            DataTable dt = MembresiaController.DisplayMembresias();
            cbMembresia.DataSource = dt;
            cbMembresia.ValueMember = "IdMembresia";
            cbMembresia.DisplayMember = "Descripcion";
           

        }

      

      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEnviarMsg_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbEnviarMsg.Checked)
            {
                if (tbCorreoE.Text == string.Empty)
                {
                    lblMsg.Text = "Correo electronico vacio. Ingresa uno valido.";
                    pictureBox.Image = Properties.Resources.advertencia;
                    lblMsg.ForeColor = Color.FromArgb(241, 196, 15);
                    cbEnviarMsg.Checked = false;
                }
                else if (Configuracion.Validar.CheckFormatEmail(tbCorreoE.Text.Trim()) == false && tbCorreoE.Text != string.Empty)
                {
                    lblMsg.Text = "Correo electronico invalido.";
                    pictureBox.Image = Properties.Resources.advertencia;
                    lblMsg.ForeColor = Color.FromArgb(241, 196, 15);
                    cbEnviarMsg.Checked = false;
                }
            }
           
                    
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if(dtpFechaFin.Value != DateTime.Now)
            {
                MessageBox.Show("!CUIDADO!\n No se recomienda cambiar la fecha actual, esto puede producir confusiones en los reportes." +
                    " Favor de reportarlo al Administrador del gimnasio.",
                       "Sistema Administrativo para Gimnasios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbEdad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Configuracion.Validar.ValidateNumber(e);
        }

        private void cbRegistrarMem_ToggleChanged(VisualPlus.Events.ToggleEventArgs e)
        {
            if (cbRegistrarMem.Checked)
            {
                
                cbMembresia.Enabled = true;
                dtpFechaInicio.Enabled = true;
                lblDescuento.Enabled = true;
            }
            else
            {
                
                cbMembresia.Enabled = false;
                dtpFechaInicio.Enabled = false;
                lblDescuento.Enabled = false;
            }
        }

        private void lblDescuento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Descuentos oDescuentos = new Descuentos();
            oDescuentos.ShowDialog();
            tbDescuento.Text = oDescuentos.Descuento.ToString("0.00");
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (tbNombre.Text == string.Empty || tbEdad.Text == string.Empty || cbTipo.Text == string.Empty)
            {
                lblMsg.Text = "Campos vacios.";
                pictureBox.Image = Properties.Resources.advertencia;
                lblMsg.ForeColor = Color.FromArgb(241, 196, 15);
            }

            else if (MessageBox.Show("¿Información correcta?", "Nuevo socio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                Modelo.Socio oSocio = new Modelo.Socio();
                oSocio.Nombre = tbNombre.Text;
                oSocio.Edad = Convert.ToInt32(tbEdad.Text);
                oSocio.Sexo = cbTipo.Text;
                oSocio.Telefono = tbTelefono.Text;
                oSocio.Email = tbCorreoE.Text;
                oSocio.Observaciones = tbObservaciones.Text;

                if (Controlador.SocioController.NuevoSocio(oSocio))
                {
                    MensajeExito msg = new MensajeExito("Socio agregado correctamente",8);
                    this.Close();
                    msg.ShowDialog();
                    
                    
                    //pictureBox.Image = Properties.Resources.bien;
                    //lblMsg.Text = "Socio agregado correctamente.";
                    //lblMsg.ForeColor = Color.FromArgb(18, 121, 74);
                }

                else
                {
                    pictureBox.Image = Properties.Resources.error;
                    lblMsg.Text = "Error fatal. Comunicate con el desarrollador.";
                    lblMsg.ForeColor = Color.FromArgb(231, 55, 55);

                }

                if (cbRegistrarMem.Checked)
                {

                }

                
               
            }
        }

        private void cbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idMembresia = cbMembresia.SelectedValue.ToString();

            try
            {
                ArrayList datos = MembresiaController.DisplayPreciosDias(_idMembresia);
                tbInscripcion.Text = datos[0].ToString();
                tbPagoPeriodo.Text = datos[1].ToString();
                int dias = Convert.ToInt32(datos[2]);
                dtpFechaFin.Value = dtpFechaInicio.Value;
                dtpFechaFin.Value = dtpFechaFin.Value.AddDays(dias);
            }
            catch
            {

            }
        }

        private void CalcularTotal()
        {
            double Inscrip = Convert.ToDouble(tbInscripcion.Text);
            double Precio = Convert.ToDouble(tbPagoPeriodo.Text);
            double Descuento = Convert.ToDouble(tbDescuento.Text);
            tbTotal.Text = ((Inscrip + Precio) - Descuento).ToString("#.00");
        }

     
        private void tbInscripcion_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void tbPagoPeriodo_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void tbDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }
    }
}
