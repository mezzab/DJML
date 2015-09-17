namespace AerolineaFrba.Abm_Ciudad
{
    partial class FormCiudades
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
            this.alta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.modificacion = new System.Windows.Forms.Button();
            this.listado = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // alta
            // 
            this.alta.Location = new System.Drawing.Point(96, 12);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(75, 23);
            this.alta.TabIndex = 0;
            this.alta.Text = "Alta";
            this.alta.UseVisualStyleBackColor = true;
            this.alta.Click += new System.EventHandler(this.alta_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Baja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // modificacion
            // 
            this.modificacion.Location = new System.Drawing.Point(97, 105);
            this.modificacion.Name = "modificacion";
            this.modificacion.Size = new System.Drawing.Size(75, 23);
            this.modificacion.TabIndex = 2;
            this.modificacion.Text = "Modificacion";
            this.modificacion.UseVisualStyleBackColor = true;
            this.modificacion.Click += new System.EventHandler(this.modificacion_Click);
            // 
            // listado
            // 
            this.listado.Location = new System.Drawing.Point(96, 151);
            this.listado.Name = "listado";
            this.listado.Size = new System.Drawing.Size(75, 23);
            this.listado.TabIndex = 3;
            this.listado.Text = "Listado";
            this.listado.UseVisualStyleBackColor = true;
            this.listado.Click += new System.EventHandler(this.listado_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(97, 226);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 4;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // FormCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 261);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.modificacion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.alta);
            this.Name = "FormCiudades";
            this.Text = "FormCiudades";
            this.Load += new System.EventHandler(this.FormCiudades_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button modificacion;
        private System.Windows.Forms.Button listado;
        private System.Windows.Forms.Button volver;
    }
}