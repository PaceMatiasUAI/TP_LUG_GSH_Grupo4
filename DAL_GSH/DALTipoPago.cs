using BE_GSH;
using Mapper_GSH;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_GSH
{
    public class DALTipoPago : SqlCon
    {
        private MAPTipoPago _mapTipoPago = new MAPTipoPago();
        public List<BETipoPago> GetTiposPago()
        {
            try
            {
                List<BETipoPago> lista = new List<BETipoPago>();
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT tpag_id, tpag_desc, tpag_recargo
                                     FROM tbTipoPago
                                     ORDER BY tpag_desc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(_mapTipoPago.Mapear(reader));
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tipos de pago: " + ex.Message, ex);
            }
        }

        public BETipoPago GetTipoPagoById(int id)
        {
            try
            {
                BETipoPago tipoPago = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT tpag_id, tpag_desc, tpag_recargo
                                     FROM tbTipoPago
                                     WHERE tpag_id = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tipoPago = _mapTipoPago.Mapear(reader);
                            }
                        }
                    }
                }
                return tipoPago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el tipo de pago por ID: " + ex.Message, ex);
            }
        }

        public BETipoPago GetTipoPagoByDesc(string descripcion)
        {
            try
            {
                BETipoPago tipoPago = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT tpag_id, tpag_desc, tpag_recargo
                                     FROM tbTipoPago
                                     WHERE tpag_desc = @descripcion";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tipoPago = _mapTipoPago.Mapear(reader);
                            }
                        }
                    }
                }
                return tipoPago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el tipo de pago por descripción: " + ex.Message, ex);
            }
        }
    }
}
