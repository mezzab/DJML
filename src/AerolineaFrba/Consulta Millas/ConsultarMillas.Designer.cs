namespace AerolineaFrba.Consulta_Millas
{
    partial class ConsultarMillas
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
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonConsultar = new System.Windows.Forms.Button();
            this.dataGridConsultaMillas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.tipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsultaMillas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Documento";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBoxDNI.Location = new System.Drawing.Point(12, 73);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(171, 23);
            this.textBoxDNI.TabIndex = 1;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(217, 27);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(87, 23);
            this.botonLimpiar.TabIndex = 2;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonConsultar
            // 
            this.botonConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.botonConsultar.Location = new System.Drawing.Point(216, 56);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(88, 40);
            this.botonConsultar.TabIndex = 3;
            this.botonConsultar.Text = "Consultar";
            this.botonConsultar.UseVisualStyleBackColor = true;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // dataGridConsultaMillas
            // 
            this.dataGridConsultaMillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConsultaMillas.Location = new System.Drawing.Point(12, 114);
            this.dataGridConsultaMillas.Name = "dataGridConsultaMillas";
            this.dataGridConsultaMillas.Size = new System.Drawing.Size(292, 150);
            this.dataGridConsultaMillas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(150, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.Color.MintCream;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBoxTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxTotal.Location = new System.Drawing.Point(204, 274);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(100, 23);
            this.textBoxTotal.TabIndex = 6;
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(117, 318);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(92, 43);
            this.botonVolver.TabIndex = 7;
            this.botonVolver.Text = "Atras";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // tipoDeDocumento
            // 
            this.tipoDeDocumento.FormattingEnabled = true;
            this.tipoDeDocumento.Location = new System.Drawing.Point(12, 29);
            this.tipoDeDocumento.Name = "tipoDeDocumento";
            this.tipoDeDocumento.Size = new System.Drawing.Size(171, 21);
            this.tipoDeDocumento.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de Documento";
            // 
            // ConsultarMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(321, 373);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoDeDocumento);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridConsultaMillas);
            this.Controls.Add(this.botonConsultar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.label1);
            this.Name = "ConsultarMillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulte Millas";
            this.Load += new System.EventHandler(this.ConsultarMillas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsultaMillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.DataGridView dataGridConsultaMillas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.ComboBox tipoDeDocumento;
        private System.Windows.Forms.Label label3;
    }
}