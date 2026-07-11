using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_GSH
{
    public class BEPago
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public BEContrato Contrato { get; set; }

        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }

        public string Estado { get; set; }
        public DateTime? FechaPago { get; set; }
       
        public BETipoPago TipoPago { get; set; }

        public decimal Recargo { get; set; }
        public decimal TotalAbonado { get; set; }


    }
}
