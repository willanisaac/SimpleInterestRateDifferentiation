
namespace ProyectoTitulacion.Vistas
{
    partial class MostrarGraficos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.comboTipoGrafico = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.toolTipExport = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipGrafico = new System.Windows.Forms.ToolTip(this.components);
            this.labelTipoVariable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboVariable = new System.Windows.Forms.ComboBox();
            this.toolTipData = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGraph
            // 
            this.buttonGraph.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonGraph.FlatAppearance.BorderSize = 0;
            this.buttonGraph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonGraph.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGraph.ForeColor = System.Drawing.Color.White;
            this.buttonGraph.Location = new System.Drawing.Point(936, 54);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(228, 31);
            this.buttonGraph.TabIndex = 24;
            this.buttonGraph.Text = "Actualiza Grafico";
            this.buttonGraph.UseVisualStyleBackColor = false;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
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
            this.dataGrid.Location = new System.Drawing.Point(12, 43);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(504, 603);
            this.dataGrid.TabIndex = 21;
            // 
            // comboTipoGrafico
            // 
            this.comboTipoGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.comboTipoGrafico.FormattingEnabled = true;
            this.comboTipoGrafico.Location = new System.Drawing.Point(706, 54);
            this.comboTipoGrafico.Name = "comboTipoGrafico";
            this.comboTipoGrafico.Size = new System.Drawing.Size(215, 33);
            this.comboTipoGrafico.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 31);
            this.label1.TabIndex = 30;
            this.label1.Text = "Registro de clientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(936, 14);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(228, 31);
            this.buttonExport.TabIndex = 31;
            this.buttonExport.Text = "Exportar Resultados";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // panelGrafico
            // 
            this.panelGrafico.Location = new System.Drawing.Point(524, 138);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Size = new System.Drawing.Size(664, 508);
            this.panelGrafico.TabIndex = 33;
            // 
            // labelTipoVariable
            // 
            this.labelTipoVariable.AutoSize = true;
            this.labelTipoVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoVariable.Location = new System.Drawing.Point(587, 11);
            this.labelTipoVariable.Name = "labelTipoVariable";
            this.labelTipoVariable.Size = new System.Drawing.Size(113, 31);
            this.labelTipoVariable.TabIndex = 27;
            this.labelTipoVariable.Text = "Variable";
            this.labelTipoVariable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(538, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 31);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tipo Grafico";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboVariable
            // 
            this.comboVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.comboVariable.FormattingEnabled = true;
            this.comboVariable.Location = new System.Drawing.Point(706, 14);
            this.comboVariable.Name = "comboVariable";
            this.comboVariable.Size = new System.Drawing.Size(215, 33);
            this.comboVariable.TabIndex = 35;
            // 
            // MostrarGraficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 650);
            this.Controls.Add(this.comboVariable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelGrafico);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTipoVariable);
            this.Controls.Add(this.comboTipoGrafico);
            this.Controls.Add(this.buttonGraph);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MostrarGraficos";
            this.Text = "MostrarGraficos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox comboTipoGrafico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.ToolTip toolTipExport;
        private System.Windows.Forms.ToolTip toolTipGrafico;
        private System.Windows.Forms.Label labelTipoVariable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboVariable;
        private System.Windows.Forms.ToolTip toolTipData;
    }
}