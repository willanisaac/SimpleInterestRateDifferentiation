using System;
using System.Windows.Forms;
using Controlador;

namespace ProyectoTitulacion.Vistas
{
    /// <summary>
    /// Formulario para ingresar nuevos datos
    /// </summary>
    public partial class EjecucionModelo : Form
    {
        /// <summary>
        /// Formulario principal
        /// </summary>
        Principal principal;

        DataFilesContoller dtf;

        /// <summary>
        /// Controlado de codigo Python para funcionalidad del modelo
        /// </summary>
        AjustmentController atc;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal"></param>
        public EjecucionModelo(Principal principal)
        {
            this.principal = principal;
            dtf = new DataFilesContoller();
            atc = new AjustmentController();
            InitializeComponent();
            toolTipEjecutarModelo.SetToolTip(buttonEjecutar, "Ejecuta el entreamiento del modelo con los datos disponibles");
            toolTipRestaurarModelo.SetToolTip(buttonRestaurar, "Reinicia el conocmiento del modelo");
            toolTipCliente.SetToolTip(buttonClientes, "Selecciona un arhchivo CSV o Excel de datos de Clientes para el entrenamiento");
            toolTipPrestamo.SetToolTip(buttonPrestamos, "Selecciona un arhchivo CSV o Excel de datos de prestamos relacionados a los clientes para el entrenamiento");
        }

        /// <summary>
        /// Cambia el estado de los botones
        /// </summary>
        /// <param name="flag"></param>
        private void enableBotones(bool flag)
        {
            Enabled = flag;
            buttonEjecutar.Enabled = flag;
            buttonRestaurar.Enabled = flag;
        }


        /// <summary>
        /// Limite superior de una tasa de interes normativa
        /// valor establecido por el banco central del ecuador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nupTasaN_ValueChanged_1(object sender, EventArgs e)
        {
            if (nupTasaN.Value > (decimal)16.76)
            {
                nupTasaN.Value = (decimal)16.76;
            }
            if (nupTasaN.Value <= 1)
            {
                nupTasaN.Value = 1;
            }
            if (nupTasaMin.Value + (decimal)0.5 >= nupTasaN.Value)
            {
                nupTasaMin.Value  = nupTasaN.Value - (decimal)0.5;
            }
        }

        /// <summary>
        /// Limite del valor de tasa de interes ajustada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nupTasaMin_ValueChanged_1(object sender, EventArgs e)
        {
            if (nupTasaMin.Value > (decimal)16.26 )
            {
                nupTasaMin.Value = (decimal)16.26;
            } 
            if (nupTasaMin.Value <= (decimal) 0.5 )
            {
                nupTasaMin.Value = (decimal)0.4;
            }
            if (nupTasaMin.Value + (decimal)0.5 >= nupTasaN.Value)
            {
                nupTasaN.Value = nupTasaMin.Value + (decimal)0.5;
            }
        }
        /// <summary>
        /// Limite de 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nupRaroc_ValueChanged_1(object sender, EventArgs e)
        {
            if (nupRaroc.Value > (decimal)0.5)
            {
                nupRaroc.Value = (decimal)0.5;
            }
            if (nupRaroc.Value < (decimal)0.005)
            {
                nupRaroc.Value = (decimal)0.005;
            }

        }

        /// <summary>
        /// Umbral de dias de mora para setear la etiqueta de incunmplimiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nupUmbral_ValueChanged(object sender, EventArgs e)
        {
            if (nupUmbral.Value < 15)
            {
                nupUmbral.Value = 15;
            }
            if (nupUmbral.Value > 90)
            {
                nupUmbral.Value = 90;
            }
                
        }

        /// <summary>
        /// Entrena la regresion logistica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegresion_Click_1(object sender, EventArgs e)
        {
            if (labelClientes.Visible && labelPrestamos.Visible)
            {

                enableBotones(false);
                principal.ejecutar(() =>
                {
                    try
                    {
                        atc.setUmbral((int)nupUmbral.Value);
                        string output = atc.train();
                        MessageBox.Show("Modelo Entranado exitosamente\n"+output);
                    }
                    catch
                    {
                        MessageBox.Show("Error al entrenar el modelo");
                    }
                });
                dtf.deleteDataTrain();
                labelClientes.Visible = false;
                labelPrestamos.Visible = false;
                enableBotones(true);
            }
            else
            {
                MessageBox.Show("Primero inserte datos de Clientes y luego de Prestamos para entrenar el modelo");
            }
        }

        /// <summary>
        /// Ajusta los parametros de la aplicacion estadistica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEjecutar_Click(object sender, EventArgs e)
        {
            enableBotones(false);
            principal.ejecutar(() =>
            {
                try
                {
                    atc.setUmbral((int)nupUmbral.Value);
                    atc.ajust((int)nupUmbral.Value, nupTasaN.Value, nupTasaMin.Value, nupRaroc.Value);
                    MessageBox.Show("Parametros de la aplicación estadistica ajustados exitosamente");
                }
                catch
                {
                    MessageBox.Show("Error al ajustar parametros");
                }
            });
            enableBotones(true);          
        }

        /// <summary>
        /// Restaura el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (atc.restore())
            {
                MessageBox.Show("Modelo restaurado, a entrenamiento por defecto");
            }
            else {
                MessageBox.Show("El proceso de restauración ha fallado");
            }
        }

        /// <summary>
        /// Carga datos de cliente para el entrenamiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClientes_Click_1(object sender, EventArgs e)
        {
            enableBotones(false);
            principal.ejecutar(() => {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Escoge los datos de los clientes";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int result = 0;
                    string path = openFileDialog.FileName;
                    if (path.Contains(".csv"))
                    {
                        result = dtf.insertCsvClientesTrain(path);
                    }
                    else
                    {
                        result = dtf.insertXlsClientesTrain(path);
                    }
                    if (result >= 0)
                    {
                        MessageBox.Show("El proceso ha terminado con exito, " + result.ToString() + " registros afectados");
                        labelClientes.Visible = true;
                    }
                    else if (result < 0)
                    {
                        MessageBox.Show("El proceso de carga ha fallado");
                    }
                }
            });
            enableBotones(true);
        }

        /// <summary>
        /// Carga 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrestamos_Click_1(object sender, EventArgs e)
        {
            principal.ejecutar("Procesando [...]\n\n Cargando datos", () => {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Escoge los datos de prestamos";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int result = 0;
                    string path = openFileDialog.FileName;
                    if (path.Contains(".csv"))
                    {
                        result = dtf.insertCsvPrestamosTrain(path);
                    }
                    else
                    {
                        result = dtf.insertXlsPrestamosTrain(path);
                    }
                    if (result >= 0)
                    {
                        dtf.calVarsTrain();
                        MessageBox.Show("El proceso ha terminado con exito, " + result.ToString() + " registros afectados, se han agrupado las variables");
                        labelPrestamos.Visible = true;
                    }
                    else if (result < 0)
                    {
                        MessageBox.Show("El proceso de carga ha fallado");
                    }
                }
            });            
        }


    }
}
