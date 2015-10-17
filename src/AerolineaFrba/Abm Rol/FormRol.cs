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
using AerolineaFrba.Abm_Rol;


namespace AerolineaFrba.Abm_Rol
{
    public partial class FormRol : Form
    {
        public FormRol()
        {
            InitializeComponent();
        }

        private Button bnAlta;
        private Button bnBaja;
        private Button bnListado;
        private Button bnModificacion;
        private Button button1;
        
        private void InitializeComponent()
        {
            this.bnAlta = new System.Windows.Forms.Button();
            this.bnBaja = new System.Windows.Forms.Button();
            this.bnListado = new System.Windows.Forms.Button();
            this.bnModificacion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnAlta
            // 
            this.bnAlta.Location = new System.Drawing.Point(96, 41);
            this.bnAlta.Name = "bnAlta";
            this.bnAlta.Size = new System.Drawing.Size(75, 23);
            this.bnAlta.TabIndex = 0;
            this.bnAlta.Text = "Alta";
            this.bnAlta.UseVisualStyleBackColor = true;
            this.bnAlta.Click += new System.EventHandler(this.bnAlta_Click);
            // 
            // bnBaja
            // 
            this.bnBaja.Location = new System.Drawing.Point(96, 84);
            this.bnBaja.Name = "bnBaja";
            this.bnBaja.Size = new System.Drawing.Size(75, 23);
            this.bnBaja.TabIndex = 1;
            this.bnBaja.Text = "Baja";
            this.bnBaja.UseVisualStyleBackColor = true;
            this.bnBaja.Click += new System.EventHandler(this.bnBaja_Click_1);
            // 
            // bnListado
            // 
            this.bnListado.Location = new System.Drawing.Point(96, 172);
            this.bnListado.Name = "bnListado";
            this.bnListado.Size = new System.Drawing.Size(75, 23);
            this.bnListado.TabIndex = 2;
            this.bnListado.Text = "Listado";
            this.bnListado.UseVisualStyleBackColor = true;
            this.bnListado.Click += new System.EventHandler(this.bnListado_Click_1);
            // 
            // bnModificacion
            // 
            this.bnModificacion.Location = new System.Drawing.Point(96, 126);
            this.bnModificacion.Name = "bnModificacion";
            this.bnModificacion.Size = new System.Drawing.Size(75, 23);
            this.bnModificacion.TabIndex = 3;
            this.bnModificacion.Text = "Modificacion";
            this.bnModificacion.UseVisualStyleBackColor = true;
            this.bnModificacion.Click += new System.EventHandler(this.bnModificacion_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRol
            // 
            this.ClientSize = new System.Drawing.Size(284, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnModificacion);
            this.Controls.Add(this.bnListado);
            this.Controls.Add(this.bnBaja);
            this.Controls.Add(this.bnAlta);
            this.Name = "FormRol";
            this.Text = "ABM ROL";
            this.Load += new System.EventHandler(this.FormRol_Load);
            this.ResumeLayout(false);

        }

        private void bnBaja_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRolBaja frm = new FormRolBaja();
            frm.ShowDialog();
            this.Visible = true;

        }

        private void bnAlta_Click(object sender, EventArgs e)
        {  
            this.Visible = false;
            FormRolAlta frm = new FormRolAlta();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void bnModificacion_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            FormRolModificacion frm = new FormRolModificacion();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void bnListado_Click_1(object sender, EventArgs e)
        {

            this.Visible = false;
            FormRolConsulta frm = new FormRolConsulta();
            frm.ShowDialog();
            this.Visible = true;
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
            
        }

        private void FormRol_Load(object sender, EventArgs e)
        {

        }

    }
}
