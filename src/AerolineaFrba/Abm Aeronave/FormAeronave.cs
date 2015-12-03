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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAeronave));
            this.bnAlta = new System.Windows.Forms.Button();
            this.bnBaja = new System.Windows.Forms.Button();
            this.bnModif = new System.Windows.Forms.Button();
            this.bnVolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnAlta
            // 
            this.bnAlta.Location = new System.Drawing.Point(101, 34);
            this.bnAlta.Name = "bnAlta";
            this.bnAlta.Size = new System.Drawing.Size(75, 23);
            this.bnAlta.TabIndex = 0;
            this.bnAlta.Text = "Alta";
            this.bnAlta.UseVisualStyleBackColor = true;
            this.bnAlta.Click += new System.EventHandler(this.bnAlta_Click);
            // 
            // bnBaja
            // 
            this.bnBaja.Location = new System.Drawing.Point(101, 74);
            this.bnBaja.Name = "bnBaja";
            this.bnBaja.Size = new System.Drawing.Size(75, 23);
            this.bnBaja.TabIndex = 1;
            this.bnBaja.Text = "Baja";
            this.bnBaja.UseVisualStyleBackColor = true;
            this.bnBaja.Click += new System.EventHandler(this.bnBaja_Click);
            // 
            // bnModif
            // 
            this.bnModif.Location = new System.Drawing.Point(101, 114);
            this.bnModif.Name = "bnModif";
            this.bnModif.Size = new System.Drawing.Size(75, 23);
            this.bnModif.TabIndex = 2;
            this.bnModif.Text = "Modificacion";
            this.bnModif.UseVisualStyleBackColor = true;
            this.bnModif.Click += new System.EventHandler(this.bnModif_Click);
            // 
            // bnVolver
            // 
            this.bnVolver.Location = new System.Drawing.Point(101, 227);
            this.bnVolver.Name = "bnVolver";
            this.bnVolver.Size = new System.Drawing.Size(75, 23);
            this.bnVolver.TabIndex = 3;
            this.bnVolver.Text = "Volver";
            this.bnVolver.UseVisualStyleBackColor = true;
            this.bnVolver.Click += new System.EventHandler(this.bnVolver_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Listado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAeronave
            // 
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnVolver);
            this.Controls.Add(this.bnModif);
            this.Controls.Add(this.bnBaja);
            this.Controls.Add(this.bnAlta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAeronave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM AERONAVE";
            this.Load += new System.EventHandler(this.FormAeronave_Load);
            this.ResumeLayout(false);

        }

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



        private void bnBaja_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAeronaveBaja frm = new FormAeronaveBaja();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void bnModif_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form frm = new modification();
            frm.ShowDialog();
            frm = (modification)this.ActiveMdiChild;
        }

        private void bnAlta_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAeronaveAlta frm = new FormAeronaveAlta();
            frm.ShowDialog();
            this.Visible = true;
        
        }

        private Button button1;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AeronaveListado frm = new AeronaveListado();
            frm.ShowDialog();
            this.Visible = true;
        }
        
    }
}
