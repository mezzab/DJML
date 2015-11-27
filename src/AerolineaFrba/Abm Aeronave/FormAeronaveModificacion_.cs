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
    public partial class FormAeronaveModificacion_ : Form
    {

        public static string MATRICULAPOSTA;

        public static string MATR;
        public static string MODEL;
        public static int C_BUTA;
        public static int KG_DISP;
        public static string FABR;
        //TODO: AGREGAR LAS VARILES QUE FALTAN


        public FormAeronaveModificacion_()
        {
            InitializeComponent();
        }
     
        public int condicion;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAeronave aeronave = new FormAeronave();
            this.Hide();
            aeronave.ShowDialog();
            aeronave = (FormAeronave)this.ActiveMdiChild;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
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

        private void mode_TextChanged(object sender, EventArgs e)
        {

        }

        private void f_alta_ValueChanged(object sender, EventArgs e)
        {
            //largo maximo matricula
            modelo.MaxLength = 10;
        }

        private void matri_TextChanged(object sender, EventArgs e)
        {
            //largo maximo matricula
            matricula.MaxLength = 7;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }



        private void FormAeronaveModificacion__Load(object sender, EventArgs e)
        {
            llenarComboTservicio();
            t_servicio.DropDownStyle = ComboBoxStyle.DropDownList;

            llenarComboFabricante();
            fabricantes.DropDownStyle = ComboBoxStyle.DropDownList;

            f_alta.Format = DateTimePickerFormat.Custom;
            f_alta.CustomFormat = "yyyy-dd-MM";

            cargarAeronaves();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;


        }



        private void cargarAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select AERO_MATRICULA from DJML.AERONAVES where AERO_BAJA_VIDA_UTIL = 0", conexion);
            da.Fill(ds, "DJML.ROLES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = 1 ;
        }

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


        private void t_servicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buscarDatos(string matricula) //completarDatos
        {
            MATR = matricula;

            string sql2 = "SELECT AERO_KILOS_DISPONIBLES FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry2 = new Query(sql2);
            KG_DISP = Convert.ToInt32(qry2.ObtenerUnicoCampo());
            /*
            string sql3 = "SELECT AERO_MODELO FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry3 = new Query(sql3);
            MODEL = qry3.ObtenerUnicoCampo().ToString();
            
            string sql1 = "SELECT DESCRIPCION FROM DJML.FABRICANTES WHERE ID_FABRICANTE = (SELECT AERO_FABRICANTE FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "' ) ";
            Query qry1 = new Query(sql1);
            FABR = qry1.ObtenerUnicoCampo().ToString();
             */



           // PARA CANTIDAD DE BUTACAS, POR EJEMPLO
            // tendrias que hacer un count de djml.aero_butacas filtrando por la matricula y guardarlo en C_BUTA
          
            // y asi con las demas
            //TODO: AGREGAR LOS QUE FALTAN

        }

        private void completarDatos()
        {

            matricula.Text = MATR;
            kg_disponibles.Text = KG_DISP.ToString();
            // c_butacas.Text = C_BUTA.ToString();
            //TODO:AGREGAR LOS QUE FALTAN
        

        }

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarDatos(comboBoxAeronaves.Text);
            completarDatos();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void actualizarDatos()
        {
            bool seCambioAlgo = false;

            if (KG_DISP.ToString() != kg_disponibles.Text )
            {
                string qry = "update [DJML].[AERONAVES] set [AERO_KILOS_DISPONIBLES] = " + kg_disponibles.Text + " where AERO_MATRICULA = '" + MATRICULAPOSTA + "'";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }
            /*.......IF............IF .............IF......... TODO: AGREGAR LOS QUE FALTAN
            if (MODEL != modelo.Text) 
            {
                string qry = "update DJML.AERONAVES set AERO_MODELO = " + modelo.Text + " where AERO_MATRICULA = '" + MATRICULAPOSTA + "'";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }*/

            //ACA VAN TODOS LOS IF, EN DONDE PREGUNTAS SI LO QUE ESTA EN CADA TEXTBOX ES DISTINTO A LO QUE BUSCASTE (QUE LO TENES GUARDADO EN LAS VARIABLES EN MAYUSCYLA)
            //EN EL CASO DE LA MATRICULA TENES QUE PREGUNTAR TAMBIEN QUE LA QUE INGRESES, NO ESTE CARGADA YA EN EL SISTEMA... 

            if (seCambioAlgo)
            {
                string cambio = "Se han guardado los nuevos datos de la aeronave.";
                avisarBien(cambio);
            }

        }

        private void avisarBien(string quePaso)
        {
            MessageBox.Show(quePaso, "SE INFORMA QUE:", MessageBoxButtons.OK, MessageBoxIcon.None);
        }


        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }



    }
}
