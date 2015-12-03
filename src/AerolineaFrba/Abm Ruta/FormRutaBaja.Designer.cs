namespace AerolineaFrba.Abm_Ruta
{
    partial class FormRutaBaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRutaBaja));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_servicio = new System.Windows.Forms.ComboBox();
            this.comboBox_destino = new System.Windows.Forms.ComboBox();
            this.comboBox_origen = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.ELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_volver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_buscar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_servicio);
            this.groupBox1.Controls.Add(this.comboBox_destino);
            this.groupBox1.Controls.Add(this.comboBox_origen);
            this.groupBox1.Controls.Add(this.dataGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 226);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rutas Aereas";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(638, 70);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 14;
            this.button_buscar.Text = "Buscar!";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ciudad Origen";
            // 
            // comboBox_servicio
            // 
            this.comboBox_servicio.FormattingEnabled = true;
            this.comboBox_servicio.Location = new System.Drawing.Point(509, 72);
            this.comboBox_servicio.Name = "comboBox_servicio";
            this.comboBox_servicio.Size = new System.Drawing.Size(121, 21);
            this.comboBox_servicio.TabIndex = 10;
            // 
            // comboBox_destino
            // 
            this.comboBox_destino.FormattingEnabled = true;
            this.comboBox_destino.Location = new System.Drawing.Point(317, 72);
            this.comboBox_destino.Name = "comboBox_destino";
            this.comboBox_destino.Size = new System.Drawing.Size(121, 21);
            this.comboBox_destino.TabIndex = 9;
            // 
            // comboBox_origen
            // 
            this.comboBox_origen.FormattingEnabled = true;
            this.comboBox_origen.Location = new System.Drawing.Point(93, 72);
            this.comboBox_origen.Name = "comboBox_origen";
            this.comboBox_origen.Size = new System.Drawing.Size(121, 21);
            this.comboBox_origen.TabIndex = 8;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ELIMINAR});
            this.dataGrid.Location = new System.Drawing.Point(16, 127);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(707, 61);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // ELIMINAR
            // 
            this.ELIMINAR.HeaderText = "ELIMINAR";
            this.ELIMINAR.Name = "ELIMINAR";
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(329, 267);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(75, 23);
            this.button_volver.TabIndex = 6;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // FormRutaBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(754, 302);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRutaBaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM RUTA - BAJA";
            this.Load += new System.EventHandler(this.FormRutaBaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_servicio;
        private System.Windows.Forms.ComboBox comboBox_destino;
        private System.Windows.Forms.ComboBox comboBox_origen;
        private System.Windows.Forms.DataGridViewButtonColumn ELIMINAR;
    }
}