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
        public static string FECHA;
      
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

            string sql44 = " select descripcion from djml.fabricantes where id_fabricante = '" + aux + "'";
            Query qry44 = new Query(sql44);
            FABR = qry44.ObtenerUnicoCampo().ToString();


            //BUSCA BUTACAS AERONAVE
            string sql5 = "SELECT COUNT(BXA_AERO_MATRICULA) FROM [DJML].[BUTACA_AERO] WHERE BXA_AERO_MATRICULA = '" + matricula + "'" +
                " group by BXA_AERO_MATRICULA ORDER BY 1 ";
            Query qry5 = new Query(sql5);
            C_BUTA = (Convert.ToInt32(qry5.ObtenerUnicoCampo()) - 1);

            // FECHA
            //string sql6 = "ACA VA EL SELECT A FECHA";
            //Query qry6 = new Query(sql6);
            //FECHA = qry6.ObtenerDataTable().ToString() + " 00:00:00.000";

            
            //*************************************************************************************
            //TODO: Falta la fecha
            //O 'LAS' fechas, depende si agregas las de baja, que a mi entender hay que ponerlas
            //*************************************************************************************
        }

        private void modificarDatos()
        {
           
            if (existeAeronave(matricula.Text).Equals(false))
            {

                if (existeAeronave(matricula.Text))
                {
                    avisar("No se pudieron actualizar los nuevos datos ingresados. Ya hay una aeronave con esa matricula.");

                    matricula.Text = MATR; //Esto carga en el textbox la matricula antes seleccionada.

                }
                if (existeAeronave(matricula.Text)==false)
                {
                     string sqm = "UPDATE [DJML].[AERONAVES] " + 
                                " ,[AERO_MATRICULA] = '" + matricula.Text + "'" +
                                " WHERE AERO_MATRICULA = '" + MATR + "'";
                     Query qry = new Query(sqm);
                     qry.pComando = sqm;
                     qry.Ejecutar();

                     string nuevaMatricula = matricula.Text;

                }
                //busco el id del servicio
                string sql = "SELECT SERV_ID FROM DJML.SERVICIOS WHERE SERV_DESCRIPCION = '" + t_servicio.Text + "'";
                Query qr = new Query(sql);
                object marc = qr.ObtenerUnicoCampo();
                string id_servicio = marc.ToString();

                //vas a tener que hacer algo igual a lo de arriva (servicio) para fabricante

                //variable auxiliar para ingresar bien la fecha 
                string aux = f_alta.Text + " 00:00:00.000";

                //Modifica la aeronave
                string sq = "UPDATE [DJML].[AERONAVES] " + 
                             " ,[AERO_MODELO] = '" + modelo.Text + "'" +
                             " ,[AERO_FABRICANTE] = '" + "'" + //completar
                             " ,[AERO_KILOS_DISPONIBLES] = '" + "'" + //completar
                             " ,[AERO_SERVICIO_ID] = '" + id_servicio + "'" +
                             " ,[AERO_BAJA_FUERA_SERVICIO] ='" + "'" + //decidir
                             " ,[AERO_BAJA_VIDA_UTIL] = '" + "'" + //decidir
                             " ,[AERO_FECHA_BAJA_DEF] = '" + "'" + //decidir
                             " ,[AERO_FECHA_ALTA] = '" + aux +"'" + //controlar que guarde bien
                             " WHERE AERO_MATRICULA = '" + matricula.Text + "'";

                //*************************************************************************************
                //TODO: COMPLETAR DATOS DEL UPDATE ...  Cuidado con fabricante y servicio que son ids
                // Tambien tenes que terminar la funcionalidad y agregar las fechas los dos tipos de baja... Esto te lo dejo para que lo hagas como creas mas correcto
                // tenes dos maneras: 1) o lo dejas asi y borras los campos de baja y fechas de bajas en el update de arriba 
                //                    2) agregas las fechas de baja en el form y trabajas con las tablas periodos_de_inactividad y aeronaves_por_periodos.

                //*************************************************************************************

                Query qry1 = new Query(sq);
                qry1.pComando = sq;
                qry1.Ejecutar();

                MessageBox.Show("Se ha modificado correctamente la aeronave! ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiar();

            }
        }

        private void completarDatos()
        {

            matricula.Text = MATR;
            kg_disponibles.Text = KG_DISP.ToString();
            modelo.Text = MODE.ToString();
            c_butacas.Text = C_BUTA.ToString();
            fabricantes.Text = FABR;
            t_servicio.Text = T_SERV;


            //tipoServicio.Text = DESCRIPCION_SERVICIO.ToString();

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

            return (obj != null);
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
            this.f_alta = null;
            this.t_servicio.SelectedItem = null;
            this.fabricantes.SelectedItem = null;

        }


        #endregion

        #region Eventos

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void matricula_TextChanged(object sender, EventArgs e)
        {

            button3.Enabled = true;
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
         
            if (controlarQueEsteTodoCompleto())
            {
                modificarDatos();
            }
            if (controlarQueEsteTodoCompleto() == false)
            {
                avisarBien("Deben estar todos los datos completados");
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MATR = comboBoxAeronaves.Text;

            buscarDatos(comboBoxAeronaves.Text);
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
