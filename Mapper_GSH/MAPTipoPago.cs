using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_GSH;
using Microsoft.Data.SqlClient;

namespace Mapper_GSH
{
    public class MAPTipoPago
    {
        public BETipoPago Mapear(SqlDataReader reader)
        {
            try 
            {
                BETipoPago tpago=new BETipoPago();

                tpago.Id = Convert.ToInt32(reader["tpag_id"]);
                tpago.Descripcion = reader["tpag_desc"].ToString();
                tpago.Recargo = Convert.ToDecimal(reader["tpag_recargo"]);
                return tpago;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el tipo de pago: " + ex.Message, ex);
            }            
        }
    }
}
