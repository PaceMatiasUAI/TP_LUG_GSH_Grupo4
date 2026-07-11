using BE_GSH;
using BE_GSH.DTO;
using DAL_GSH;
using Mapper_GSH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL_GSH
{
    public class BLLPago
    {
        private DALPago _dalPago = new DALPago();
        private DALContrato _dalContrato = new DALContrato();
        private MAPPago _mapPago = new MAPPago();
        private DALSucursal _dalSucursal = new DALSucursal();
        private DALPrestador _dalPrestador = new DALPrestador();
        private DALTipoPago _dalTipoPago = new DALTipoPago();

        public List<DTOPago> ObtenerPagos()
        {
            try
            {
                List<BEPago> pagos = _dalPago.GetPagos();
                return _mapPago.MapearDTO(pagos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pagos: " + ex.Message, ex);
            }
        }

        public List<DTOPago> ObtenerPagosPorSucursalPrestador(int idSucursal, int idPrestador)
        {
            try
            {
                if (idSucursal <= 0)
                    throw new Exception("Debe seleccionar una sucursal válida.");

                if (idPrestador <= 0)
                    throw new Exception("Debe seleccionar un prestador válido.");

                BEContrato contrato = _dalContrato.GetContratoBySucPrest(idSucursal, idPrestador);

                if (contrato == null)
                    return new List<DTOPago>();

                List<BEPago> pagos = _dalPago.GetPagosByContrato(contrato.Id);

                return _mapPago.MapearDTO(pagos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pagos por sucursal y prestador: " + ex.Message, ex);
            }
        }
        public void AltaPago(int idSucursal, int idPrestador, int idTipoPago, DateTime fechaVencimiento, decimal importe)
        {
            try
            {
                if (idSucursal <= 0)
                    throw new Exception("Debe seleccionar una sucursal válida.");

                if (idPrestador <= 0)
                    throw new Exception("Debe seleccionar un prestador válido.");

                if (idTipoPago <= 0)
                    throw new Exception("Debe seleccionar un tipo de pago válido.");

                if (importe <= 0)
                    throw new Exception("El importe debe ser mayor a cero.");

                BESucursal sucursal = _dalSucursal.GetById(idSucursal);

                if (sucursal == null)
                    throw new Exception("No existe la sucursal seleccionada.");

                if (!sucursal.Activo)
                    throw new Exception("No se puede generar un pago para una sucursal inactiva.");

                BEPrestador prestador = _dalPrestador.GetById(idPrestador);

                if (prestador == null)
                    throw new Exception("No existe el prestador seleccionado.");

                if (!prestador.Activo)
                    throw new Exception("No se puede generar un pago para un prestador inactivo.");

                BEContrato contrato = _dalContrato.GetContratoBySucPrest(idSucursal, idPrestador);

                if (contrato == null)
                    throw new Exception("No existe una asociación entre la sucursal y el prestador.");

                if (!contrato.Activo)
                    throw new Exception("No se puede generar un pago porque la asociación está inactiva.");

                BETipoPago tipoPago = _dalTipoPago.GetTipoPagoById(idTipoPago);

                if (tipoPago == null)
                    throw new Exception("No existe el tipo de pago seleccionado.");

                using (TransactionScope trx = new TransactionScope())
                {
                    BEPago pago = new BEPago
                    {
                        Codigo = _dalPago.GetProximoCodigoPago(),
                        Contrato = contrato,
                        FechaVencimiento = fechaVencimiento.Date,
                        Importe = importe,
                        Estado = "No Cancelado",
                        FechaPago = null,
                        TipoPago = tipoPago,
                        Recargo = 0,
                        TotalAbonado = 0
                    };

                    if (_dalPago.PagoExists(pago.Codigo))
                        throw new Exception("Ya existe un pago con el código generado. Intente nuevamente.");

                    _dalPago.InsertPago(pago);

                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el pago: " + ex.Message, ex);
            }
        }
        public BEPago PagarPago(string codigoPago)
        {
            try
            {
                // Validar que se haya seleccionado un pago
                if (string.IsNullOrWhiteSpace(codigoPago))
                    throw new Exception("Debe seleccionar un pago.");

                BEPago pago = _dalPago.GetPagoByCod(codigoPago);

                if (pago == null || pago.Id <= 0)
                    throw new Exception("No existe el pago seleccionado.");

                if (pago.Estado.Trim().ToUpper() == "CANCELADO" || pago.FechaPago.HasValue)
                    throw new Exception("El pago seleccionado ya se encuentra cancelado.");

                DateTime fechaPago = DateTime.Today;

                decimal recargo = 0;

                if (fechaPago.Date > pago.FechaVencimiento.Date)
                {
                    recargo = pago.Importe * pago.TipoPago.Recargo;
                }
                pago.FechaPago = fechaPago;
                pago.Recargo = recargo;
                pago.TotalAbonado = pago.Importe + recargo;
                
                return pago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error pago seleccionado: " + ex.Message, ex);
            }
        }
        public void ConfirmarPago (BEPago pago)
        {
            try
            {
                pago.Estado = "Cancelado";
                using (TransactionScope trx = new TransactionScope())
                {
                    _dalPago.RealizarPago(pago);
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error confirmar pago: " + ex.Message, ex);
            }
        }
    }
}

