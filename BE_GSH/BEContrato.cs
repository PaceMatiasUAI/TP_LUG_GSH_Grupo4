using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_GSH
{
    public class BEContrato
    {
        public int Id { get; set; }
        public BESucursal Sucursal { get; set; }
        public BEPrestador Prestador { get; set; }

        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }

        public BEContrato()
        {            
            Activo = true;
        }
    }
}
