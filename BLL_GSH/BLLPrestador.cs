using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_GSH;
using BE_GSH;
using System.Text.RegularExpressions;
using System.Transactions;

namespace BLL_GSH
{
    public class BLLPrestador
    {
        private DALPrestador _dalPrestador = new DALPrestador();
        private DALContrato _dalContrato = new DALContrato();
        #region getters
        public List<BEPrestador> GetPrestadores()
        {
            return _dalPrestador.GetPrestadores();
        }
        public BEPrestador ObtenerPrestadorPorCodigo(string codigo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    throw new Exception("Debe indicar el código del prestador.");

                codigo = FormatearCodigo(codigo, "PRE-");
                BEPrestador prestador = _dalPrestador.GetPrestByCod(codigo);

                if (prestador == null)
                    throw new Exception("No existe un prestador con el código indicado.");

                return prestador;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el prestador: " + ex.Message, ex);
            }
        }
        #endregion
        #region ABM
        public void AltaPrestador(BEPrestador prestador)
        {
            try
            {
                ValidarPrestador(prestador);

                prestador.Codigo = FormatearCodigo(prestador.Codigo, "PRE-");
                prestador.Nombre = prestador.Nombre.Trim();
                prestador.Telefono = prestador.Telefono.Trim();
                prestador.Activo = true;

                using (var trx = new TransactionScope())
                {
                    if (_dalPrestador.PrestadorExists(prestador.Codigo))
                        throw new Exception("Ya existe un prestador con el mismo código.");
                    _dalPrestador.InsertPrestador(prestador);
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el prestador: " + ex.Message, ex);
            }
        }

        private void ValidarPrestador(BEPrestador prestador)
        {
            if (prestador == null)
                throw new Exception("El prestador no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(prestador.Codigo))
                throw new Exception("El código del prestador es obligatorio.");
            // Eliminar el prefijo "PRE-" si está presente por el usuario o por si es una modificacion
            string codigo = prestador.Codigo.Trim().ToUpper();

            if (codigo.StartsWith("PRE-"))
                codigo = codigo.Replace("PRE-", "");

            if (!Regex.IsMatch(codigo, @"^[A-Z0-9]{5}$"))
                throw new Exception("El código del prestador debe tener 5 caracteres alfanuméricos en mayúscula.");

            if (string.IsNullOrWhiteSpace(prestador.Nombre))
                throw new Exception("El nombre del prestador es obligatorio.");

            if (prestador.Nombre.Trim().Length < 4 || prestador.Nombre.Trim().Length > 60)
                throw new Exception("El nombre del prestador debe tener entre 4 y 60 caracteres.");

            if (string.IsNullOrWhiteSpace(prestador.Telefono))
                throw new Exception("El teléfono del prestador es obligatorio.");

            if (prestador.Telefono.Trim().Length < 8 || prestador.Telefono.Trim().Length > 20)
                throw new Exception("El teléfono del prestador debe tener entre 8 y 20 caracteres.");

            if (!Regex.IsMatch(prestador.Telefono.Trim(), @"^[0-9]+$"))
                throw new Exception("El teléfono del prestador debe contener solo números.");
        }

        private string FormatearCodigo(string codigo, string prefijo)
        {
            codigo = codigo.Trim().ToUpper();

            if (codigo.StartsWith(prefijo))
                codigo = codigo.Replace(prefijo, "");

            return prefijo + codigo;
        }

        
        public void ModificarPrestador(BEPrestador prestador, BEPrestador anterior)
        {
            try
            {
                if (anterior == null)
                    throw new Exception("El prestador original no puede ser nulo.");

                if (prestador == null)
                    throw new Exception("El prestador modificado no puede ser nulo.");
                // datos que no se pueden modificar: Codigo, Id
                prestador.Id = anterior.Id;
                prestador.Codigo = anterior.Codigo;
                ValidarPrestador(prestador);

                prestador.Nombre = prestador.Nombre.Trim();
                prestador.Telefono = prestador.Telefono.Trim();
                if (!prestador.Activo && anterior.Activo && _dalContrato.AnyContratoExists(0, prestador.Id, true))
                    throw new Exception("No se puede desactivar el prestador porque tiene asociaciones activas.");

                using (var trx = new TransactionScope())
                {
                    if(!_dalPrestador.PrestadorExists(prestador.Codigo))
                        throw new Exception("No existe un prestador con el código indicado.");
                    _dalPrestador.UpdatePrestador(prestador);
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el prestador: " + ex.Message, ex);
            }
        }
        public void BajaPrestador(string codigo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigo))
                    throw new Exception("Debe seleccionar un prestador.");

                codigo = FormatearCodigo(codigo, "PRE-");

                BEPrestador prestador = _dalPrestador.GetPrestByCod(codigo);

                if (prestador == null || prestador.Id <= 0)
                    throw new Exception("No existe el prestador seleccionado.");

                using (TransactionScope trx = new TransactionScope())
                {
                    if (_dalContrato.AnyContratoExists(0,prestador.Id,false))
                        throw new Exception("No se puede eliminar el prestador porque tiene asociaciones o historial relacionado.");

                    _dalPrestador.DeletePrestador(prestador.Id);

                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el prestador: " + ex.Message, ex);
            }
        }
        #endregion
    }
}

