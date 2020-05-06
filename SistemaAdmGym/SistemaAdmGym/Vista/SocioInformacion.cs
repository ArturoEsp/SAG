﻿using System;
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
    public partial class SocioInformacion : Form
    {
        Modelo.Socio oSocio;
        public SocioInformacion(string Nombre,int Id)
        {
            InitializeComponent();
            cxFlatStatusBar1.Text = "Información de "+Nombre;
            oSocio = Controlador.SocioController.getDatosSocio(Id);
            lblNombre.Text = oSocio.Nombre;
            lblCorreo.Text = oSocio.Email;
            lblTelefono.Text = oSocio.Telefono;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}