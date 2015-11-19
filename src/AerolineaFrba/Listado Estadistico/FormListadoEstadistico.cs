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
            ejecutarPrimerFiltro();
           
         }

        private void segundoFiltro_Click(object sender, EventArgs e)
        {
            ejecutarSegundoFiltro();
        }

        private void tercerFiltro_Click(object sender, EventArgs e)
        {
            ejecutarTercerFiltro();
        }

        private void cuartoFiltro_Click(object sender, EventArgs e)
        {
            ejecutarCuartoFiltro(); 
        }

        private void quintoFiltro_Click(object sender, EventArgs e)
        {
            ejecutarQuintoFiltro();
        }


        private void ejecutarPrimerFiltro()
        {
            //Top 5 de los destinos con más pasajes comprados.

            switch (comboBoxTrimestre.SelectedIndex)
            {
                //"Enero-Febrero-Marzo"
                case 0:
                    string primerTrimestre = "select DISTINCT TOP 5  c.CIUD_DETALLE,COUNT(p.PASA_VIAJE_ID) AS CANTIDAD from djml.PASAJES p join djml.VIAJES v on p.PASA_VIAJE_ID = v.VIAJE_ID join djml.RUTAS r on v.VIAJE_RUTA_ID = r.RUTA_CODIGO join djml.TRAMOS t on r.RUTA_TRAMO = t.TRAMO_ID join djml.CIUDADES c on t.TRAMO_CIUDAD_DESTINO = c.CIUD_ID join djml.COMPRAS com on p.PASA_COMPRA_ID = com.COMPRA_ID WHERE DAY(COM.COMPRA_FECHA) >= 01	AND MONTH(COM.COMPRA_FECHA) <= 03 AND YEAR(COM.COMPRA_FECHA ) =  " + txtAnio.Text + " AND COM.COMPRA_ID NOT IN (SELECT CANC_COMPRA_ID FROM DJML.CANCELACIONES)  group by c.CIUD_DETALLE  ORDER BY 2 desc";
                    Query qry = new Query(primerTrimestre);
                    datos.DataSource = qry.ObtenerDataTable();

                    break;

                //Abril-Mayo-Junio
                case 1:
                    string segundoTrimestre = "select DISTINCT TOP 5  c.CIUD_DETALLE,COUNT(p.PASA_VIAJE_ID) AS CANTIDAD from djml.PASAJES p join djml.VIAJES v on p.PASA_VIAJE_ID = v.VIAJE_ID join djml.RUTAS r on v.VIAJE_RUTA_ID = r.RUTA_CODIGO join djml.TRAMOS t on r.RUTA_TRAMO = t.TRAMO_ID join djml.CIUDADES c on t.TRAMO_CIUDAD_DESTINO = c.CIUD_ID join djml.COMPRAS com on p.PASA_COMPRA_ID = com.COMPRA_ID WHERE DAY(COM.COMPRA_FECHA) >= 01 AND MONTH(COM.COMPRA_FECHA) >= 04 AND MONTH(COM.COMPRA_FECHA) <= 06 AND YEAR(COM.COMPRA_FECHA ) =  " + txtAnio.Text + " AND COM.COMPRA_ID NOT IN (SELECT CANC_COMPRA_ID FROM DJML.CANCELACIONES) group by c.CIUD_DETALLE ORDER BY 2 desc";
                    Query qry2 = new Query(segundoTrimestre);
                    datos.DataSource = qry2.ObtenerDataTable();

                    break;

                //Julio-Agosto-Septiembre
                case 2:
                    string tercerTrimestre = " select DISTINCT TOP 5  c.CIUD_DETALLE,COUNT(p.PASA_VIAJE_ID) AS CANTIDAD from djml.PASAJES p join djml.VIAJES v on p.PASA_VIAJE_ID = v.VIAJE_ID join djml.RUTAS r on v.VIAJE_RUTA_ID = r.RUTA_CODIGO join djml.TRAMOS t on r.RUTA_TRAMO = t.TRAMO_ID join djml.CIUDADES c on t.TRAMO_CIUDAD_DESTINO = c.CIUD_ID join djml.COMPRAS com on p.PASA_COMPRA_ID = com.COMPRA_ID WHERE DAY(COM.COMPRA_FECHA) >= 01 AND MONTH(COM.COMPRA_FECHA) >= 07 AND MONTH(COM.COMPRA_FECHA) <= 09 AND YEAR(COM.COMPRA_FECHA ) =  " + txtAnio.Text + " AND COM.COMPRA_ID NOT IN (SELECT CANC_COMPRA_ID FROM DJML.CANCELACIONES) group by c.CIUD_DETALLE ORDER BY 2 desc";
                    Query qry3 = new Query(tercerTrimestre);
                    datos.DataSource = qry3.ObtenerDataTable();
                    break;

                //Octubre-Noviembre-Diciembre
                case 3:
                    string cuartoTrimestre = " select DISTINCT TOP 5  c.CIUD_DETALLE,COUNT(p.PASA_VIAJE_ID) AS CANTIDAD from djml.PASAJES p join djml.VIAJES v on p.PASA_VIAJE_ID = v.VIAJE_ID join djml.RUTAS r on v.VIAJE_RUTA_ID = r.RUTA_CODIGO join djml.TRAMOS t on r.RUTA_TRAMO = t.TRAMO_ID join djml.CIUDADES c on t.TRAMO_CIUDAD_DESTINO = c.CIUD_ID join djml.COMPRAS com on p.PASA_COMPRA_ID = com.COMPRA_ID WHERE DAY(COM.COMPRA_FECHA) >= 01 AND MONTH(COM.COMPRA_FECHA) >= 10 AND MONTH(COM.COMPRA_FECHA) <= 12 AND YEAR(COM.COMPRA_FECHA ) =  " + txtAnio.Text + " AND COM.COMPRA_ID NOT IN (SELECT CANC_COMPRA_ID FROM DJML.CANCELACIONES) group by c.CIUD_DETALLE ORDER BY 2 desc";
                    Query qry4 = new Query(cuartoTrimestre);
                    datos.DataSource = qry4.ObtenerDataTable();

                    break;

            }

        }

        private void ejecutarSegundoFiltro() 
        {
            //Top 5 de los destinos con aeronaves más vacías.
             switch (comboBoxTrimestre.SelectedIndex)
            {
                //"Enero-Febrero-Marzo"
                case 0:
                    string primerTrimestre = "SELECT TOP 5 C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID, COUNT(BA.BXA_BUTA_ID) CANTIDAD FROM DJML.AERONAVES A "
                    +"JOIN DJML.VIAJES V ON A.AERO_MATRICULA = V.VIAJE_AERO_ID " 
                    +"JOIN DJML.RUTAS R ON R.RUTA_CODIGO = V.VIAJE_RUTA_ID "
                    +" JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID "
                    +" JOIN DJML.CIUDADES C ON T.TRAMO_CIUDAD_DESTINO = C.CIUD_ID "
                    +" JOIN DJML.BUTACA_AERO BA ON A.AERO_MATRICULA = BA.BXA_AERO_MATRICULA"
                    +" WHERE A.AERO_BAJA_VIDA_UTIL = 0 "
                    +" AND  DAY(V.VIAJE_FECHA_SALIDA) >= 01"	
                    +" AND MONTH(V.VIAJE_FECHA_SALIDA) <= 03 "
                    +" AND YEAR(V.VIAJE_FECHA_SALIDA) =  " + txtAnio.Text + ""
                    + " GROUP BY C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID "
                    +" ORDER BY 4 ASC";
                    Query qry = new Query(primerTrimestre);
                    datos.DataSource = qry.ObtenerDataTable();

                    break;

                //Abril-Mayo-Junio
                case 1:
                    string segundoTrimestre = "SELECT TOP 5 C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID, COUNT(BA.BXA_BUTA_ID) CANTIDAD FROM DJML.AERONAVES A"
                    +"JOIN DJML.VIAJES V ON A.AERO_MATRICULA = V.VIAJE_AERO_ID"
                    +"JOIN DJML.RUTAS R ON R.RUTA_CODIGO = V.VIAJE_RUTA_ID"
                    +"JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    +"JOIN DJML.CIUDADES C ON T.TRAMO_CIUDAD_DESTINO = C.CIUD_ID"
                    +"JOIN DJML.BUTACA_AERO BA ON A.AERO_MATRICULA = BA.BXA_AERO_MATRICULA"
                    +"WHERE A.AERO_BAJA_VIDA_UTIL = 0 "
                    +"AND  DAY(V.VIAJE_FECHA_SALIDA) >= 01"
                    +"AND MONTH(V.VIAJE_FECHA_SALIDA) >= 04	"
                    +"AND MONTH(V.VIAJE_FECHA_SALIDA) <= 06 "
                    +"AND YEAR(V.VIAJE_FECHA_SALIDA) =  " + txtAnio.Text + " "
                    +"GROUP BY C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID"
                    +"ORDER BY 4 ASC";
                    Query qry2 = new Query(segundoTrimestre);
                    datos.DataSource = qry2.ObtenerDataTable();

                    break;

                //Julio-Agosto-Septiembre
                case 2:
                    string tercerTrimestre = " SELECT TOP 5 C.CIUD_DETALLE, A.AERO_MATRICULA, V.VIAJE_ID,COUNT(BA.BXA_BUTA_ID) CANTIDAD FROM DJML.AERONAVES A"
                    +"JOIN DJML.VIAJES V ON A.AERO_MATRICULA = V.VIAJE_AERO_ID"
                    +"JOIN DJML.RUTAS R ON R.RUTA_CODIGO = V.VIAJE_RUTA_ID"
                    +"JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    +"JOIN DJML.CIUDADES C ON T.TRAMO_CIUDAD_DESTINO = C.CIUD_ID"
                    +"JOIN DJML.BUTACA_AERO BA ON A.AERO_MATRICULA = BA.BXA_AERO_MATRICULA"
                    +"WHERE A.AERO_BAJA_VIDA_UTIL = 0 "
                    +"AND  DAY(V.VIAJE_FECHA_SALIDA) >= 01"
                    +" AND MONTH(V.VIAJE_FECHA_SALIDA) >= 07	"
                    +" AND MONTH(V.VIAJE_FECHA_SALIDA) <= 09 "
                    +" AND YEAR(V.VIAJE_FECHA_SALIDA) =  " + txtAnio.Text + " "
                    + "GROUP BY C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID"
                    +"ORDER BY 4 ASC";
                     Query qry3 = new Query(tercerTrimestre);
                    datos.DataSource = qry3.ObtenerDataTable();
                    break;

                //Octubre-Noviembre-Diciembre
                case 3:
                    string cuartoTrimestre = "SELECT TOP 5 C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID, COUNT(BA.BXA_BUTA_ID) CANTIDAD FROM DJML.AERONAVES A"
                    +"JOIN DJML.VIAJES V ON A.AERO_MATRICULA = V.VIAJE_AERO_ID"
                    +"JOIN DJML.RUTAS R ON R.RUTA_CODIGO = V.VIAJE_RUTA_ID"
                    +"JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    +"JOIN DJML.CIUDADES C ON T.TRAMO_CIUDAD_DESTINO = C.CIUD_ID"
                    +"JOIN DJML.BUTACA_AERO BA ON A.AERO_MATRICULA = BA.BXA_AERO_MATRICULA"
                    +"WHERE A.AERO_BAJA_VIDA_UTIL = 0 "
                    +"AND  DAY(V.VIAJE_FECHA_SALIDA) >= 01	"
                    +"AND MONTH(V.VIAJE_FECHA_SALIDA) >= 10"
                    +"AND MONTH(V.VIAJE_FECHA_SALIDA) <= 12"
                    +"AND YEAR(V.VIAJE_FECHA_SALIDA) =  " + txtAnio.Text + " "
                    + "GROUP BY C.CIUD_DETALLE, A.AERO_MATRICULA,V.VIAJE_ID"
                    +"ORDER BY 4 ASC";
                    Query qry4 = new Query(cuartoTrimestre);
                    datos.DataSource = qry4.ObtenerDataTable();

                    break;

            }
        }


        private void ejecutarTercerFiltro()
        {
            //Top 5 de los Clientes con más puntos acumulados a la fecha
        }


        private void ejecutarCuartoFiltro()
        {
            //Top 5 de los destinos con pasajes cancelados.
             switch (comboBoxTrimestre.SelectedIndex)
            {
                //"Enero-Febrero-Marzo"
                case 0:
                    string primerTrimestre = "SELECT TOP 5 C1.CIUD_DETALLE, COUNT(CAN.CANC_ID) AS CANTIDAD FROM DJML.CANCELACIONES CAN"
                    +"JOIN DJML.COMPRAS COM ON CAN.CANC_COMPRA_ID = COM.COMPRA_ID"
                    +"JOIN DJML.VIAJES V ON COM.COMPRA_VIAJE_ID = V.VIAJE_ID"
                    +"JOIN DJML.RUTAS R ON V.VIAJE_ID = R.RUTA_CODIGO"
                    +"JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    +"JOIN DJML.CIUDADES C1 ON T.TRAMO_CIUDAD_DESTINO = C1.CIUD_ID"
                    +"WHERE DAY(CAN.CANC_FECHA_DEVOLUCION) >= 1 "
                    +"AND MONTH(CAN.CANC_FECHA_DEVOLUCION) <= 03 "
                    +"AND YEAR(CAN.CANC_FECHA_DEVOLUCION)=  " + txtAnio.Text + " "
                    +"GROUP BY C1.CIUD_DETALLE "
                    +"ORDER BY 2 DESC";
                      Query qry = new Query(primerTrimestre);
                    datos.DataSource = qry.ObtenerDataTable();

                    break;

                //Abril-Mayo-Junio
                case 1:
                    string segundoTrimestre = "SELECT TOP 5 C1.CIUD_DETALLE, COUNT(CAN.CANC_ID) AS CANTIDAD FROM DJML.CANCELACIONES CAN"
                    +"JOIN DJML.COMPRAS COM ON CAN.CANC_COMPRA_ID = COM.COMPRA_ID"
                    +"JOIN DJML.VIAJES V ON COM.COMPRA_VIAJE_ID = V.VIAJE_ID"
                    +"JOIN DJML.RUTAS R ON V.VIAJE_ID = R.RUTA_CODIGO"
                    +"JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    +"JOIN DJML.CIUDADES C1 ON T.TRAMO_CIUDAD_DESTINO = C1.CIUD_ID"
                    +"WHERE DAY(CAN.CANC_FECHA_DEVOLUCION) >= 1 "
                    +"AND MONTH(CAN.CANC_FECHA_DEVOLUCION) >= 04"
                    +"AND MONTH(CAN.CANC_FECHA_DEVOLUCION) <= 06 "
                    +"AND YEAR(CAN.CANC_FECHA_DEVOLUCION)= " + txtAnio.Text + ""
                    +"GROUP BY C1.CIUD_DETALLE "
                    +"ORDER BY 2 DESC";
                    Query qry2 = new Query(segundoTrimestre);
                    datos.DataSource = qry2.ObtenerDataTable();

                    break;

                //Julio-Agosto-Septiembre
                case 2:
                    string tercerTrimestre = " SELECT TOP 5 C1.CIUD_DETALLE, COUNT(CAN.CANC_ID) AS CANTIDAD FROM DJML.CANCELACIONES CAN"
                    + "JOIN DJML.COMPRAS COM ON CAN.CANC_COMPRA_ID = COM.COMPRA_ID"
                    + "JOIN DJML.VIAJES V ON COM.COMPRA_VIAJE_ID = V.VIAJE_ID"
                    + "JOIN DJML.RUTAS R ON V.VIAJE_ID = R.RUTA_CODIGO"
                    + "JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    + "JOIN DJML.CIUDADES C1 ON T.TRAMO_CIUDAD_DESTINO = C1.CIUD_ID"
                    + "WHERE DAY(CAN.CANC_FECHA_DEVOLUCION) >= 1 "
                    + "AND MONTH(CAN.CANC_FECHA_DEVOLUCION) >= 07"
                    + "AND MONTH(CAN.CANC_FECHA_DEVOLUCION) <= 09 "
                    + "AND YEAR(CAN.CANC_FECHA_DEVOLUCION)= " + txtAnio.Text + ""
                    + "GROUP BY C1.CIUD_DETALLE "
                    + "ORDER BY 2 DESC";

                    Query qry3 = new Query(tercerTrimestre);
                    datos.DataSource = qry3.ObtenerDataTable();
                    break;

                //Octubre-Noviembre-Diciembre
                case 3:
                    string cuartoTrimestre = "SELECT TOP 5 C1.CIUD_DETALLE, COUNT(CAN.CANC_ID) AS CANTIDAD FROM DJML.CANCELACIONES CAN"
                    +"JOIN DJML.COMPRAS COM ON CAN.CANC_COMPRA_ID = COM.COMPRA_ID"
                    +"JOIN DJML.VIAJES V ON COM.COMPRA_VIAJE_ID = V.VIAJE_ID"
                    +"JOIN DJML.RUTAS R ON V.VIAJE_ID = R.RUTA_CODIGO"
                    +"JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID"
                    +"JOIN DJML.CIUDADES C1 ON T.TRAMO_CIUDAD_DESTINO = C1.CIUD_ID"
                    +"WHERE DAY(CAN.CANC_FECHA_DEVOLUCION) >= 1 "
                    +"AND MONTH(CAN.CANC_FECHA_DEVOLUCION) >= 10"
                    +"AND MONTH(CAN.CANC_FECHA_DEVOLUCION) <= 12 "
                    +"AND YEAR(CAN.CANC_FECHA_DEVOLUCION)= " + txtAnio.Text + ""
                    +"GROUP BY C1.CIUD_DETALLE "
                    +"ORDER BY 2 DESC";
                    Query qry4 = new Query(cuartoTrimestre);
                    datos.DataSource = qry4.ObtenerDataTable();

                    break;

            }


        }


        private void ejecutarQuintoFiltro()
        {
            //Top 5 de las aeronaves con mayor cantidad de días fuera de servicio.
        }
    }

   
}



