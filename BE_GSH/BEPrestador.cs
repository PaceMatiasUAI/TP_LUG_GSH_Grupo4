using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_GSH
{
    public class BEPrestador
    {
        
        public int Id { get; set; }
        public string Codigo { get;  set; }
        public string Nombre { get;  set; }
        public string Telefono { get;  set; }
        public bool Activo { get; set; }

        public BEPrestador()
        {
            Activo = true;
        }
        
    }
}
