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
    public class DALPrestador : SqlCon
    {
        private MAPPrestador _mapPrest = new MAPPrestador();

        public List<BEPrestador> GetPrestadores()
        {
            try
            {
                List<BEPrestador> lista = new List<BEPrestador>();

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT pre_id, pre_codigo, pre_nombre, pre_telefono, pre_activo
                                     FROM tbPrestador
                                     ORDER BY pre_codigo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(_mapPrest.Mapear(reader));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar prestadores: " + ex.Message, ex);
            }
        }
        public BEPrestador GetById(int id)
        {
            try 
            {
                BEPrestador prestador = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT pre_id, pre_codigo, pre_nombre, pre_telefono, pre_activo
                                     FROM tbPrestador
                                     WHERE pre_id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                prestador = _mapPrest.Mapear(reader);
                            }
                        }
                    }
                }
                return prestador;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el prestador por código: " + ex.Message, ex);
            }
        }
        

        public BEPrestador GetPrestByCod(string cod)
        {
            try
            {
                BEPrestador prestador = null;

                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT pre_id, pre_codigo, pre_nombre, pre_telefono, pre_activo
                                     FROM tbPrestador
                                     WHERE pre_codigo = @cod";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                prestador = _mapPrest.Mapear(reader);
                            }
                        }
                    }
                }

                return prestador;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el prestador por código: " + ex.Message, ex);
            }
        }

        public bool PrestadorExists(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) 
                                     FROM tbPrestador 
                                     WHERE pre_codigo = @cod";

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
                throw new Exception("Error al verificar la existencia del prestador: " + ex.Message, ex);
            }
        }

        public void InsertPrestador(BEPrestador prestador)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"INSERT INTO tbPrestador 
                                     (pre_codigo, pre_nombre, pre_telefono, pre_activo)
                                     VALUES 
                                     (@codigo, @nombre, @telefono, @activo)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", prestador.Codigo);
                        command.Parameters.AddWithValue("@nombre", prestador.Nombre);
                        command.Parameters.AddWithValue("@telefono", prestador.Telefono);
                        command.Parameters.AddWithValue("@activo", prestador.Activo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el prestador: " + ex.Message, ex);
            }
        }

        public void UpdatePrestador(BEPrestador prestador)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"UPDATE tbPrestador
                                     SET pre_nombre = @nombre,
                                         pre_telefono = @telefono,
                                         pre_activo = @activo                   
                                     WHERE pre_codigo = @codigo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", prestador.Codigo);
                        command.Parameters.AddWithValue("@nombre", prestador.Nombre);
                        command.Parameters.AddWithValue("@telefono", prestador.Telefono);
                        command.Parameters.AddWithValue("@activo", prestador.Activo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el prestador: " + ex.Message, ex);
            }
        }

        public void DeletePrestador(int id)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"DELETE FROM tbPrestador 
                                     WHERE pre_id = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el prestador: " + ex.Message, ex);
            }
        }

        public void DesactivaPrestador(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"UPDATE tbPrestador 
                                     SET pre_activo = 0 
                                     WHERE pre_codigo = @cod";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactivar el prestador: " + ex.Message, ex);
            }
        }

        public void ActivaPrestador(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();

                    string query = @"UPDATE tbPrestador 
                                     SET pre_activo = 1 
                                     WHERE pre_codigo = @cod";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar el prestador: " + ex.Message, ex);
            }
        }
    }
}
