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
    public class MAPContrato
    {
        public BEContrato Mapear(SqlDataReader reader, BESucursal sucu,BEPrestador pre)
        {
            try
            {
                
                BEContrato contrato = new BEContrato();
                contrato.Id = Convert.ToInt32(reader["con_id"]);
                contrato.Sucursal = sucu;
                contrato.Prestador = pre;
                contrato.FechaAlta = Convert.ToDateTime(reader["con_fechaAlta"]);
                contrato.Activo = Convert.ToBoolean(reader["con_activo"]);
                return contrato;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el contrato: " + ex.Message, ex);
            }                
        }

        public List<DTOContrato> MapearDTO(List<BEContrato> contratos, string tipo)
        {
            try
            {
                string _codigo = "";
                string _nombre = "";
                List<DTOContrato> listaDTO = new List<DTOContrato>();
                foreach (var contrato in contratos)
                {
                    if (tipo == "sucursal")
                    {
                        _codigo = contrato.Prestador.Codigo;
                        _nombre = contrato.Prestador.Nombre;
                    }
                    else if (tipo == "prestador")
                    {
                        _codigo = contrato.Sucursal.Codigo;
                        _nombre = contrato.Sucursal.Nombre;
                    }
                    else
                    {
                        throw new Exception("Tipo de mapeo de contrato no válido.");
                    }
                    DTOContrato dto = new DTOContrato
                    {
                        Id = contrato.Id,
                        Codigo = _codigo,
                        Nombre = _nombre,
                        Fecha = contrato.FechaAlta,
                        Activo = contrato.Activo
                    };
                    listaDTO.Add(dto);
                }
                return listaDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear los contratos a DTO: " + ex.Message, ex);
            }
        }
    }
}
