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
using System.Data.SqlClient;
using AerolineaFrba.Inicio_Aplicacion;



namespace AerolineaFrba.Generacion_Viaje
{
    public partial class FormGenerarViaje : Form
    {

        public FormGenerarViaje()
        {
            InitializeComponent();
        }

  
        private void button3_Click(object sender, EventArgs e)
        {
             //HACER: FALTA VALIDAR QUE FECHA SALIDA, FECHA LLEGADA Y FECHA LLEGADA ESTIMADA SEAN MAYORES A GETTIME!!
          
            DateTime fechaSistema = DateTime.Now;
            int diferenciaDias = fechaLlegadaEstimada.Value.Day - fechaSalida.Value.Day;  
            {
                //valida que no supere 24 hs el vuelo y sean mayores a hoy
                if ((fechaSalida.Value.Year == fechaLlegadaEstimada.Value.Year) &&
                (fechaSalida.Value.Month == fechaLlegadaEstimada.Value.Month) &&
                (diferenciaDias <= 1) &&
                (fechaSalida.Value.Year >= fechaSistema.Year) &&
                (fechaSalida.Value.Month >= fechaSistema.Month) &&
                (fechaSalida.Value.Day >= fechaSistema.Day) &&
                (fechaLlegadaEstimada.Value.Year >= fechaSistema.Year) &&
                (fechaLlegadaEstimada.Value.Month >= fechaSistema.Month) &&
                (fechaLlegadaEstimada.Value.Day >= fechaSistema.Day))
                {

                    LlenarComboBoxAeronaves();
                    label4.Visible = true;
                    comboBoxAeronaves.Visible = true;
                }
                else
                {
                    MessageBox.Show("Entre la Fecha Salida y Fecha Llegada Estimada no puede haber mas de 24 hs. Tampoco se puede generar un viaje con fecha anterior a " + fechaSistema + "", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxAeronaves.Visible = false;
                    datos.Visible = false;
                    label4.Visible = false;
                }
            }
        }

        private void fechaLlegada_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fechaLLegadaEstimada_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAeronaves.SelectedIndex != -1)
            { 
                datos.Visible = true;
                cargarGridCiudades();
            }
              else
                datos.Visible = false;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
            this.Hide();
            inicioF.ShowDialog();
            inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }
         

       

        private void FormGenerarViaje_Load_1(object sender, EventArgs e)
        {
            
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;
            label4.Visible = false;
            comboBoxAeronaves.Visible = false;
            label5.Visible = false;
            datos.Visible = false;
       
        }

        private void fechaSalida_ValueChanged(object sender, EventArgs e)
        {
               
        }

               

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {
           
           
            //obtiene el ruta_codigo seleccionado por el usuario para generar el viaje 
            int rutaCodigo;
            rutaCodigo = Convert.ToInt32(datos.Rows[e.RowIndex].Cells[1].Value.ToString());

            //obtener datos de ruta
            int rutaServicioId;
            Query qry3 = new Query("SELECT RUTA_SERVICIO FROM DJML.RUTAS WHERE RUTA_CODIGO = '" + rutaCodigo + "'");
            rutaServicioId = (int)qry3.ObtenerUnicoCampo();
  
            //obtener datos aeronave
            int servicioAeronave;
            Query qry4 = new Query("select AERO_SERVICIO_ID from djml.AERONAVES WHERE AERO_MATRICULA = '" + comboBoxAeronaves.SelectedValue  + "'");
            servicioAeronave = (int)qry4.ObtenerUnicoCampo();

            if (servicioAeronave == rutaServicioId)
            {   
                
                //HACER: CORREGIR INSERCION EN FECHAS QUE ESTA ROMPIENDO

                //hace la insercion en la base de datos del nuevo viaje generado
                string sql1 = "INSERT INTO DJML.VIAJES (VIAJE_FECHA_SALIDA, VIAJE_FECHA_LLEGADA, VIAJE_FECHA_LLEGADA_ESTIMADA, VIAJE_AERO_ID, VIAJE_RUTA_ID)"
                                + "values ('" + fechaSalida.Value.ToShortDateString() + "','"+null+"' ,'" + fechaLlegadaEstimada.Value.ToShortDateString() + "', '" + comboBoxAeronaves.SelectedValue.ToString() + "', " + rutaCodigo + ")";
                Query qry = new Query(sql1);
                qry.pComando = sql1;
                qry.Ejecutar();
                
                MessageBox.Show("Viaje Generado Correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //Lo envia a form Funcionalidades
                FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
                this.Hide();
                inicioF.ShowDialog();
                inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
            }
            else 
            {
                MessageBox.Show("No coinciden el Tipo de Servicio de la Aeronave con el Servicio de la Ruta de Vuelo. ¡Seleccione otra opcion!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
   
        }

      
      

        public void LlenarComboBoxAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct AERO_MATRICULA from DJML.AERONAVES a where a.AERO_BAJA_FUERA_SERVICIO = 0 and a.AERO_BAJA_VIDA_UTIL = 0 and a.AERO_MATRICULA not in (select v.VIAJE_AERO_ID from DJML.VIAJES v where datepart(YEAR,VIAJE_FECHA_SALIDA) = '" + fechaSalida.Value.Year + "' and DATEPART(MONTH,VIAJE_FECHA_SALIDA) = '" + fechaSalida.Value.Month + "' and DATEPART(DAY,VIAJE_FECHA_SALIDA) =  '" + fechaSalida.Value.Day + "' and DATEPART(YEAR,VIAJE_FECHA_LLEGADA_ESTIMADA) = '" + fechaLlegadaEstimada.Value.Year + "' and DATEPART(MONTH,VIAJE_FECHA_LLEGADA_ESTIMADA) = '" + fechaLlegadaEstimada.Value.Month + "'  and DATEPART(DAY,VIAJE_FECHA_LLEGADA_ESTIMADA) =  '" + fechaLlegadaEstimada.Value.Day + "')", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = null;

            comboBoxAeronaves.Visible = false;
        }

       private void cargarGridCiudades()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

        
            Query qry3 = new Query("SELECT R.RUTA_CODIGO, C1.CIUD_DETALLE AS ORIGEN, C2.CIUD_DETALLE AS DESTINO FROM DJML.RUTAS R JOIN DJML.TRAMOS T ON R.RUTA_TRAMO = T.TRAMO_ID JOIN DJML.CIUDADES C1 ON T.TRAMO_CIUDAD_ORIGEN = C1.CIUD_ID JOIN DJML.CIUDADES C2 ON T.TRAMO_CIUDAD_DESTINO = C2.CIUD_ID ");
            datos.DataSource = qry3.ObtenerDataTable();
  
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    


        }
    }



