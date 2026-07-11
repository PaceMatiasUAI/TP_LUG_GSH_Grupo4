using BE_GSH;
using DAL_GSH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_GSH
{
    public class BLLTipoPago
    {
        private DALTipoPago _dalTipoPago = new DALTipoPago();

        public List<BETipoPago> GetTiposPago()
        {
            try
            {
                return _dalTipoPago.GetTiposPago();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los tipos de pago: " + ex.Message, ex);
            }
        }
        public BETipoPago ObtenerTipoPagoPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Debe seleccionar un tipo de pago válido.");

                BETipoPago tipoPago = _dalTipoPago.GetTipoPagoById(id);
                if (tipoPago == null)
                    throw new Exception("No existe el tipo de pago seleccionado.");

                return tipoPago;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el tipo de pago: " + ex.Message, ex);
            }
        }
    }
}
