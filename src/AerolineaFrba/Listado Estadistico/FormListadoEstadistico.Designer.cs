namespace AerolineaFrba.Listado_Estadistico
{
    partial class FormListadoEstadistico
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.comboBoxTrimestre = new System.Windows.Forms.ComboBox();
            this.primerFiltro = new System.Windows.Forms.Button();
            this.tercerFiltro = new System.Windows.Forms.Button();
            this.quintoFiltro = new System.Windows.Forms.Button();
            this.segundoFiltro = new System.Windows.Forms.Button();
            this.cuartoFiltro = new System.Windows.Forms.Button();
            this.datos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año (AAAA):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre:";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(95, 19);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 5;
            this.txtAnio.TextChanged += new System.EventHandler(this.txtAnio_TextChanged);
            // 
            // comboBoxTrimestre
            // 
            this.comboBoxTrimestre.FormattingEnabled = true;
            this.comboBoxTrimestre.Location = new System.Drawing.Point(326, 18);
            this.comboBoxTrimestre.Name = "comboBoxTrimestre";
            this.comboBoxTrimestre.Size = new System.Drawing.Size(166, 21);
            this.comboBoxTrimestre.TabIndex = 6;
            this.comboBoxTrimestre.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrimestre_SelectedIndexChanged);
            // 
            // primerFiltro
            // 
            this.primerFiltro.Location = new System.Drawing.Point(12, 68);
            this.primerFiltro.Name = "primerFiltro";
            this.primerFiltro.Size = new System.Drawing.Size(110, 73);
            this.primerFiltro.TabIndex = 7;
            this.primerFiltro.Text = "DESTINOS CON MAS PASAJES COMPRADOS";
            this.primerFiltro.UseVisualStyleBackColor = true;
            this.primerFiltro.Click += new System.EventHandler(this.primerFiltro_Click);
            // 
            // tercerFiltro
            // 
            this.tercerFiltro.Location = new System.Drawing.Point(270, 68);
            this.tercerFiltro.Name = "tercerFiltro";
            this.tercerFiltro.Size = new System.Drawing.Size(110, 73);
            this.tercerFiltro.TabIndex = 8;
            this.tercerFiltro.Text = "CLIENTES CON MAS PUNTOS ACUMULADOS A LA FECHA";
            this.tercerFiltro.UseVisualStyleBackColor = true;
            this.tercerFiltro.Click += new System.EventHandler(this.tercerFiltro_Click);
            // 
            // quintoFiltro
            // 
            this.quintoFiltro.Location = new System.Drawing.Point(523, 68);
            this.quintoFiltro.Name = "quintoFiltro";
            this.quintoFiltro.Size = new System.Drawing.Size(110, 73);
            this.quintoFiltro.TabIndex = 9;
            this.quintoFiltro.Text = "AERONAVES CON MAYOR CANTIDAD DE DIAS FUERA DE SERVICIO";
            this.quintoFiltro.UseVisualStyleBackColor = true;
            this.quintoFiltro.Click += new System.EventHandler(this.quintoFiltro_Click);
            // 
            // segundoFiltro
            // 
            this.segundoFiltro.Location = new System.Drawing.Point(144, 68);
            this.segundoFiltro.Name = "segundoFiltro";
            this.segundoFiltro.Size = new System.Drawing.Size(110, 73);
            this.segundoFiltro.TabIndex = 10;
            this.segundoFiltro.Text = "DESTINOS CON AERONAVES MAS VACIAS";
            this.segundoFiltro.UseVisualStyleBackColor = true;
            this.segundoFiltro.Click += new System.EventHandler(this.segundoFiltro_Click);
            // 
            // cuartoFiltro
            // 
            this.cuartoFiltro.Location = new System.Drawing.Point(397, 68);
            this.cuartoFiltro.Name = "cuartoFiltro";
            this.cuartoFiltro.Size = new System.Drawing.Size(110, 73);
            this.cuartoFiltro.TabIndex = 11;
            this.cuartoFiltro.Text = "DESTINOS CON PASAJES CANCELADOS";
            this.cuartoFiltro.UseVisualStyleBackColor = true;
            this.cuartoFiltro.Click += new System.EventHandler(this.cuartoFiltro_Click);
            // 
            // datos
            // 
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(12, 161);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(621, 150);
            this.datos.TabIndex = 12;
            // 
            // FormListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 387);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.cuartoFiltro);
            this.Controls.Add(this.segundoFiltro);
            this.Controls.Add(this.quintoFiltro);
            this.Controls.Add(this.tercerFiltro);
            this.Controls.Add(this.primerFiltro);
            this.Controls.Add(this.comboBoxTrimestre);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FormListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.FormListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox comboBoxTrimestre;
        private System.Windows.Forms.Button primerFiltro;
        private System.Windows.Forms.Button tercerFiltro;
        private System.Windows.Forms.Button quintoFiltro;
        private System.Windows.Forms.Button segundoFiltro;
        private System.Windows.Forms.Button cuartoFiltro;
        private System.Windows.Forms.DataGridView datos;
    }
}