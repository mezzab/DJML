using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class FormRutaModificacion2 : Form
    {
        public FormRutaModificacion2()
        {
            InitializeComponent();
        }

        private void FormRutaModificacion2_Load(object sender, EventArgs e)
        {
            //comboBox_origen
            string qry_origen = "SELECT CIUD_DETALLE, CIUD_ID FROM DJML.CIUDADES ORDER BY 1";
            DataTable origen_data = new Query(qry_origen).ObtenerDataTable();

            //comboBox_destino
            string qry_destino = "SELECT CIUD_DETALLE, CIUD_ID FROM DJML.CIUDADES ORDER BY 1";
            DataTable destino_data = new Query(qry_destino).ObtenerDataTable();

            //comboBox_servicio
            string qry_servicio = "SELECT SERV_DESCRIPCION, SERV_ID FROM DJML.SERVICIOS ORDER BY 1";
            DataTable servicio_data = new Query(qry_servicio).ObtenerDataTable();
        }
    }
}
