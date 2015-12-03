namespace AerolineaFrba.Login_Usuario
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.txtPassw = new System.Windows.Forms.TextBox();
            this.bnSalir = new System.Windows.Forms.Button();
            this.bnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(103, 20);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(100, 20);
            this.txtUsu.TabIndex = 2;
            this.txtUsu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPassw
            // 
            this.txtPassw.Location = new System.Drawing.Point(103, 56);
            this.txtPassw.Name = "txtPassw";
            this.txtPassw.Size = new System.Drawing.Size(100, 20);
            this.txtPassw.TabIndex = 3;
            this.txtPassw.TextChanged += new System.EventHandler(this.txtPassw_TextChanged);
            // 
            // bnSalir
            // 
            this.bnSalir.Location = new System.Drawing.Point(44, 92);
            this.bnSalir.Name = "bnSalir";
            this.bnSalir.Size = new System.Drawing.Size(75, 33);
            this.bnSalir.TabIndex = 5;
            this.bnSalir.Text = "Salir";
            this.bnSalir.UseVisualStyleBackColor = true;
            this.bnSalir.Click += new System.EventHandler(this.bnSalir_Click);
            // 
            // bnAceptar
            // 
            this.bnAceptar.Location = new System.Drawing.Point(128, 92);
            this.bnAceptar.Name = "bnAceptar";
            this.bnAceptar.Size = new System.Drawing.Size(75, 33);
            this.bnAceptar.TabIndex = 6;
            this.bnAceptar.Text = "Aceptar";
            this.bnAceptar.UseVisualStyleBackColor = true;
            this.bnAceptar.Click += new System.EventHandler(this.bnAceptar_Click_Login);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(245, 137);
            this.Controls.Add(this.bnAceptar);
            this.Controls.Add(this.bnSalir);
            this.Controls.Add(this.txtPassw);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Inicie sesion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.TextBox txtPassw;
        private System.Windows.Forms.Button bnSalir;
        private System.Windows.Forms.Button bnAceptar;
    }
}