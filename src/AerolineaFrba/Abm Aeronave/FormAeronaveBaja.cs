using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba.Properties;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormAeronaveBaja : Form
    {
        public static string tipo;

        public FormAeronaveBaja()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAeronave aero = new FormAeronave();
            this.Hide();
            aero.ShowDialog();
            aero = (FormAeronave)this.ActiveMdiChild;

        }

        private void FormAeronaveBaja_Load(object sender, EventArgs e)
        {
            comboBoxTipoBaja.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoBaja.Items.Add("COMPLETÓ VIDA UTIL");
            comboBoxTipoBaja.Items.Add("FUERA DE SERVICIO");
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBoxTipoBaja.Text == "COMPLETÓ VIDA UTIL")
            {

                tipo = "VIDA";
                this.Visible = false;
                FormBajaCompletoVidaUtil frm = new FormBajaCompletoVidaUtil();
                frm.ShowDialog();
                this.Visible = true;
            }
            else
            if(comboBoxTipoBaja.Text == "FUERA DE SERVICIO")
            {
                tipo = "SERVICIO";
                this.Visible = false;
                FormBajaFueraServicio frm = new FormBajaFueraServicio();
                frm.ShowDialog();
                this.Visible = true;
            }
              

        }

        private void comboBoxTipoBaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
