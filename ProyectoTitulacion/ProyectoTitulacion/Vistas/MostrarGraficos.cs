using Controlador;
using System;
using System.Data;  
using System.Linq;
using System.Windows.Forms;

namespace ProyectoTitulacion.Vistas
{
    public partial class MostrarGraficos : Form
    {
        /// <summary>
        /// Tipos de graficos soportados
        /// </summary>
        private readonly string[] tipoGragicosBasicos = new string[] { "Distribución Normal", "Acumulativo" };

        /// <summary>
        /// Formulario principal
        /// </summary>
        private Principal principal;

        /// <summary>
        /// Controlado de codigo Python para funcionalidad del modelo
        /// </summary>
        private AjustmentController atc;

        /// <summary>
        /// Controlado de archivos
        /// </summary>
        private DataFilesContoller dfc;

        /// <summary>
        /// Contolador de datos
        /// </summary>
        private DataContoller dtc;

        /// <summary>
        /// Controlador de graficos
        /// </summary>
        private GraphContoller gfc;

        /// <summary>
        /// Data
        /// </summary>
        private DataTable data;

        public MostrarGraficos(Principal principal)
        {
            gfc = new GraphContoller();
            atc = new AjustmentController();
            dtc = new DataContoller();
            dfc = new DataFilesContoller();
            this.principal = principal;
            InitializeComponent();
            principal.ejecutar("Calculando [...]\n\nAjustando Tasas" , () => { atc.predict(); });
            data = dtc.getKeyValues();
            dataGrid.DataSource = data;
            toolTipExport.SetToolTip(buttonExport, "Exporta los resultados a un archivo Excel");
            toolTipGrafico.SetToolTip(buttonGraph, "Presiona para actualizar el grafico");
            toolTipData.SetToolTip(dataGrid, "Selecciona un resgitro para verlo especifico en el grafico");
            loadCombos();
        }

        /// <summary>
        /// Coloca las posibles variables a seleccion de graficos
        /// </summary>
        private void loadCombos()
        {
            comboTipoGrafico.Items.Clear();
            comboVariable.Items.Clear();
            comboTipoGrafico.Items.AddRange(tipoGragicosBasicos);
            comboTipoGrafico.SelectedIndex = 0;
            comboVariable.Items.AddRange(dataGrid.Columns.Cast<DataGridViewColumn>().Select(
                x => x.HeaderText).Where(x => x != "identificacion").ToArray());
            comboVariable.SelectedIndex = comboVariable.Items.Count - 1;
            loadGraph();
            }

        /// <summary>
        /// Trae el valor de una columna espceifica del datagridview
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private string getSelectedIdentificacion(DataGridView dataGridView, string column)
        {
            string identificacion = string.Empty;

            if (dataGridView.CurrentCell != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                int columnIndex = dataGridView.Columns[column].Index;
                object cellValue = dataGridView.Rows[rowIndex].Cells[columnIndex].Value;
                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    identificacion = cellValue.ToString();
                }
            }
            else if (dataGridView.Rows.Count > 0)
            {
                object firstCellValue = dataGridView.Rows[0].Cells[column].Value;
                if (firstCellValue != null && !string.IsNullOrWhiteSpace(firstCellValue.ToString()))
                {
                    identificacion = firstCellValue.ToString();
                }
            }
            return identificacion;
        }

        /// <summary>
        /// Actualiza los graficos
        /// </summary>
        private void loadGraph() {
            string columnName = comboVariable.SelectedItem.ToString();
            Tuple<int, int> sizeInPixels = Tuple.Create(panelGrafico.Width, panelGrafico.Height);
            DataTable filtered = dtc.SortDataTableByColumn(dtc.filterDataTableByIdentificacion(data, "identificacion", getSelectedIdentificacion(dataGrid, "identificacion")), comboVariable.SelectedItem.ToString());
            if (comboTipoGrafico.SelectedItem.ToString().Equals(tipoGragicosBasicos[0]))
            {
                panelGrafico.BackgroundImage = gfc.generateNormalDistribution(
                    dtc.GetColumnAsDoubles(data, columnName),
                    dtc.GetColumnAsDoubles(filtered, columnName),
                    "Gráfico de distribución de: " + columnName,
                    "Valores de: " + columnName,
                    "Numero de Clientes",
                    sizeInPixels);
            }
            else
            {
                panelGrafico.BackgroundImage = gfc.generateSimpleLinePlotOrdinal(
                   dtc.GetColumnAsDoubles(data, columnName),
                   dtc.GetColumnAsDoubles(filtered, columnName),
                   "Acumulativo normal de: " + columnName,
                   "Conteo de clientes",
                   "Valores de: " + columnName,
                   sizeInPixels);
                        
            }

        }

        /// <summary>
        /// Exporta un Data table a un Excel
        /// </summary>
        /// <param name="dataTable"></param>
        public void ResultsToExcel()
        {   
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Guardamos el archivo Excel
                    dfc.saveResults(saveFileDialog.FileName);
                }
            }
        }


    /// <summary>
    /// Actualiza los graficos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonGraph_Click(object sender, EventArgs e)
        {
            principal.ejecutar("Graficando [...]", () => { loadGraph(); });
            
        }

        /// <summary>
        /// Exporta los datos disponibles a un archivo de excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            principal.ejecutar("Exportando [...]", () => { ResultsToExcel(); });
            
        }
    }
}
