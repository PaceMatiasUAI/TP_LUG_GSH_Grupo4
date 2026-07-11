using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_GSH;
using Microsoft.Data.SqlClient;

namespace Mapper_GSH
{
    public class MAPPrestador
    {
        public BEPrestador Mapear(SqlDataReader reader)
        {
            try
            {
                BEPrestador prestador=new BEPrestador();
                prestador.Id = Convert.ToInt32(reader["pre_id"]);
                prestador.Codigo = reader["pre_codigo"].ToString();
                prestador.Nombre = reader["pre_nombre"].ToString();
                prestador.Telefono = reader["pre_telefono"].ToString();
                prestador.Activo = Convert.ToBoolean(reader["pre_activo"]);
                return prestador;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el prestador: " + ex.Message, ex);
            }
        }
    }
}
