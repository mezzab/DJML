namespace AerolineaFrba.Abm_Aeronave
{
    partial class FormAeronaveAlta
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
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bn = new System.Windows.Forms.Button();
            this.matricula = new System.Windows.Forms.TextBox();
            this.modelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKg_disp = new System.Windows.Forms.TextBox();
            this.txtC_but = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboFab = new System.Windows.Forms.ComboBox();
            this.comboT_serv = new System.Windows.Forms.ComboBox();
            this.f_alta = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matricula";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(30, 298);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 39);
            this.button3.TabIndex = 9;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "Dar de alta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bn
            // 
            this.bn.Location = new System.Drawing.Point(124, 298);
            this.bn.Name = "bn";
            this.bn.Size = new System.Drawing.Size(75, 39);
            this.bn.TabIndex = 11;
            this.bn.Text = "Limpiar";
            this.bn.UseVisualStyleBackColor = true;
            this.bn.Click += new System.EventHandler(this.bn_limpiar_Click);
            // 
            // matricula
            // 
            this.matricula.Location = new System.Drawing.Point(152, 20);
            this.matricula.Name = "matricula";
            this.matricula.Size = new System.Drawing.Size(204, 20);
            this.matricula.TabIndex = 12;
            this.matricula.TextChanged += new System.EventHandler(this.matricula_TextChanged);
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(152, 57);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(204, 20);
            this.modelo.TabIndex = 13;
            this.modelo.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Modelo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "KG Disponibles";
            // 
            // txtKg_disp
            // 
            this.txtKg_disp.Location = new System.Drawing.Point(152, 92);
            this.txtKg_disp.Name = "txtKg_disp";
            this.txtKg_disp.Size = new System.Drawing.Size(204, 20);
            this.txtKg_disp.TabIndex = 16;
            this.txtKg_disp.TextChanged += new System.EventHandler(this.txtKg_disp_TextChanged);
            // 
            // txtC_but
            // 
            this.txtC_but.Location = new System.Drawing.Point(152, 208);
            this.txtC_but.Name = "txtC_but";
            this.txtC_but.Size = new System.Drawing.Size(204, 20);
            this.txtC_but.TabIndex = 17;
            this.txtC_but.TextChanged += new System.EventHandler(this.txtC_but_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cantidad Butacas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fabricante";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tipo Servicio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Fecha de alta";
            // 
            // comboFab
            // 
            this.comboFab.FormattingEnabled = true;
            this.comboFab.Location = new System.Drawing.Point(152, 131);
            this.comboFab.Name = "comboFab";
            this.comboFab.Size = new System.Drawing.Size(204, 21);
            this.comboFab.TabIndex = 22;
            // 
            // comboT_serv
            // 
            this.comboT_serv.FormattingEnabled = true;
            this.comboT_serv.Location = new System.Drawing.Point(152, 168);
            this.comboT_serv.Name = "comboT_serv";
            this.comboT_serv.Size = new System.Drawing.Size(204, 21);
            this.comboT_serv.TabIndex = 23;
            this.comboT_serv.SelectedIndexChanged += new System.EventHandler(this.comboT_serv_SelectedIndexChanged);
            // 
            // f_alta
            // 
            this.f_alta.Location = new System.Drawing.Point(152, 242);
            this.f_alta.Name = "f_alta";
            this.f_alta.Size = new System.Drawing.Size(204, 20);
            this.f_alta.TabIndex = 24;
            this.f_alta.ValueChanged += new System.EventHandler(this.f_alta_ValueChanged_1);
            // 
            // FormAeronaveAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(384, 349);
            this.Controls.Add(this.f_alta);
            this.Controls.Add(this.comboT_serv);
            this.Controls.Add(this.comboFab);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtC_but);
            this.Controls.Add(this.txtKg_disp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.matricula);
            this.Controls.Add(this.bn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Name = "FormAeronaveAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAeronaveAlta";
            this.Load += new System.EventHandler(this.FormAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bn;
        private System.Windows.Forms.TextBox matricula;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKg_disp;
        private System.Windows.Forms.TextBox txtC_but;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboFab;
        private System.Windows.Forms.ComboBox comboT_serv;
        private System.Windows.Forms.DateTimePicker f_alta;
    }
}