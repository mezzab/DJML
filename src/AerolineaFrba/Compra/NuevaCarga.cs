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
    public partial class NuevaCarga : Form
    {


        public static DataTable tabla2 = new DataTable();
        public static DataTable tabla = new DataTable();

        public static string butaca = "";
        public static string tipoBucata = "";
        public static string aeroButacaID = "";

        public static string kgs = "";

        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;
        public static string TIPO;

        public static bool esNuevo = true;

        public static int cantidadPasajesCargados = 0;
        public static int cantidadEncomiendasCargados = 0;
        public static int maxPasajes = 10;
        public static int maxEncomiendas = 10;

        public static int idEncomienda = 0;

        public static bool primeraE = true;
        public static bool primerP = true;

        public static decimal precioBasePasaje;
        public static decimal precioBaseEncomienda;
        public static decimal porcentajeServicio;

        public static string IDC;

      

        public NuevaCarga()
        {
            InitializeComponent();
        }

        private void NuevaCarga_Load(object sender, EventArgs e)
        {

        }

        #region Manejo de tablas


        #endregion



        #region Eventos




        #endregion



        #region Funciones Auxliares



        #endregion


    }
}
