using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Devolucion
{
    public partial class Devolucion1 : Form
    {

        public static string codigo_devolucion;

        public Devolucion1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Devolucion0 FormInicioFuncionalidades = new Devolucion0();
            this.Hide();
            FormInicioFuncionalidades.StartPosition = FormStartPosition.CenterScreen;

            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (Devolucion0)this.ActiveMdiChild;
        }

        private void Devolucion1_Load(object sender, EventArgs e)
        {

        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            // insert a djml.cancelaciones
            // guardo el id y el codigo
            
            // agrego campo devolucion_id a cada pasaje seleccionado y cada precio su precio a 
            decimal sumaPreciosPasajesEncomiendasDevueltos;
            // agrego campo devolucion_id a cada encomienda seleccionada y sumo cada precio a 
            //modifico el precio de la compra: le reso esa variable al precio de la compra. 


        }


    }
}
