using System.Configuration;

namespace Controlador
{
    /// <summary>
    /// Clase de referencia para propiedades comunes entre los controladores
    /// </summary>
    public abstract class AbstractController
    {
        /// <summary>
        /// String de conexion
        /// </summary>
        protected string connectionString;

        /// <summary>
        /// Ruta de la dll de Python
        /// </summary>
        protected string pythonDllPath;

        /// <summary>
        /// Ruta de python.runtime.dll
        /// </summary>
        protected string pythonRuntimeDllPath;

        /// <summary>
        /// Rutas de python
        /// </summary>
        protected string pythonPath;

        /// <summary>
        /// Ruta de instalacion de Python
        /// </summary>
        protected string pythonHome;

        /// <summary>
        /// Ruta del ejecutable de Python
        /// </summary>
        protected string pythonExecPath;

        /// <summary>
        /// Constructor base
        /// </summary>
        public AbstractController()
        {
            connectionString = new AppSettingsReader().GetValue("ConnectionString", string.Empty.GetType()).ToString();
            pythonDllPath = new AppSettingsReader().GetValue("PythonDllPath", string.Empty.GetType()).ToString();
            pythonHome = new AppSettingsReader().GetValue("PythonHome", string.Empty.GetType()).ToString();
            pythonExecPath = new AppSettingsReader().GetValue("PythonExecPath", string.Empty.GetType()).ToString();
        }

      
    }
}
