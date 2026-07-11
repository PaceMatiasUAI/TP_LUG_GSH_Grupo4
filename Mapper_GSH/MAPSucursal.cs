using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_GSH;
using Microsoft.Data.SqlClient;

namespace Mapper_GSH
{
    public class MAPSucursal
    {
        public BESucursal Mapear(SqlDataReader reader)
        {
            try
            {
                BESucursal sucursal = new BESucursal();
                sucursal.Id = Convert.ToInt32(reader["suc_id"]);
                sucursal.Codigo = reader["suc_codigo"].ToString();
                sucursal.Nombre = reader["suc_nombre"].ToString();
                sucursal.Telefono = reader["suc_telefono"].ToString();
                sucursal.Direccion = reader["suc_direccion"].ToString();
                sucursal.Activo = Convert.ToBoolean(reader["suc_activo"]);
                return sucursal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear la sucursal: " + ex.Message, ex);
            }

        }
    }
}
