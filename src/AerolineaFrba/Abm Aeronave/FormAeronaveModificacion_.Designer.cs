namespace AerolineaFrba.Abm_Aeronave
{
    partial class FormAeronaveModificacion_
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.matricula = new System.Windows.Forms.TextBox();
            this.modelo = new System.Windows.Forms.TextBox();
            this.c_butacas = new System.Windows.Forms.TextBox();
            this.t_servicio = new System.Windows.Forms.ComboBox();
            this.kg_disponibles = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.f_alta = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.fabricantes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxAeronaves = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fabricante = new System.Windows.Forms.TextBox();
            this.tipoServicio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matricula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kg Disponibles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad Butacas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Seleccione Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(308, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seleccione Fabricante";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Modelo";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // matricula
            // 
            this.matricula.Location = new System.Drawing.Point(20, 38);
            this.matricula.Name = "matricula";
            this.matricula.Size = new System.Drawing.Size(121, 20);
            this.matricula.TabIndex = 10;
            this.matricula.TextChanged += new System.EventHandler(this.matri_TextChanged);
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(20, 81);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(121, 20);
            this.modelo.TabIndex = 11;
            this.modelo.TextChanged += new System.EventHandler(this.mode_TextChanged);
            // 
            // c_butacas
            // 
            this.c_butacas.Location = new System.Drawing.Point(20, 131);
            this.c_butacas.Name = "c_butacas";
            this.c_butacas.Size = new System.Drawing.Size(121, 20);
            this.c_butacas.TabIndex = 14;
            this.c_butacas.TextChanged += new System.EventHandler(this.c_butacas_TextChanged);
            // 
            // t_servicio
            // 
            this.t_servicio.FormattingEnabled = true;
            this.t_servicio.Location = new System.Drawing.Point(311, 37);
            this.t_servicio.Name = "t_servicio";
            this.t_servicio.Size = new System.Drawing.Size(121, 21);
            this.t_servicio.TabIndex = 15;
            this.t_servicio.SelectedIndexChanged += new System.EventHandler(this.t_servicio_SelectedIndexChanged);
            // 
            // kg_disponibles
            // 
            this.kg_disponibles.Location = new System.Drawing.Point(20, 170);
            this.kg_disponibles.Name = "kg_disponibles";
            this.kg_disponibles.Size = new System.Drawing.Size(121, 20);
            this.kg_disponibles.TabIndex = 16;
            this.kg_disponibles.TextChanged += new System.EventHandler(this.kg_disponibles_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(165, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Fecha Alta";
            // 
            // f_alta
            // 
            this.f_alta.Location = new System.Drawing.Point(168, 131);
            this.f_alta.Name = "f_alta";
            this.f_alta.Size = new System.Drawing.Size(121, 20);
            this.f_alta.TabIndex = 18;
            this.f_alta.ValueChanged += new System.EventHandler(this.f_alta_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 59);
            this.button1.TabIndex = 19;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 37);
            this.button2.TabIndex = 20;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(331, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 37);
            this.button3.TabIndex = 22;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // fabricantes
            // 
            this.fabricantes.FormattingEnabled = true;
            this.fabricantes.Location = new System.Drawing.Point(311, 80);
            this.fabricantes.Name = "fabricantes";
            this.fabricantes.Size = new System.Drawing.Size(121, 21);
            this.fabricantes.TabIndex = 23;
            this.fabricantes.SelectedIndexChanged += new System.EventHandler(this.fabricantes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "SELECCIONE AERONAVE A MOFICIAR";
            // 
            // comboBoxAeronaves
            // 
            this.comboBoxAeronaves.FormattingEnabled = true;
            this.comboBoxAeronaves.Location = new System.Drawing.Point(134, 57);
            this.comboBoxAeronaves.Name = "comboBoxAeronaves";
            this.comboBoxAeronaves.Size = new System.Drawing.Size(224, 21);
            this.comboBoxAeronaves.TabIndex = 24;
            this.comboBoxAeronaves.SelectedIndexChanged += new System.EventHandler(this.comboBoxAeronaves_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.fabricante);
            this.groupBox1.Controls.Add(this.tipoServicio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fabricantes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.matricula);
            this.groupBox1.Controls.Add(this.f_alta);
            this.groupBox1.Controls.Add(this.modelo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.c_butacas);
            this.groupBox1.Controls.Add(this.kg_disponibles);
            this.groupBox1.Controls.Add(this.t_servicio);
            this.groupBox1.Location = new System.Drawing.Point(20, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 212);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de aeronave";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(181, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "Fabricante";
            // 
            // fabricante
            // 
            this.fabricante.Location = new System.Drawing.Point(168, 81);
            this.fabricante.Name = "fabricante";
            this.fabricante.Size = new System.Drawing.Size(121, 20);
            this.fabricante.TabIndex = 26;
            this.fabricante.TextChanged += new System.EventHandler(this.fabricante_TextChanged);
            // 
            // tipoServicio
            // 
            this.tipoServicio.Location = new System.Drawing.Point(168, 38);
            this.tipoServicio.Name = "tipoServicio";
            this.tipoServicio.Size = new System.Drawing.Size(121, 20);
            this.tipoServicio.TabIndex = 25;
            this.tipoServicio.TextChanged += new System.EventHandler(this.tipo_servicio_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(181, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tipo Servicio";
            // 
            // FormAeronaveModificacion_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(489, 398);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAeronaves);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "FormAeronaveModificacion_";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moficacion Aeronave";
            this.Load += new System.EventHandler(this.FormAeronaveModificacion__Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox matricula;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.TextBox c_butacas;
        private System.Windows.Forms.ComboBox t_servicio;
        private System.Windows.Forms.TextBox kg_disponibles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker f_alta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox fabricantes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxAeronaves;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fabricante;
        private System.Windows.Forms.TextBox tipoServicio;
        private System.Windows.Forms.Label label8;
    }
}