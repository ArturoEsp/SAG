using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace SistemaAdmGym.Vista
{
    public partial class Login : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        public Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.Black;
            }
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                tbUsuario.Text = "Usuario";
                tbUsuario.ForeColor = Color.FromArgb(87, 87, 87);
            }
        }

        private void tbContrasenia_Enter(object sender, EventArgs e)
        {
            if (tbContrasenia.Text == "Contraseña")
            {
                tbContrasenia.Text = "";
                tbContrasenia.ForeColor = Color.Black;
                tbContrasenia.UseSystemPasswordChar = true;
            }
        }

        private void tbContrasenia_Leave(object sender, EventArgs e)
        {
            if (tbContrasenia.Text == "")
            {
                tbContrasenia.Text = "Contraseña";
                tbContrasenia.ForeColor = Color.FromArgb(87, 87, 87);
                tbContrasenia.UseSystemPasswordChar = false;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            if (Controlador.UsuarioController.VerificarUsuario(tbUsuario.Text.Trim(), tbContrasenia.Text.Trim()))
            {
                Index home = new Index(tbUsuario.Text.Trim());
                this.Hide();
                home.Show();
                
                
            }
            else
                MessageBox.Show("Usuario/Contraseña incorrecta.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
