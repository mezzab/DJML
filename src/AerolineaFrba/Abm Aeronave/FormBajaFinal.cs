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
    public partial class FormBajaFinal : Form
    {
        public FormBajaFinal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (FormAeronaveBaja.tipo == "VIDA")
            {
                Form funcionalidades = new FormBajaCompletoVidaUtil();
                this.Hide();
                funcionalidades.ShowDialog();
                funcionalidades = (FormBajaCompletoVidaUtil)this.ActiveMdiChild;
            }
            if (FormAeronaveBaja.tipo == "SERVICIO")
            {
                Form funcionalidades = new FormBajaFueraServicio();
                this.Hide();
                funcionalidades.ShowDialog();
                funcionalidades = (FormBajaFueraServicio)this.ActiveMdiChild;
            }
        }

        private void FormBajaFinal_Load(object sender, EventArgs e)
        {
            comboBoxTipoBaja.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoBaja.Items.Add("Cancelar todos los viajes.");
            comboBoxTipoBaja.Items.Add("Suplantar la aeronave por otra.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxTipoBaja.Text == "Cancelar todos los viajes.")
            {
                if (FormAeronaveBaja.tipo == "VIDA")
                {
                    /*TODO: 
                    FormBajaCompletoVidaUtil.MATRICULAVIDA;
                    */
                }
                
                if (FormAeronaveBaja.tipo == "SERVICIO")
                {
                    /* TODO:
                 * estas son las variables que necesitas para hacer todo
                FormBajaFueraServicio.MATRICULASERVICIO;
                FormBajaFueraServicio.inicio; //fecha inicio
                FormBajaFueraServicio.fin; // fecha fin
                 */
                }


                MessageBox.Show("Aeronave inhabilitada exitosamente y se cancelaron todos los viajes de la aeronave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (comboBoxTipoBaja.Text == "Suplantar la aeronave por otra.")
            {
              
                
                if (FormAeronaveBaja.tipo == "VIDA")
                {
                    /*TODO:
                    FormBajaCompletoVidaUtil.MATRICULAVIDA;
                    */
                }

                if (FormAeronaveBaja.tipo == "SERVICIO")
                {

                    /* TODO:
                     * estas son las variables que necesitas para hacer todo
                    FormBajaFueraServicio.MATRICULASERVICIO;
                    FormBajaFueraServicio.inicio; //fecha inicio
                    FormBajaFueraServicio.fin; // fecha fin
                     */
                }

                MessageBox.Show("Aeronave inhabilitada exitosamente y se suplantaron los viajes por otra aeronave de la flota", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
