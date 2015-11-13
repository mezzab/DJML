namespace AerolineaFrba.Compra
{
    partial class CargaDatos
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
            this.BuscarPorCliente = new System.Windows.Forms.Button();
            this.dniNum = new System.Windows.Forms.TextBox();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tipo2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.telefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LimpiarCliente = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butacaSeleccionada = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Siguiente = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.verificacion = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.kilos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.combo = new System.Windows.Forms.ComboBox();
            this.t1 = new System.Windows.Forms.Label();
            this.t = new System.Windows.Forms.Label();
            this.verificacion2 = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verificacion)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verificacion2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarPorCliente);
            this.groupBox1.Controls.Add(this.dniNum);
            this.groupBox1.Controls.Add(this.tipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 321);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CLIENTE";
            // 
            // BuscarPorCliente
            // 
            this.BuscarPorCliente.Location = new System.Drawing.Point(152, 63);
            this.BuscarPorCliente.Name = "BuscarPorCliente";
            this.BuscarPorCliente.Size = new System.Drawing.Size(103, 37);
            this.BuscarPorCliente.TabIndex = 5;
            this.BuscarPorCliente.Text = " Buscar";
            this.BuscarPorCliente.UseVisualStyleBackColor = true;
            this.BuscarPorCliente.Click += new System.EventHandler(this.BuscarPorCliente_Click);
            // 
            // dniNum
            // 
            this.dniNum.Location = new System.Drawing.Point(21, 79);
            this.dniNum.Name = "dniNum";
            this.dniNum.Size = new System.Drawing.Size(114, 20);
            this.dniNum.TabIndex = 4;
            this.dniNum.TextChanged += new System.EventHandler(this.dni_TextChanged);
            // 
            // tipo
            // 
            this.tipo.FormattingEnabled = true;
            this.tipo.Location = new System.Drawing.Point(21, 36);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(114, 21);
            this.tipo.TabIndex = 3;
            this.tipo.SelectedIndexChanged += new System.EventHandler(this.tipoDeDocumento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de Documento";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tipo2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.fechaNacimiento);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numero);
            this.groupBox3.Controls.Add(this.telefono);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.mail);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.direccion);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nombre);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.apellido);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(11, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 211);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Cliente";
            // 
            // tipo2
            // 
            this.tipo2.FormattingEnabled = true;
            this.tipo2.Location = new System.Drawing.Point(140, 35);
            this.tipo2.Name = "tipo2";
            this.tipo2.Size = new System.Drawing.Size(98, 21);
            this.tipo2.TabIndex = 16;
            this.tipo2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tipo Documento";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaNacimiento.Location = new System.Drawing.Point(140, 182);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(99, 20);
            this.fechaNacimiento.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Fecha de nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Numero de Documento";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(139, 84);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(100, 20);
            this.numero.TabIndex = 7;
            this.numero.TextChanged += new System.EventHandler(this.numero_TextChanged);
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(9, 182);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 20);
            this.telefono.TabIndex = 11;
            this.telefono.TextChanged += new System.EventHandler(this.telefono_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Telefono";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(140, 133);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(100, 20);
            this.mail.TabIndex = 9;
            this.mail.TextChanged += new System.EventHandler(this.mail_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Mail (*)";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(9, 133);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(100, 20);
            this.direccion.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Direccion";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(9, 84);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(9, 35);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 20);
            this.apellido.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellido";
            // 
            // LimpiarCliente
            // 
            this.LimpiarCliente.Location = new System.Drawing.Point(297, 277);
            this.LimpiarCliente.Name = "LimpiarCliente";
            this.LimpiarCliente.Size = new System.Drawing.Size(144, 50);
            this.LimpiarCliente.TabIndex = 15;
            this.LimpiarCliente.Text = "Limpiar todo";
            this.LimpiarCliente.UseVisualStyleBackColor = true;
            this.LimpiarCliente.Click += new System.EventHandler(this.LimpiarCliente_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butacaSeleccionada);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.Siguiente);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(455, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 319);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PASAJE";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // butacaSeleccionada
            // 
            this.butacaSeleccionada.BackColor = System.Drawing.SystemColors.Menu;
            this.butacaSeleccionada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.butacaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.butacaSeleccionada.Location = new System.Drawing.Point(6, 236);
            this.butacaSeleccionada.Name = "butacaSeleccionada";
            this.butacaSeleccionada.Size = new System.Drawing.Size(256, 16);
            this.butacaSeleccionada.TabIndex = 4;
            this.butacaSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Seleccione una de las siguientes butacas:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(6, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(261, 182);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // Siguiente
            // 
            this.Siguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Siguiente.Location = new System.Drawing.Point(9, 263);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(253, 43);
            this.Siguiente.TabIndex = 4;
            this.Siguiente.Text = "Cargar Pasaje";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(38, 632);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(148, 54);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Atras";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // verificacion
            // 
            this.verificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.verificacion.Location = new System.Drawing.Point(5, 19);
            this.verificacion.Name = "verificacion";
            this.verificacion.Size = new System.Drawing.Size(706, 117);
            this.verificacion.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(493, 632);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 54);
            this.button1.TabIndex = 19;
            this.button1.Text = "SIGUIENTE: PAGAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.kilos);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(289, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 153);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ENCOMIENDA";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button2.Location = new System.Drawing.Point(6, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cargar Encomienda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // kilos
            // 
            this.kilos.Location = new System.Drawing.Point(18, 51);
            this.kilos.Name = "kilos";
            this.kilos.Size = new System.Drawing.Size(120, 20);
            this.kilos.TabIndex = 1;
            this.kilos.TextChanged += new System.EventHandler(this.kilos_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Ingrese el peso en Kgs:";
            // 
            // combo
            // 
            this.combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(298, 74);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(141, 25);
            this.combo.TabIndex = 21;
            this.combo.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.t1.Location = new System.Drawing.Point(302, 23);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(123, 20);
            this.t1.TabIndex = 22;
            this.t1.Text = "Seleccione qué";
            this.t1.Click += new System.EventHandler(this.label13_Click);
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.t.Location = new System.Drawing.Point(303, 46);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(126, 20);
            this.t.TabIndex = 23;
            this.t.Text = "desea comprar:";
            this.t.Click += new System.EventHandler(this.label14_Click);
            // 
            // verificacion2
            // 
            this.verificacion2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.verificacion2.Location = new System.Drawing.Point(6, 14);
            this.verificacion2.Name = "verificacion2";
            this.verificacion2.Size = new System.Drawing.Size(706, 129);
            this.verificacion2.TabIndex = 24;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.verificacion);
            this.groupBox5.Location = new System.Drawing.Point(9, 334);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(717, 143);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "LISTA DE PASAJES A COMPRAR";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.verificacion2);
            this.groupBox6.Location = new System.Drawing.Point(9, 480);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(717, 149);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "LISTA DE ENCOMIENDAS A COMPRAR";
            // 
            // CargaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 698);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.t);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LimpiarCliente);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CargaDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga datos de pasajeros";
            this.Load += new System.EventHandler(this.FormCompra3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verificacion)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verificacion2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BuscarPorCliente;
        private System.Windows.Forms.TextBox dniNum;
        private System.Windows.Forms.ComboBox tipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button LimpiarCliente;
        private System.Windows.Forms.DateTimePicker fechaNacimiento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button Siguiente;
        private System.Windows.Forms.ComboBox tipo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.TextBox butacaSeleccionada;
        private System.Windows.Forms.DataGridView verificacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox kilos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.DataGridView verificacion2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}