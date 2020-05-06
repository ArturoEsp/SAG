using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAdmGym.Vista
{
    public partial class Index : Form
    {
        MembresiasHome _formMembresia;
        SociosHome _formSocios;
        UsuariosHome _formUsuarios;
        public Index(string _nombreUsuario)
        {
            InitializeComponent();
            cxFlatStatusBar.Text = "Sistema Administrador de Gimnasios - Bienvenido " + _nombreUsuario;
            lblNombreGimnasio.Text = "Nombre del Gimnasio";

            AbrirForms();
        }

        private void AddFormInPanel(Form fh)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(31, 31, 31), Color.FromArgb(87, 87, 87), 90f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

     
        private void Index_Load(object sender, EventArgs e)
        {

        }

       

        private void btnSocios_Click_1(object sender, EventArgs e)
        {          
            AddFormInPanel(_formSocios);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (Controlador.UsuarioController.isAdmin())
            {
               
                AddFormInPanel(_formUsuarios);
            }
            else
                MessageBox.Show("PERMISO DENEGADO, NO ERES ADMINISTRADOR.", "Sistema Administrativo de Gimnasios",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            
            AddFormInPanel(_formMembresia);
        }

        private void btnAcercade_Click(object sender, EventArgs e)
        {
            Acercade oAcercade = new Acercade();
            oAcercade.ShowDialog();
        }

        


        private void AbrirForms()
        {
            var form = Application.OpenForms.OfType<MembresiasHome>().FirstOrDefault();
            _formMembresia = form ?? new MembresiasHome();

            var formSocio = Application.OpenForms.OfType<SociosHome>().FirstOrDefault();
            _formSocios = formSocio ?? new SociosHome();

            var formUsuarios = Application.OpenForms.OfType<UsuariosHome>().FirstOrDefault();
            _formUsuarios = formUsuarios ?? new UsuariosHome();
        }
    }
}
