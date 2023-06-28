using System;
using System.Windows.Forms;
using Controlador;

namespace ProyectoTitulacion.Vistas
{
    /// <summary>
    /// Formulario para ingresar nuevos datos
    /// </summary>
    public partial class CargarNuevosDatos : Form
    {
        /// <summary>
        /// Formulario principal
        /// </summary>
        Principal principal;

        /// <summary>
        /// Controlado de archivos
        /// </summary>
        DataFilesContoller dtf;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal"></param>
        public CargarNuevosDatos(Principal principal)
        {
            this.principal = principal;
            dtf = new DataFilesContoller();
            InitializeComponent();
            toolTipcliente.SetToolTip(buttonClientes, "Selecciona un arhchivo CSV o Excel de datos de Clientes con la descripción de columnas mostradas en la parte inferior de esta pantalla");
            toolTipPrestamos.SetToolTip(buttonPrestamos, "Selecciona un arhchivo CSV o Excel de datos de prestamos relacionados a los clientes con la descripción de columnas mostradas en la parte inferior de esta pantalla");
        }

        /// <summary>
        /// Cambia el estado de los botones
        /// </summary>
        /// <param name="flag"></param>
        private void enableBotones(bool flag)
        {
            this.Enabled = flag;
            buttonClientes.Enabled = flag;
            buttonPrestamos.Enabled = flag;
        }

        /// <summary>
        /// Carga datos de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClientes_Click(object sender, EventArgs e)
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
                        result = dtf.insertCsvClientes(path);
                    }
                    else
                    {
                        result = dtf.insertXlsClientes(path);
                    }
                    if (result >= 0)
                    {
                        MessageBox.Show("El proceso ha terminado con exito, " + result.ToString() + " registros afectados");
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
        /// Carga datos de Prestamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrestamos_Click(object sender, EventArgs e)
        {
            enableBotones(false);
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
                        result = dtf.insertCsvPrestamos(path);
                    }
                    else
                    {
                        result = dtf.insertXlsPrestamos(path);
                    }
                    if (result >= 0)
                    {
                        dtf.calVars();
                        MessageBox.Show("El proceso ha terminado con exito, " + result.ToString() + " registros afectados, se han agrupado las variables");
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
        /// Elimina todos los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            dtf.deleteData();
            MessageBox.Show("Los datos se han eliminado");
        }
    }
}
