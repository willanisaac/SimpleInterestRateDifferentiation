
namespace ProyectoTitulacion.Vistas
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonModelo = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.buttonData = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.pictureFondo = new System.Windows.Forms.PictureBox();
            this.labelCarga = new System.Windows.Forms.Label();
            this.timerOff = new System.Windows.Forms.Timer(this.components);
            this.timerOn = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelMenu.Controls.Add(this.buttonModelo);
            this.panelMenu.Controls.Add(this.buttonResult);
            this.panelMenu.Controls.Add(this.buttonLoadData);
            this.panelMenu.Controls.Add(this.buttonData);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(154, 649);
            this.panelMenu.TabIndex = 8;
            // 
            // buttonModelo
            // 
            this.buttonModelo.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonModelo.FlatAppearance.BorderSize = 0;
            this.buttonModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModelo.ForeColor = System.Drawing.Color.White;
            this.buttonModelo.Location = new System.Drawing.Point(3, 160);
            this.buttonModelo.Name = "buttonModelo";
            this.buttonModelo.Size = new System.Drawing.Size(149, 54);
            this.buttonModelo.TabIndex = 6;
            this.buttonModelo.Text = "Ajuste de Parametros para ";
            this.buttonModelo.UseVisualStyleBackColor = false;
            this.buttonModelo.Click += new System.EventHandler(this.buttonModelo_Click);
            // 
            // buttonResult
            // 
            this.buttonResult.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonResult.FlatAppearance.BorderSize = 0;
            this.buttonResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResult.ForeColor = System.Drawing.Color.White;
            this.buttonResult.Location = new System.Drawing.Point(2, 239);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(149, 54);
            this.buttonResult.TabIndex = 5;
            this.buttonResult.Text = "Ajuste de tasas de interés";
            this.buttonResult.UseVisualStyleBackColor = false;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonLoadData.FlatAppearance.BorderSize = 0;
            this.buttonLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadData.ForeColor = System.Drawing.Color.White;
            this.buttonLoadData.Location = new System.Drawing.Point(3, 81);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(152, 54);
            this.buttonLoadData.TabIndex = 4;
            this.buttonLoadData.Text = "Cargar nuevos Datos";
            this.buttonLoadData.UseVisualStyleBackColor = false;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // buttonData
            // 
            this.buttonData.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonData.FlatAppearance.BorderSize = 0;
            this.buttonData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonData.ForeColor = System.Drawing.Color.White;
            this.buttonData.Location = new System.Drawing.Point(3, 12);
            this.buttonData.Name = "buttonData";
            this.buttonData.Size = new System.Drawing.Size(151, 54);
            this.buttonData.TabIndex = 2;
            this.buttonData.Text = "Variables de Entrada";
            this.buttonData.UseVisualStyleBackColor = false;
            this.buttonData.Click += new System.EventHandler(this.buttonData_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Controls.Add(this.pictureFondo);
            this.panelContenedor.Controls.Add(this.labelCarga);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContenedor.Location = new System.Drawing.Point(154, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1190, 650);
            this.panelContenedor.TabIndex = 9;
            // 
            // pictureFondo
            // 
            this.pictureFondo.Image = ((System.Drawing.Image)(resources.GetObject("pictureFondo.Image")));
            this.pictureFondo.Location = new System.Drawing.Point(213, 43);
            this.pictureFondo.Name = "pictureFondo";
            this.pictureFondo.Size = new System.Drawing.Size(708, 483);
            this.pictureFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureFondo.TabIndex = 10;
            this.pictureFondo.TabStop = false;
            // 
            // labelCarga
            // 
            this.labelCarga.AutoSize = true;
            this.labelCarga.BackColor = System.Drawing.Color.White;
            this.labelCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.labelCarga.ForeColor = System.Drawing.Color.Black;
            this.labelCarga.Location = new System.Drawing.Point(292, 198);
            this.labelCarga.Name = "labelCarga";
            this.labelCarga.Size = new System.Drawing.Size(505, 78);
            this.labelCarga.TabIndex = 9;
            this.labelCarga.Text = "Procesando [...]";
            this.labelCarga.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCarga.Visible = false;
            this.labelCarga.VisibleChanged += new System.EventHandler(this.labelCarga_VisibleChanged);
            // 
            // timerOff
            // 
            this.timerOff.Interval = 10;
            this.timerOff.Tick += new System.EventHandler(this.timerOff_Tick);
            // 
            // timerOn
            // 
            this.timerOn.Interval = 10;
            this.timerOn.Tick += new System.EventHandler(this.timerOn_Tick);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 649);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de diferenciación de tasas de interés ajustadas al nivel de riesgo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.panelMenu.ResumeLayout(false);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonModelo;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Button buttonData;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Timer timerOff;
        private System.Windows.Forms.Timer timerOn;
        private System.Windows.Forms.Label labelCarga;
        private System.Windows.Forms.PictureBox pictureFondo;
    }
}