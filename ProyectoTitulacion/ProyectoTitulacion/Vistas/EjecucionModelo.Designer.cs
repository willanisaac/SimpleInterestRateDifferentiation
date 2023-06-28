
namespace ProyectoTitulacion.Vistas
{
    partial class EjecucionModelo
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
            this.buttonRestaurar = new System.Windows.Forms.Button();
            this.toolTipEjecutarModelo = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipRestaurarModelo = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCliente = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPrestamo = new System.Windows.Forms.ToolTip(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.nupTasaMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nupUmbral = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nupRaroc = new System.Windows.Forms.NumericUpDown();
            this.labelRelacion = new System.Windows.Forms.Label();
            this.labelTasa = new System.Windows.Forms.Label();
            this.nupTasaN = new System.Windows.Forms.NumericUpDown();
            this.buttonEjecutar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRegresion = new System.Windows.Forms.Button();
            this.labelPrestamos = new System.Windows.Forms.Label();
            this.labelClientes = new System.Windows.Forms.Label();
            this.buttonPrestamos = new System.Windows.Forms.Button();
            this.buttonClientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupTasaMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupUmbral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRaroc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTasaN)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRestaurar
            // 
            this.buttonRestaurar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonRestaurar.FlatAppearance.BorderSize = 0;
            this.buttonRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestaurar.ForeColor = System.Drawing.Color.White;
            this.buttonRestaurar.Location = new System.Drawing.Point(12, 579);
            this.buttonRestaurar.Name = "buttonRestaurar";
            this.buttonRestaurar.Size = new System.Drawing.Size(297, 59);
            this.buttonRestaurar.TabIndex = 10;
            this.buttonRestaurar.Text = "Restaurar Conocimiento";
            this.buttonRestaurar.UseVisualStyleBackColor = false;
            this.buttonRestaurar.Click += new System.EventHandler(this.buttonRestaurar_Click);
            // 
            // toolTipEjecutarModelo
            // 
            this.toolTipEjecutarModelo.AutomaticDelay = 1000;
            this.toolTipEjecutarModelo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.toolTipEjecutarModelo.ShowAlways = true;
            this.toolTipEjecutarModelo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTipRestaurarModelo
            // 
            this.toolTipRestaurarModelo.AutomaticDelay = 100;
            this.toolTipRestaurarModelo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.toolTipRestaurarModelo.ShowAlways = true;
            this.toolTipRestaurarModelo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTipCliente
            // 
            this.toolTipCliente.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTipPrestamo
            // 
            this.toolTipPrestamo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(591, 650);
            this.splitter1.TabIndex = 29;
            this.splitter1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(668, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(464, 31);
            this.label3.TabIndex = 50;
            this.label3.Text = "Parámetros de aplicación estadística.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupTasaMin
            // 
            this.nupTasaMin.DecimalPlaces = 2;
            this.nupTasaMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nupTasaMin.Location = new System.Drawing.Point(1033, 133);
            this.nupTasaMin.Name = "nupTasaMin";
            this.nupTasaMin.Size = new System.Drawing.Size(120, 20);
            this.nupTasaMin.TabIndex = 49;
            this.nupTasaMin.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.nupTasaMin.ValueChanged += new System.EventHandler(this.nupTasaMin_ValueChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(687, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 31);
            this.label2.TabIndex = 48;
            this.label2.Text = "Tasa de interés normativa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupUmbral
            // 
            this.nupUmbral.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nupUmbral.Location = new System.Drawing.Point(1033, 221);
            this.nupUmbral.Name = "nupUmbral";
            this.nupUmbral.Size = new System.Drawing.Size(120, 20);
            this.nupUmbral.TabIndex = 47;
            this.nupUmbral.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nupUmbral.ValueChanged += new System.EventHandler(this.nupUmbral_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(592, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 31);
            this.label1.TabIndex = 46;
            this.label1.Text = "Días de mora para incumplimiento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupRaroc
            // 
            this.nupRaroc.DecimalPlaces = 2;
            this.nupRaroc.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nupRaroc.Location = new System.Drawing.Point(1033, 178);
            this.nupRaroc.Name = "nupRaroc";
            this.nupRaroc.Size = new System.Drawing.Size(120, 20);
            this.nupRaroc.TabIndex = 45;
            this.nupRaroc.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nupRaroc.ValueChanged += new System.EventHandler(this.nupRaroc_ValueChanged_1);
            // 
            // labelRelacion
            // 
            this.labelRelacion.AutoSize = true;
            this.labelRelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRelacion.Location = new System.Drawing.Point(668, 165);
            this.labelRelacion.Name = "labelRelacion";
            this.labelRelacion.Size = new System.Drawing.Size(343, 31);
            this.labelRelacion.TabIndex = 44;
            this.labelRelacion.Text = "Relación de ajuste RAROC";
            this.labelRelacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTasa
            // 
            this.labelTasa.AutoSize = true;
            this.labelTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTasa.Location = new System.Drawing.Point(717, 122);
            this.labelTasa.Name = "labelTasa";
            this.labelTasa.Size = new System.Drawing.Size(294, 31);
            this.labelTasa.TabIndex = 43;
            this.labelTasa.Text = "Tasa de interés minima";
            this.labelTasa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupTasaN
            // 
            this.nupTasaN.DecimalPlaces = 2;
            this.nupTasaN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nupTasaN.Location = new System.Drawing.Point(1033, 93);
            this.nupTasaN.Name = "nupTasaN";
            this.nupTasaN.Size = new System.Drawing.Size(120, 20);
            this.nupTasaN.TabIndex = 42;
            this.nupTasaN.Value = new decimal(new int[] {
            1606,
            0,
            0,
            131072});
            this.nupTasaN.ValueChanged += new System.EventHandler(this.nupTasaN_ValueChanged_1);
            // 
            // buttonEjecutar
            // 
            this.buttonEjecutar.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonEjecutar.FlatAppearance.BorderSize = 0;
            this.buttonEjecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonEjecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEjecutar.ForeColor = System.Drawing.Color.White;
            this.buttonEjecutar.Location = new System.Drawing.Point(674, 353);
            this.buttonEjecutar.Name = "buttonEjecutar";
            this.buttonEjecutar.Size = new System.Drawing.Size(420, 50);
            this.buttonEjecutar.TabIndex = 41;
            this.buttonEjecutar.Text = "Ajustar parametros aplicación estadística";
            this.buttonEjecutar.UseVisualStyleBackColor = false;
            this.buttonEjecutar.Click += new System.EventHandler(this.buttonEjecutar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(581, 62);
            this.label4.TabIndex = 56;
            this.label4.Text = "    Entrenamiento de Regresión Logistica para\r\npredicción de la probabilidad de i" +
    "ncumplimiento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRegresion
            // 
            this.buttonRegresion.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRegresion.FlatAppearance.BorderSize = 0;
            this.buttonRegresion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonRegresion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonRegresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegresion.ForeColor = System.Drawing.Color.White;
            this.buttonRegresion.Location = new System.Drawing.Point(96, 353);
            this.buttonRegresion.Name = "buttonRegresion";
            this.buttonRegresion.Size = new System.Drawing.Size(357, 50);
            this.buttonRegresion.TabIndex = 55;
            this.buttonRegresion.Text = "Entrenar Regresión Logistica PD";
            this.buttonRegresion.UseVisualStyleBackColor = false;
            this.buttonRegresion.Click += new System.EventHandler(this.buttonRegresion_Click_1);
            // 
            // labelPrestamos
            // 
            this.labelPrestamos.AutoSize = true;
            this.labelPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrestamos.Location = new System.Drawing.Point(437, 189);
            this.labelPrestamos.Name = "labelPrestamos";
            this.labelPrestamos.Size = new System.Drawing.Size(49, 31);
            this.labelPrestamos.TabIndex = 54;
            this.labelPrestamos.Text = "Ok";
            this.labelPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPrestamos.Visible = false;
            // 
            // labelClientes
            // 
            this.labelClientes.AutoSize = true;
            this.labelClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientes.Location = new System.Drawing.Point(437, 133);
            this.labelClientes.Name = "labelClientes";
            this.labelClientes.Size = new System.Drawing.Size(49, 31);
            this.labelClientes.TabIndex = 53;
            this.labelClientes.Text = "Ok";
            this.labelClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelClientes.Visible = false;
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
            this.buttonPrestamos.Location = new System.Drawing.Point(134, 189);
            this.buttonPrestamos.Name = "buttonPrestamos";
            this.buttonPrestamos.Size = new System.Drawing.Size(297, 50);
            this.buttonPrestamos.TabIndex = 52;
            this.buttonPrestamos.Text = "Cargar datos de Prestamos";
            this.buttonPrestamos.UseVisualStyleBackColor = false;
            this.buttonPrestamos.Click += new System.EventHandler(this.buttonPrestamos_Click_1);
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
            this.buttonClientes.Location = new System.Drawing.Point(134, 133);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(297, 50);
            this.buttonClientes.TabIndex = 51;
            this.buttonClientes.Text = "Cargar datos de Clientes";
            this.buttonClientes.UseVisualStyleBackColor = false;
            this.buttonClientes.Click += new System.EventHandler(this.buttonClientes_Click_1);
            // 
            // EjecucionModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 650);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonRegresion);
            this.Controls.Add(this.labelPrestamos);
            this.Controls.Add(this.labelClientes);
            this.Controls.Add(this.buttonPrestamos);
            this.Controls.Add(this.buttonClientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nupTasaMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nupUmbral);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nupRaroc);
            this.Controls.Add(this.labelRelacion);
            this.Controls.Add(this.labelTasa);
            this.Controls.Add(this.nupTasaN);
            this.Controls.Add(this.buttonEjecutar);
            this.Controls.Add(this.buttonRestaurar);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EjecucionModelo";
            this.Text = "CargarNuevosDatos";
            ((System.ComponentModel.ISupportInitialize)(this.nupTasaMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupUmbral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRaroc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTasaN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRestaurar;
        private System.Windows.Forms.ToolTip toolTipEjecutarModelo;
        private System.Windows.Forms.ToolTip toolTipRestaurarModelo;
        private System.Windows.Forms.ToolTip toolTipCliente;
        private System.Windows.Forms.ToolTip toolTipPrestamo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupTasaMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupUmbral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupRaroc;
        private System.Windows.Forms.Label labelRelacion;
        private System.Windows.Forms.Label labelTasa;
        private System.Windows.Forms.NumericUpDown nupTasaN;
        private System.Windows.Forms.Button buttonEjecutar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRegresion;
        private System.Windows.Forms.Label labelPrestamos;
        private System.Windows.Forms.Label labelClientes;
        private System.Windows.Forms.Button buttonPrestamos;
        private System.Windows.Forms.Button buttonClientes;
    }
}