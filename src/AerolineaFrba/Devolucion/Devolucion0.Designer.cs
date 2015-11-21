namespace AerolineaFrba.Devolucion
{
    partial class Devolucion0
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
            this.Siguiente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pasajes1 = new System.Windows.Forms.DataGridView();
            this.Agregar = new System.Windows.Forms.Button();
            this.codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.encomiendas = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasajes1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encomiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // Siguiente
            // 
            this.Siguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Siguiente.Location = new System.Drawing.Point(359, 455);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(301, 49);
            this.Siguiente.TabIndex = 7;
            this.Siguiente.Text = "Devolver los pasajes/encomiendas marcados";
            this.Siguiente.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pasajes1);
            this.groupBox1.Location = new System.Drawing.Point(13, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 178);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de pasajes a devolver";
            // 
            // pasajes1
            // 
            this.pasajes1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pasajes1.Location = new System.Drawing.Point(11, 19);
            this.pasajes1.Name = "pasajes1";
            this.pasajes1.Size = new System.Drawing.Size(630, 149);
            this.pasajes1.TabIndex = 3;
            this.pasajes1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pasajes1_CellClick);
            this.pasajes1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pasajes1_CellContentClick);
            // 
            // Agregar
            // 
            this.Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar.Location = new System.Drawing.Point(359, 16);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(301, 49);
            this.Agregar.TabIndex = 2;
            this.Agregar.Text = "Buscar Items ";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // codigo
            // 
            this.codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.codigo.Location = new System.Drawing.Point(209, 30);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(144, 23);
            this.codigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingrese el codigo de compra:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(16, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.encomiendas);
            this.groupBox2.Location = new System.Drawing.Point(13, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 178);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de pasajes a devolver";
            // 
            // encomiendas
            // 
            this.encomiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.encomiendas.Location = new System.Drawing.Point(11, 19);
            this.encomiendas.Name = "encomiendas";
            this.encomiendas.Size = new System.Drawing.Size(630, 149);
            this.encomiendas.TabIndex = 3;
            this.encomiendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.encomiendas_CellClick);
            this.encomiendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.encomiendas_CellContentClick);
            // 
            // Devolucion0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Siguiente);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.codigo);
            this.Controls.Add(this.label1);
            this.Name = "Devolucion0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución";
            this.Load += new System.EventHandler(this.Devolucion0_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pasajes1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.encomiendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Siguiente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView pasajes1;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView encomiendas;
    }
}