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
using System.Globalization;
using System.Text.RegularExpressions;


namespace AerolineaFrba.Abm_Aeronave
{
    public partial class modification : Form
    {

        public static string MATR;
        public static string MODE;
        public static int C_BUTA;
        public static int KG_DISP;
        public static string FABR;
        public static string T_SERV;
        public static DateTime FECHA;
      
        public modification()
        {
            InitializeComponent();
        }

        private void modification_Load(object sender, EventArgs e)
        {
            llenarComboTservicio();
            t_servicio.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarComboFabricante();
            fabricantes.DropDownStyle = ComboBoxStyle.DropDownList;

            f_alta.Format = DateTimePickerFormat.Custom;
            f_alta.CustomFormat = "yyyy-dd-MM";

            matricula.Enabled = false;
            cargarAeronaves();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;

            button3.Enabled = false;

            //matricula.Enabled = false;

        }

        private void buscarDatos(string matricula)
        {
            //BUSCA SERVICIO AERONAVE
            
            string sql = "SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS WHERE SERV_ID = (SELECT AERO_SERVICIO_ID FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "')";
            Query qr = new Query(sql);
            object marc = qr.ObtenerUnicoCampo();
            T_SERV = marc.ToString();

            //BUSCA KG_DISPONIBLES DE AERONAVE
            string sql2 = "SELECT AERO_KILOS_DISPONIBLES FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry2 = new Query(sql2);
            KG_DISP = Convert.ToInt32(qry2.ObtenerUnicoCampo());

            //BUSCA MODELO DE AERONAVE
            string sql3 = " SELECT AERO_MODELO FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry3 = new Query(sql3);
            MODE = qry3.ObtenerUnicoCampo().ToString();

            //BUSCA FABRICANTE AERONAVE
            string sql4 = " SELECT AERO_FABRICANTE FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry4 = new Query(sql4);
            string aux = qry4.ObtenerUnicoCampo().ToString();

            string sql44 = " select descripcion from djml.fabricantes where id_fabricante = '" + aux + "'" ;
            Query qry44 = new Query(sql44);
            FABR = qry44.ObtenerUnicoCampo().ToString();


            //BUSCA BUTACAS AERONAVE
            string sql5 = "SELECT COUNT(BXA_AERO_MATRICULA) FROM [DJML].[BUTACA_AERO] WHERE BXA_AERO_MATRICULA = '" + matricula + "'" +
                " group by BXA_AERO_MATRICULA ORDER BY 1 ";
            Query qry5 = new Query(sql5);
            C_BUTA = (Convert.ToInt32(qry5.ObtenerUnicoCampo()) - 1);

            // FECHA
            string sql6 = "SELECT AERO_FECHA_ALTA FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry6 = new Query(sql6);
            object auxiliar = qry6.ObtenerUnicoCampo();

            if (auxiliar == System.DBNull.Value )
            { FECHA = Convert.ToDateTime("1777-7-7"); }
            if (auxiliar != System.DBNull.Value )
            { FECHA = Convert.ToDateTime(auxiliar); }
            
            //*************************************************************************************
            //TODO: Agregar las demas fechas??
            //
            //*************************************************************************************
        }

        private void modificarDatos()
        {

            if (matricula.Text != MATR)
            {
                if (existeAeronave(matricula.Text))
                {
                    avisar("No se pudieron actualizar los nuevos datos ingresados. Ya hay una aeronave con esa matricula.");

                    matricula.Text = MATR; //Esto carga en el textbox la matricula antes seleccionada.

                }
                if (existeAeronave(matricula.Text) == false)
                {   /*no anda
                    string Q = "UPDATE [DJML].[BUTACA_AERO] " +
                               " SET [BXA_AERO_MATRICULA] = '" + matricula.Text + "'" +
                               " where BXA_AERO_MATRICULA ='" + MATR + "'";
                    Query QW = new Query(Q);
                    QW.pComando = Q;
                    QW.Ejecutar();


                    string Q1 = "UPDATE [DJML].[AERONAVES_POR_PERIODOS ] " +
                              " SET [AXP_MATRI_AERONAVE] = '" + matricula.Text + "'" +
                              " where AXP_MATRI_AERONAVE ='" + MATR + "'";
                    Query QW1 = new Query(Q1);
                    QW1.pComando = Q1;
                    QW.Ejecutar();

                    string Q2 = "UPDATE [DJML].[VIAJES] " +
                          " SET [VIAJE_AERO_ID] = '" + matricula.Text + "'" +
                          " where VIAJE_AERO_ID ='" + MATR + "'";
                    Query QW2 = new Query(Q2);
                    QW2.pComando = Q2;
                    QW2.Ejecutar();

                    string Q3 = "UPDATE [DJML].[REGISTRO_DESTINO] " +
                       " SET [RD_AERO_ID] = '" + matricula.Text + "'" +
                       " where RD_AERO_ID ='" + MATR + "'";
                    Query QW3 = new Query(Q3);
                    QW3.pComando = Q3;
                    QW3.Ejecutar();

                    string sqm = "UPDATE [DJML].[AERONAVES] " +
                               " SET [AERO_MATRICULA] = '" + matricula.Text + "'" +
                               " WHERE AERO_MATRICULA = '" + MATR + "'";
                    Query qry = new Query(sqm);
                    qry.pComando = sqm;
                    qry.Ejecutar();

                    string nuevaMatricula = matricula.Text;*/
                    modificarDatos1();

                }
            }

            if (matricula.Text == MATR)
            {

                modificarDatos1();
               
            }

        }

        private void modificarDatos1()
        {

            if (c_butacas.Text != C_BUTA.ToString())
            {
                string borrar = "DELETE FROM [DJML].[BUTACA_AERO] WHERE BXA_AERO_MATRICULA = '" + matricula.Text + "'";
                Query qry = new Query(borrar);
                qry.pComando = borrar;
                qry.Ejecutar();

                for (int i = (Convert.ToInt32(c_butacas.Text) + 1); i >= 1; i--) // lo hago hasta 1, por que los ids empiezan de 1
                {
                    string sql1 = "INSERT INTO [DJML].[BUTACA_AERO] ([BXA_BUTA_ID],[BXA_AERO_MATRICULA] ,[BXA_ESTADO]) VALUES (" + i + ", '" + matricula.Text + "' , 1 ) ";

                    Query qry1 = new Query(sql1);
                    qry1.pComando = sql1;
                    qry1.Ejecutar();
                }

                modificarDatos2();

            } 
            if (c_butacas.Text == C_BUTA.ToString())
            {
                modificarDatos2();
            }

        }

        private void modificarDatos2()
        {

          
            //busco el id del servicio
            string sql = "SELECT SERV_ID FROM DJML.SERVICIOS WHERE SERV_DESCRIPCION = '" + t_servicio.Text + "'";
            Query qr = new Query(sql);
            object marc = qr.ObtenerUnicoCampo();
            string id_servicio = marc.ToString();
            
            // busco el fabricante 
            string sqld = "SELECT ID_FABRICANTE FROM DJML.FABRICANTES WHERE DESCRIPCION = '" + fabricantes.Text + "'";
            Query qrd = new Query(sqld);
            object marcd = qrd.ObtenerUnicoCampo();
            string id_fabricante = marcd.ToString();

            string aux = f_alta.Text + " 00:00:00.000";

            string sq = "UPDATE [DJML].[AERONAVES] " +
                     " SET [AERO_FABRICANTE] = '" + id_fabricante + "' " +
                     " , [AERO_KILOS_DISPONIBLES] = " + kg_disponibles.Text  +
                     " , [AERO_SERVICIO_ID] = '" + id_servicio + "'" +
                     " , [AERO_MODELO] ='" + modelo.Text  + "'" +
                     " , [AERO_FECHA_ALTA] = '" + aux + "'" +
                     " WHERE AERO_MATRICULA = '" + matricula.Text + "'";

            bool esNull = false;
            if (f_alta.Text == "1777-07-07")
            {
                esNull = true; 
            }
             if (f_alta.Text != "1777-07-07")
            {
                esNull = false;
            }        
            if (esNull)
            {
                sq = "UPDATE [DJML].[AERONAVES] " +
                       " SET [AERO_MODELO] = '" + modelo.Text + "'" +
                       " ,[AERO_FABRICANTE] = '" + id_fabricante + "'" +
                       " ,[AERO_KILOS_DISPONIBLES] = " + kg_disponibles.Text + 
                       " ,[AERO_SERVICIO_ID] = '" + id_servicio + "'" +
                       " , [AERO_MODELO] ='" + modelo.Text + "'" +
                       " WHERE AERO_MATRICULA = '" + matricula.Text + "'";
            }
            Query qry1 = new Query(sq);
            qry1.pComando = sq;
            qry1.Ejecutar();

            MessageBox.Show("Se ha modificado correctamente la aeronave! ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
           

        }

        private void completarDatos()
        {

            matricula.Text = MATR;
            kg_disponibles.Text = KG_DISP.ToString();
            modelo.Text = MODE.ToString();
            c_butacas.Text = C_BUTA.ToString();
            fabricantes.Text = FABR;
            t_servicio.Text = T_SERV;
            f_alta.Value = FECHA;
           

        }

        #region Carga de combo box

        //CARGA COMBO AERONAVES
        private void cargarAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select AERO_MATRICULA from DJML.AERONAVES where AERO_BAJA_VIDA_UTIL = 0", conexion);
            da.Fill(ds, "DJML.ROLES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = 1;

        }

        // LLENA COMBO FABRICANTE
        private void llenarComboFabricante()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.FABRICANTES ORDER BY 1", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            fabricantes.DataSource = ds.Tables[0].DefaultView;
            fabricantes.ValueMember = "DESCRIPCION";
            fabricantes.SelectedItem = null;

        }

        // LLENA COMBO TIPO SERVICIO
        private void llenarComboTservicio()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS ORDER BY 1", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            t_servicio.DataSource = ds.Tables[0].DefaultView;
            t_servicio.ValueMember = "SERV_DESCRIPCION";
            t_servicio.SelectedItem = null;

        }
        #endregion

        #region Funciones boludas

        private bool existeAeronave(string matricula)
        {
            string sql = "SELECT AERO_MATRICULA FROM DJML.AERONAVES" +
                          " WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry1 = new Query(sql);
            object obj = qry1.ObtenerUnicoCampo();

            return (obj !=null);
        }

        private void avisarBien(string quePaso)
        {
            MessageBox.Show(quePaso, "SE INFORMA QUE:", MessageBoxButtons.OK, MessageBoxIcon.None);
        }


        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        //CONTROLA QUE NO HAYA CAMPOS SIN DATOS
        private bool controlarQueEsteTodoCompleto()
        {
            bool estanTodos = false;

            if (matricula.Text != "" &&
            modelo.Text != "" &&
            kg_disponibles.Text != "" &&
            c_butacas.Text != "" &&
            fabricantes.Text != "" &&
            t_servicio.Text != "" &&
            f_alta.Text + " 00:00:00.000" != "")
            {
                estanTodos = true;
            }

            return estanTodos;
        }

        private void limpiar()
        {
            this.matricula.Clear();
            this.modelo.Clear();
            this.c_butacas.Clear();
            this.kg_disponibles.Clear();
            f_alta.Value = Convert.ToDateTime("1777-7-7");
            this.t_servicio.SelectedItem = null;
            this.fabricantes.SelectedItem = null;

        }


        #endregion

        #region Eventos

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            limpiar();
        }


        private void matricula_TextChanged(object sender, EventArgs e)
        {

            button3.Enabled = true;
        }

        private void kg_disponibles_TextChanged(object sender, EventArgs e)
        {
            kg_disponibles.Text = Regex.Replace(kg_disponibles.Text, @"[^\d]", "");
        }

        private void c_butacas_TextChanged(object sender, EventArgs e)
        {
            c_butacas.Text = Regex.Replace(c_butacas.Text, @"[^\d]", "");
        }


        #endregion

        #region Botones

        private void button2_Click(object sender, EventArgs e)
        {
            FormAeronave aeronave = new FormAeronave();
            this.Hide();
            aeronave.ShowDialog();
            aeronave = (FormAeronave)this.ActiveMdiChild;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompleto() == false)
            {
                avisarBien("Deben estar todos los datos completados");
            }
            if (controlarQueEsteTodoCompleto())
            {
                modificarDatos();
            }
          

            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            groupBox1.Enabled = true;

            MATR = comboBoxAeronaves.Text;

            buscarDatos(MATR);
            completarDatos();
        
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        #endregion

        #region Funciones Descartadas(por el momento)

        /*
        private void actualizarDatos()
        {
            bool seCambioAlgo = false;

            if (MATR != matricula.Text)
            {
                //SI LA MATRICULA EXISTE NO CONTINUA
                if (existeAeronave(matricula.Text))
                {
                    avisar("No se pudieron actualizar los nuevos datos ingresados. Ya hay una aeronave con esa matricula.");

                    matricula.Text = MATR; //Esto carga en el textbox la matricula antes seleccionada.

                }

                if (existeAeronave(matricula.Text).Equals(false))
                {

                    if (KG_DISP.ToString() != kg_disponibles.Text)
                    {
                        //completar
                        seCambioAlgo = true;
                    }

                    if (MODE != modelo.Text)
                    {
                        //completar
                        seCambioAlgo = true;
                    }

                    if (C_BUTA.ToString() != c_butacas.Text)
                    {
                        //completar
                        //tenes que hacecr un count y todo eso
                        seCambioAlgo = true;
                    }


                    if (T_SERV != t_servicio.Text)
                    {
                        string query = " update [DJML].[AERONAVES] set [AERO_SERVICIO_ID] = (SELECT SERV_ID FROM DJML.SERVICIOS WHERE SERV_DESCRIPCION = '" + t_servicio.Text + "')";

                        new Query(query).Ejecutar();
                        seCambioAlgo = true;
                    }
                    if (FABR != fabricantes.Text)
                    {
                        // string query = " update [DJML].[AERONAVES] set [AERO_SERVICIO_ID] = (SELECT SERV_ID FROM DJML.SERVICIOS WHERE SERV_DESCRIPCION = '" + t_servicio.Text + "')";
                        //igual al pero con fabricante

                        //       new Query(query).Ejecutar();
                        seCambioAlgo = true;
                    }
                }
            }

            if (seCambioAlgo)
            {
                string cambio = "Se han guardado los nuevos datos de la aeronave.";
                modificarDatos();
                avisarBien(cambio);
            }

        }
*/
        #endregion 


    }
}
