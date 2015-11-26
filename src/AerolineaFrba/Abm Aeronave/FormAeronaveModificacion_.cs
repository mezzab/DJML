using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormAeronaveModificacion_ : Form
    {
        public FormAeronaveModificacion_()
        {
            InitializeComponent();
        }
     
        public int condicion;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAeronave aeronave = new FormAeronave();
            this.Hide();
            aeronave.ShowDialog();
            aeronave = (FormAeronave)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            this.matri.Clear();
            this.modelo.Clear();
            this.fab.Clear();
            this.c_butacas.Clear();
            this.kg_disp.Clear();
            this.f_alta = null;
            this.f_baja_aero = null;
            this.f_alta_aero = null;
            this.t_servicio.SelectedItem = null;

        }

        private void mode_TextChanged(object sender, EventArgs e)
        {

        }

        private void f_alta_ValueChanged(object sender, EventArgs e)
        {
            //largo maximo matricula
            modelo.MaxLength = 10;
        }

        private void matri_TextChanged(object sender, EventArgs e)
        {
            //largo maximo matricula
            matri.MaxLength = 7;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Valida la falta de campos
        private void faltanDatos()
        {
            if (matri.Text.Length.Equals(0) || modelo.Text.Length.Equals(0) || fab.Text.Length.Equals(0) | t_servicio.SelectedItem != null || c_butacas.Text.Length.Equals(0) || kg_disp.Text.Length.Equals(0) || f_baja_aero != null || f_alta != null )
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bool error1 = f_alta.Value.Date < DateTime.Now.Date;
            bool error2 = f_baja_aero.Value.Date < DateTime.Now.Date;
            bool error3 = f_alta_aero.Value.Date < DateTime.Now.Date;
            if (error1 || error2 || error3)
                {
                MessageBox.Show("Fecha incorrecta");
                }
            
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            faltanDatos();
        }


        

        private void kg_disp_(object sender, EventArgs e)
        {
            //valida maximo 999 kg disponibles
            kg_disp.MaxLength = 4;
        }

        

    }
}
