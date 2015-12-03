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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarMillas));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.botonConsultar = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGridView();
            this.labelDetalle = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.tipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalMillas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(352, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Documento";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBoxDNI.Location = new System.Drawing.Point(355, 71);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(132, 23);
            this.textBoxDNI.TabIndex = 1;
            // 
            // botonConsultar
            // 
            this.botonConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.botonConsultar.Location = new System.Drawing.Point(554, 54);
            this.botonConsultar.Name = "botonConsultar";
            this.botonConsultar.Size = new System.Drawing.Size(132, 40);
            this.botonConsultar.TabIndex = 3;
            this.botonConsultar.Text = "Consultar";
            this.botonConsultar.UseVisualStyleBackColor = true;
            this.botonConsultar.Click += new System.EventHandler(this.botonConsultar_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid1.Location = new System.Drawing.Point(15, 141);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(792, 165);
            this.dataGrid1.TabIndex = 4;
            // 
            // labelDetalle
            // 
            this.labelDetalle.AutoSize = true;
            this.labelDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.labelDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDetalle.Location = new System.Drawing.Point(283, 342);
            this.labelDetalle.Name = "labelDetalle";
            this.labelDetalle.Size = new System.Drawing.Size(245, 17);
            this.labelDetalle.TabIndex = 5;
            this.labelDetalle.Text = "Total de millas en el ultimo año :";
            this.labelDetalle.Click += new System.EventHandler(this.labelDetalle_Click);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(15, 330);
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
            this.tipoDeDocumento.Location = new System.Drawing.Point(154, 71);
            this.tipoDeDocumento.Name = "tipoDeDocumento";
            this.tipoDeDocumento.Size = new System.Drawing.Size(132, 21);
            this.tipoDeDocumento.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(151, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Millas";
            // 
            // totalMillas
            // 
            this.totalMillas.BackColor = System.Drawing.Color.MintCream;
            this.totalMillas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalMillas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.totalMillas.Location = new System.Drawing.Point(534, 343);
            this.totalMillas.Name = "totalMillas";
            this.totalMillas.Size = new System.Drawing.Size(153, 16);
            this.totalMillas.TabIndex = 13;
            this.totalMillas.TextChanged += new System.EventHandler(this.totalMillas_TextChanged);
            // 
            // ConsultarMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(813, 397);
            this.Controls.Add(this.totalMillas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tipoDeDocumento);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelDetalle);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.botonConsultar);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarMillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulte Millas";
            this.Load += new System.EventHandler(this.ConsultarMillas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Button botonConsultar;
        private System.Windows.Forms.DataGridView dataGrid1;
        private System.Windows.Forms.Label labelDetalle;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.ComboBox tipoDeDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalMillas;
    }
}