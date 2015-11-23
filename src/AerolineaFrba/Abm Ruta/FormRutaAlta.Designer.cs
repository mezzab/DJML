namespace AerolineaFrba.Abm_Ruta
{
    partial class FormRutaAlta
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
            this.button_volver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_precio_encomienda = new System.Windows.Forms.TextBox();
            this.text_precio_pasaje = new System.Windows.Forms.TextBox();
            this.comboBox_servicio = new System.Windows.Forms.ComboBox();
            this.comboBox_destino = new System.Windows.Forms.ComboBox();
            this.comboBox_origen = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(133, 374);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(75, 23);
            this.button_volver.TabIndex = 4;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_guardar);
            this.groupBox1.Controls.Add(this.label_message);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.text_precio_encomienda);
            this.groupBox1.Controls.Add(this.text_precio_pasaje);
            this.groupBox1.Controls.Add(this.comboBox_servicio);
            this.groupBox1.Controls.Add(this.comboBox_destino);
            this.groupBox1.Controls.Add(this.comboBox_origen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 356);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rutas Aereas";
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(121, 327);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 6;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label_message
            // 
            this.label_message.BackColor = System.Drawing.Color.Red;
            this.label_message.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_message.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_message.Location = new System.Drawing.Point(15, 167);
            this.label_message.Name = "label_message";
            this.label_message.Padding = new System.Windows.Forms.Padding(10);
            this.label_message.Size = new System.Drawing.Size(285, 143);
            this.label_message.TabIndex = 10;
            this.label_message.Text = "errores";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_message.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Precio Base Kilo Encomienda ($)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Precio Base Pasaje ($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ciudad Origen";
            // 
            // text_precio_encomienda
            // 
            this.text_precio_encomienda.Location = new System.Drawing.Point(179, 127);
            this.text_precio_encomienda.Name = "text_precio_encomienda";
            this.text_precio_encomienda.Size = new System.Drawing.Size(121, 20);
            this.text_precio_encomienda.TabIndex = 4;
            // 
            // text_precio_pasaje
            // 
            this.text_precio_pasaje.Location = new System.Drawing.Point(179, 101);
            this.text_precio_pasaje.Name = "text_precio_pasaje";
            this.text_precio_pasaje.Size = new System.Drawing.Size(121, 20);
            this.text_precio_pasaje.TabIndex = 3;
            // 
            // comboBox_servicio
            // 
            this.comboBox_servicio.FormattingEnabled = true;
            this.comboBox_servicio.Location = new System.Drawing.Point(121, 74);
            this.comboBox_servicio.Name = "comboBox_servicio";
            this.comboBox_servicio.Size = new System.Drawing.Size(121, 21);
            this.comboBox_servicio.TabIndex = 2;
            // 
            // comboBox_destino
            // 
            this.comboBox_destino.FormattingEnabled = true;
            this.comboBox_destino.Location = new System.Drawing.Point(121, 47);
            this.comboBox_destino.Name = "comboBox_destino";
            this.comboBox_destino.Size = new System.Drawing.Size(121, 21);
            this.comboBox_destino.TabIndex = 1;
            // 
            // comboBox_origen
            // 
            this.comboBox_origen.FormattingEnabled = true;
            this.comboBox_origen.Location = new System.Drawing.Point(121, 20);
            this.comboBox_origen.Name = "comboBox_origen";
            this.comboBox_origen.Size = new System.Drawing.Size(121, 21);
            this.comboBox_origen.TabIndex = 0;
            // 
            // FormRutaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_volver);
            this.Name = "FormRutaAlta";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ABM RUTA - ALTA";
            this.Load += new System.EventHandler(this.FormRutaAlta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_precio_encomienda;
        private System.Windows.Forms.TextBox text_precio_pasaje;
        private System.Windows.Forms.ComboBox comboBox_servicio;
        private System.Windows.Forms.ComboBox comboBox_destino;
        private System.Windows.Forms.ComboBox comboBox_origen;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}