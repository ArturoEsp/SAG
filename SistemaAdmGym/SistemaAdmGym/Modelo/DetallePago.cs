using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAdmGym.Modelo
{
    public class DetallePago
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string IdSocio { get; set; }
        public string IdMembresia { get; set; }
        public double Subtotal { get; set; }
        public double Descuento  { get; set; }
        public double Total { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
