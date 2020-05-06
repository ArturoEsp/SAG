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
    public partial class UsuariosHome : Form
    {
        private int _Id;
        private string _Nombre;
        private int _Tipo;


        public UsuariosHome()
        {
            InitializeComponent();
            dgvUsuarios.DataSource = Controlador.UsuarioController.ListarUsuarios();
        }

        private void tbBuscar_Enter(object sender, EventArgs e)
        {
            if (tbBuscar.Text == "Buscar...")
            {
                tbBuscar.Text = "";
                tbBuscar.ForeColor = Color.Black;
            }
        }

        private void tbBuscar_Leave(object sender, EventArgs e)
        {
            if (tbBuscar.Text == string.Empty)
            {
                tbBuscar.Text = "Buscar...";
                tbBuscar.ForeColor = Color.Gray;
            }
        }

        private void UsuariosHome_Load(object sender, EventArgs e)
        {

        }





        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            (dgvUsuarios.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '{0}%'", tbBuscar.Text);

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            UsuariosNuevo oNuevoU = new UsuariosNuevo();
            oNuevoU.ShowDialog();
            dgvUsuarios.DataSource = Controlador.UsuarioController.ListarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                _Id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value.ToString());
                _Nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();

                UsuarioEditar oEditar = new UsuarioEditar(_Nombre, _Id);
                oEditar.ShowDialog();

                dgvUsuarios.DataSource = Controlador.UsuarioController.ListarUsuarios();
            }
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                _Id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value.ToString());
                _Nombre = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
          
                string RespAdm = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                if (RespAdm == "Si")
                    _Tipo = 1;
                if(RespAdm == "No")
                    _Tipo = 0;

                DialogResult dr = new DialogResult();
                if (_Tipo == 1)
                    dr = MessageBox.Show("¿Quitar permisos de Administrador a " + _Nombre + "?", "Sistema Administrador de Gimnasios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_Tipo == 0)
                    dr = MessageBox.Show("¿Agregar permisos de Administrador a " + _Nombre + "?", "Sistema Administrador de Gimnasios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    Controlador.UsuarioController.PermisosAdministrador(_Id,_Tipo);
                    dgvUsuarios.DataSource = Controlador.UsuarioController.ListarUsuarios();
                }

             

            }
        }


    }
}
