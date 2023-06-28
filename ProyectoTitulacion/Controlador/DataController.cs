using System.Data;
using AccesoDatos;
using System.Data.SqlClient;
using System.Linq;
using System;
using Python.Runtime;

namespace Controlador
{
    /// <summary>
    /// Clase para controlar la gestion del uso de datos
    /// </summary>
    public class DataContoller : AbstractController
    {
        /// <summary>
        /// Persistencia de datos para los datos de clientes.
        /// </summary>
        private DataTable datosClientes;

        /// <summary>
        /// Persistencia de datos para los datos de prestamos
        /// </summary>
        private DataTable datosPrestamos;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataContoller() : base() { }


        #region Despliegue Datos

        /// <summary>
        /// Actualiza los datos de clientes con nuevos parametros
        /// </summary>
        /// <param name="parameters"></param>
        public void setDatosClientesParams(params SqlParameter[] parameters) {
            if (parameters is null)
            {
                datosClientes = ReadFromSql.ExecuteStoredProcedure(connectionString,
                    ProcedimientosAlmacenados.sps_datos_cliente_por_identificacion.ToString());
            } else {
                datosClientes = ReadFromSql.ExecuteStoredProcedure(connectionString,
                    ProcedimientosAlmacenados.sps_datos_cliente_por_identificacion.ToString(), parameters);
            }
        }

        /// <summary>
        /// Acualiza los datos para los prestamos con nuevos parametros
        /// </summary>
        /// <param name="parameters"></param>
        public void setDatosPrestamosParams(params SqlParameter[] parameters) {
            if (parameters is null) {
                datosPrestamos = ReadFromSql.ExecuteStoredProcedure(connectionString,
                    ProcedimientosAlmacenados.sps_datos_prestamos_por_identificacion.ToString());
            } else {
                datosPrestamos = ReadFromSql.ExecuteStoredProcedure(connectionString,
                    ProcedimientosAlmacenados.sps_datos_prestamos_por_identificacion.ToString(), parameters);
            }   
        }

        /// <summary>
        /// Actualiza los datos de clientes
        /// </summary>
        /// <param name="parameters"></param>
        public void setDatosClientes(DataTable datosClientes)
        {
            this.datosClientes = datosClientes;
        }

        /// <summary>
        /// Actualiza los datos de clientes
        /// </summary>
        /// <param name="parameters"></param>
        public void setDatosPrestamos(DataTable datosPrestamos)
        {
            this.datosPrestamos = datosPrestamos;
        }

        /// <summary>
        /// Retorna los datos de cliente
        /// </summary>
        /// <returns></returns>
        public DataTable getDatosClientes() {
            if (datosClientes == null) {
                setDatosClientesParams(null);
            }
            return datosClientes;
        }

        /// <summary>
        /// Retorna los datos de cliente
        /// </summary>
        /// <returns></returns>
        public DataTable getDatosPrestamos() {
            if (datosPrestamos == null) {
                setDatosPrestamosParams(null);
            }
            return datosPrestamos;
        }

        /// <summary>
        /// Datos en uso
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable CurrentData(bool flag) {
            return flag ? datosClientes : datosPrestamos;
        }

        /// <summary>
        /// Obtiene los valores unicos y los cuenta 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <returns>estructura doble de string y entero</returns>
        public (string[] uniqueValues, int[] valueCounts) GetUniqueValuesAndCounts(DataTable dt, string columnName)
        {
            Type tipo = dt.Columns[columnName].DataType;
            var uniqueValueCount = dt.AsEnumerable().GroupBy(row => row.Field<object>(columnName).ToString())
                .Select(group => new {
                    Value = group.Key,
                    Count = group.Count()
                }).OrderBy(item => item.Value).ToList();
                
            if (tipo == typeof(int) || tipo == typeof(double) || tipo == typeof(float))
            {
                uniqueValueCount = dt.AsEnumerable().GroupBy(row => row.Field<object>(columnName).ToString())
                    .Select(group => new {
                        Value = Math.Round(double.Parse(group.Key), 2).ToString("F2"),
                        Count = group.Count()
                    }).OrderBy(item => double.Parse(item.Value)).ToList();
            }
            return (uniqueValueCount.Select(x => x.Value).ToArray(), uniqueValueCount.Select(x => x.Count).ToArray());
        }

        /// <summary>
        /// Retorna una columna como arreglo de double
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public double[] GetColumnAsDoubles(DataTable dataTable, string columnName)
        {
            // Verifica que la tabla contenga la columna especificada
            if (!dataTable.Columns.Contains(columnName))
                throw new ArgumentException("La columna especificada no existe en la tabla.");
            // Comprueba que la columna especificada sea de tipo numérico
            Type columnType = dataTable.Columns[columnName].DataType;
            if (!typeof(double).IsAssignableFrom(columnType) && !typeof(int).IsAssignableFrom(columnType))
                throw new ArgumentException("La columna especificada no es de tipo numérico.");
            // Obtiene la columna como un arreglo de double
            return dataTable.AsEnumerable().Select(row => Convert.ToDouble(row[columnName])).ToArray();
        }

        /// <summary>
        /// Calcula el percentil de datos
        /// </summary>
        /// <param name="sortedData"></param>
        /// <param name="percentile"></param>
        /// <returns></returns>
        public double getPercentile(double[] sortedData, double percentile)
        {
            double index = (percentile / 100) * (sortedData.Length - 1);
            int lower = (int)Math.Floor(index);
            int upper = (int)Math.Ceiling(index);
            if (lower == upper)
            {
                return sortedData[lower];
            }
            return sortedData[lower] + (sortedData[upper] - sortedData[lower]) * (index - lower);
        }

        /// <summary>
        /// Remueve datos atipicos
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double[] RemoveOutliers(double[] data)
        {
            Array.Sort(data);
            double Q1 = getPercentile(data, 25);
            double Q3 = getPercentile(data, 75);
            double IQR = Q3 - Q1;
            double lowerBound = Q1 - 1.5 * IQR;
            double upperBound = Q3 + 1.5 * IQR;
            // Filtra los datos para eliminar los datos atípicos
            double[] filteredData = data.Where(x => x >= lowerBound && x <= upperBound).ToArray();
            return filteredData;
        }

        /// <summary>
        /// Filtra un dataTable por un item con el valor value
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="item"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DataTable filterDataTableByIdentificacion(DataTable dataTable, string item,string value)
        {
            DataView view = new DataView(dataTable);
            view.RowFilter = $"{item} = '{value}'";
            DataTable filteredTable = view.ToTable();
            return filteredTable;
        }

        /// <summary>
        /// Ordena un datatable mediante una columna espcifica
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columnName"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public DataTable SortDataTableByColumn(DataTable dataTable, string columnName, string asc="ASC")
        {
            dataTable.DefaultView.Sort = columnName + " " + asc;
            return dataTable.DefaultView.ToTable();
        }

        #endregion


        #region Despligue Resultados

        public DataTable getKeyValues()
        {
            return ReadFromSql.ExecuteStoredProcedure(connectionString,
                ProcedimientosAlmacenados.sps_vals.ToString());

        }

        #endregion





    }
}
