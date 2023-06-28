using System;
using ProyectoTitulacion.Vistas;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Controlador;

namespace ProyectoTitulacion
{
    /// <summary>
    /// Formulario de bienvenida
    /// </summary>
    public partial class Bienvenida : Form
    {
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public Bienvenida()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Importacion de librerias para mover las ventanas a traves de la pantalla
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("Gdi32.DLL", EntryPoint = "CreateRoundRectRgn")]
        private extern static IntPtr CreateRoundRectRgn(int v1, int v2, int width, int height, int v3, int v4);

        /// <summary>
        /// indicador de fin de programa
        /// </summary>
        private bool flag_exit = false;

        /// <summary>
        /// Ventana relacionada
        /// </summary>
        private Form principal;

        /// <summary>
        /// Cerrar Aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e) {
            flag_exit = true;
            timerOff.Start();
        }

        /// <summary>
        /// Minimizar aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMin_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Efecto para mover la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Efecto para mover la pantalla desde label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTittle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Efecto de aparicion y desvanecimiento
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
        /// detencion de efectos de transcicion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOff_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.05;
            if (Opacity == 0)
            {
                timerOff.Stop();
                if (flag_exit)
                {
                    Application.Exit();
                }
                else
                {
                    principal = new Principal();
                    principal.Show();
                    Hide();
                }
            }
        }

        /// <summary>
        /// Inicio de la vista principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInicio_Click(object sender, EventArgs e)
        {
            flag_exit = false;
            timerOff.Start();
            
        }

        private void labelTittle_Click(object sender, EventArgs e)
        {

        }
    }
}
