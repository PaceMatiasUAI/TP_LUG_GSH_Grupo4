using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_GSH;
using DAL_GSH;
using System.Transactions;
using System.Text.RegularExpressions;

namespace BLL_GSH
{
    public class BLLSucursal
    {
        private DALSucursal _dalSucursal = new DALSucursal();
        private DALContrato _dalContrato = new DALContrato();
        #region getters
        public BESucursal ObtenerSucursalPorCodigo(string codigo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    throw new Exception("Debe indicar el código de la sucursal.");

                codigo = FormatearCodigo(codigo, "SUC-");
                BESucursal sucursal = _dalSucursal.GetSucByCod(codigo);

                if (sucursal == null)
                    throw new Exception("No existe una sucursal con el código indicado.");

                return sucursal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la sucursal: " + ex.Message, ex);
            }
        }
        public List<BESucursal> GetSucursales()
        {
            return _dalSucursal.GetSucursales();
        }
        #endregion
        #region ABM
        public void AltaSucursal(BESucursal sucursal)
        {
            try
            {
                ValidarSucursal(sucursal);

                sucursal.Codigo = FormatearCodigo(sucursal.Codigo, "SUC-");
                sucursal.Nombre = sucursal.Nombre.Trim();
                sucursal.Telefono = sucursal.Telefono.Trim();
                sucursal.Direccion = sucursal.Direccion.Trim();
                sucursal.Activo = true;

                using (var trx= new TransactionScope())
                {
                    if (_dalSucursal.SucursalExists(sucursal.Codigo))
                        throw new Exception("Ya existe una sucursal con el mismo código.");
                    _dalSucursal.InsertSucursal(sucursal);
                    trx.Complete();
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la sucursal: " + ex.Message, ex);
            }
        }

        private void ValidarSucursal(BESucursal sucursal)
        {
            if (sucursal == null)
                throw new Exception("La sucursal no puede ser nula.");

            if (string.IsNullOrWhiteSpace(sucursal.Codigo))
                throw new Exception("El código de la sucursal es obligatorio.");

            string codigo = sucursal.Codigo.Trim().ToUpper();
            // Eliminar el prefijo "SUC-" si está presente por el usuario o por si es una modificacion
            if (codigo.StartsWith("SUC-"))
                codigo = codigo.Replace("SUC-", "");

            if (!Regex.IsMatch(codigo, @"^[A-Z0-9]{5}$"))
                throw new Exception("El código de la sucursal debe tener 5 caracteres alfanuméricos en mayúscula.");

            if (string.IsNullOrWhiteSpace(sucursal.Nombre))
                throw new Exception("El nombre de la sucursal es obligatorio.");

            if (sucursal.Nombre.Trim().Length < 4 || sucursal.Nombre.Trim().Length > 60)
                throw new Exception("El nombre de la sucursal debe tener entre 4 y 60 caracteres.");

            if (string.IsNullOrWhiteSpace(sucursal.Telefono))
                throw new Exception("El teléfono de la sucursal es obligatorio.");

            if (sucursal.Telefono.Trim().Length < 8 || sucursal.Telefono.Trim().Length > 20)
                throw new Exception("El teléfono de la sucursal debe tener entre 8 y 20 caracteres.");

            if (!Regex.IsMatch(sucursal.Telefono.Trim(), @"^[0-9]+$"))
                throw new Exception("El teléfono de la sucursal debe contener solo números.");

            if (string.IsNullOrWhiteSpace(sucursal.Direccion))
                throw new Exception("La dirección de la sucursal es obligatoria.");

            if (sucursal.Direccion.Trim().Length < 6 || sucursal.Direccion.Trim().Length > 60)
                throw new Exception("La dirección de la sucursal debe tener entre 6 y 60 caracteres.");

            if (!(sucursal.Direccion.Any(char.IsLetter) && sucursal.Direccion.Any(char.IsNumber)))
                throw new Exception("La dirección de la sucursal debe contener letras y números.");
        }

        private string FormatearCodigo(string codigo, string prefijo)
        {
            codigo = codigo.Trim().ToUpper();

            if (codigo.StartsWith(prefijo))
                codigo = codigo.Replace(prefijo, "");

            return prefijo + codigo;
        }
        public void ModificarSucursal(BESucursal sucursal, BESucursal anterior)
        {
            try
            {
                if (anterior == null)
                    throw new Exception("La sucursal original no puede ser nula.");

                if (sucursal == null)
                    throw new Exception("La sucursal modificada no puede ser nula.");
                // datos que no se pueden modificar: Codigo, Id
                sucursal.Id = anterior.Id;
                sucursal.Codigo = anterior.Codigo;
                ValidarSucursal(sucursal);
                
                sucursal.Nombre = sucursal.Nombre.Trim();
                sucursal.Telefono = sucursal.Telefono.Trim();
                sucursal.Direccion = sucursal.Direccion.Trim();

                if(!sucursal.Activo && anterior.Activo && _dalContrato.AnyContratoExists(sucursal.Id, 0, true))
                    throw new Exception("No se puede desactivar la sucursal porque tiene asociaciones relacionadas.");

                using (var trx = new TransactionScope())
                {
                    if (!_dalSucursal.SucursalExists(sucursal.Codigo))
                        throw new Exception("No existe una sucursal con el código indicado.");
                    _dalSucursal.UpdateSucursal(sucursal);
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la sucursal: " + ex.Message, ex);
            }
        }
        public void BajaSucursal(string codigo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    throw new Exception("Debe seleccionar una sucursal.");

                codigo = FormatearCodigo(codigo, "SUC-");

                BESucursal sucursal = _dalSucursal.GetSucByCod(codigo);

                if (sucursal == null || sucursal.Id <= 0)
                    throw new Exception("No existe la sucursal seleccionada.");

                using (TransactionScope trx = new TransactionScope())
                {
                    if (_dalContrato.AnyContratoExists(sucursal.Id,0,false))
                        throw new Exception("No se puede eliminar la sucursal porque tiene asociaciones o historial relacionado.");

                    _dalSucursal.DeleteSucursal(sucursal.Id);

                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja la sucursal: " + ex.Message, ex);
            }
        }

        #endregion
    }
}
