using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAdmGym.Modelo
{
    public class Membresia
    {
        public string IdMembresia { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public double Inscripcion { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
    }
}
