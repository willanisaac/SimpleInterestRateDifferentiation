using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AccesoDatos
{
    /// <summary>
    /// Clase de inserciòn de datos a SQL
    /// </summary>
    public static class InsertToSql
    {
        /// <summary>
        /// Importa un archivo CSV a SQL, los nombres de columnas deben coincidir
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns>bool : el proceso es exitoso?</returns>
        public static int ImportCsvToSql(string csvFilePath, string connectionString, string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    var headerLine = reader.ReadLine();
                    var headers = headerLine.Split(';');
                    foreach (var header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        dt.Rows.Add(values);
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = tableName;
                        bulkCopy.WriteToServer(dt);
                    }
                }
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al insertar los datos: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Importa un archivo Excel a SQL, los nombres de columnas deben coincidir
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns>bool : el proceso es exitoso?</returns>
        public static int ImportXlsToSql(string excelFilePath, string connectionString, string tableName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                    {
                        var worksheet = package.Workbook.Worksheets[0];
                        var headers = Enumerable.Range(1, worksheet.Dimension.Columns)
                                                .Select(col => worksheet.Cells[1, col].Value.ToString())
                                                .ToArray();
                        DataTable table = new DataTable();
                        foreach (var header in headers)
                        {
                            table.Columns.Add(header);
                        }
                        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                        {
                            DataRow dataRow = table.NewRow();
                            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                            {
                                var cellValue = worksheet.Cells[row, col].Value;
                                dataRow[headers[col - 1]] = cellValue ?? DBNull.Value;
                            }
                            table.Rows.Add(dataRow);
                        }
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                        {
                            bulkCopy.DestinationTableName = tableName;
                            bulkCopy.WriteToServer(table);
                        }
                        return table.Rows.Count;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// inserta un DataTable en SQL, los nombres de columnas deben coincidir
        /// </summary>
        /// <param name="data"></param>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns>bool : el proceso es exitoso?</returns>
        public static int DataTableToSql(DataTable data, string connectionString, string tableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = tableName;
                        foreach (DataColumn column in data.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                        }
                        bulkCopy.WriteToServer(data);
                    }
                }
                return data.Rows.Count;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Toma un archivo binario e inserta todo el contenido en una tabla especifica
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="connectionString"></param>
        /// <returns> bool :  el proceso es exitoso? </returns>
        public static bool ModelToSql(string filePath, string connectionString, int id)
        {
            try
            {
                byte[] modelData = File.ReadAllBytes(filePath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO modelo_entrenado (Id, ModelData) VALUES (@Id, @ModelData)", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@ModelData", modelData);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    
    }
}
