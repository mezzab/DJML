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
            this.labelDetalle = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.tipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emptyCanjes = new System.Windows.Forms.Label();
            this.emptyMillas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsultaMillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridConsultaMillas.Location = new System.Drawing.Point(36, 140);
            this.dataGridConsultaMillas.Name = "dataGridConsultaMillas";
            this.dataGridConsultaMillas.Size = new System.Drawing.Size(292, 150);
            this.dataGridConsultaMillas.TabIndex = 4;
            // 
            // labelDetalle
            // 
            this.labelDetalle.AutoSize = true;
            this.labelDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.labelDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDetalle.Location = new System.Drawing.Point(525, 38);
            this.labelDetalle.Name = "labelDetalle";
            this.labelDetalle.Size = new System.Drawing.Size(55, 17);
            this.labelDetalle.TabIndex = 5;
            this.labelDetalle.Text = "Total :";
            this.labelDetalle.Click += new System.EventHandler(this.label2_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(320, 318);
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(412, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(292, 150);
            this.dataGridView1.TabIndex = 10;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Location = new System.Drawing.Point(586, 26);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(97, 31);
            this.labelTotal.TabIndex = 11;
            this.labelTotal.Text = "Total :";
            this.labelTotal.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Millas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(409, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Canjes";
            // 
            // emptyCanjes
            // 
            this.emptyCanjes.AutoSize = true;
            this.emptyCanjes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.emptyCanjes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.emptyCanjes.Location = new System.Drawing.Point(513, 195);
            this.emptyCanjes.Name = "emptyCanjes";
            this.emptyCanjes.Size = new System.Drawing.Size(0, 31);
            this.emptyCanjes.TabIndex = 15;
            this.emptyCanjes.Visible = false;
            // 
            // emptyMillas
            // 
            this.emptyMillas.AutoSize = true;
            this.emptyMillas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.emptyMillas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.emptyMillas.Location = new System.Drawing.Point(132, 195);
            this.emptyMillas.Name = "emptyMillas";
            this.emptyMillas.Size = new System.Drawing.Size(0, 31);
            this.emptyMillas.TabIndex = 16;
            this.emptyMillas.Visible = false;
            // 
            // ConsultarMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(727, 373);
            this.Controls.Add(this.emptyMillas);
            this.Controls.Add(this.emptyCanjes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoDeDocumento);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelDetalle);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.DataGridView dataGridConsultaMillas;
        private System.Windows.Forms.Label labelDetalle;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.ComboBox tipoDeDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label emptyCanjes;
        private System.Windows.Forms.Label emptyMillas;
    }
}