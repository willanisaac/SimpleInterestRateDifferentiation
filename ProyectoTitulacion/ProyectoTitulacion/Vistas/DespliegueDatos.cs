using System;
using Controlador;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Data;
using System.Diagnostics;

namespace ProyectoTitulacion.Vistas
{
    /// <summary>
    /// Formulario de muestra de datos simple
    /// </summary>
    public partial class DespliegueDatos : Form
    {
        /// <summary>
        /// Formulario Principal
        /// </summary>
        private Principal principal;

        /// <summary>
        /// Controlador de datos
        /// </summary>
        private DataContoller dtc;

        /// <summary>
        /// Controlador de Python para graficos
        /// </summary>
        private GraphContoller gfc;

        /// <summary>
        /// indica si los datos mostrados pertencen al de los clientes
        /// </summary>
        private bool flagCliente;

        /// <summary>
        /// Tipos basicos de graficos
        /// </summary>
        private readonly string[] tipoGragicosBasicos = new string[] { "Histograma-Barras", "Linea Temporal" , "Scatter"};

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public DespliegueDatos(Principal principal)
        {
            this.principal = principal;
            dtc = new DataContoller();
            gfc = new GraphContoller();
            flagCliente = false;
            InitializeComponent();
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
        /// Refresca los combo box y actualiza el grafico
        /// </summary>
        private void loadCombos()
        {
            labelDatos.Visible = false;

            // limpiar contenido de combos
            comboTipoGrafico.Items.Clear();
            comboVariablesX.Items.Clear();
            comboVariablesY.Items.Clear();

            // carga tipos de graficos en comboBox
            comboTipoGrafico.Items.AddRange(tipoGragicosBasicos);
            comboTipoGrafico.SelectedIndex = 0;

            // carga nombres de variables en comboBox
            comboVariablesX.Items.AddRange(dataGrid.Columns.Cast<DataGridViewColumn>().Select(
                x => x.HeaderText).Where(x => x != "identificacion" //&& x != "codigo_prestamo"
                ).ToArray());
            comboVariablesX.SelectedIndex = 0;
            comboVariablesY.Items.AddRange(dataGrid.Columns.Cast<DataGridViewColumn>().Select(
                x => x.HeaderText).Where(x => x != "identificacion" //&& x != "codigo_prestamo"
                ).ToArray());
            comboVariablesY.SelectedIndex = 0;
            loadGraphs();
        }

        /// <summary>
        /// Carga los graficos
        /// </summary>
        private void loadGraphs()
        {
            labelGraficar.Visible = true;
            Tuple<int, int> sizeInPixels = Tuple.Create(panelGrafico.Width, panelGrafico.Height);
            string columnName = comboVariablesX.SelectedItem.ToString();
            string columnNameY = columnName;
            if (comboVariablesY.SelectedIndex != 0) {
                columnNameY = comboVariablesY.SelectedItem.ToString();
            } 
            switch (comboTipoGrafico.SelectedItem.ToString())
            {
                case "Linea Temporal":
                    if (dtc.CurrentData(flagCliente).Columns[columnNameY].DataType == typeof(string))
                    {
                        MessageBox.Show("Grafico solo disponible para variables numéricas en el eje Y y fecha_corte en X ");
                    } else {
                        comboVariablesX.SelectedItem = "fecha_corte";
                        columnName = "fecha_corte";
                        DataTable filtered = dtc.SortDataTableByColumn( dtc.filterDataTableByIdentificacion(dtc.CurrentData(flagCliente),"identificacion",
                            getSelectedIdentificacion(dataGrid, "identificacion")), columnName);
                        panelGrafico.BackgroundImage = gfc.generatePlotString(
                            filtered.AsEnumerable().Select(row => row.Field<string>(columnName)).ToArray(),
                            dtc.GetColumnAsDoubles(filtered, columnNameY),
                            "Linea Temporal para: " + columnNameY,
                            "Valores de: " + columnName,
                            "valores de: " + columnNameY,
                            sizeInPixels);
                    }
                    break;

                case "Histograma-Barras":
                    try
                    {
                        var (uniqueValues, valueCounts) = dtc.GetUniqueValuesAndCounts(dtc.CurrentData(flagCliente), columnName);
                        if (dtc.CurrentData(flagCliente).Columns[columnName].DataType == typeof(string) || columnName.Equals("numero_cargas"))
                        {
                            panelGrafico.BackgroundImage = gfc.generateBarPlot(uniqueValues,
                            valueCounts.Select(i => (double)i).ToArray(),
                            "Gráfico de Barras, para: " + columnName,
                            "Valores de: " + columnName,
                            "Conteeo de ocurrencias",
                            sizeInPixels);
                        }
                        else {
                            panelGrafico.BackgroundImage = gfc.generateHistPlot(
                                checkBox.Checked? dtc.RemoveOutliers( dtc.GetColumnAsDoubles(dtc.CurrentData(flagCliente), columnName)):
                                 dtc.GetColumnAsDoubles(dtc.CurrentData(flagCliente), columnName),
                            "Histograma, para: " + columnName,
                            "Valores de: " + columnName,
                            "Conteeo de ocurrencias",
                            sizeInPixels);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Error interno: " + e.Message);
                    }
                break;

                case "Scatter":
                    if (dtc.CurrentData(flagCliente).Columns[columnName].DataType != typeof(string) &&
                        dtc.CurrentData(flagCliente).Columns[columnNameY].DataType != typeof(string))
                    {

                        panelGrafico.BackgroundImage = gfc.generateScatterPlot(
                            checkBox.Checked ? dtc.RemoveOutliers(dtc.GetColumnAsDoubles(dtc.CurrentData(flagCliente), columnName)) :
                             dtc.GetColumnAsDoubles(dtc.CurrentData(flagCliente), columnName),
                            checkBox.Checked ? dtc.RemoveOutliers(dtc.GetColumnAsDoubles(dtc.CurrentData(flagCliente), columnNameY)) :
                                 dtc.GetColumnAsDoubles(dtc.CurrentData(flagCliente), columnNameY),
                            "Histograma, para: " + columnName + "-" + comboVariablesY,
                            "Valores de: " + columnName,
                            "Conteeo de: " + columnNameY,
                            sizeInPixels);
                    }
                    else
                    {
                        MessageBox.Show("Grafico solo disponible para ambas variables numéricas");
                    }
                    break;
            }
        }

        /// <summary>
        /// cambia el estado de los elementos interactuables
        /// </summary>
        /// <param name="flag"></param>
        private void enableBotones(bool flag) {
            this.Enabled = flag;
            buttonClientes.Enabled = flag;
            buttonPrestamos.Enabled = flag;
            comboVariablesX.Enabled = flag;
            buttonGraph.Enabled = flag;
            try
            {
                if (!comboTipoGrafico.SelectedItem.Equals("Histograma-Barras"))
                {
                    comboVariablesY.Enabled = flag;
                } else {
                    comboVariablesY.Enabled = false;
                }
            }
            catch {
                comboVariablesY.Enabled = false;
            }
        }



        /// <summary>
        /// Despliega datos de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClientes_Click(object sender, EventArgs e)
        {
            enableBotones(false);
            flagCliente = true;
            comboTipoGrafico.Enabled = false;
            principal.ejecutar(() =>
            {
                dataGrid.DataSource = dtc.getDatosClientes();
                dataGrid.Refresh();
                loadCombos();
            });
            enableBotones(true);
        }

        /// <summary>
        /// Despliega datos de prestamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrestamos_Click(object sender, EventArgs e)
        {
            enableBotones(false);
            flagCliente = false;
            comboTipoGrafico.Enabled = true;
            principal.ejecutar(() =>
            {
                dataGrid.DataSource = dtc.getDatosPrestamos();
                dataGrid.Refresh();
                loadCombos();
            });
            enableBotones(true);
        }

        /// <summary>
        /// Carga los graficos en un panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGraph_Click(object sender, EventArgs e)
        {
            enableBotones(false);
            principal.ejecutar(() =>
            {
                loadGraphs();
            });
            enableBotones(true);
        }

        /// <summary>
        /// Deshabilita la eleccion de otros variables en el grafico de Histograma-Barras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboVariablesY.Enabled = !comboTipoGrafico.SelectedItem.ToString().Equals("Histograma-Barras");
            labelEscoge.Visible = comboTipoGrafico.SelectedItem.ToString().Equals("Linea Temporal");
            if (labelEscoge.Visible) {
                comboVariablesX.SelectedItem = "fecha_corte";
                comboVariablesX.Enabled = false;
            }
        }
    }

}
