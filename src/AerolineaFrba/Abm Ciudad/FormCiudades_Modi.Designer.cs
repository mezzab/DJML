namespace AerolineaFrba.Abm_Ciudad
{
    partial class FormCiudades_Modi
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
            this.volver = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.nuevoNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(102, 116);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 0;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(22, 37);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(47, 13);
            this.label.TabIndex = 6;
            this.label.Text = "Nombre:";
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(183, 72);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 4;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.darBaja_Click);
            // 
            // nuevoNombre
            // 
            this.nuevoNombre.Location = new System.Drawing.Point(75, 34);
            this.nuevoNombre.Name = "nuevoNombre";
            this.nuevoNombre.Size = new System.Drawing.Size(183, 20);
            this.nuevoNombre.TabIndex = 7;
            // 
            // FormCiudades_Modi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.nuevoNombre);
            this.Controls.Add(this.label);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.volver);
            this.Name = "FormCiudades_Modi";
            this.Text = "Modificion de Ciudad";
            this.Load += new System.EventHandler(this.FormCiudades_Modi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.TextBox nuevoNombre;
    }
}