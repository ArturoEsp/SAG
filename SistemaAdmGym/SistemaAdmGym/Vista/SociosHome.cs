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
    public partial class SociosHome : Form
    {
        private int _Id;
        private string _Nombre;
        int _TotalSocios;


        public SociosHome()
        {
            InitializeComponent();
            FillDataGrid();
            EstadisticasComponent();


        }

        private async void EstadisticasComponent()
        {
            _TotalSocios = await Controlador.SocioController.TotalSociosActivos();
            lblSociosActivos.Text = _TotalSocios.ToString();

            _TotalSocios = await Controlador.SocioController.TotalSociosInactivos();
            lblSociosInactivos.Text = _TotalSocios.ToString();

        }

        private async void FillDataGrid()
        {
            dgvSocios.DataSource = await Controlador.SocioController.ListarSocios();
        }


        private void SociosHome_Load(object sender, EventArgs e)
        {
            
        }


        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SociosNuevo oNuevo = new SociosNuevo();
            oNuevo.ShowDialog();
            FillDataGrid();
            EstadisticasComponent();

        }

        private void tbBuscar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            (dgvSocios.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nombre LIKE '{0}%'", tbBuscar.Text);
        }

        private void tbBuscar_Enter_1(object sender, EventArgs e)
        {
            if (tbBuscar.Text == "Buscar...")
            {
                tbBuscar.Text = "";
                tbBuscar.ForeColor = Color.Black;
            }
        }


        private void tbBuscar_Leave_1(object sender, EventArgs e)
        {

            if (tbBuscar.Text == string.Empty)
            {
                tbBuscar.Text = "Buscar...";
                tbBuscar.ForeColor = Color.Gray;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow != null)
            {
                _Id = Convert.ToInt32(dgvSocios.CurrentRow.Cells[0].Value.ToString());
                _Nombre = dgvSocios.CurrentRow.Cells[1].Value.ToString();

                SocioEditar oEditar = new SocioEditar(_Nombre, _Id);
                oEditar.ShowDialog();

                FillDataGrid();
                EstadisticasComponent();
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Controlador.UsuarioController.isAdmin())
            {
                _Id = Convert.ToInt32(dgvSocios.CurrentRow.Cells[0].Value.ToString());
                _Nombre = dgvSocios.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show("¡ADVERTENCIA!\n\n" +
                    "¿Desea eliminar el Socio " + _Nombre + "?\n" +
                    "Se eliminara todo el expediente.", "Sistema Administrativo de Gimnasios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Controlador.SocioController.EliminarSocio(_Id);
                    MessageBox.Show("Eliminación correcta", "Sistema Administrativo de Gimnsios",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FillDataGrid();
                    EstadisticasComponent();

                }
            }
            else
            {
                MessageBox.Show("PERMISO DENEGADO, NO ERES ADMINISTRADOR.", "Sistema Administrativo de Gimnasios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void PaintTransparentBackground(Control c, PaintEventArgs e)
        {
            if (c.Parent == null || !Application.RenderWithVisualStyles)
                return;

            ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        }

        private void dgvSocios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name.Equals("Estado"))
            {
                if (e.Value != null && e.Value.ToString().Trim() == "Inactivo")
                {
                    dgv.Rows[e.RowIndex].Cells["Estado"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgv.Rows[e.RowIndex].Cells["Estado"].Style.ForeColor = Color.Green;
                }
            }
        }

    

        private void dgvSocios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Id = Convert.ToInt32(dgvSocios.CurrentRow.Cells[0].Value.ToString());
            _Nombre = dgvSocios.CurrentRow.Cells[1].Value.ToString();

            SocioInformacion oInfo = new SocioInformacion(_Nombre,_Id);
            oInfo.Show();
        }
    }
}
