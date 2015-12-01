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
        public static string MODE;
        public static int C_BUTA;
        public static int KG_DISP;
        public static string FABR;
        public static string A_SERV;
        public static string S_DESC;
        public static int VALOR_SERVICIO;
        public static string DESCRIPCION_SERVICIO;


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
            this.fabricante.Clear();
            this.tipoServicio.Clear();

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


        private void t_servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoServicio.Text = t_servicio.Text;
        }

        private void buscarDatos(string matricula)
        {
            //BUSCA SERVICIO AERONAVE
            /*
            string sql = "SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS WHERE SERV_ID = (SELECT AERO_SERVICIO_ID FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "')";
            Query qr = new Query(sql);
            A_SERV = qr.ObtenerUnicoCampo().ToString(); */

            //LO hice de las dos formas, separando para no hacer un sub select, pero me tira una execpcion. Como recomendas, como 
            // esta arriba o esta forma comentada?
            
            string _sql = "SELECT AERO_SERVICIO_ID FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query _qr = new Query(_sql);
            VALOR_SERVICIO = Convert.ToInt32(_qr.ObtenerUnicoCampo());

            /*
            string sql_ = "SELECT SERV_DESCRIPCION FROM DJML.SERVICIOS WHERE SERV_ID = '" + VALOR_SERVICIO + "'";
            Query qr_ = new Query(sql_);
            DESCRIPCION_SERVICIO = qr_.ObtenerUnicoCampo().ToString();*/
            

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
            C_BUTA = Convert.ToInt32(qry5.ObtenerUnicoCampo());


        }

        private void completarDatos()
        {

            matricula.Text = MATR;
            kg_disponibles.Text = KG_DISP.ToString();
            modelo.Text = MODE.ToString();
            c_butacas.Text = C_BUTA.ToString();
            fabricante.Text = FABR.ToString();


            string aux = "1";
            if (VALOR_SERVICIO == 1 )
            {
                aux = "Turista";
                A_SERV = aux;
            }
            if (VALOR_SERVICIO == 2 )
            { 
                
               aux = "Ejecutivo";
               A_SERV = aux;
            }
            if (VALOR_SERVICIO == 3)
            { 
                aux = "Primera Clase";
                A_SERV = aux;
            }
            tipoServicio.Text = A_SERV.ToString();

            t_servicio.SelectedItem = A_SERV.ToString();

            //tipoServicio.Text = DESCRIPCION_SERVICIO.ToString();

        }

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            MATR = comboBoxAeronaves.Text;
            MATRICULAPOSTA = comboBoxAeronaves.Text;
            // Cuando cambias el box, busca los datos y los carga
            buscarDatos(comboBoxAeronaves.Text);
            completarDatos();
        }

        private void modificar(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompleto().Equals(false))
            {
                MessageBox.Show("Primero debes completar todos los datos. ");
            }
            actualizarDatos();
        }


        //******************************************************************************************//
        // NO SE SI HACER EL UPDATE EN ACTUALIZAR DATOS, CREO QUE SERIA MEJOR EN MODIFICARDATOS()
        //******************************************************************************************//
        private void actualizarDatos()
        {
            bool seCambioAlgo = false;

            if (MATR != matricula.Text)
            {
                //SI LA MATRICULA EXISTE NO CONTINUA
                if (existeAeronave(matricula.Text))
                {
                    avisar("No se pudieron actualizar los nuevos datos ingresados. Ya hay una aeronave con esa matricula.");

                    matricula.Text = MATR;

                }
                // ACA ES DONDE NO SE SI HAGO EL UPDATE EN CADA CAMPO
                if (existeAeronave(matricula.Text).Equals(false))
                {
                    //CONTROLA QUE LOS VALORES NUEVOS SEAN DISTINTOS A LOS ANTERIORES
                    if (KG_DISP.ToString() != kg_disponibles.Text)
                    {
                        //UNA FORMA string query = " update [DJML].[AERONAVES] set [AERO_KILOS_DISPONIBLES] = '" + kg_disponibles.Text + "' where AERO_MATRICULA = '" + MATRICULAPOSTA + "'";
                        //new Query(query).Ejecutar();
                        //seCambioAlgo = true;
                        kg_disponibles.Text = KG_DISP.ToString();
                        seCambioAlgo = true;
                    }

                    if (MODE != modelo.Text)
                    {
                        // string query = "UPDATE [DJML].[AERONAVES] set [AERO_MODELO] = '" + modelo.Text + "' where AERO_MATRICULA = '" + MATRICULAPOSTA + "'";

                        //new Query(query).Ejecutar();
                        //seCambioAlgo = true;
                        modelo.Text = MODE.ToString();
                        seCambioAlgo = true;
                    }

                    //TODO: CONTROLAR SI EL UPDATE ES CORRECTO.
                    if (C_BUTA.ToString() != c_butacas.Text)
                    {
                        //string query = " update [DJML].[BUTACAS] set [BUTA_NRO] = '" + c_butacas.Text + "' where AERO_MATRICULA = '" + MATRICULAPOSTA + "'";

                        //new Query(query).Ejecutar();
                        //seCambioAlgo = true;

                        c_butacas.Text = C_BUTA.ToString();
                        seCambioAlgo = true;
                        //SELECT BXA_AERO_MATRICULA FROM [DJML].[BUTACA_AERO] WHERE BXA_AERO_MATRICULA = 'asq-169'
                    }

                    //Si el servicio seleccionado, es distinto al existente actualiza.
                    if (S_DESC != t_servicio.SelectedItem.ToString())
                    {
                        //string query = " update [DJML].[SERVICIOS] set [SERV_DESCRIPCION] = '" + S_DESC + "'";

                        ///new Query(query).Ejecutar();
                        ///seCambioAlgo = true;
                        tipoServicio.Text = A_SERV.ToString();
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


        //CONTROLA LA EXISTENCIA DE LA NAVE
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

        private void kg_disponibles_TextChanged(object sender, EventArgs e)
        {

            //solo deja ingresar numeros
            kg_disponibles.Text = Regex.Replace(kg_disponibles.Text, @"[^\d]", "");
        }

        private void c_butacas_TextChanged(object sender, EventArgs e)
        {

            //solo deja ingresar numeros
            c_butacas.Text = Regex.Replace(c_butacas.Text, @"[^\d]", "");
        }

        //*********************************************//
        // NO SE SI HACER EL UPDATE EN MODIFICARDATOS()
        //*********************************************//
        private void modificarDatos()
        {
            if (existeAeronave(matricula.Text).Equals(false))
            {

                //variable auxiliar para ingresar bien la fecha 
                string aux = f_alta.Text + " 00:00:00.000";

                //Modifica la aeronave
                string sql = "UPDATE [DJML].[AERONAVES] (AERO_MATRICULA, " +
                                    "AERO_MODELO, " +
                                    "AERO_FABRICANTE, " +
                                    "AERO_KILOS_DISPONIBLES," +
                                    "AERO_SERVICIO_ID, " +
                                    "AERO_BAJA_FUERA_SERVICIO, " +
                                    "AERO_BAJA_VIDA_UTIL, " +
                                    "AERO_FECHA_BAJA_DEF, " +
                                    "AERO_FECHA_ALTA ) " +
                            "VALUES ('" + matricula.Text + "', " +
                                    "'" + modelo.Text + "', " +
                                    "( select ID_FABRICANTE from djml.FABRICANTES where DESCRIPCION = '" + fabricante.Text + "'), " +
                                    "'" + kg_disponibles.Text + "', " +
                                    "( select serv_id from djml.servicios where SERV_DESCRIPCION = '" + tipoServicio.Text + "'), " +
                                    " 0, 0, NULL, ' " + aux + "' )";


                Query qry1 = new Query(sql);
                qry1.pComando = sql;
                qry1.Ejecutar();

                MessageBox.Show("Se ha modificado correctamente la nueva aeronave! ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.None);
                limpiar();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompleto())
            {
                actualizarDatos();
                modificarDatos();
            }
            if (controlarQueEsteTodoCompleto() == false)
            {
                avisarBien("Deben estar todos los datos completados");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tipo_servicio_TextChanged(object sender, EventArgs e)
        {
            tipoServicio.Enabled = false;
            t_servicio.Text = tipoServicio.Text;

        }

        private void fabricante_TextChanged(object sender, EventArgs e)
        {
            fabricante.Enabled = false;
            fabricantes.Text = fabricante.Text;
        }

        private void fabricantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            fabricante.Text = fabricantes.Text;
        }



    }
}
