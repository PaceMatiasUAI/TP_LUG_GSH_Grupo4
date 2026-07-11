using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_GSH.DTO
{
    public class DTOPago
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string Sucursal { get; set; }
        public string Prestador { get; set; }

        public DateTime Vencimiento { get; set; }
        public decimal Importe { get; set; }

        public string Estado { get; set; }
        public DateTime? Pagado { get; set; }

        public string Medio { get; set; }
        public decimal Recargo { get; set; }
        public decimal Total { get; set; }
    }
}
