namespace AerolineaFrba.Compra
{
    partial class PagoConTarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoConTarjeta));
            this.ActualizarDatos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tipoT = new System.Windows.Forms.ComboBox();
            this.cuotas = new System.Windows.Forms.ComboBox();
            this.NuevaTarjeta = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.vencimientoTarjeta = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.codigoTarjeta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numTarjeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
            this.Comprar = new System.Windows.Forms.Button();
            this.LimpiarTodo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BuscarPorCliente = new System.Windows.Forms.Button();
            this.dniNum = new System.Windows.Forms.TextBox();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.tipo2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.total = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActualizarDatos
            // 
            this.ActualizarDatos.Location = new System.Drawing.Point(261, 84);
            this.ActualizarDatos.Name = "ActualizarDatos";
            this.ActualizarDatos.Size = new System.Drawing.Size(75, 36);
            this.ActualizarDatos.TabIndex = 14;
            this.ActualizarDatos.Text = "Actualizar Datos";
            this.ActualizarDatos.UseVisualStyleBackColor = true;
            this.ActualizarDatos.Click += new System.EventHandler(this.ActualizarDatos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tipoT);
            this.groupBox2.Controls.Add(this.cuotas);
            this.groupBox2.Controls.Add(this.NuevaTarjeta);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.vencimientoTarjeta);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.codigoTarjeta);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.numTarjeta);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(5, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarjeta";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tipoT
            // 
            this.tipoT.FormattingEnabled = true;
            this.tipoT.Location = new System.Drawing.Point(18, 38);
            this.tipoT.Name = "tipoT";
            this.tipoT.Size = new System.Drawing.Size(144, 21);
            this.tipoT.TabIndex = 11;
            this.tipoT.SelectedIndexChanged += new System.EventHandler(this.tiposTarjeta_SelectedIndexChanged);
            // 
            // cuotas
            // 
            this.cuotas.FormattingEnabled = true;
            this.cuotas.Location = new System.Drawing.Point(375, 37);
            this.cuotas.Name = "cuotas";
            this.cuotas.Size = new System.Drawing.Size(91, 21);
            this.cuotas.TabIndex = 10;
            this.cuotas.SelectedIndexChanged += new System.EventHandler(this.cuotas_SelectedIndexChanged);
            // 
            // NuevaTarjeta
            // 
            this.NuevaTarjeta.Location = new System.Drawing.Point(194, 75);
            this.NuevaTarjeta.Name = "NuevaTarjeta";
            this.NuevaTarjeta.Size = new System.Drawing.Size(144, 43);
            this.NuevaTarjeta.TabIndex = 8;
            this.NuevaTarjeta.Text = "Cargar Nueva Tarjeta";
            this.NuevaTarjeta.UseVisualStyleBackColor = true;
            this.NuevaTarjeta.Click += new System.EventHandler(this.NuevaTarjeta_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(372, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Cuotas";
            // 
            // vencimientoTarjeta
            // 
            this.vencimientoTarjeta.CustomFormat = "MM/yy";
            this.vencimientoTarjeta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vencimientoTarjeta.Location = new System.Drawing.Point(375, 86);
            this.vencimientoTarjeta.Name = "vencimientoTarjeta";
            this.vencimientoTarjeta.Size = new System.Drawing.Size(91, 20);
            this.vencimientoTarjeta.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(191, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Codigo de Seguridad";
            // 
            // codigoTarjeta
            // 
            this.codigoTarjeta.Location = new System.Drawing.Point(194, 38);
            this.codigoTarjeta.Name = "codigoTarjeta";
            this.codigoTarjeta.Size = new System.Drawing.Size(144, 20);
            this.codigoTarjeta.TabIndex = 5;
            this.codigoTarjeta.TextChanged += new System.EventHandler(this.codigoTarjeta_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tipo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(372, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Vencimiento";
            // 
            // numTarjeta
            // 
            this.numTarjeta.Location = new System.Drawing.Point(18, 86);
            this.numTarjeta.Name = "numTarjeta";
            this.numTarjeta.Size = new System.Drawing.Size(144, 20);
            this.numTarjeta.TabIndex = 1;
            this.numTarjeta.TextChanged += new System.EventHandler(this.numTarjeta_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // Volver
            // 
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(23, 456);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(99, 41);
            this.Volver.TabIndex = 2;
            this.Volver.Text = "Atras";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.button1_Click);
            // 
            // Comprar
            // 
            this.Comprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comprar.Location = new System.Drawing.Point(368, 456);
            this.Comprar.Name = "Comprar";
            this.Comprar.Size = new System.Drawing.Size(108, 41);
            this.Comprar.TabIndex = 3;
            this.Comprar.Text = "PAGAR";
            this.Comprar.UseVisualStyleBackColor = true;
            this.Comprar.Click += new System.EventHandler(this.Comprar_Click);
            // 
            // LimpiarTodo
            // 
            this.LimpiarTodo.Location = new System.Drawing.Point(128, 456);
            this.LimpiarTodo.Name = "LimpiarTodo";
            this.LimpiarTodo.Size = new System.Drawing.Size(108, 41);
            this.LimpiarTodo.TabIndex = 4;
            this.LimpiarTodo.Text = "Limpiar Todo";
            this.LimpiarTodo.UseVisualStyleBackColor = true;
            this.LimpiarTodo.Click += new System.EventHandler(this.LimpiarTodo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarPorCliente);
            this.groupBox1.Controls.Add(this.dniNum);
            this.groupBox1.Controls.Add(this.tipo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 242);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // BuscarPorCliente
            // 
            this.BuscarPorCliente.Location = new System.Drawing.Point(13, 130);
            this.BuscarPorCliente.Name = "BuscarPorCliente";
            this.BuscarPorCliente.Size = new System.Drawing.Size(114, 37);
            this.BuscarPorCliente.TabIndex = 5;
            this.BuscarPorCliente.Text = "Buscar";
            this.BuscarPorCliente.UseVisualStyleBackColor = true;
            this.BuscarPorCliente.Click += new System.EventHandler(this.BuscarPorCliente_Click);
            // 
            // dniNum
            // 
            this.dniNum.Location = new System.Drawing.Point(13, 97);
            this.dniNum.Name = "dniNum";
            this.dniNum.Size = new System.Drawing.Size(114, 20);
            this.dniNum.TabIndex = 4;
            this.dniNum.TextChanged += new System.EventHandler(this.dniNum_TextChanged);
            // 
            // tipo
            // 
            this.tipo.FormattingEnabled = true;
            this.tipo.Location = new System.Drawing.Point(13, 54);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(114, 21);
            this.tipo.TabIndex = 3;
            this.tipo.SelectedIndexChanged += new System.EventHandler(this.tipo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de Documento";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Nuevo);
            this.groupBox3.Controls.Add(this.tipo2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.fechaNacimiento);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ActualizarDatos);
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
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(135, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 211);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Cliente";
            // 
            // Nuevo
            // 
            this.Nuevo.Location = new System.Drawing.Point(261, 133);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(75, 69);
            this.Nuevo.TabIndex = 17;
            this.Nuevo.Text = "Cargar Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // tipo2
            // 
            this.tipo2.FormattingEnabled = true;
            this.tipo2.Location = new System.Drawing.Point(140, 35);
            this.tipo2.Name = "tipo2";
            this.tipo2.Size = new System.Drawing.Size(98, 21);
            this.tipo2.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tipo Documento";
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
            this.telefono.Location = new System.Drawing.Point(12, 183);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 20);
            this.telefono.TabIndex = 11;
            this.telefono.TextChanged += new System.EventHandler(this.telefono_TextChanged);
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Apellido";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.total);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(6, 387);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 56);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pago";
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.MintCream;
            this.total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.total.Location = new System.Drawing.Point(225, 19);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(100, 16);
            this.total.TabIndex = 1;
            this.total.TextChanged += new System.EventHandler(this.total_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label16.Location = new System.Drawing.Point(101, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Importe a abonar: ";
            // 
            // PagoConTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(511, 509);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LimpiarTodo);
            this.Controls.Add(this.Comprar);
            this.Controls.Add(this.Volver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PagoConTarjeta";
            this.Text = "Carga de datos para pago con tarjeta";
            this.Load += new System.EventHandler(this.FormEfectivo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button Comprar;
        private System.Windows.Forms.Button ActualizarDatos;
        private System.Windows.Forms.ComboBox cuotas;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button NuevaTarjeta;
        private System.Windows.Forms.DateTimePicker vencimientoTarjeta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox codigoTarjeta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox numTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LimpiarTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BuscarPorCliente;
        private System.Windows.Forms.TextBox dniNum;
        private System.Windows.Forms.ComboBox tipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox tipo2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaNacimiento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox tipoT;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Label label16;
    }
}