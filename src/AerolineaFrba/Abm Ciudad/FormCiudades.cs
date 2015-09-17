using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class FormCiudades : Form
    {
        public FormCiudades()
        {
            InitializeComponent();
        }

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
            this.alta.Location = new System.Drawing.Point(108, 21);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(75, 23);
            this.alta.TabIndex = 0;
            this.alta.Text = "Alta";
            this.alta.UseVisualStyleBackColor = true;
            this.alta.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Baja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // modificacion
            // 
            this.modificacion.Location = new System.Drawing.Point(108, 107);
            this.modificacion.Name = "modificacion";
            this.modificacion.Size = new System.Drawing.Size(75, 23);
            this.modificacion.TabIndex = 2;
            this.modificacion.Text = "Modificación";
            this.modificacion.UseVisualStyleBackColor = true;
            this.modificacion.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // listado
            // 
            this.listado.Location = new System.Drawing.Point(108, 151);
            this.listado.Name = "listado";
            this.listado.Size = new System.Drawing.Size(75, 23);
            this.listado.TabIndex = 3;
            this.listado.Text = "Listado";
            this.listado.UseVisualStyleBackColor = true;
            this.listado.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(108, 216);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 4;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormCiudades
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.modificacion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.alta);
            this.Name = "FormCiudades";
            this.Text = "ABM Ciudades";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Button alta; //alta

        private void button1_Click(object sender, EventArgs e)
        {
          FormCiudades_Alta alta = new FormCiudades_Alta();
          this.Hide();
          alta.ShowDialog();
          alta = (FormCiudades_Alta)this.ActiveMdiChild;
        }

        private Button button2;//baja

        private void button2_Click(object sender, EventArgs e)
        {
            FormCiudades_Baja baja = new FormCiudades_Baja();
            this.Hide();
            baja.ShowDialog();
            baja = (FormCiudades_Baja)this.ActiveMdiChild;

        }

        private Button modificacion; //mod
       

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormCiudades_Modificacion modificacion = new FormCiudades_Modificacion();
            this.Hide();
            modificacion.ShowDialog();
            modificacion = (FormCiudades_Modificacion)this.ActiveMdiChild;
        }
        private Button listado;//listado
        
        private void button4_Click_1(object sender, EventArgs e)
        {
            FormCiudades_Listado listado = new FormCiudades_Listado();
            this.Hide();
            listado.ShowDialog();
            listado = (FormCiudades_Listado)this.ActiveMdiChild;
        }

        private Button volver;//atras
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
