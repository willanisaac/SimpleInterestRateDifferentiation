using System;
using System.IO;
using Python.Runtime;
using System.Drawing;
using System.Linq;
using System.Diagnostics;

namespace Controlador
{
    /// <summary>
    /// Clase de gestion  de graficos con interoperabilidad de Python
    /// </summary>
    public class GraphContoller : PythonContoller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public GraphContoller() : base() { }

        /// <summary>
        /// Dibuja un grafico de lineas dadas las coordenadas
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        /// <param name="labels"></param>
        /// <param name="size"></param>
        /// <returns>Bitmap a ser insertado en un panel</returns>
        public Bitmap generatePlotDouble(double[] x, double[] y, string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80)
        {
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                // Importa la librería matplotlib.pyplot de Python
                dynamic plt = Py.Import("matplotlib.pyplot");

                // Calcula el tamaño del gráfico en pulgadas
                double widthInInches = sizeInPixels.Item1 / (double)dpi;
                double heightInInches = sizeInPixels.Item2 / (double)dpi;

                // Establece el tamaño del gráfico en pulgadas y el dpi
                plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);

                // Genera el gráfico deseado y lo guarda en una variable
                dynamic plot = plt.plot(x, y );

                // Agrega un título al gráfico
                plt.title(title);

                // Agrega descripciones a los ejes X e Y
                plt.xlabel(labelX);
                plt.ylabel(labelY);

                // Agrega la leyenda a la parte superior del gráfico
                plt.legend(loc: "upper center");

                // Guarda el gráfico en un archivo temporal
                string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                plt.savefig(tempFileName);

                // Carga el archivo en un objeto Bitmap y lo retorna
                return new Bitmap(tempFileName);
            }
        }

        /// <summary>
        /// Dibuja un grafico de lineas en linea temporal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        /// <param name="labels"></param>
        /// <param name="size"></param>
        /// <returns>Bitmap a ser insertado en un panel</returns>
        public Bitmap generatePlotString(string[] x, double[] y, string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80)
        {
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                // Importa la librería matplotlib.pyplot de Python
                dynamic plt = Py.Import("matplotlib.pyplot");

                // Calcula el tamaño del gráfico en pulgadas
                double widthInInches = sizeInPixels.Item1 / (double)dpi;
                double heightInInches = sizeInPixels.Item2 / (double)dpi;

                // Establece el tamaño del gráfico en pulgadas y el dpi
                plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);

                // Genera el gráfico deseado y lo guarda en una variable
                dynamic plot = plt.plot(x, y);

                // Agrega un título al gráfico
                plt.title(title, fontsize: "xx-large");

                // Hace que las etiquetas de la parte inferior sean verticales
                plt.xticks(rotation: 90);

                // Si el tamaño de 'x' es mayor a 50, omite algunos xticks
                if (x.Length > 30)
                {
                    int step = x.Length / 30;
                    var indices = Enumerable.Range(0, x.Length).Where(index => index % step == 0).ToArray();
                    plt.xticks(indices, x.Where((_, index) => index % step == 0).ToArray());
                }

                  // Agrega descripciones a los ejes X e Y
                plt.xlabel(labelX, fontsize: "xx-large");
                plt.ylabel(labelY, fontsize: "xx-large");

                // Agrega la leyenda a la parte superior del gráfico
                plt.legend(loc: "upper center");

                // Guarda el gráfico en un archivo temporal
                string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                plt.savefig(tempFileName);

                // Carga el archivo en un objeto Bitmap y lo retorna
                return new Bitmap(tempFileName);
            }
        }

        /// <summary>
        /// Dibuja un grafico de barras
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        /// <param name="labels"></param>
        /// <param name="sizeInPixels"></param>
        /// <param name="dpi"></param>
        /// <returns>Bitmap a ser insertado en un panel</returns>
        public Bitmap generateBarPlot(string[] x, double[] y, string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80)
        {
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                // Importa la librería matplotlib.pyplot de Python
                dynamic plt = Py.Import("matplotlib.pyplot");

                // Calcula el tamaño del gráfico en pulgadas
                double widthInInches = sizeInPixels.Item1 / (double)dpi;
                double heightInInches = sizeInPixels.Item2 / (double)dpi;

                // Establece el tamaño del gráfico en pulgadas y el dpi
                plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);

                // Genera el gráfico de barras deseado y lo guarda en una variable
                dynamic plot = plt.bar(x, y);

                // Agrega un título al gráfico
                plt.title(title, fontsize: "xx-large");

                // Agrega descripciones a los ejes X e Y
                plt.xlabel(labelX, fontsize: "xx-large");
                plt.ylabel(labelY, fontsize: "xx-large");

                // Hace que las etiquetas de la parte inferior sean verticales
                plt.xticks(rotation: 90);
                
                // Si el tamaño de 'x' es mayor a 50, omite algunos xticks
                if (x.Length > 30)
                {
                    int step = x.Length / 30;
                    var indices = Enumerable.Range(0, x.Length).Where(index => index % step == 0).ToArray();
                    plt.xticks(indices, x.Where((_, index) => index % step == 0).ToArray());
                }

                // Ajusta automáticamente el diseño del gráfico
                plt.tight_layout();

                // Guarda el gráfico en un archivo temporal
                string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                plt.savefig(tempFileName);

                // Carga el archivo en un objeto Bitmap y lo retorna
                return new Bitmap(tempFileName);
            }
        }

        /// <summary>
        /// Dibuja un grafico de barras
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        /// <param name="labels"></param>
        /// <param name="sizeInPixels"></param>
        /// <param name="dpi"></param>
        /// <returns>Bitmap a ser insertado en un panel</returns>
        public Bitmap generateHistPlot(double[] y, string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80)
        {
            try
            {
                PythonEngine.Initialize();
                using (Py.GIL())
                {
                    // Importa la librería matplotlib.pyplot de Python
                    dynamic plt = Py.Import("matplotlib.pyplot");

                    // Calcula el tamaño del gráfico en pulgadas
                    double widthInInches = sizeInPixels.Item1 / (double)dpi;
                    double heightInInches = sizeInPixels.Item2 / (double)dpi;

                    // Establece el tamaño del gráfico en pulgadas y el dpi
                    plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);

                    // Genera el gráfico de barras deseado y lo guarda en una variable
                    dynamic plot = plt.hist(y, bins: 50);

                    // Agrega un título al gráfico
                    plt.title(title, fontsize: "xx-large");

                    // Agrega descripciones a los ejes X e Y
                    plt.xlabel(labelX, fontsize: "xx-large");
                    plt.ylabel(labelY, fontsize: "xx-large");

                    // Hace que las etiquetas de la parte inferior sean verticales
                    plt.xticks(rotation: 90);


                    // Ajusta automáticamente el diseño del gráfico
                    plt.tight_layout();

                    // Guarda el gráfico en un archivo temporal
                    string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                    plt.savefig(tempFileName);

                    // Carga el archivo en un objeto Bitmap y lo retorna
                    return new Bitmap(tempFileName);
                }
            }
            catch (PythonException e)
            {
                Debug.WriteLine("Error: " + e.Message);
                throw e;
            }
            finally {
                PythonEngine.Shutdown();
            }
        }

        /// <summary>
        /// Dibuja un grafico de dispersion
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        /// <param name="labels"></param>
        /// <param name="sizeInPixels"></param>
        /// <param name="dpi"></param>
        /// <returns></returns>
        public Bitmap generateScatterPlot(double[] x, double[] y, string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80)
        {
            try
            {
                PythonEngine.Initialize();
                using (Py.GIL())
                {
                    // Importa la librería matplotlib.pyplot de Python
                    dynamic plt = Py.Import("matplotlib.pyplot");

                    // Calcula el tamaño del gráfico en pulgadas
                    double widthInInches = sizeInPixels.Item1 / (double)dpi;
                    double heightInInches = sizeInPixels.Item2 / (double)dpi;

                    // Establece el tamaño del gráfico en pulgadas y el dpi
                    plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);

                    // Genera el gráfico scatter deseado y lo guarda en una variable
                    dynamic plot = plt.scatter(x, y);

                    // Agrega un título al gráfico
                    plt.title(title, fontsize: "xx-large");

                    // Agrega descripciones a los ejes X e Y
                    plt.xlabel(labelX, fontsize: "xx-large");
                    plt.ylabel(labelY, fontsize: "xx-large");

                    // Ajusta automáticamente el diseño del gráfico
                    plt.tight_layout();

                    // Guarda el gráfico en un archivo temporal
                    string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                    plt.savefig(tempFileName);

                    // Carga el archivo en un objeto Bitmap y lo retorna
                    return new Bitmap(tempFileName);
                }
            
            }
            catch (PythonException e)
            {
                Debug.WriteLine("Se produjo un error de Python:");
                Debug.WriteLine($"Error: {e.Message}");
                Debug.WriteLine($"Tipo de excepción de Python: {e.Type}");
                return null;
            }
            finally
            {
                PythonEngine.Shutdown();
            }
        }

        /// <summary>
        /// Grafica una distribucion normal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="dots"></param>
        /// <param name="title"></param>
        /// <param name="labelX"></param>
        /// <param name="labelY"></param>
        /// <param name="sizeInPixels"></param>
        /// <param name="dpi"></param>
        /// <returns></returns>
        public Bitmap generateNormalDistribution(double[] x,  double[] dots ,string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80)
        {
            try
            {
                Array.Sort(x);
                Array.Sort(dots);
                PythonEngine.Initialize();
                using (Py.GIL())
                {
                    dynamic np = Py.Import("numpy");
                    dynamic plt = Py.Import("matplotlib.pyplot");
                    dynamic scipy = Py.Import("scipy.stats");
                    double widthInInches = sizeInPixels.Item1 / (double)dpi;
                    double heightInInches = sizeInPixels.Item2 / (double)dpi;
                    plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);
                    dynamic serie = np.array(x);
                    dynamic dotsSeries = np.array(dots);
                    plt.fill_between(serie, scipy.norm.pdf(serie, np.mean(serie), np.std(serie)), color: "skyblue");
                    plt.plot(dotsSeries, scipy.norm.pdf(dotsSeries, np.mean(serie), np.std(serie)), "ro");
                    plt.xlabel(labelX, fontsize: "xx-large");
                    plt.ylabel(labelY, fontsize: "xx-large");
                    plt.title(title, fontsize: "xx-large");
                    string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                    plt.savefig(tempFileName);
                    return new Bitmap(tempFileName);
                }
            }
            catch (PythonException e)
            {
                Debug.WriteLine("Se produjo un error de Python:");
                Debug.WriteLine($"Error: {e.Message}");
                Debug.WriteLine($"Tipo de excepción de Python: {e.Type}");
                return null;
            }
            finally
            {
                PythonEngine.Shutdown();
            }
        }

        /// <summary>
        /// Genera una grafico de lineas ordinal simple
        /// </summary>
        /// <param name="x"></param>
        /// <param name="dots"></param>
        /// <param name="title"></param>
        /// <param name="labelX"></param>
        /// <param name="labelY"></param>
        /// <param name="sizeInPixels"></param>
        /// <param name="dpi"></param>
        /// <returns></returns>
        public Bitmap generateSimpleLinePlotOrdinal(double[] x, double[] dots, string title, string labelX, string labelY, Tuple<int, int> sizeInPixels, int dpi = 80) {
            try
            {
                Array.Sort(x);
                Array.Sort(dots);
                PythonEngine.Initialize();
                using (Py.GIL())
                {
                    dynamic py = Py.Import("builtins");
                    dynamic np = Py.Import("numpy");
                    dynamic plt = Py.Import("matplotlib.pyplot");
                    double widthInInches = sizeInPixels.Item1 / (double)dpi;
                    double heightInInches = sizeInPixels.Item2 / (double)dpi;
                    plt.figure(figsize: new PyTuple(new PyObject[] { new PyFloat(widthInInches), new PyFloat(heightInInches) }), dpi: dpi);
                    dynamic serie = np.array(x);
                    dynamic dotsSeries = np.array(dots);
                    plt.plot(py.range(py.len(serie)), serie);
                    plt.plot(py.range(py.len(dotsSeries)), dotsSeries, "ro");
                    plt.xlabel(labelX, fontsize: "xx-large");
                    plt.ylabel(labelY, fontsize: "xx-large");
                    plt.title(title, fontsize: "xx-large");
                    string tempFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
                    plt.savefig(tempFileName);
                    return new Bitmap(tempFileName);

                }
            }
            catch (PythonException e)
            {
                Debug.WriteLine("Se produjo un error de Python:");
                Debug.WriteLine($"Error: {e.Message}");
                Debug.WriteLine($"Tipo de excepción de Python: {e.Type}");
                return null;
            }
            finally
            {
                PythonEngine.Shutdown();
            }
        }
    
    }
}
