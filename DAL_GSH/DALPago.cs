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
    public class DALPago :SqlCon
    {
        private MAPPago _mapPago = new MAPPago();
        private DALContrato _dalContrato = new DALContrato();
        private DALTipoPago _dalTipoPago = new DALTipoPago();

        public List<BEPago> GetPagos()
        {
            try
            {
                List<BEPago> lista = new List<BEPago>();
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT pag_id, pag_codigo, pag_contrato, pag_fechaVencimiento,
                                            pag_importe, pag_estado, pag_fechaPago, pag_tipoPago,
                                            pag_recargo, pag_totalAbonado
                                     FROM tbPago
                                     ORDER BY pag_codigo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BEContrato contrato = _dalContrato.GetContratoById(Convert.ToInt32(reader["pag_contrato"]));
                                BETipoPago tipoPago = _dalTipoPago.GetTipoPagoById(Convert.ToInt32(reader["pag_tipoPago"]));
                                lista.Add(_mapPago.Mapear(reader, contrato, tipoPago));
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar pagos: " + ex.Message, ex);
            }
        }

        public BEPago GetPagoByCod(string cod)
        {
            try
            {
                BEPago pago = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT pag_id, pag_codigo, pag_contrato, pag_fechaVencimiento,
                                            pag_importe, pag_estado, pag_fechaPago, pag_tipoPago,
                                            pag_recargo, pag_totalAbonado
                                     FROM tbPago
                                     WHERE pag_codigo = @cod";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BEContrato contrato = _dalContrato.GetContratoById(Convert.ToInt32(reader["pag_contrato"]));
                                BETipoPago tipoPago = _dalTipoPago.GetTipoPagoById(Convert.ToInt32(reader["pag_tipoPago"]));
                                pago = _mapPago.Mapear(reader, contrato, tipoPago);
                            }
                        }
                    }
                }
                return pago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pago por código: " + ex.Message, ex);
            }
        }

        public bool PagoExists(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT COUNT(*)
                                     FROM tbPago
                                     WHERE pag_codigo = @cod";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del pago: " + ex.Message, ex);
            }
        }

        public void InsertPago(BEPago pago)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"INSERT INTO tbPago
                                     (pag_codigo, pag_contrato, pag_fechaVencimiento, pag_importe,
                                      pag_estado, pag_fechaPago, pag_tipoPago, pag_recargo, pag_totalAbonado)
                                     VALUES
                                     (@codigo, @contrato, @fechaVencimiento, @importe,
                                      @estado, @fechaPago, @tipoPago, @recargo, @totalAbonado)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", pago.Codigo);
                        command.Parameters.AddWithValue("@contrato", pago.Contrato.Id);
                        command.Parameters.AddWithValue("@fechaVencimiento", pago.FechaVencimiento);
                        command.Parameters.AddWithValue("@importe", pago.Importe);
                        command.Parameters.AddWithValue("@estado", pago.Estado);
                        if (pago.FechaPago == null)
                            command.Parameters.AddWithValue("@fechaPago", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@fechaPago", pago.FechaPago);
                        command.Parameters.AddWithValue("@tipoPago", pago.TipoPago.Id);
                        command.Parameters.AddWithValue("@recargo", pago.Recargo);
                        command.Parameters.AddWithValue("@totalAbonado", pago.TotalAbonado);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el pago: " + ex.Message, ex);
            }
        }

        public void UpdatePago(BEPago pago)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"UPDATE tbPago
                                     SET pag_fechaVencimiento = @fechaVencimiento,
                                         pag_importe = @importe,
                                         pag_estado = @estado,
                                         pag_fechaPago = @fechaPago,
                                         pag_tipoPago = @tipoPago,
                                         pag_recargo = @recargo,
                                         pag_totalAbonado = @totalAbonado
                                     WHERE pag_codigo = @codigo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", pago.Codigo);
                        command.Parameters.AddWithValue("@fechaVencimiento", pago.FechaVencimiento);
                        command.Parameters.AddWithValue("@importe", pago.Importe);
                        command.Parameters.AddWithValue("@estado", pago.Estado);
                        if (pago.FechaPago == null)
                            command.Parameters.AddWithValue("@fechaPago", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@fechaPago", pago.FechaPago);
                        command.Parameters.AddWithValue("@tipoPago", pago.TipoPago.Id);
                        command.Parameters.AddWithValue("@recargo", pago.Recargo);
                        command.Parameters.AddWithValue("@totalAbonado", pago.TotalAbonado);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pago: " + ex.Message, ex);
            }
        }

        public List<BEPago> GetPagosByContrato(int idContrato)
        {
            try
            {
                List<BEPago> lista = new List<BEPago>();
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT pag_id, pag_codigo, pag_contrato, pag_fechaVencimiento,
                                            pag_importe, pag_estado, pag_fechaPago, pag_tipoPago,
                                            pag_recargo, pag_totalAbonado
                                     FROM tbPago
                                     WHERE pag_contrato = @idContrato
                                     ORDER BY pag_fechaVencimiento";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContrato", idContrato);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BEContrato contrato = _dalContrato.GetContratoById(Convert.ToInt32(reader["pag_contrato"]));
                                BETipoPago tipoPago = _dalTipoPago.GetTipoPagoById(Convert.ToInt32(reader["pag_tipoPago"]));
                                lista.Add(_mapPago.Mapear(reader, contrato, tipoPago));
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar pagos por contrato: " + ex.Message, ex);
            }
        }

        public List<BEPago> GetPagosBySucPrest(string codSucursal, string codPrestador)
        {
            try
            {
                List<BEPago> lista = new List<BEPago>();
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT p.pag_id, p.pag_codigo, p.pag_contrato, p.pag_fechaVencimiento,
                                            p.pag_importe, p.pag_estado, p.pag_fechaPago, p.pag_tipoPago,
                                            p.pag_recargo, p.pag_totalAbonado
                                     FROM tbPago p
                                     INNER JOIN tbContrato c ON p.pag_contrato = c.con_id
                                     INNER JOIN tbSucursal s ON s.suc_id = c.con_sucursal
                                     INNER JOIN tbPrestador pr ON pr.pre_id = c.con_prestador
                                     WHERE s.suc_codigo = @codSucursal
                                     AND pr.pre_codigo = @codPrestador                                   
                                     ORDER BY p.pag_fechaVencimiento";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codSucursal", codSucursal);
                        command.Parameters.AddWithValue("@codPrestador", codPrestador);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BEContrato contrato = _dalContrato.GetContratoById(Convert.ToInt32(reader["pag_contrato"]));
                                BETipoPago tipoPago = _dalTipoPago.GetTipoPagoById(Convert.ToInt32(reader["pag_tipoPago"]));
                                lista.Add(_mapPago.Mapear(reader, contrato, tipoPago));
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar pagos por sucursal y prestador: " + ex.Message, ex);
            }
        }

        public void RealizarPago(BEPago pago)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"UPDATE tbPago
                                     SET pag_estado = @estado,
                                         pag_fechaPago = @fechaPago,
                                         pag_recargo = @recargo,
                                         pag_totalAbonado = @totalAbonado
                                     WHERE pag_codigo = @codigo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", pago.Codigo);
                        command.Parameters.AddWithValue("@estado", pago.Estado);
                        if (pago.FechaPago == null)
                            pago.FechaPago=DateTime.Now;
                        else
                            command.Parameters.AddWithValue("@fechaPago", pago.FechaPago);
                        command.Parameters.AddWithValue("@recargo", pago.Recargo);
                        command.Parameters.AddWithValue("@totalAbonado", pago.TotalAbonado);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el pago: " + ex.Message, ex);
            }
        }
        public string GetProximoCodigoPago()
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "SELECT ISNULL(MAX(pag_id), 0) + 1 FROM tbPago";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int proximoId = Convert.ToInt32(command.ExecuteScalar());

                        return "PAG-" + proximoId.ToString("D6");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el próximo código de pago: " + ex.Message, ex);
            }
        }
    }
}
