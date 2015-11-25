namespace AerolineaFrba.Devolucion
{
    partial class Devolucion1
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
            this.motivo = new System.Windows.Forms.RichTextBox();
            this.Siguiente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el motivo de esta devolución:";
            // 
            // motivo
            // 
            this.motivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.motivo.Location = new System.Drawing.Point(17, 41);
            this.motivo.MaxLength = 255;
            this.motivo.Name = "motivo";
            this.motivo.Size = new System.Drawing.Size(291, 151);
            this.motivo.TabIndex = 1;
            this.motivo.Text = "";
            this.motivo.TextChanged += new System.EventHandler(this.motivo_TextChanged);
            // 
            // Siguiente
            // 
            this.Siguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Siguiente.Location = new System.Drawing.Point(98, 200);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(209, 49);
            this.Siguiente.TabIndex = 2;
            this.Siguiente.Text = "Finalizar devolución";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Location = new System.Drawing.Point(16, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Devolucion1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Siguiente);
            this.Controls.Add(this.motivo);
            this.Controls.Add(this.label1);
            this.Name = "Devolucion1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución de pasaje/encomienda";
            this.Load += new System.EventHandler(this.Devolucion1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox motivo;
        private System.Windows.Forms.Button Siguiente;
        private System.Windows.Forms.Button button1;
    }
}