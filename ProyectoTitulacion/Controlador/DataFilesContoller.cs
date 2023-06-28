using AccesoDatos;

namespace Controlador
{
    /// <summary>
    /// Controlador para el manejo de archivos de datos
    /// </summary>
    public class DataFilesContoller : PythonContoller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DataFilesContoller() : base() {}

        /// <summary>
        /// Inserta el archivo Csv para los datos de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertCsvClientes(string path)
        {
            return InsertToSql.ImportCsvToSql(path, connectionString, "datos_cliente");
        }

        /// <summary>
        /// Inserta el archivo Excel para los datos de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertXlsClientes(string path)
        {
            return InsertToSql.ImportXlsToSql (path, connectionString, "datos_cliente");
        }

        /// <summary>
        /// Inserta datos de prestamos desde un csv
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertCsvPrestamos(string path)
        {
            return InsertToSql.ImportCsvToSql(path, connectionString, "datos_prestamos");
        }

        /// <summary>
        /// Inserta el archivo Excel para los datos de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertXlsPrestamos(string path)
        {
            return InsertToSql.ImportXlsToSql(path, connectionString, "datos_prestamos");
        }


        /// <summary>
        /// Train Inserta el archivo Csv para los datos de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertCsvClientesTrain(string path)
        {
            return InsertToSql.ImportCsvToSql(path, connectionString, "datos_cliente_train");
        }

        /// <summary>
        /// Train Inserta el archivo Excel para los datos de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertXlsClientesTrain(string path)
        {
            return InsertToSql.ImportXlsToSql(path, connectionString, "datos_cliente_train");
        }

        /// <summary>
        /// Train inser datos de prestamos desde un csv
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertCsvPrestamosTrain(string path)
        {
            return InsertToSql.ImportCsvToSql(path, connectionString, "datos_prestamos_train");
        }

        /// <summary>
        /// Train Inserta el archivo Excel para los datos de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int insertXlsPrestamosTrain(string path)
        {
            return InsertToSql.ImportXlsToSql(path, connectionString, "datos_prestamos_train");
        }


        /// <summary>
        /// Calcula la tabla secundaria para los datos de prestamos agrupados en la tabla de clientes
        /// </summary>
        public void calVars() {
            RunPythonScript(CodeRef.calculateVars());
        }

        /// <summary>
        /// Calcula la tabla secundarria para los datos pretamos agrupados para el entrenamiento
        /// </summary>
        public void calVarsTrain() {
            RunPythonScript(CodeRef.calculateVarsTrain());
        }

        /// <summary>
        /// Guarda los resultado del modelo a un archivo excel
        /// </summary>
        /// <param name="path"></param>
        public void saveResults(string path) {
            RunPythonScript(CodeRef.saveExcel(path));
        }

        public int deleteData() {
            return OperationsSQL.ExecuteStoredProcedureNoResult(connectionString, "spd_data", null);
        }

        public int deleteDataTrain() {
            return OperationsSQL.ExecuteStoredProcedureNoResult(connectionString, "spd_data_train", null);
        }
    }
}
