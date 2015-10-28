using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class FormCompra2 : Form
    {
        public static Boolean tipoPasaje = true;
        public static bool esModificar = false;

        public FormCompra2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCompra1 volver = new FormCompra1();
            this.Hide();
            volver.ShowDialog();
            volver = (FormCompra1)this.ActiveMdiChild;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormPasaje enc = new FormPasaje();
            this.Hide();
            enc.ShowDialog();
            enc = (FormPasaje)this.ActiveMdiChild;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CompraEncomienda Pasaje = new CompraEncomienda();
            this.Hide();
            Pasaje.ShowDialog();
            Pasaje = (CompraEncomienda)this.ActiveMdiChild;

            
          
        }

        private void FormCompra2_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FormCompra1.viajeID.ToString());
        }

        /*private void button4_Click_1(object sender, EventArgs e) // esto es solo para probar, despues vuela. 
        {
            Query qry10 = new Query("SELECT VIAJE_AERO_ID FROM DJML.VIAJES WHERE VIAJE_ID =" + "'"+FormCompra1.viajeID+"'");

            string aeroID = (string)qry10.ObtenerUnicoCampo();
            MessageBox.Show("El numero de matricula de la aeronave que realizara el viaje es:" + aeroID , "Consulta de matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show(FormCompra1.viajeID.ToString());
        }*/
    }
}
