using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL_GSH
{
    public class SqlCon
    {
        protected SqlConnection ConGSH_DB()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["GSH_DB"].ConnectionString;
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la conexión a la base de datos: " + ex.Message);
            }
        }

    }
}
