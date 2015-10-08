namespace AerolineaFrba.Generacion_Viaje
{
    partial class FormGenerarViaje
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
            this.button2 = new System.Windows.Forms.Button();
            this.fechaSalida = new System.Windows.Forms.DateTimePicker();
            this.fechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.fechaLLegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAeronaves = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SELECCIONAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CIUDAD_ORIGEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIUDAD_DESTINO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // fechaSalida
            // 
            this.fechaSalida.Location = new System.Drawing.Point(182, 41);
            this.fechaSalida.Name = "fechaSalida";
            this.fechaSalida.Size = new System.Drawing.Size(200, 20);
            this.fechaSalida.TabIndex = 2;
            this.fechaSalida.ValueChanged += new System.EventHandler(this.fechaSalida_ValueChanged);
            // 
            // fechaLlegada
            // 
            this.fechaLlegada.Location = new System.Drawing.Point(182, 68);
            this.fechaLlegada.Name = "fechaLlegada";
            this.fechaLlegada.Size = new System.Drawing.Size(200, 20);
            this.fechaLlegada.TabIndex = 3;
            // 
            // fechaLLegadaEstimada
            // 
            this.fechaLLegadaEstimada.Location = new System.Drawing.Point(182, 94);
            this.fechaLLegadaEstimada.Name = "fechaLLegadaEstimada";
            this.fechaLLegadaEstimada.Size = new System.Drawing.Size(200, 20);
            this.fechaLLegadaEstimada.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha Salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha Llegada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha LLegada Estimada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seleccionar Aeronave";
            // 
            // comboBoxAeronaves
            // 
            this.comboBoxAeronaves.FormattingEnabled = true;
            this.comboBoxAeronaves.Location = new System.Drawing.Point(182, 155);
            this.comboBoxAeronaves.Name = "comboBoxAeronaves";
            this.comboBoxAeronaves.Size = new System.Drawing.Size(200, 21);
            this.comboBoxAeronaves.TabIndex = 9;
            //this.comboBoxAeronaves.SelectedIndexChanged += new System.EventHandler(this.comboBoxAeronaves_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECCIONAR,
            this.CIUDAD_ORIGEN,
            this.CIUDAD_DESTINO});
            this.dataGridView1.Location = new System.Drawing.Point(37, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(345, 133);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SELECCIONAR
            // 
            this.SELECCIONAR.HeaderText = "SELECCIONAR";
            this.SELECCIONAR.Name = "SELECCIONAR";
            // 
            // CIUDAD_ORIGEN
            // 
            this.CIUDAD_ORIGEN.HeaderText = "CIUDAD_ORIGEN";
            this.CIUDAD_ORIGEN.Name = "CIUDAD_ORIGEN";
            // 
            // CIUDAD_DESTINO
            // 
            this.CIUDAD_DESTINO.HeaderText = "CIUDAD_DESTINO";
            this.CIUDAD_DESTINO.Name = "CIUDAD_DESTINO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Seleccionar Ruta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Buscar Aeronaves:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(182, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormGenerarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 407);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxAeronaves);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaLLegadaEstimada);
            this.Controls.Add(this.fechaLlegada);
            this.Controls.Add(this.fechaSalida);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormGenerarViaje";
            this.Text = "Generar Viaje";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker fechaSalida;
        private System.Windows.Forms.DateTimePicker fechaLlegada;
        private System.Windows.Forms.DateTimePicker fechaLLegadaEstimada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAeronaves;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewButtonColumn SELECCIONAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIUDAD_ORIGEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIUDAD_DESTINO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
    }
}