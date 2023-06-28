
namespace ProyectoTitulacion.Vistas
{
    partial class CargarNuevosDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarNuevosDatos));
            this.buttonPrestamos = new System.Windows.Forms.Button();
            this.buttonClientes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureFondo = new System.Windows.Forms.PictureBox();
            this.toolTipcliente = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPrestamos = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPrestamos
            // 
            this.buttonPrestamos.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonPrestamos.FlatAppearance.BorderSize = 0;
            this.buttonPrestamos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonPrestamos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrestamos.ForeColor = System.Drawing.Color.White;
            this.buttonPrestamos.Location = new System.Drawing.Point(12, 68);
            this.buttonPrestamos.Name = "buttonPrestamos";
            this.buttonPrestamos.Size = new System.Drawing.Size(297, 50);
            this.buttonPrestamos.TabIndex = 11;
            this.buttonPrestamos.Text = "Cargar datos de Prestamos";
            this.buttonPrestamos.UseVisualStyleBackColor = false;
            this.buttonPrestamos.Click += new System.EventHandler(this.buttonPrestamos_Click);
            // 
            // buttonClientes
            // 
            this.buttonClientes.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonClientes.FlatAppearance.BorderSize = 0;
            this.buttonClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClientes.ForeColor = System.Drawing.Color.White;
            this.buttonClientes.Location = new System.Drawing.Point(12, 12);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(297, 50);
            this.buttonClientes.TabIndex = 10;
            this.buttonClientes.Text = "Cargar datos de Clientes";
            this.buttonClientes.UseVisualStyleBackColor = false;
            this.buttonClientes.Click += new System.EventHandler(this.buttonClientes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(349, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(829, 124);
            this.label4.TabIndex = 23;
            this.label4.Text = "Seleccione un archivo csv o excel con los datos primero de clientes \r\ny luego de " +
    "prestamos para caluclar las tasas de interes ajustadas.\r\n\r\nLos datos deben tener" +
    " la siguiente estructura";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureFondo
            // 
            this.pictureFondo.Image = ((System.Drawing.Image)(resources.GetObject("pictureFondo.Image")));
            this.pictureFondo.Location = new System.Drawing.Point(12, 209);
            this.pictureFondo.Name = "pictureFondo";
            this.pictureFondo.Size = new System.Drawing.Size(1115, 429);
            this.pictureFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureFondo.TabIndex = 24;
            this.pictureFondo.TabStop = false;
            // 
            // toolTipcliente
            // 
            this.toolTipcliente.ShowAlways = true;
            this.toolTipcliente.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTipPrestamos
            // 
            this.toolTipPrestamos.ShowAlways = true;
            this.toolTipPrestamos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(12, 153);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(297, 50);
            this.buttonDelete.TabIndex = 25;
            this.buttonDelete.Text = "Eliminar Datos";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // CargarNuevosDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 650);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.pictureFondo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonPrestamos);
            this.Controls.Add(this.buttonClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargarNuevosDatos";
            this.Text = "CargarNuevosDatos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureFondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrestamos;
        private System.Windows.Forms.Button buttonClientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureFondo;
        private System.Windows.Forms.ToolTip toolTipcliente;
        private System.Windows.Forms.ToolTip toolTipPrestamos;
        private System.Windows.Forms.Button buttonDelete;
    }
}