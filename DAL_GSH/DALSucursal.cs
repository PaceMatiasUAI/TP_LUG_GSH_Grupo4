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
    public class DALSucursal : SqlCon
    {
        private MAPSucursal _mapSucu = new MAPSucursal();
        public List<BESucursal> GetSucursales()
        {
            try
            {
                List<BESucursal> lista = new List<BESucursal>();
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT suc_id, suc_codigo, suc_nombre, suc_telefono, suc_direccion, suc_activo
                                     FROM tbSucursal
                                     ORDER BY suc_codigo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(_mapSucu.Mapear(reader));
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar sucursales: " + ex.Message, ex);
            }
        }

        public BESucursal GetById(int id)
        {
            try
            {
                BESucursal sucursal = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT suc_id, suc_codigo, suc_nombre, suc_telefono, suc_direccion, suc_activo
                                     FROM tbSucursal
                                     WHERE suc_id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sucursal = _mapSucu.Mapear(reader);
                            }
                        }
                    }
                }
                return sucursal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la sucursal por ID: " + ex.Message, ex);
            }
        }
        

        public BESucursal GetSucByCod(string cod)
        {
            try
            {
                BESucursal sucursal = null;
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT suc_id, suc_codigo, suc_nombre, suc_telefono, suc_direccion, suc_activo
                                     FROM tbSucursal
                                     WHERE suc_codigo = @cod";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sucursal = _mapSucu.Mapear(reader);
                            }
                        }
                    }
                }
                return sucursal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la sucursal por ID: " + ex.Message, ex);
            }
        }

        public bool SucursalExists(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"SELECT COUNT(*) FROM tbSucursal WHERE suc_codigo = @cod";
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
                throw new Exception("Error al verificar la existencia de la sucursal: " + ex.Message, ex);
            }
        }

        public void InsertSucursal(BESucursal sucursal)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"INSERT INTO tbSucursal (suc_codigo, suc_nombre, suc_telefono, suc_direccion, suc_activo)
                                     VALUES (@codigo, @nombre, @telefono, @direccion, @activo)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", sucursal.Codigo);
                        command.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                        command.Parameters.AddWithValue("@telefono", sucursal.Telefono);
                        command.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                        command.Parameters.AddWithValue("@activo", sucursal.Activo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la sucursal: " + ex.Message, ex);
            }
        }

        public void UpdateSucursal(BESucursal sucursal)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"UPDATE tbSucursal
                                     SET suc_nombre = @nombre,
                                         suc_telefono = @telefono,
                                         suc_direccion = @direccion,
                                            suc_activo = @activo
                                     WHERE suc_codigo = @codigo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", sucursal.Codigo);
                        command.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                        command.Parameters.AddWithValue("@telefono", sucursal.Telefono);
                        command.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                        command.Parameters.AddWithValue("@activo", sucursal.Activo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la sucursal: " + ex.Message, ex);
            }
        }

        public void DeleteSucursal(int id)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"DELETE FROM tbSucursal WHERE suc_id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la sucursal: " + ex.Message, ex);
            }
        }

        public void DesactivaSucursal(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"UPDATE tbSucursal SET suc_activo = 0 WHERE suc_codigo = @cod";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desactivar la sucursal: " + ex.Message, ex);
            }
        }

        public void ActivaSucursal(string cod)
        {
            try
            {
                using (SqlConnection connection = ConGSH_DB())
                {
                    connection.Open();
                    string query = @"UPDATE tbSucursal SET suc_activo = 1 WHERE suc_codigo = @cod";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al activar la sucursal: " + ex.Message, ex);
            }
        }
    }
}
