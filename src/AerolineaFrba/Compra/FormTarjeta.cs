﻿using System;
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

namespace AerolineaFrba.Compra
{
    public partial class FormEfectivo : Form
    {
        public static DataTable tablaTarjeta = new DataTable();

        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;

        public static bool esNuevo = true;


        public FormEfectivo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFormaDePago volver = new FormFormaDePago();
            volver.StartPosition = FormStartPosition.CenterScreen;
          
            this.Hide();
            volver.ShowDialog();
            volver = (FormFormaDePago)this.ActiveMdiChild;
        }

        private void LimpiarCliente_Click(object sender, EventArgs e)
        {
            apellido.Text = "";
            nombre.Text = "";
            direccion.Text = "";
            mail.Text = "";
            telefono.Text = "";
            numero.Text = "";
            fechaNacimiento.ResetText();

        }
        public void LlenarComboBoxTipoDocumento()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.TIPO_DOCUMENTO", conexion1);
            da.Fill(ds1, "DJML.TIPO_DOCUMENTO");

            tipo.DataSource = ds1.Tables[0].DefaultView;
            tipo.ValueMember = "DESCRIPCION";
            tipo.SelectedItem = null;
        }

        public void LlenarComboBoxTiposTarjetas()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select nombre from djml.tipos_de_tarjeta", conexion1);
            da.Fill(ds1, "DJML.TIPOS_DE_TARJETA");

            tipoT.DataSource = ds1.Tables[0].DefaultView;
            tipoT.ValueMember = "NOMBRE";
            tipoT.SelectedItem = null;
        }

        private void FormEfectivo_Load(object sender, EventArgs e)
        {
            if (FormFormaDePago.pagoEnEfectivo == true)
            {  
                groupBox2.Visible = false;
                groupBox4.Visible = true;
            }
            if (FormFormaDePago.pagoEnEfectivo == false)
            {
                groupBox2.Visible = true;
                groupBox4.Visible = false;
            }

            Comprar.Enabled = false;
            LlenarComboBoxTipoDocumento();
            tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            LlenarComboBoxTiposTarjetas();
            tipoT.DropDownStyle = ComboBoxStyle.DropDownList;
            cuotas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void tipoDeDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarNuevoCliente()
        {
            string aux = "1";
            if (tipo2.Text.ToString() == "DNI")
            { aux = "1"; }
            if (tipo2.Text.ToString() == "LC")
            { aux = "2"; }
            if (tipo2.Text.ToString() == "LE")
            { aux = "3"; }

            string sql = "INSERT INTO DJML.CLIENTES(CLIE_DNI, CLIE_TIPO_DOC, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DIRECCION, CLIE_EMAIL, CLIE_TELEFONO, CLIE_FECHA_NACIMIENTO) " +
                                            "VALUES(" + numero.Text + ", '" + aux + "', '" + nombre.Text + "', '" + apellido.Text + "', '" + direccion.Text + "', '" + mail.Text + "', " + telefono.Text + ", '" + fechaNacimiento.Text + "' )";
            Query qry = new Query(sql);
            //qry.pComando = sql;
            qry.Ejecutar();

        }

        private void cargarNuevaTarjeta(string numeroTarjeta)
        {
            //BUG ... 
            // FECHA DE VENCIMIENTO DE LA TARJETA? 
            if (tipoT.Text == "")
            {
                avisar("Debe seleccionar un tipo de tarjeta");
            }
            else if (tipoT.Text != "")
            {
                string tipoTarjeta = tipoT.Text;
                string sql = "SELECT ID FROM DJML.TIPOS_DE_TARJETA " +
                            "WHERE NOMBRE = '" + tipoT.Text + "'" ;
                Query qry = new Query(sql);
                string idTipoTarjeta = qry.ObtenerUnicoCampo().ToString();

                avisar("el id de la tarjeta es: " + idTipoTarjeta);

                string sql2 = "INSERT INTO DJML.TARJETAS_DE_CREDITO(TARJ_NUMERO, TARJ_TIPO_ID) " +
                                                "VALUES(" + numeroTarjeta + ", " + idTipoTarjeta + ")";
                Query qry2 = new Query(sql2);
                //qry.pComando = sql;
                qry2.Ejecutar();

                avisar("Se guardo correctamente la nueva tarjeta en el sistema.");
            }
        


        }


        private void LimpiarTodo_Click(object sender, EventArgs e)
        {
            tipo.Text = null;
            tipo2.Text = null;
            dniNum.Text = "";
            apellido.Text = "";
            nombre.Text = "";
            direccion.Text = "";
            mail.Text = "";
            telefono.Text = "";
            numero.Text = "";
            fechaNacimiento.ResetText();

        }



        private bool validarDni(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                         "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }


        //AUXILIAR DE AUTOCOMPLETAR DATOS
        private void buscarDatos(string dni, string tipoDoc) //completarDatos
        {
            string sql = "SELECT CLIE_NOMBRE FROM DJML.CLIENTES " +
                        "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            Nombre = qry.ObtenerUnicoCampo().ToString();

            string sql1 = "SELECT CLIE_APELLIDO FROM DJML.CLIENTES " +
            "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry1 = new Query(sql1);
            Apellido = qry1.ObtenerUnicoCampo().ToString();

            string sql2 = "SELECT CLIE_DIRECCION FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry2 = new Query(sql2);
            Direccion = qry2.ObtenerUnicoCampo().ToString();

            string sql3 = "SELECT CLIE_EMAIL FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry3 = new Query(sql3);
            Mail = qry3.ObtenerUnicoCampo().ToString();


            string sql4 = "SELECT CLIE_TELEFONO FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry4 = new Query(sql4);
            Telefono = qry4.ObtenerUnicoCampo().ToString();

            DNI = dni;
            TipoDNI = tipo.Text.ToString();

            // MessageBox.Show("mmm" + TipoDNI + "MMM");
            string sql5 = "SELECT CLIE_FECHA_NACIMIENTO FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry5 = new Query(sql5);
            FechaNacimiento = (DateTime)qry5.ObtenerUnicoCampo();

        }

        //AUXILIAR DE AUTOCOMPLETAR DATOS
        private void completarDatos()
        {
            tipo2.Text = TipoDNI;
            apellido.Text = Apellido;
            nombre.Text = Nombre;
            direccion.Text = Direccion;
            mail.Text = Mail;
            telefono.Text = Telefono;
            numero.Text = DNI;
            fechaNacimiento.Text = FechaNacimiento.ToString();

        }

        private void actualizarDatos()
        {
            bool seCambioAlgo = false;
            string aux = "1";
            if (tipo2.Text.ToString() == "DNI")
            { aux = "1"; }
            if (tipo2.Text.ToString() == "LC")
            { aux = "2"; }
            if (tipo2.Text.ToString() == "LE")
            { aux = "3"; }

            if (Nombre != nombre.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_NOMBRE = '" + nombre.Text + "'" +
                          " where CLIE_DNI = " + DNI +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }
            if (Apellido != apellido.Text)
            {

                string qry = "update DJML.CLIENTES " +
                            " set CLIE_APELLIDO = '" + apellido.Text + "'" +
                            " where CLIE_DNI = " + DNI +
                            " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();
                seCambioAlgo = true;
            }
            if (Direccion != direccion.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_DIRECCION= '" + direccion.Text + "'" +
                          " where CLIE_DNI = " + DNI +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }
            if (Telefono != telefono.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_TELEFONO = '" + telefono.Text + "'" +
                          " where CLIE_DNI = " + DNI +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();
                seCambioAlgo = true;
            }
            if (Mail != mail.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_EMAIL = '" + mail.Text + "'" +
                          " where CLIE_DNI = " + DNI +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }

            if (FechaNacimiento.ToString() != fechaNacimiento.Text)
            {

                //BUG
                string converted = DateTime.ParseExact(fechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                //avisar("mmm" + converted + "mmm");
                string qry = "update DJML.CLIENTES" +
                           " set CLIE_FECHA_NACIMIENTO = CAST('" + converted + "' AS DATETIME)" +
                           " where CLIE_DNI = " + DNI +
                           " and CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                seCambioAlgo = true;
            }
            if (DNI.ToString() != numero.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_DNI = '" + numero.Text + "'" +
                          " where CLIE_DNI = " + DNI +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();
                seCambioAlgo = true;
            }
            if (TipoDNI != tipo2.Text)
            {
                string qry = "update DJML.CLIENTES " +
                       " set CLIE_TIPO_DOC =" + aux +
                       " where CLIE_DNI = " + dniNum.Text +
                       " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }

            if (seCambioAlgo)
            {
                string cambio = "Se han guardado los nuevos datos del cliente";
                avisar(cambio);
            }

        }

        private bool existeUsuario(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                         "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }

        private bool existeTarjeta(string numeroTarjeta)
        {
            string sql = "SELECT TARJ_ID FROM DJML.TARJETAS_DE_CREDITO " +
                         "WHERE TARJ_NUMERO =" + numeroTarjeta  ;
          
            Query qry = new Query(sql);
            object idTarjeta = qry.ObtenerUnicoCampo();

            return idTarjeta != null;
        }

        private void BuscarPorCliente_Click(object sender, EventArgs e)
        {
            String tipoDoc = tipo.Text.Trim();

            string dni = dniNum.Text;


            if (dni != "" && tipoDoc != "")
            {
                if (dni.Length >= 7)
                {
                    if (existeUsuario(dni, tipoDoc))
                    {
                        esNuevo = false;
                        buscarDatos(dni, tipoDoc);
                        completarDatos();
                        // avisar("existe usuario");
                    }
                    else
                    {
                        MessageBox.Show("El cliente es inexistente, debe cargar sus datos para poder seguir con las operaciones");

                        esNuevo = true;
                        tipo2.Text = tipo.Text;
                        apellido.Text = "";
                        nombre.Text = "";
                        direccion.Text = "";
                        mail.Text = "";
                        telefono.Text = "";
                        numero.Text = dniNum.Text;
                        fechaNacimiento.ResetText();

                    }
                }
                else
                    MessageBox.Show("El numero de documento debe poseer al menos 7 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Seleccione un tipo e ingrese un numero de documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDatos_Click(object sender, EventArgs e)
        {
            if (esNuevo == false)
            {
                actualizarDatos();

            }
            if (esNuevo)
            {
                avisar("Primero debe clickear en 'Nuevo', para guardar al nuevo cliente.");
            }
        }


        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Comprar_Click(object sender, EventArgs e)
        {
           //HACER



            Form1 volver = new Form1();
            volver.StartPosition = FormStartPosition.CenterScreen;

            this.Hide();
            volver.ShowDialog();
            volver = (Form1)this.ActiveMdiChild;


        }

        private void tiposTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargarCuotas(tipoT.Text);
            

        }

        private void cuotas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarCuotas( string tipo)
        {

             string sql = "select CUOTAS from djml.tipos_de_tarjeta " +
                           "WHERE NOMBRE = '"+ tipo + "'" ;
            Query qry = new Query(sql);
            UInt16 MaxCuotas = Convert.ToUInt16(qry.ObtenerUnicoCampo());

            cuotas.Items.Clear();

            for (int i = 1; i <= MaxCuotas; i++)
            {
                cuotas.Items.Add(i);
             }

        }

        private void NuevoCliente_Click(object sender, EventArgs e)
        {

        }

        private void Nuevo_Click(object sender, EventArgs e)
        {

            if (existeUsuario(numero.Text, tipo2.Text))
            {
                avisar("Ya existe un usuario con ese tipo y numero de documento.");
            }
            if (existeUsuario(numero.Text, tipo2.Text) == false)
            {
            cargarNuevoCliente();

            esNuevo = false;
            }

        }

        private void NuevaTarjeta_Click(object sender, EventArgs e)
        {
            if (numTarjeta.Text == "") 
            {
                avisar("Debe ingresar un numero de tarjeta.");
            }
            else if (numTarjeta.Text.Length != 16 )
            {
                avisar("La tarjeta debe tener 16 digitos.");
            }
            if( numTarjeta.Text.Length == 16 )
            {

                string numeroTarjeta = numTarjeta.Text;

                if (existeTarjeta(numeroTarjeta))
                {
                    avisar("Ya esta guardada esta tarjeta en el sistema.");
                }
                if (existeTarjeta(numeroTarjeta) == false)
                {

                    cargarNuevaTarjeta(numeroTarjeta);

                }
            }

        }

        private void dniNum_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }

        private void numero_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }

        private void telefono_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }

        private void numTarjeta_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }

        private void codigoTarjeta_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }



    }

}
