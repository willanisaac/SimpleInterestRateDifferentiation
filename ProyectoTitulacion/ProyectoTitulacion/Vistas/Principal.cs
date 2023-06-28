using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTitulacion.Vistas
{
    /// <summary>
    /// Formulario principal
    /// </summary>
    public partial class Principal : Form
    {

        #region Propiedades
        /// <summary>
        /// variable de formulario
        /// </summary>
        private Form formGenerico;
        #endregion

        #region Funciones
        /// <summary>
        /// Inicializador
        /// </summary>
        public Principal()
        {
            InitializeComponent();
            Opacity = 0;
            timerOn.Start();
    }

        /// <summary>
        /// Aparicion de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOn_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += 0.05;
            }
            if (Opacity == 1)
            {
                timerOn.Stop();
            }
        }

        /// <summary>
        /// Desvanecimiento de la venatana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOff_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.05;
            if (Opacity == 0)
            {
                timerOff.Stop();
                Application.Exit();
            }
        }

        /// <summary>
        /// Cierra la aplicación al cerrar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }        

        /// <summary>
        /// Muestra label de carga
        /// </summary>
        public void ejecutar(Action action) {
            labelCarga.Visible = true;
            Refresh();
            action();
            labelCarga.Visible = false;
            Refresh();
        }

        /// <summary>
        /// Muestra label de carga con un codigo especfico
        /// </summary>
        public void ejecutar(string title, Action action)
        {
            string preview = labelCarga.Text;
            labelCarga.Text = title;
            labelCarga.Visible = true;
            Refresh();
            action();
            labelCarga.Visible = false;
            labelCarga.Text = preview;
            Refresh();
        }

        /// <summary>
        /// Reseta colores
        /// </summary>
        private void resetColor() {
            buttonData.BackColor = panelMenu.BackColor;
            buttonLoadData.BackColor = panelMenu.BackColor;
            buttonModelo.BackColor = panelMenu.BackColor;
            buttonResult.BackColor = panelMenu.BackColor;
        }
        #endregion

        /// <summary>
        /// Despliega una ventana para mostrar los datos de forma matricial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonData_Click(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor != Color.Green)
            {
                resetColor();
                (sender as Button).BackColor = Color.Green;
                labelCarga.Visible = true;
                formGenerico?.Dispose();
                formGenerico = new DespliegueDatos(this)
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formGenerico);
                formGenerico.Show();
                labelCarga.Visible = false;
            }
        }

        /// <summary>
        /// Carga un el formulario de carga de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor != Color.Green)
            {
                resetColor();
                (sender as Button).BackColor = Color.Green;
                labelCarga.Visible = true;
                formGenerico?.Dispose();
                formGenerico = new CargarNuevosDatos(this)
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formGenerico);
                formGenerico.Show();
                labelCarga.Visible = false;
            }
        }

        /// <summary>
        /// Carga el formulario del modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModelo_Click(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor != Color.Green)
            {
                resetColor();
                (sender as Button).BackColor = Color.Green;
                labelCarga.Visible = true;
                formGenerico?.Dispose();
                formGenerico = new EjecucionModelo(this)
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formGenerico);
                formGenerico.Show();
                labelCarga.Visible = false;
            }
        }

        private void labelCarga_VisibleChanged(object sender, EventArgs e)
        {
            pictureFondo.Visible = false;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor != Color.Green)
            {
                resetColor();
                (sender as Button).BackColor = Color.Green;
                labelCarga.Visible = true;
                formGenerico?.Dispose();
                formGenerico = new MostrarGraficos(this)
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formGenerico);
                formGenerico.Show();
                labelCarga.Visible = false;
            }
        }
    }
}
