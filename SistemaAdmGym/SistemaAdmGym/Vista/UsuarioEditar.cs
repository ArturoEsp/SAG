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
    public partial class UsuarioEditar : Form
    {
        Modelo.Usuario oUsuario;
        private int _Id;

        public UsuarioEditar(string Nombre,int Id)
        {
            InitializeComponent();
            cxFlatStatusBar1.Text = "Editar usuario: "+Nombre;
            _Id = Id;

            oUsuario = Controlador.UsuarioController.GetDatos(Id);
            tbUsuario.Text = oUsuario.UsuarioName;
            if (oUsuario.Tipo == 1)
                cbTipo.Checked = true;
            if (oUsuario.Tipo == 0)
                cbTipo.Checked = false;
            tbNombre.Text = oUsuario.Nombre;
            tbTelefono.Text = oUsuario.Telefono;
            tbEmail.Text = oUsuario.Email;

        }

        private void UsuarioEditar_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbUsuario.Text == string.Empty || tbContrasena.Text == string.Empty || tbNombre.Text == string.Empty)
                MessageBox.Show("Campos vacios. Ingresa la información correcta.",
                    "Sistema Administrador de Gimnasios",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            else
            {
                oUsuario = new Modelo.Usuario();
                oUsuario.UsuarioName = tbUsuario.Text;
                oUsuario.Contrasenia = tbContrasena.Text;
                if (cbTipo.Checked)
                    oUsuario.Tipo = 1;
                else
                    oUsuario.Tipo = 0;
                oUsuario.Nombre = tbNombre.Text;
                oUsuario.Telefono = tbTelefono.Text;
                oUsuario.Email = tbEmail.Text;
                oUsuario.Id = _Id;
                if (Controlador.UsuarioController.UpdateUsuario(oUsuario))
                    MessageBox.Show("Actualización correcta.", "Sistema Administrador de Gimnasios",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error Fatal. Comunicate con el técnico del sistema.", "Sistema Administrador de Gimnasios",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);

                this.Close();

                
            }
        }
    }
}
