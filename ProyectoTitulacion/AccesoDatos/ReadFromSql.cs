using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AccesoDatos
{
    /// <summary>
    /// Clase para obtener datos MSSQL
    /// </summary>
    public static class ReadFromSql
    {
        /// <summary>
        /// Recupera el resultado de un SQL de seleccion con una cantidad indefinida de parametros
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteStoredProcedure(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }

        /// <summary>
        /// Carga el conocimiento de entrenamiento
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string LoadModelFromDatabase(string connectionString)
        {
            byte[] modelData;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select top 1 ModelData from modelo_entrenado order by id desc", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            modelData = (byte[])reader["ModelData"];
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".joblib");
            File.WriteAllBytes(tempFilePath, modelData);
            return tempFilePath;
        }

        /// <summary>
        /// Carga el conocimiento de entrenamiento
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static string LoadModel(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sps_model_knowledge", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    byte[] result = (byte[])command.ExecuteScalar();
                    string fileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".bin");
                    File.WriteAllBytes(fileName, result);
                    return fileName;
                }
            }
        }


    }
}
