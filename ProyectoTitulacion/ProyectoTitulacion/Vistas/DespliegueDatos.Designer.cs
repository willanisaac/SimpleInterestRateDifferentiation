
namespace ProyectoTitulacion.Vistas
{
    partial class DespliegueDatos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.buttonClientes = new System.Windows.Forms.Button();
            this.buttonPrestamos = new System.Windows.Forms.Button();
            this.comboTipoGrafico = new System.Windows.Forms.ComboBox();
            this.comboVariablesX = new System.Windows.Forms.ComboBox();
            this.labelTipoGraficos = new System.Windows.Forms.Label();
            this.labelVariables = new System.Windows.Forms.Label();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboVariablesY = new System.Windows.Forms.ComboBox();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.labelGraficar = new System.Windows.Forms.Label();
            this.labelDatos = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.labelEscoge = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.GridColor = System.Drawing.SystemColors.Highlight;
            this.dataGrid.Location = new System.Drawing.Point(12, 58);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(496, 582);
            this.dataGrid.TabIndex = 5;
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
            this.buttonClientes.Location = new System.Drawing.Point(12, 2);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(245, 50);
            this.buttonClientes.TabIndex = 8;
            this.buttonClientes.Text = "Datos de Clientes";
            this.buttonClientes.UseVisualStyleBackColor = false;
            this.buttonClientes.Click += new System.EventHandler(this.buttonClientes_Click);
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
            this.buttonPrestamos.Location = new System.Drawing.Point(263, 2);
            this.buttonPrestamos.Name = "buttonPrestamos";
            this.buttonPrestamos.Size = new System.Drawing.Size(245, 50);
            this.buttonPrestamos.TabIndex = 9;
            this.buttonPrestamos.Text = "Datos de Prestamos";
            this.buttonPrestamos.UseVisualStyleBackColor = false;
            this.buttonPrestamos.Click += new System.EventHandler(this.buttonPrestamos_Click);
            // 
            // comboTipoGrafico
            // 
            this.comboTipoGrafico.Enabled = false;
            this.comboTipoGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.comboTipoGrafico.FormattingEnabled = true;
            this.comboTipoGrafico.Location = new System.Drawing.Point(514, 41);
            this.comboTipoGrafico.Name = "comboTipoGrafico";
            this.comboTipoGrafico.Size = new System.Drawing.Size(215, 33);
            this.comboTipoGrafico.TabIndex = 10;
            this.comboTipoGrafico.SelectedIndexChanged += new System.EventHandler(this.comboTipoGrafico_SelectedIndexChanged);
            // 
            // comboVariablesX
            // 
            this.comboVariablesX.Enabled = false;
            this.comboVariablesX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.comboVariablesX.FormattingEnabled = true;
            this.comboVariablesX.Location = new System.Drawing.Point(767, 80);
            this.comboVariablesX.Name = "comboVariablesX";
            this.comboVariablesX.Size = new System.Drawing.Size(217, 33);
            this.comboVariablesX.TabIndex = 11;
            // 
            // labelTipoGraficos
            // 
            this.labelTipoGraficos.AutoSize = true;
            this.labelTipoGraficos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoGraficos.Location = new System.Drawing.Point(508, 9);
            this.labelTipoGraficos.Name = "labelTipoGraficos";
            this.labelTipoGraficos.Size = new System.Drawing.Size(193, 31);
            this.labelTipoGraficos.TabIndex = 12;
            this.labelTipoGraficos.Text = "Tipo de gráfico";
            this.labelTipoGraficos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVariables
            // 
            this.labelVariables.AutoSize = true;
            this.labelVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVariables.Location = new System.Drawing.Point(736, 9);
            this.labelVariables.Name = "labelVariables";
            this.labelVariables.Size = new System.Drawing.Size(127, 31);
            this.labelVariables.TabIndex = 13;
            this.labelVariables.Text = "Variables";
            this.labelVariables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGrafico
            // 
            this.panelGrafico.Location = new System.Drawing.Point(514, 132);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Size = new System.Drawing.Size(664, 508);
            this.panelGrafico.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(729, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(729, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboVariablesY
            // 
            this.comboVariablesY.Enabled = false;
            this.comboVariablesY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.comboVariablesY.FormattingEnabled = true;
            this.comboVariablesY.Location = new System.Drawing.Point(767, 41);
            this.comboVariablesY.Name = "comboVariablesY";
            this.comboVariablesY.Size = new System.Drawing.Size(217, 33);
            this.comboVariablesY.TabIndex = 17;
            // 
            // buttonGraph
            // 
            this.buttonGraph.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonGraph.Enabled = false;
            this.buttonGraph.FlatAppearance.BorderSize = 0;
            this.buttonGraph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonGraph.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGraph.ForeColor = System.Drawing.Color.White;
            this.buttonGraph.Location = new System.Drawing.Point(998, 84);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(180, 31);
            this.buttonGraph.TabIndex = 18;
            this.buttonGraph.Text = "Graficar";
            this.buttonGraph.UseVisualStyleBackColor = false;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // labelGraficar
            // 
            this.labelGraficar.AutoSize = true;
            this.labelGraficar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelGraficar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGraficar.Location = new System.Drawing.Point(999, 36);
            this.labelGraficar.Name = "labelGraficar";
            this.labelGraficar.Size = new System.Drawing.Size(180, 40);
            this.labelGraficar.TabIndex = 19;
            this.labelGraficar.Text = "Presione para\r\nactualizar el gráfico ↓";
            this.labelGraficar.Visible = false;
            // 
            // labelDatos
            // 
            this.labelDatos.AutoSize = true;
            this.labelDatos.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatos.ForeColor = System.Drawing.Color.White;
            this.labelDatos.Location = new System.Drawing.Point(26, 67);
            this.labelDatos.Name = "labelDatos";
            this.labelDatos.Size = new System.Drawing.Size(460, 31);
            this.labelDatos.TabIndex = 20;
            this.labelDatos.Text = "↑ Seleccione los datos a mostrar ↑";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.Location = new System.Drawing.Point(514, 84);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(167, 20);
            this.checkBox.TabIndex = 21;
            this.checkBox.Text = "Sin Valores Atipicos";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // labelEscoge
            // 
            this.labelEscoge.AutoSize = true;
            this.labelEscoge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEscoge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscoge.Location = new System.Drawing.Point(517, 107);
            this.labelEscoge.Name = "labelEscoge";
            this.labelEscoge.Size = new System.Drawing.Size(180, 20);
            this.labelEscoge.TabIndex = 22;
            this.labelEscoge.Text = "← escoge un registro";
            this.labelEscoge.Visible = false;
            // 
            // DespliegueDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 650);
            this.Controls.Add(this.labelEscoge);
            this.Controls.Add(this.comboVariablesX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.labelDatos);
            this.Controls.Add(this.labelGraficar);
            this.Controls.Add(this.buttonGraph);
            this.Controls.Add(this.comboVariablesY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelGrafico);
            this.Controls.Add(this.labelVariables);
            this.Controls.Add(this.labelTipoGraficos);
            this.Controls.Add(this.comboTipoGrafico);
            this.Controls.Add(this.buttonPrestamos);
            this.Controls.Add(this.buttonClientes);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DespliegueDatos";
            this.Text = "DespliegueDatos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button buttonClientes;
        private System.Windows.Forms.Button buttonPrestamos;
        private System.Windows.Forms.ComboBox comboTipoGrafico;
        private System.Windows.Forms.ComboBox comboVariablesX;
        private System.Windows.Forms.Label labelTipoGraficos;
        private System.Windows.Forms.Label labelVariables;
        private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboVariablesY;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.Label labelGraficar;
        private System.Windows.Forms.Label labelDatos;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label labelEscoge;
    }
}