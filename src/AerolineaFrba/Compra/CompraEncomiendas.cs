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
    public partial class CompraEncomiendas : Form
    {
        public static DataTable tablaEnco = new DataTable();
        public static int identificador = 1;

        public static bool esNuevo = true;
        public static bool esLaPrimeraVez = true;

        public static int cantidadEncomiendasCargadas = 0;
       
        public static string kilosEncomienda = "";
     
        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;


        public CompraEncomiendas()
        {
            InitializeComponent();
        }

        private void CompraEncomiendas_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
