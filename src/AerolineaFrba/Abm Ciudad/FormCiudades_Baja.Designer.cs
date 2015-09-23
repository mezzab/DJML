namespace AerolineaFrba.Abm_Ciudad
{
    partial class FormCiudades_Baja
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
            this.darBaja = new System.Windows.Forms.Button();
            this.BoxCiudades = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(101, 114);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 0;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // darBaja
            // 
            this.darBaja.Location = new System.Drawing.Point(192, 66);
            this.darBaja.Name = "darBaja";
            this.darBaja.Size = new System.Drawing.Size(75, 23);
            this.darBaja.TabIndex = 1;
            this.darBaja.Text = "Dar de baja";
            this.darBaja.UseVisualStyleBackColor = true;
            // 
            // BoxCiudades
            // 
            this.BoxCiudades.FormattingEnabled = true;
            this.BoxCiudades.Location = new System.Drawing.Point(125, 39);
            this.BoxCiudades.Name = "BoxCiudades";
            this.BoxCiudades.Size = new System.Drawing.Size(142, 21);
            this.BoxCiudades.TabIndex = 2;
            this.BoxCiudades.SelectedIndexChanged += new System.EventHandler(this.BoxCiudades_SelectedIndexChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(21, 42);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(98, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Seleccione ciudad:";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormCiudades_Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(this.label);
            this.Controls.Add(this.BoxCiudades);
            this.Controls.Add(this.darBaja);
            this.Controls.Add(this.volver);
            this.Name = "FormCiudades_Baja";
            this.Text = "Baja de ciudad:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button darBaja;
        private System.Windows.Forms.ComboBox BoxCiudades;
        private System.Windows.Forms.Label label;
    }
}