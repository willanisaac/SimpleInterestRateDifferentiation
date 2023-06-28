using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controlador
{
    /// <summary>
    /// Clase de referencia para la funcionalidad de Python
    /// </summary>
    public abstract class PythonContoller : AbstractController
    {
        /// <summary>
        /// Establecimiento de condiciones para un correcto funcionamiento de Python
        /// </summary>
        public PythonContoller() : base()
        {
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDllPath);
            Environment.SetEnvironmentVariable("PYTHONHOME", pythonHome);
            Environment.SetEnvironmentVariable("PYTHONNET_PYTHON_EXECUTABLE", pythonExecPath);
        }


        /// <summary>
        /// Transforma un DataTable de C# a DataFrame de pandas-python 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static dynamic DataTableToPandasDataFrame(DataTable dt)
        {
            dynamic np = Py.Import("numpy");
            dynamic pd = Py.Import("pandas");

            Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();

            foreach (DataColumn col in dt.Columns)
            {
                if (col.DataType == typeof(int))
                    dict[col.ColumnName] = np.array((from object item in col.Table.AsEnumerable() select Convert.ToInt32(item)).ToArray<int>());
                else if (col.DataType == typeof(double))
                    dict[col.ColumnName] = np.array((from object item in col.Table.AsEnumerable() select Convert.ToDouble(item)).ToArray<double>());
                else if (col.DataType == typeof(string))
                    dict[col.ColumnName] = np.array((from object item in col.Table.AsEnumerable() select Convert.ToString(item)).ToArray<string>());
            }
            return pd.DataFrame(dict);
        }

        /// <summary>
        /// Transforma un DataFrame de pandas-python a DataTable de C#
        /// </summary>
        /// <param name="pdDataFrame"></param>
        /// <returns></returns>
        public static DataTable PandasDataFrameToDataTable(dynamic pdDataFrame)
        {
            // Convierte el DataFrame de pandas a DataTable de C#
            DataTable dt = new DataTable();
            foreach (var col in pdDataFrame.columns)
            {
                dt.Columns.Add(col.ToString());
            }

            foreach (var row in pdDataFrame.itertuples())
            {
                DataRow newRow = dt.NewRow();
                foreach (var item in row)
                {
                    newRow[item[0]] = item[1].ToString();
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        /// <summary>
        /// Ejecuta un script de Python
        /// </summary>
        /// <param name="pythonScript"></param>
        public static void RunPythonScript(string pythonScript)
        {
            PythonEngine.Initialize();
            using (Py.GIL()) // adquiere el Global Interpreter Lock (GIL)
            {
                PythonEngine.Exec(pythonScript);
            }
            PythonEngine.Shutdown();
        }

        /// <summary>
        /// Ejecuta un script de Python con una salida string
        /// </summary>
        /// <param name="pythonScript"></param>
        /// <param name="string_value"></param>
        /// <returns></returns>
        public static string RunPythonScriptReadString(string pythonScript, string string_value) {
            string output = string.Empty;
            PythonEngine.Initialize();
            using (Py.GIL()) // adquiere el Global Interpreter Lock (GIL)
            {
                dynamic gil = Py.CreateScope();
                gil.Exec(pythonScript);
                output = gil.Get<string>(string_value);
            }
            PythonEngine.Shutdown();
            return output;
        }

    }
}
