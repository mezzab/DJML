namespace AerolineaFrba.Compra
{
    partial class CompraEncomiendas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dniNum = new System.Windows.Forms.TextBox();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.mai = new System.Windows.Forms.TextBox();
            this.tel = new System.Windows.Forms.TextBox();
            this.dir = new System.Windows.Forms.TextBox();
            this.ape = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.TextBox();
            this.tipo2 = new System.Windows.Forms.ComboBox();
            this.num = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kgs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.encomiendas = new System.Windows.Forms.DataGridView();
            this.Atras = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encomiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dniNum);
            this.groupBox1.Controls.Add(this.tipo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dniNum
            // 
            this.dniNum.Location = new System.Drawing.Point(156, 37);
            this.dniNum.Name = "dniNum";
            this.dniNum.Size = new System.Drawing.Size(124, 20);
            this.dniNum.TabIndex = 4;
            // 
            // tipo
            // 
            this.tipo.FormattingEnabled = true;
            this.tipo.Location = new System.Drawing.Point(9, 36);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(121, 21);
            this.tipo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero de documento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fecha);
            this.groupBox2.Controls.Add(this.mai);
            this.groupBox2.Controls.Add(this.tel);
            this.groupBox2.Controls.Add(this.dir);
            this.groupBox2.Controls.Add(this.ape);
            this.groupBox2.Controls.Add(this.nom);
            this.groupBox2.Controls.Add(this.tipo2);
            this.groupBox2.Controls.Add(this.num);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 135);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del cliente";
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(422, 90);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(121, 20);
            this.fecha.TabIndex = 15;
            // 
            // mai
            // 
            this.mai.Location = new System.Drawing.Point(422, 43);
            this.mai.Name = "mai";
            this.mai.Size = new System.Drawing.Size(121, 20);
            this.mai.TabIndex = 14;
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(292, 90);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(121, 20);
            this.tel.TabIndex = 13;
            // 
            // dir
            // 
            this.dir.Location = new System.Drawing.Point(292, 43);
            this.dir.Name = "dir";
            this.dir.Size = new System.Drawing.Size(121, 20);
            this.dir.TabIndex = 12;
            // 
            // ape
            // 
            this.ape.Location = new System.Drawing.Point(153, 91);
            this.ape.Name = "ape";
            this.ape.Size = new System.Drawing.Size(121, 20);
            this.ape.TabIndex = 11;
            this.ape.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(153, 45);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(121, 20);
            this.nom.TabIndex = 10;
            // 
            // tipo2
            // 
            this.tipo2.FormattingEnabled = true;
            this.tipo2.Location = new System.Drawing.Point(12, 44);
            this.tipo2.Name = "tipo2";
            this.tipo2.Size = new System.Drawing.Size(121, 21);
            this.tipo2.TabIndex = 9;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(12, 91);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(121, 20);
            this.num.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Numero de documento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tipo de documento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Fecha de nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kgs);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(22, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 80);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encomienda";
            // 
            // kgs
            // 
            this.kgs.Location = new System.Drawing.Point(93, 32);
            this.kgs.Name = "kgs";
            this.kgs.Size = new System.Drawing.Size(121, 20);
            this.kgs.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Kilos a enviar:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(350, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(451, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 55);
            this.button3.TabIndex = 3;
            this.button3.Text = "Agregar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // encomiendas
            // 
            this.encomiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.encomiendas.Location = new System.Drawing.Point(19, 333);
            this.encomiendas.Name = "encomiendas";
            this.encomiendas.Size = new System.Drawing.Size(561, 180);
            this.encomiendas.TabIndex = 4;
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(19, 531);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(146, 47);
            this.Atras.TabIndex = 5;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(434, 531);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 47);
            this.button4.TabIndex = 6;
            this.button4.Text = "Siguiente: Pagar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CompraEncomiendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 590);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.encomiendas);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompraEncomiendas";
            this.Text = "Compra de encomiendas";
            this.Load += new System.EventHandler(this.CompraEncomiendas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encomiendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox dniNum;
        private System.Windows.Forms.ComboBox tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ape;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.ComboBox tipo2;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.TextBox mai;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox dir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox kgs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView encomiendas;
        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Button button4;
    }
}