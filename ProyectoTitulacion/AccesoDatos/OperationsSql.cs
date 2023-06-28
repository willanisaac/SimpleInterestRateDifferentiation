using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    /// <summary>
    /// Clase de operaciones de SQL que no requieren un retorno de datos
    /// Las funciones aqui implementadas retorna el numero de filas afectadas
    /// </summary>
    public static class OperationsSQL
    {
        /// <summary>
        /// Ejecuta un procedimiento almacenado y 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns> numero de filas afectasas, -1 si falla</returns>
        public static int ExecuteStoredProcedureNoResult(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    try
                    {
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// Retorna 0 is el proceso es exitoso
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dataU"></param>
        /// <returns></returns>
        public static int UpdateDataU(string connectionString) {
            int deleted = ExecuteStoredProcedureNoResult(connectionString, "spd_data_u", null);
            return deleted;
        }
    }
}
