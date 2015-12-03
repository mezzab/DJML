namespace AerolineaFrba.Canje_Millas
{
    partial class canjeMillas
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
            this.tipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.cantidad = new System.Windows.Forms.TextBox();
            this.productoSeleccionado = new System.Windows.Forms.TextBox();
            this.cantidadLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.canje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipoDeDocumento
            // 
            this.tipoDeDocumento.FormattingEnabled = true;
            this.tipoDeDocumento.Location = new System.Drawing.Point(12, 33);
            this.tipoDeDocumento.Name = "tipoDeDocumento";
            this.tipoDeDocumento.Size = new System.Drawing.Size(129, 21);
            this.tipoDeDocumento.TabIndex = 18;
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonVolver.Location = new System.Drawing.Point(19, 424);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(129, 43);
            this.botonVolver.TabIndex = 17;
            this.botonVolver.Text = "Atras";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBoxDNI.Location = new System.Drawing.Point(165, 33);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(151, 23);
            this.textBoxDNI.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(162, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Numero de Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tipo de Documento";
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridProductos.Location = new System.Drawing.Point(6, 21);
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.Size = new System.Drawing.Size(583, 164);
            this.dataGridProductos.TabIndex = 21;
            this.dataGridProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProductos_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(410, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 40);
            this.button1.TabIndex = 21;
            this.button1.Text = "Ver canjes disponibles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cantidad
            // 
            this.cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidad.Location = new System.Drawing.Point(134, 276);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(123, 22);
            this.cantidad.TabIndex = 23;
            this.cantidad.TextChanged += new System.EventHandler(this.cantidad_TextChanged);
            // 
            // productoSeleccionado
            // 
            this.productoSeleccionado.BackColor = System.Drawing.Color.MintCream;
            this.productoSeleccionado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productoSeleccionado.Location = new System.Drawing.Point(6, 233);
            this.productoSeleccionado.Name = "productoSeleccionado";
            this.productoSeleccionado.Size = new System.Drawing.Size(583, 15);
            this.productoSeleccionado.TabIndex = 24;
            // 
            // cantidadLabel
            // 
            this.cantidadLabel.AutoSize = true;
            this.cantidadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadLabel.Location = new System.Drawing.Point(3, 279);
            this.cantidadLabel.Name = "cantidadLabel";
            this.cantidadLabel.Size = new System.Drawing.Size(125, 16);
            this.cantidadLabel.TabIndex = 25;
            this.cantidadLabel.Text = "Ingrese la cantidad:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cantidad);
            this.groupBox1.Controls.Add(this.productoSeleccionado);
            this.groupBox1.Controls.Add(this.dataGridProductos);
            this.groupBox1.Controls.Add(this.cantidadLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 327);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // canje
            // 
            this.canje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canje.Location = new System.Drawing.Point(457, 424);
            this.canje.Name = "canje";
            this.canje.Size = new System.Drawing.Size(125, 42);
            this.canje.TabIndex = 27;
            this.canje.Text = "Canjear";
            this.canje.UseVisualStyleBackColor = true;
            this.canje.Click += new System.EventHandler(this.canje_Click);
            // 
            // canjeMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(625, 488);
            this.Controls.Add(this.canje);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoDeDocumento);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.label1);
            this.Name = "canjeMillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canje Millas";
            this.Load += new System.EventHandler(this.canjeMillas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tipoDeDocumento;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
      //  private System.Windows.Forms.Button canjear;
        private System.Windows.Forms.DataGridView dataGridProductos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.TextBox cantidad;
        private System.Windows.Forms.TextBox productoSeleccionado;
        private System.Windows.Forms.Label cantidadLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button canje;
    }
}