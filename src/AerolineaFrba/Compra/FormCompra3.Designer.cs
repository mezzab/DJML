namespace AerolineaFrba.Compra
{
    partial class FormCompra3
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
            this.Volver = new System.Windows.Forms.Button();
            this.Siguiente = new System.Windows.Forms.Button();
            this.pasajero = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Actualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(9, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 321);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // BuscarPorCliente
            // 
            this.BuscarPorCliente.Location = new System.Drawing.Point(152, 63);
            this.BuscarPorCliente.Name = "BuscarPorCliente";
            this.BuscarPorCliente.Size = new System.Drawing.Size(97, 37);
            this.BuscarPorCliente.TabIndex = 5;
            this.BuscarPorCliente.Text = "Buscar";
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
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(12, 183);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 20);
            this.telefono.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 167);
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
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Mail";
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
            this.LimpiarCliente.Location = new System.Drawing.Point(175, 382);
            this.LimpiarCliente.Name = "LimpiarCliente";
            this.LimpiarCliente.Size = new System.Drawing.Size(89, 53);
            this.LimpiarCliente.TabIndex = 15;
            this.LimpiarCliente.Text = "Limpiar";
            this.LimpiarCliente.UseVisualStyleBackColor = true;
            this.LimpiarCliente.Click += new System.EventHandler(this.LimpiarCliente_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butacaSeleccionada);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(292, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 320);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Butacas disponibles";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // butacaSeleccionada
            // 
            this.butacaSeleccionada.BackColor = System.Drawing.SystemColors.Menu;
            this.butacaSeleccionada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.butacaSeleccionada.Location = new System.Drawing.Point(9, 293);
            this.butacaSeleccionada.Name = "butacaSeleccionada";
            this.butacaSeleccionada.Size = new System.Drawing.Size(256, 13);
            this.butacaSeleccionada.TabIndex = 4;
            this.butacaSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 27);
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
            this.dataGridView1.Location = new System.Drawing.Point(6, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(261, 240);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(36, 381);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(93, 54);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Atras";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Siguiente
            // 
            this.Siguiente.Location = new System.Drawing.Point(456, 381);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(90, 54);
            this.Siguiente.TabIndex = 4;
            this.Siguiente.Text = "Siguiente";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // pasajero
            // 
            this.pasajero.BackColor = System.Drawing.SystemColors.Menu;
            this.pasajero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pasajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.pasajero.Location = new System.Drawing.Point(315, 14);
            this.pasajero.Name = "pasajero";
            this.pasajero.Size = new System.Drawing.Size(100, 16);
            this.pasajero.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label12.Location = new System.Drawing.Point(17, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(296, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "Por favor, ingrese los datos del Pasajero Nro:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(321, 381);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(95, 54);
            this.Actualizar.TabIndex = 17;
            this.Actualizar.Text = "Actualizar Datos";
            this.Actualizar.UseVisualStyleBackColor = true;
            // 
            // FormCompra3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 451);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pasajero);
            this.Controls.Add(this.LimpiarCliente);
            this.Controls.Add(this.Siguiente);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCompra3";
            this.Text = "Carga datos de pasajeros";
            this.Load += new System.EventHandler(this.FormCompra3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox pasajero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.TextBox butacaSeleccionada;
    }
}