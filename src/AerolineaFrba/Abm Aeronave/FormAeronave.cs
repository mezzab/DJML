using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Inicio_Aplicacion;
using AerolineaFrba.Abm_Aeronave;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormAeronave : Form
    {
        public FormAeronave()
        {
            InitializeComponent();
        }

        private Button bnAlta;
        private Button bnBaja;
        private Button bnModif;
        private Button bnVolver;

        private void InitializeComponent()
        {
            this.bnAlta = new System.Windows.Forms.Button();
            this.bnBaja = new System.Windows.Forms.Button();
            this.bnModif = new System.Windows.Forms.Button();
            this.bnVolver = new System.Windows.Forms.Button();
            this.bnListado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnAlta
            // 
            this.bnAlta.Location = new System.Drawing.Point(36, 42);
            this.bnAlta.Name = "bnAlta";
            this.bnAlta.Size = new System.Drawing.Size(75, 23);
            this.bnAlta.TabIndex = 0;
            this.bnAlta.Text = "Alta";
            this.bnAlta.UseVisualStyleBackColor = true;
            this.bnAlta.Click += new System.EventHandler(this.bnAlta_Click);
            // 
            // bnBaja
            // 
            this.bnBaja.Location = new System.Drawing.Point(174, 42);
            this.bnBaja.Name = "bnBaja";
            this.bnBaja.Size = new System.Drawing.Size(75, 23);
            this.bnBaja.TabIndex = 1;
            this.bnBaja.Text = "Baja";
            this.bnBaja.UseVisualStyleBackColor = true;
            this.bnBaja.Click += new System.EventHandler(this.bnBaja_Click);
            // 
            // bnModif
            // 
            this.bnModif.Location = new System.Drawing.Point(36, 90);
            this.bnModif.Name = "bnModif";
            this.bnModif.Size = new System.Drawing.Size(75, 23);
            this.bnModif.TabIndex = 2;
            this.bnModif.Text = "Modificacion";
            this.bnModif.UseVisualStyleBackColor = true;
            // 
            // bnVolver
            // 
            this.bnVolver.Location = new System.Drawing.Point(102, 187);
            this.bnVolver.Name = "bnVolver";
            this.bnVolver.Size = new System.Drawing.Size(75, 23);
            this.bnVolver.TabIndex = 3;
            this.bnVolver.Text = "Volver";
            this.bnVolver.UseVisualStyleBackColor = true;
            this.bnVolver.Click += new System.EventHandler(this.bnVolver_Click);
            // 
            // bnListado
            // 
            this.bnListado.Location = new System.Drawing.Point(174, 90);
            this.bnListado.Name = "bnListado";
            this.bnListado.Size = new System.Drawing.Size(75, 23);
            this.bnListado.TabIndex = 9;
            this.bnListado.Text = "Listado";
            this.bnListado.UseVisualStyleBackColor = true;
            this.bnListado.Click += new System.EventHandler(this.bnListado_Click);
            // 
            // FormAeronave
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bnListado);
            this.Controls.Add(this.bnVolver);
            this.Controls.Add(this.bnModif);
            this.Controls.Add(this.bnBaja);
            this.Controls.Add(this.bnAlta);
            this.Name = "FormAeronave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM AERONAVE";
            this.Load += new System.EventHandler(this.FormAeronave_Load);
            this.ResumeLayout(false);

        }

        private Button bnListado;

        private void FormAeronave_Load(object sender, EventArgs e)
        {
        }

        private void bnListado_Click(object sender, EventArgs e)
        {

        }

        private void bnVolver_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades aero = new FormInicioFuncionalidades();
            this.Hide();
            aero.ShowDialog();
            aero = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void bnAlta_Click(object sender, EventArgs e)
        {

        }

        private void bnBaja_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAeronaveBaja frm = new FormAeronaveBaja();
            frm.ShowDialog();
            this.Visible = true;
        }

        
    }
}
