using BE_GSH;
using DAL_GSH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BE_GSH.DTO;
using Mapper_GSH;

namespace BLL_GSH
{
    public class BLLContrato
    {
        private DALContrato _dalContrato = new DALContrato();
        private DALSucursal _dalSucursal = new DALSucursal();
        private DALPrestador _dalPrestador = new DALPrestador();
        private MAPContrato _mapContrato = new MAPContrato();

        public void AsignarPrestadorASucursal(string codigoSucursal, string codigoPrestador)
        {
            try
            {
                BEContrato contrato = validarRelacion(codigoSucursal, codigoPrestador);

                using (TransactionScope trx = new TransactionScope())
                {                     
                    if (contrato.Id > 0)
                    {
                        if (contrato.Activo)
                            throw new Exception("El prestador ya está asociado a la sucursal seleccionada.");

                        _dalContrato.ActivaContrato(contrato.Id);
                        trx.Complete();
                        return;
                    }

                    contrato.FechaAlta = DateTime.Today;
                    contrato.Activo = true;
                    _dalContrato.InsertContrato(contrato);
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al asociar el prestador a la sucursal: " + ex.Message, ex);
            }
        }
        private BEContrato validarRelacion(string codigoSucursal, string codigoPrestador)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoSucursal))
                    throw new Exception("Debe seleccionar una sucursal.");

                if (string.IsNullOrWhiteSpace(codigoPrestador))
                    throw new Exception("Debe seleccionar un prestador.");

                codigoSucursal = FormatearCodigo(codigoSucursal, "SUC-");
                codigoPrestador = FormatearCodigo(codigoPrestador, "PRE-");

                BESucursal sucursal = _dalSucursal.GetSucByCod(codigoSucursal);

                if (sucursal == null || sucursal.Id <= 0)
                    throw new Exception("No existe la sucursal seleccionada.");
                if (!sucursal.Activo)
                    throw new Exception("Sucursal seleccionada inactiva.");

                BEPrestador prestador = _dalPrestador.GetPrestByCod(codigoPrestador);

                if (prestador == null || prestador.Id <= 0)
                    throw new Exception("No existe el prestador seleccionado.");
                if (!prestador.Activo)
                    throw new Exception("Prestador seleccionado inactivo.");

                BEContrato contrato = _dalContrato.GetContratoBySucPrest(sucursal.Id, prestador.Id);
                if (contrato == null || contrato.Id<=0)
                    contrato = new BEContrato { Id = 0, Sucursal = sucursal, Prestador = prestador};

                return contrato;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar la relación entre sucursal y prestador: " + ex.Message, ex);
            }
        }
        public void DesasociarPrestadorDeSucursal(string codigoSucursal, string codigoPrestador)
        {
            try
            {
                BEContrato contrato = validarRelacion(codigoSucursal, codigoPrestador);

                if (contrato == null || contrato.Id <= 0)
                    throw new Exception("No existe una asociación entre la sucursal y el prestador seleccionados.");

                if (!contrato.Activo)
                    throw new Exception("La asociación seleccionada ya se encuentra inactiva.");

                using (TransactionScope trx = new TransactionScope())
                {
                    if (_dalContrato.TienePagosPendientes(contrato.Id))
                        throw new Exception("No se puede quitar la asociación porque tiene pagos pendientes.");

                    _dalContrato.DesactivaContrato(contrato.Id);

                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al quitar la asociación: " + ex.Message, ex);
            }
        }
        private string FormatearCodigo(string codigo, string prefijo)
        {
            codigo = codigo.Trim().ToUpper();

            if (codigo.StartsWith(prefijo))
                codigo = codigo.Replace(prefijo, "");

            return prefijo + codigo;
        }
        public List<DTOContrato> ObtenerContratosPorSucursal(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Debe seleccionar una sucursal válida.");

                List<BEContrato> contratos = _dalContrato.GetContratosBySucId(id);
                List<DTOContrato> listaDTO = _mapContrato.MapearDTO(contratos, "sucursal");
                return listaDTO;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores asociados a la sucursal: " + ex.Message, ex);
            }
        }
        public List<DTOContrato> ObtenerContratosPorPrestador(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Debe seleccionar un prestador válido.");

                List<BEContrato> contratos = _dalContrato.GetContratosByPresId(id);
                List<DTOContrato> listaDTO = _mapContrato.MapearDTO(contratos, "prestador");
                return listaDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las sucursales asociadas al prestador: " + ex.Message, ex);
            }
        }
        public List<BEPrestador> ObtenerPrestadoresPorSucursal(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Debe seleccionar una sucursal válida.");
                List<BEPrestador> prestadores = _dalContrato.GetPrestadoresBySucId(id);
                return prestadores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los prestadores asociados a la sucursal: " + ex.Message, ex);
            }
        }
    }
}

