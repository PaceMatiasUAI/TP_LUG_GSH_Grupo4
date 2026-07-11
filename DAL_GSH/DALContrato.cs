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
    public class DALContrato : SqlCon
    {
        private MAPContrato _mapContrato = new MAPContrato();
        private MAPPrestador _mapPrestador = new MAPPrestador();
        private MAPSucursal _mapSucursal = new MAPSucursal();
        private DALSucursal _dalSucursal = new DALSucursal();
        private DALPrestador _dalPrestador = new DALPrestador();
        public List<BEContrato> GetContratos()
        {
            try
            {
                List<BEContrato> lista = new List<BEContrato>();

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "SELECT con_id, con_sucursal, con_prestador, con_fechaAlta, con_activo FROM tbContrato";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BESucursal sucursal = _dalSucursal.GetById(Convert.ToInt32(reader["con_sucursal"]));
                                BEPrestador prestador = _dalPrestador.GetById(Convert.ToInt32(reader["con_prestador"]));
                                lista.Add(_mapContrato.Mapear(reader,sucursal,prestador));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar contratos: " + ex.Message, ex);
            }
        }
        public List<BEContrato> GetContratosBySucId(int id)
        {
            try
            {
                List<BEContrato> lista = new List<BEContrato>();

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "SELECT con_id, con_sucursal, con_prestador, con_fechaAlta, con_activo FROM tbContrato WHERE con_sucursal = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BESucursal sucursal = _dalSucursal.GetById(Convert.ToInt32(reader["con_sucursal"]));
                                BEPrestador prestador = _dalPrestador.GetById(Convert.ToInt32(reader["con_prestador"]));
                                lista.Add(_mapContrato.Mapear(reader, sucursal, prestador));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar contratos: " + ex.Message, ex);
            }
        }
        public List<BEContrato> GetContratosByPresId(int id)
        {
            try
            {
                List<BEContrato> lista = new List<BEContrato>();

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "SELECT con_id, con_sucursal, con_prestador, con_fechaAlta, con_activo FROM tbContrato WHERE  con_prestador=@id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BESucursal sucursal = _dalSucursal.GetById(Convert.ToInt32(reader["con_sucursal"]));
                                BEPrestador prestador = _dalPrestador.GetById(Convert.ToInt32(reader["con_prestador"]));
                                lista.Add(_mapContrato.Mapear(reader, sucursal, prestador));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar contratos: " + ex.Message, ex);
            }
        }
        public BEContrato GetContratoById(int id)
        {
            try
            {
                BEContrato contrato = null;

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = "SELECT con_id, con_sucursal, con_prestador, con_fechaAlta, con_activo FROM tbContrato WHERE con_id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BESucursal sucursal = _dalSucursal.GetById(Convert.ToInt32(reader["con_sucursal"]));
                                BEPrestador prestador = _dalPrestador.GetById(Convert.ToInt32(reader["con_prestador"]));
                                contrato = _mapContrato.Mapear(reader, sucursal, prestador);
                            }
                        }
                    }
                }

                return contrato;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el contrato por ID: " + ex.Message, ex);
            }
        }

        public BEContrato GetContratoBySucPrest(int idSucursal, int idPrestador)
        {
            try
            {
                BEContrato contrato = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = "SELECT con_id, con_sucursal, con_prestador, con_fechaAlta, con_activo FROM tbContrato WHERE con_sucursal = @idSucursal AND con_prestador = @idPrestador";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idSucursal", idSucursal);
                        command.Parameters.AddWithValue("@idPrestador", idPrestador);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BESucursal sucursal = _dalSucursal.GetById(Convert.ToInt32(reader["con_sucursal"]));
                                BEPrestador prestador = _dalPrestador.GetById(Convert.ToInt32(reader["con_prestador"]));
                                contrato = _mapContrato.Mapear(reader, sucursal, prestador);
                            }
                        }
                    }
                }

                return contrato;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el contrato por sucursal y prestador: " + ex.Message, ex);
            }
        }

        public bool ContratoExists(int idSucursal, int idPrestador)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM tbContrato WHERE con_sucursal = @idSucursal AND con_prestador = @idPrestador AND con_activo = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idSucursal", idSucursal);
                        command.Parameters.AddWithValue("@idPrestador", idPrestador);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del contrato: " + ex.Message, ex);
            }
        }

        public bool AnyContratoExists(int idSucursal, int idPrestador, bool activos)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query =  "SELECT COUNT(*) FROM tbContrato " +
                                    "WHERE (con_sucursal = @idSucursal OR @idSucursal=0) " +
                                    "AND (con_prestador = @idPrestador OR @idPrestador=0) " +
                                    "AND (@activo=0 OR con_activo=1)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idSucursal", idSucursal);
                        command.Parameters.AddWithValue("@idPrestador", idPrestador);
                        command.Parameters.AddWithValue("@activo", activos ? 1 : 0);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar contrato: " + ex.Message, ex);
            }
        }

        public void InsertContrato(BEContrato contrato)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "INSERT INTO tbContrato (con_sucursal, con_prestador, con_fechaAlta, con_activo) VALUES (@sucursal, @prestador, @fechaAlta, @activo)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sucursal", contrato.Sucursal.Id);
                        command.Parameters.AddWithValue("@prestador", contrato.Prestador.Id);
                        command.Parameters.AddWithValue("@fechaAlta", contrato.FechaAlta);
                        command.Parameters.AddWithValue("@activo", contrato.Activo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el contrato: " + ex.Message, ex);
            }
        }

        public void DesactivaContrato(int idContrato)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"UPDATE tbContrato SET con_activo = 0 WHERE con_id = @idContrato";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContrato", idContrato);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactivar el contrato: " + ex.Message, ex);
            }
        }

        public void ActivaContrato(int idContrato)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = "UPDATE tbContrato SET con_activo = 1 WHERE con_id = @idContrato";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContrato", idContrato);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar el contrato: " + ex.Message, ex);
            }
        }

        public List<BEPrestador> GetPrestadoresBySucursal(string codSucursal)
        {
            try
            {
                List<BEPrestador> lista = new List<BEPrestador>();

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT p.pre_id, p.pre_codigo, p.pre_nombre, p.pre_telefono, p.pre_activo
                                     FROM tbPrestador p
                                     INNER JOIN tbContrato c ON p.pre_id = c.con_prestador
                                     INNER JOIN tbSucursal s ON s.suc_id = c.con_sucursal
                                     WHERE s.suc_codigo = @codSucursal
                                     ORDER BY p.pre_codigo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codSucursal", codSucursal);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(_mapPrestador.Mapear(reader));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar prestadores por sucursal: " + ex.Message, ex);
            }
        }

        public List<BESucursal> GetSucursalesByPrestador(string codPrestador)
        {
            try
            {
                List<BESucursal> lista = new List<BESucursal>();

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT s.suc_id, s.suc_codigo, s.suc_nombre, s.suc_telefono, s.suc_direccion, s.suc_activo
                                     FROM tbSucursal s
                                     INNER JOIN tbContrato c ON s.suc_id = c.con_sucursal
                                     INNER JOIN tbPrestador p ON p.pre_id = c.con_prestador
                                     WHERE p.pre_codigo = @codPrestador                                     
                                     ORDER BY s.suc_codigo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codPrestador", codPrestador);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(_mapSucursal.Mapear(reader));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar sucursales por prestador: " + ex.Message, ex);
            }
        }

        public bool TienePagosPendientes(int idContrato)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*)
                                     FROM tbPago
                                     WHERE pag_contrato = @idContrato
                                     AND pag_estado = 'No Cancelado'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idContrato", idContrato);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar pagos pendientes del contrato: " + ex.Message, ex);
            }
        }
        public List<BEPrestador> GetPrestadoresBySucId (int id)
        {
            try
            {
                List<BEContrato> contratos = GetContratosBySucId(id);
                List<BEPrestador> prestadores = new List<BEPrestador>();
                foreach(BEContrato contrato in contratos)
                {
                    prestadores.Add(contrato.Prestador);
                }
                return prestadores;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
