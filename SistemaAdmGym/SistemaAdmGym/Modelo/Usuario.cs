﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAdmGym.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioName { get; set; }
        public string Contrasenia { get; set; }
        public int Tipo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
