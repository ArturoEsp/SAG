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
    public partial class UsuariosNuevo : Form
    {
        public UsuariosNuevo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbUsuario.Text == string.Empty || tbContrasena.Text == string.Empty || tbNombre.Text == string.Empty || tbApellidos.Text == string.Empty)
                MessageBox.Show("Campos vacios. Ingresa la información correspondiente.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tbEmail.Text != string.Empty && !Configuracion.Validar.CheckFormatEmail(tbEmail.Text))
                MessageBox.Show("Correo electronico invalido.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Modelo.Usuario oUsuario = new Modelo.Usuario();
                oUsuario.UsuarioName = tbUsuario.Text.Trim();
                oUsuario.Contrasenia = tbContrasena.Text.Trim();
                if (cbTipo.Checked)
                    oUsuario.Tipo = 1;
                else
                    oUsuario.Tipo = 0;
                oUsuario.Nombre = tbNombre.Text.Trim() + " " + tbApellidos.Text.Trim();
                oUsuario.Telefono = tbTelefono.Text.Trim();
                oUsuario.Email = tbEmail.Text.Trim();

                if (Controlador.UsuarioController.Nuevo(oUsuario))
                    MessageBox.Show("Usuario agregado correctamente.");

                else
                    MessageBox.Show("Ocurrio un error");

                this.Close();

            }

        }

        
    }
}
