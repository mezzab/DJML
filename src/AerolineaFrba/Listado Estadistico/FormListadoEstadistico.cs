using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Properties;
using AerolineaFrba.Inicio_Aplicacion;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class FormListadoEstadistico : Form
    {
        public FormListadoEstadistico()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
        
        }

        private void FormListadoEstadistico_Load(object sender, EventArgs e)
        {
            txtAnio.Focus();
            llenarComboBoxTrimestre();
            comboBoxTrimestre.DropDownStyle = ComboBoxStyle.DropDownList;
            primerFiltro.Enabled = false;
            segundoFiltro.Enabled = false;
            tercerFiltro.Enabled = false;
            cuartoFiltro.Enabled = false;
            quintoFiltro.Enabled = false;
        
        }


        private void llenarComboBoxTrimestre()
        {
            //CARGA COMBOBOX TRIMESTRE
            comboBoxTrimestre.Items.Add("PRIMER TRIMESTRE");
            comboBoxTrimestre.Items.Add("SEGUNDO TRIMESTRE");
            comboBoxTrimestre.Items.Add("TERCER TRIMESTRE");
            comboBoxTrimestre.Items.Add("CUARTO TRIMESTRE");

        }

        private bool faltaElegirTrimestreYAnio()
        {
            return ((comboBoxTrimestre.Text == "") && (txtAnio.SelectedText == ""));
        }

        private void txtAnio_TextChanged(object sender, EventArgs e)
        {
            if(!faltaElegirTrimestreYAnio())
            {
                primerFiltro.Enabled = true;
                segundoFiltro.Enabled = true;
                tercerFiltro.Enabled = true;
                cuartoFiltro.Enabled = true;
                quintoFiltro.Enabled = true;  
            }else 
            {
                primerFiltro.Enabled = false;
                segundoFiltro.Enabled = false;
                tercerFiltro.Enabled = false;
                cuartoFiltro.Enabled = false;
                quintoFiltro.Enabled = false;
            }

        }
        

        private void comboBoxTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!faltaElegirTrimestreYAnio())
            {
                primerFiltro.Enabled = true;
                segundoFiltro.Enabled = true;
                tercerFiltro.Enabled = true;
                cuartoFiltro.Enabled = true;
                quintoFiltro.Enabled = true;  
            }else 
            {
                primerFiltro.Enabled = false;
                segundoFiltro.Enabled = false;
                tercerFiltro.Enabled = false;
                cuartoFiltro.Enabled = false;
                quintoFiltro.Enabled = false;
            }

        }

        private void primerFiltro_Click(object sender, EventArgs e)
        {
            //Top 5 de los destinos con más pasajes comprados.


      //    string listado = "SELECT * FROM DJML.CIUDADES";
                /*         
            -----comienzo listado Top 5 de los destinos con más pasajes comprados.
            select c.CIUD_DETALLE,p.PASA_VIAJE_ID,COUNT(p.PASA_VIAJE_ID) from djml.PASAJES p
            join djml.VIAJES v on p.PASA_VIAJE_ID = v.VIAJE_ID
            join djml.RUTAS r on v.VIAJE_RUTA_ID = r.RUTA_CODIGO
            join djml.TRAMOS t on r.RUTA_TRAMO = t.TRAMO_ID
            join djml.CIUDADES c on t.TRAMO_CIUDAD_DESTINO = c.CIUD_ID
            group by p.PASA_VIAJE_ID, c.CIUD_DETALLE

            Query qry = new Query(listado);
            datos.DataSource = qry.ObtenerDataTable();
                */    
         }

        private void segundoFiltro_Click(object sender, EventArgs e)
        {
            //Top 5 de los destinos con aeronaves más vacías.
        }

        private void tercerFiltro_Click(object sender, EventArgs e)
        {
            //Top 5 de los Clientes con más puntos acumulados a la fecha
        }

        private void cuartoFiltro_Click(object sender, EventArgs e)
        {
            //Top 5 de los destinos con pasajes cancelados.
        }

        private void quintoFiltro_Click(object sender, EventArgs e)
        {
            //Top 5 de las aeronaves con mayor cantidad de días fuera de servicio.
        }
    }
}



