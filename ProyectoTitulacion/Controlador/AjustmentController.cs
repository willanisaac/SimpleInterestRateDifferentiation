using System;
using System.IO;
using Python.Runtime;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Data;
using AccesoDatos;
using System.Data.SqlClient;

namespace Controlador
{
    /// <summary>
    /// Controlador del modelo de para funcionalidad de diferenciación de tasas de interes
    /// </summary>
    public class AjustmentController : PythonContoller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AjustmentController() : base() {}

        /// <summary>
        /// Entrena el modelo
        /// </summary>
        public string train() {
            return RunPythonScriptReadString(CodeRef.train(), "output");
        }

        /// <summary>
        /// Entrena el modelo
        /// </summary>
        public bool ajust(int umbral, decimal norm_tasa, decimal min_tasa, decimal rarocIndex)
        {
            RunPythonScript(CodeRef.ajust(umbral, norm_tasa, min_tasa, rarocIndex));
            return true;
        }

        /// <summary>
        /// Restaura el conocimiento del modelo y de la aplicaciòn logistica
        /// </summary>
        /// <returns></returns>
        public bool restore() {
            try
            {
                OperationsSQL.ExecuteStoredProcedureNoResult(connectionString, ProcedimientosAlmacenados.spd_model_knowledge.ToString(), null);
                return true;
            }
            catch {
                return false;
            }

        }

        /// <summary>
        /// Realiza el calculo de las tasas de interes
        /// </summary>
        public void predict() {
            RunPythonScript(CodeRef.predict());
        }


        /// <summary>
        /// Coloca el valor del cincumplimeinto segun el valor del ummbral
        /// </summary>
        /// <param name="umbral"></param>
        /// <returns></returns>
        public bool setUmbral(int umbral) {
            try
            {
                SqlParameter parameter = new SqlParameter("@umbral", SqlDbType.Int);
                parameter.Value = umbral;
                OperationsSQL.ExecuteStoredProcedureNoResult(connectionString, ProcedimientosAlmacenados.spu_incumplimiento.ToString(), new SqlParameter[] {parameter});
                return true;
            }
            catch
            {
                return false;
            }
        }

     

    }
}
