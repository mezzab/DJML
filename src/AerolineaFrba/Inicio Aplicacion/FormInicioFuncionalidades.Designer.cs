namespace AerolineaFrba.Inicio_Aplicacion
{
    partial class FormInicioFuncionalidades
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
            this.abm_rol = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // abm_rol
            // 
            this.abm_rol.Location = new System.Drawing.Point(45, 39);
            this.abm_rol.Name = "abm_rol";
            this.abm_rol.Size = new System.Drawing.Size(75, 36);
            this.abm_rol.TabIndex = 0;
            this.abm_rol.Text = "ABM ROL";
            this.abm_rol.UseVisualStyleBackColor = true;
            this.abm_rol.Click += new System.EventHandler(this.abm_rol_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "ABM AERONAVE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "AMB RUTAS";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(173, 141);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 36);
            this.button4.TabIndex = 3;
            this.button4.Text = "ABM CIUDAD";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormInicioFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.abm_rol);
            this.Name = "FormInicioFuncionalidades";
            this.Text = "Funcionalidades";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button abm_rol;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}