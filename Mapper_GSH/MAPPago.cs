using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_GSH;
using BE_GSH.DTO;
using Microsoft.Data.SqlClient;

namespace Mapper_GSH
{
    public class MAPPago
    {
        public BEPago Mapear(SqlDataReader reader, BEContrato cont, BETipoPago tpago)
        {
            try
            {
                BEPago pago = new BEPago();

                pago.Id = Convert.ToInt32(reader["pag_id"]);
                pago.Codigo = reader["pag_codigo"].ToString();
                pago.Contrato = cont;
                pago.FechaVencimiento = Convert.ToDateTime(reader["pag_fechaVencimiento"]);
                pago.Importe = Convert.ToDecimal(reader["pag_importe"]);
                pago.Estado = reader["pag_estado"].ToString();
                pago.FechaPago = reader["pag_fechaPago"] == DBNull.Value ? null : Convert.ToDateTime(reader["pag_fechaPago"]);
                pago.TipoPago = tpago;
                pago.Recargo = Convert.ToDecimal(reader["pag_recargo"]);
                pago.TotalAbonado = Convert.ToDecimal(reader["pag_totalAbonado"]);
                
                return pago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el pago: " + ex.Message, ex);
            }
        } 
        public List<DTOPago> MapearDTO(List<BEPago> pagos)
        {
            try
            {
                List<DTOPago> listaDTO = new List<DTOPago>();
                foreach (var pago in pagos)
                {
                    DTOPago dto = new DTOPago
                    {
                        Id = pago.Id,
                        Codigo = pago.Codigo,
                        Sucursal = pago.Contrato.Sucursal.Codigo,
                        Prestador = pago.Contrato.Prestador.Codigo,
                        Vencimiento = pago.FechaVencimiento,
                        Importe = pago.Importe,
                        Estado = pago.Estado,
                        Pagado = pago.FechaPago,
                        Medio = pago.TipoPago.Descripcion,
                        Recargo = pago.Recargo,
                        Total = pago.TotalAbonado
                    };
                    listaDTO.Add(dto);
                }
                return listaDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear los pagos a DTO: " + ex.Message, ex);
            }
        }
    }
}
