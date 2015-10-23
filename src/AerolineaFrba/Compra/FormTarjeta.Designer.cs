namespace AerolineaFrba.Compra
{
    partial class FormEfectivo
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
            this.numeroDeDocumento = new System.Windows.Forms.TextBox();
            this.tipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LimpiarCliente = new System.Windows.Forms.Button();
            this.ActualizarDatos = new System.Windows.Forms.Button();
            this.NuevoCliente = new System.Windows.Forms.Button();
            this.fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Volver = new System.Windows.Forms.Button();
            this.Comprar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numTarjeta = new System.Windows.Forms.TextBox();
            this.tipoTarjeta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.codigoTarjeta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.vencimientoTarjeta = new System.Windows.Forms.DateTimePicker();
            this.NuevaTarjeta = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cuotasTarjeta = new System.Windows.Forms.ComboBox();
            this.LimpiarTodo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BuscarPorCliente);
            this.groupBox1.Controls.Add(this.numeroDeDocumento);
            this.groupBox1.Controls.Add(this.tipoDeDocumento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 271);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BuscarPorCliente
            // 
            this.BuscarPorCliente.Location = new System.Drawing.Point(9, 154);
            this.BuscarPorCliente.Name = "BuscarPorCliente";
            this.BuscarPorCliente.Size = new System.Drawing.Size(114, 33);
            this.BuscarPorCliente.TabIndex = 5;
            this.BuscarPorCliente.Text = "Buscar";
            this.BuscarPorCliente.UseVisualStyleBackColor = true;
            // 
            // numeroDeDocumento
            // 
            this.numeroDeDocumento.Location = new System.Drawing.Point(9, 112);
            this.numeroDeDocumento.Name = "numeroDeDocumento";
            this.numeroDeDocumento.Size = new System.Drawing.Size(114, 20);
            this.numeroDeDocumento.TabIndex = 4;
            // 
            // tipoDeDocumento
            // 
            this.tipoDeDocumento.FormattingEnabled = true;
            this.tipoDeDocumento.Location = new System.Drawing.Point(9, 56);
            this.tipoDeDocumento.Name = "tipoDeDocumento";
            this.tipoDeDocumento.Size = new System.Drawing.Size(114, 21);
            this.tipoDeDocumento.TabIndex = 3;
            this.tipoDeDocumento.SelectedIndexChanged += new System.EventHandler(this.tipoDeDocumento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de Documento";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LimpiarCliente);
            this.groupBox3.Controls.Add(this.ActualizarDatos);
            this.groupBox3.Controls.Add(this.NuevoCliente);
            this.groupBox3.Controls.Add(this.fechaNacimiento);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.telefono);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.mail);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numero);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.direccion);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nombre);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.apellido);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(137, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 234);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Cliente";
            // 
            // LimpiarCliente
            // 
            this.LimpiarCliente.Location = new System.Drawing.Point(268, 168);
            this.LimpiarCliente.Name = "LimpiarCliente";
            this.LimpiarCliente.Size = new System.Drawing.Size(75, 36);
            this.LimpiarCliente.TabIndex = 15;
            this.LimpiarCliente.Text = "Limpiar";
            this.LimpiarCliente.UseVisualStyleBackColor = true;
            this.LimpiarCliente.Click += new System.EventHandler(this.LimpiarCliente_Click);
            // 
            // ActualizarDatos
            // 
            this.ActualizarDatos.Location = new System.Drawing.Point(268, 113);
            this.ActualizarDatos.Name = "ActualizarDatos";
            this.ActualizarDatos.Size = new System.Drawing.Size(75, 36);
            this.ActualizarDatos.TabIndex = 14;
            this.ActualizarDatos.Text = "Actualizar Datos";
            this.ActualizarDatos.UseVisualStyleBackColor = true;
            // 
            // NuevoCliente
            // 
            this.NuevoCliente.Location = new System.Drawing.Point(268, 61);
            this.NuevoCliente.Name = "NuevoCliente";
            this.NuevoCliente.Size = new System.Drawing.Size(75, 36);
            this.NuevoCliente.TabIndex = 13;
            this.NuevoCliente.Text = "Nuevo";
            this.NuevoCliente.UseVisualStyleBackColor = true;
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaNacimiento.Location = new System.Drawing.Point(143, 142);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(99, 20);
            this.fechaNacimiento.TabIndex = 5;
            this.fechaNacimiento.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Fecha de nacimiento";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(143, 93);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(100, 20);
            this.telefono.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Telefono";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(143, 44);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(100, 20);
            this.mail.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Mail";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(12, 196);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(100, 20);
            this.numero.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Numero de Documento";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(12, 142);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(100, 20);
            this.direccion.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Direccion";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(12, 93);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(12, 44);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 20);
            this.apellido.TabIndex = 1;
            this.apellido.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellido";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cuotasTarjeta);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.NuevaTarjeta);
            this.groupBox2.Controls.Add(this.vencimientoTarjeta);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.codigoTarjeta);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tipoTarjeta);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numTarjeta);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarjeta";
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(90, 420);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(99, 41);
            this.Volver.TabIndex = 2;
            this.Volver.Text = "Atras";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.button1_Click);
            // 
            // Comprar
            // 
            this.Comprar.Location = new System.Drawing.Point(203, 420);
            this.Comprar.Name = "Comprar";
            this.Comprar.Size = new System.Drawing.Size(108, 41);
            this.Comprar.TabIndex = 3;
            this.Comprar.Text = "Comprar";
            this.Comprar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // numTarjeta
            // 
            this.numTarjeta.Location = new System.Drawing.Point(18, 42);
            this.numTarjeta.Name = "numTarjeta";
            this.numTarjeta.Size = new System.Drawing.Size(144, 20);
            this.numTarjeta.TabIndex = 1;
            // 
            // tipoTarjeta
            // 
            this.tipoTarjeta.Location = new System.Drawing.Point(18, 94);
            this.tipoTarjeta.Name = "tipoTarjeta";
            this.tipoTarjeta.Size = new System.Drawing.Size(144, 20);
            this.tipoTarjeta.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tipo";
            // 
            // codigoTarjeta
            // 
            this.codigoTarjeta.Location = new System.Drawing.Point(195, 94);
            this.codigoTarjeta.Name = "codigoTarjeta";
            this.codigoTarjeta.Size = new System.Drawing.Size(144, 20);
            this.codigoTarjeta.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(192, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Fecha de Vencimiento";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(192, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Codigo de Seguridad";
            // 
            // vencimientoTarjeta
            // 
            this.vencimientoTarjeta.CustomFormat = "MM/yy";
            this.vencimientoTarjeta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vencimientoTarjeta.Location = new System.Drawing.Point(195, 42);
            this.vencimientoTarjeta.Name = "vencimientoTarjeta";
            this.vencimientoTarjeta.Size = new System.Drawing.Size(144, 20);
            this.vencimientoTarjeta.TabIndex = 7;
            // 
            // NuevaTarjeta
            // 
            this.NuevaTarjeta.Location = new System.Drawing.Point(377, 26);
            this.NuevaTarjeta.Name = "NuevaTarjeta";
            this.NuevaTarjeta.Size = new System.Drawing.Size(91, 36);
            this.NuevaTarjeta.TabIndex = 8;
            this.NuevaTarjeta.Text = "Nueva";
            this.NuevaTarjeta.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(374, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Cuotas";
            // 
            // cuotasTarjeta
            // 
            this.cuotasTarjeta.FormattingEnabled = true;
            this.cuotasTarjeta.Location = new System.Drawing.Point(377, 93);
            this.cuotasTarjeta.Name = "cuotasTarjeta";
            this.cuotasTarjeta.Size = new System.Drawing.Size(91, 21);
            this.cuotasTarjeta.TabIndex = 10;
            // 
            // LimpiarTodo
            // 
            this.LimpiarTodo.Location = new System.Drawing.Point(327, 420);
            this.LimpiarTodo.Name = "LimpiarTodo";
            this.LimpiarTodo.Size = new System.Drawing.Size(108, 41);
            this.LimpiarTodo.TabIndex = 4;
            this.LimpiarTodo.Text = "Limpiar";
            this.LimpiarTodo.UseVisualStyleBackColor = true;
            this.LimpiarTodo.Click += new System.EventHandler(this.LimpiarTodo_Click);
            // 
            // FormEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 470);
            this.Controls.Add(this.LimpiarTodo);
            this.Controls.Add(this.Comprar);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormEfectivo";
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.FormEfectivo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button Comprar;
        private System.Windows.Forms.Button BuscarPorCliente;
        private System.Windows.Forms.TextBox numeroDeDocumento;
        private System.Windows.Forms.ComboBox tipoDeDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button LimpiarCliente;
        private System.Windows.Forms.Button ActualizarDatos;
        private System.Windows.Forms.Button NuevoCliente;
        private System.Windows.Forms.ComboBox cuotasTarjeta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button NuevaTarjeta;
        private System.Windows.Forms.DateTimePicker vencimientoTarjeta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox codigoTarjeta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tipoTarjeta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox numTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LimpiarTodo;
    }
}