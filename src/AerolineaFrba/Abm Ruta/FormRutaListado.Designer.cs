namespace AerolineaFrba.Abm_Ruta
{
    partial class FormRutaListado
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
            this.button_volver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            this.SuspendLayout();
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(255, 292);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(75, 23);
            this.button_volver.TabIndex = 3;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 274);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rutas Aereas";
            // 
            // datos
            // 
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(6, 19);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(583, 249);
            this.datos.TabIndex = 0;
            this.datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // FormRutaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 327);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_volver);
            this.Name = "FormRutaListado";
            this.Text = "ABM RUTA - LISTADO";
            this.Load += new System.EventHandler(this.FormRutaListado_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView datos;
    }
}