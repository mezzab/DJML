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
    public partial class CompraPasaje : Form
    {


        public static DataTable tabla = new DataTable();
        public static int cantidadPasajesCargados = 0;
        public static string butaca = "";
        public static string tipoBucata = "";
        public static string aeroButacaID = "";

        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI ;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;

        public static bool esNuevo = true;
        
        public CompraPasaje()
        {
            InitializeComponent();
        }

        //LLENA EL DATAGRID DE BUTACAS
        private void llenarButacas()
        {
            //inicio lleno butacas

            Query qry10 = new Query("SELECT VIAJE_AERO_ID FROM DJML.VIAJES WHERE VIAJE_ID =" + "'" + FormCompra1.viajeID + "'");
            string aeroID = (string)qry10.ObtenerUnicoCampo();

            //    MessageBox.Show("El numero de matricula de la aeronave que realizara el viaje es:" + aeroID , "Consulta de matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);



            string qryButacas = "SELECT X.BXA_ID aeroButacaID, B.BUTA_NRO Butaca, T.DESCRIPCION Tipo " +
                                "FROM DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T " +
                                "WHERE X.BXA_BUTA_ID = B.BUTA_ID " +
                                "AND T.TIPO_BUTACA_ID = B.BUTA_TIPO_ID " +
                                "AND X.BXA_AERO_MATRICULA = '" + aeroID + "' " +
                                "AND X.BXA_ESTADO = 1";


            //MessageBox.Show(qryButacas);

            dataGridView1.DataSource = new Query(qryButacas).ObtenerDataTable();

            dataGridView1.Columns["aeroButacaID"].Visible = false;  

            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 52;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 78;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
                FormPasaje volver = new FormPasaje();
                volver.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                volver.ShowDialog();
                volver = (FormPasaje)this.ActiveMdiChild;
      
        }

        private void crearColumnas()
        {   
            tabla.Columns.Add("Id Butaca", typeof(string));
            tabla.Columns.Add("Butaca", typeof(string));
            tabla.Columns.Add("Tipo Butaca", typeof(string));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Tipo de Documento", typeof(string));
            tabla.Columns.Add("Numero de Documento", typeof(int));
            tabla.Columns.Add("Mail", typeof(string));
            tabla.Columns.Add("Telefono", typeof(UInt64));
            tabla.Columns.Add("Fecha de nacimiento", typeof(DateTime));
            tabla.Columns.Add("Direccion", typeof(string));
            tabla.Columns.Add("Precio", typeof(int));
        }

        private void cargarDatosATabla()
        {
            DataRow uno = tabla.NewRow();
            uno["Id Butaca"] = aeroButacaID;
            uno["Butaca"] = butaca;
            uno["Tipo Butaca"] = tipoBucata;
         
            uno["Nombre"] = nombre.Text;
            uno["Apellido"] = apellido.Text;
            uno["Tipo de Documento"] = tipo.Text;
            uno["Numero de Documento"] = numero.Text;
            uno["mail"] = mail.Text;
            uno["Telefono"] = telefono.Text;
            uno["Fecha de nacimiento"] = fechaNacimiento.Text;
            uno["Direccion"] = direccion.Text;
            // uno["Precio"] = precio;


            //agrego los datos del pasajero a la tabla
            tabla.Rows.Add(uno);
        }

        private bool controlarQueEsteTodoCompletado()
        {
            bool estanTodos = false;

            if (apellido.Text != "" &&
            nombre.Text != "" &&
            direccion.Text != "" &&
            //mail.Text != "" && //es opcional
            telefono.Text != "" &&
            numero.Text != "" &&
            fechaNacimiento.Text != "" &&
            butaca != "" &&
            tipoBucata != "")
            {
                estanTodos = true;
            }

            return estanTodos;
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompletado())
            {
                if (cantidadPasajesCargados == FormPasaje.cantPasajes)
                {
                    avisar("Usted ya cargó los datos de los " + FormPasaje.cantPasajes + " pasajes que quiere comprar.");
                }

                if (cantidadPasajesCargados < FormPasaje.cantPasajes)
                {
                   
                    if (FormPasaje.cantPasajes == FormPasaje.cantPasajes1) // si es el primero entonces crea las columnas
                    {   //creo las columnas de la tabla statica

                        crearColumnas();
                    }
                    //agrego los datos del pasajero



                    if (esNuevo)
                    {
                        //avisar("Todavia no anda el Insert para un cliente nuevo");
                        cargarNuevoCliente(); //INSERT DE LOS CAMPOS

                    }
                    else
                    {

                        actualizarDatos(); // SI EL USUARIO CAMBIO UN DATO ACTUALIZA LOS DATOS DEL CLIENTE

                    }


                    cargarDatosATabla();

                    darBajaButaca(aeroButacaID);

                    FormPasaje.cantPasajes1--;
                    cantidadPasajesCargados++;

                   
                    LimpiarCliente_Click(sender, e);
                    llenarButacas();
                    butacaSeleccionada.Visible = false;
                    esNuevo = false;
                    butaca = "";
                    tipoBucata = "";

                }
       
                verificacion.DataSource = tabla;
                verificacion.Show();
                verificacion.Columns["Id Butaca"].Visible = false;
                verificacion.Columns["Mail"].Visible = false;
                verificacion.Columns["Telefono"].Visible = false;
                verificacion.Columns["Fecha de nacimiento"].Visible = false;
                verificacion.Columns["Direccion"].Visible = false;
                DataGridViewColumn column = verificacion.Columns[0];
                column.Width = 50;
                DataGridViewColumn column2 = verificacion.Columns[2];
                column2.Width = 50;
                DataGridViewColumn column3 = verificacion.Columns[3];
                column3.Width = 75;
                DataGridViewColumn column6 = verificacion.Columns[6];
                column6.Width = 60;
                DataGridViewColumn column12 = verificacion.Columns[12];
                column6.Width = 78;

            }

            else if (controlarQueEsteTodoCompletado() == false)
            {
                MessageBox.Show("Debes completar los datos obligatorios y seleccionar una butaca.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //FALTA HACER LOS UPDATES
        private void actualizarDatos()
        {
           bool seCambioAlgo = false;
           string aux = "1";
           if (tipo.Text.ToString() == "DNI")
           { aux = "1"; }
           if (tipo.Text.ToString() == "LC")
           { aux = "2"; }
           if (tipo.Text.ToString() == "LE")
           { aux = "3"; }

           if(Nombre != nombre.Text)
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
          
         /* if (FechaNacimiento.ToString() != fechaNacimiento.Text)
           {

                //BUG
               string converted = DateTime.ParseExact(fechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
               //avisar("mmm" + converted + "mmm");
               string qry = "update DJML.CLIENTES" +
                          " set CLIE_FECHA_NACIMIENTO = CAST('"+ converted +"' AS DATETIME)" +
                          " where CLIE_DNI = " + DNI +
                          " and CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";
              
              seCambioAlgo = true;
           }*/
               if (TipoDNI != tipo.Text)
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
               string cambio = "Se han guardado los nuevos datos del cliente.";
               avisar(cambio);
           }

        }

        private void cargarNuevoCliente()
        {
            string aux = "1";
            if (tipo.Text.ToString() == "DNI")
             { aux = "1";  }
            if (tipo.Text.ToString() == "LC")
             { aux = "2";  }
            if (tipo.Text.ToString() == "LE")
             { aux = "3";  }
                   
            string sql = "INSERT INTO DJML.CLIENTES(CLIE_DNI, CLIE_TIPO_DOC, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DIRECCION, CLIE_EMAIL, CLIE_TELEFONO, CLIE_FECHA_NACIMIENTO) " +
                                            "VALUES("+ numero.Text + ", '"+ aux + "', '"+ nombre.Text + "', '"+ apellido.Text + "', '"+ direccion.Text + "', '"+ mail.Text +  "', "+ telefono.Text + ", '"+ fechaNacimiento.Text +"' )";
            Query qry = new Query(sql);
            //qry.pComando = sql;
            qry.Ejecutar();
             
                      
          
        }

        private void darBajaButaca(string aeroButacaID)
        {

            //DAR DE BAJA BUTACA
         // MessageBox.Show("se ha dado de baja la butaca de id= " + aeroButacaID);

            string qry = " update DJML.BUTACA_AERO " +
                            " set BXA_ESTADO = 0  " +
                            " where BXA_ID = '" + aeroButacaID + "'";

            new Query(qry).Ejecutar();
        }

        private void darAltaButaca(string aeroButacaID)
        {

            string alta = " update DJML.BUTACA_AERO " +
                            " set BXA_ESTADO = 1" +
                            " where BXA_ID = '" + aeroButacaID + "'";

                   
            Query qry = new Query(alta);
            qry.pComando = alta;
            new Query(alta).Ejecutar();


            //avisar("mmm" + aeroButacaID+ "mmm");

        }
        //AUTOCOMPLETA CAMPOS
        private void BuscarPorCliente_Click(object sender, EventArgs e)
        {
            String tipoDoc = tipo.Text.Trim();

             string dni = dniNum.Text;

                      
            if (dni != "" && tipoDoc != "")
            {
                if (dni.Length >= 7 )
                {
                    if (existeUsuario(dni, tipoDoc))
                    {
                        esNuevo = false; 
                        buscarDatos(dni,tipoDoc );
                        completarDatos();
                       // avisar("existe usuario");
                    }
                    else
                    {
                        MessageBox.Show("El cliente es inexistente, debe cargar sus datos para poder seguir con las operaciones");

                        esNuevo = true;
                        
                        apellido.Text = "";
                        nombre.Text = "";
                        direccion.Text = "";
                        mail.Text = "";
                        telefono.Text = "";
                        
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
            TipoDNI = tipoDoc;

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
            tipo.Text = TipoDNI;
            apellido.Text = Apellido;
            nombre.Text = Nombre;
            direccion.Text = Direccion;
            mail.Text = Mail;
            telefono.Text = Telefono;
            numero.Text = DNI.ToString() ;
            fechaNacimiento.Text = FechaNacimiento.ToString();

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

        private void FormCompra3_Load(object sender, EventArgs e)
        {
            
            this.StartPosition = FormStartPosition.CenterScreen;
            
            verificacion.DataSource = tabla;
            verificacion.Show();
            //verificacion.Columns["Id Butaca"].Visible = false;
            
           // Siguiente.Enabled = false;
            LlenarComboBoxTipoDocumento();
             tipo.DropDownStyle = ComboBoxStyle.DropDownList;
             LlenarComboBoxTipoDocumento2();
            tipo2.DropDownStyle = ComboBoxStyle.DropDownList;
           
            tipo2.Enabled = false;
            tipo.Text = tipo2.Text;
            numero.Enabled = false;
            tipo2.Text = "DNI";
            DataGridViewColumn column = verificacion.Columns[0];
            column.Width = 52;

            llenarButacas();
           
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

        public void LlenarComboBoxTipoDocumento2()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.TIPO_DOCUMENTO", conexion1);
            da.Fill(ds1, "DJML.TIPO_DOCUMENTO");

            tipo2.DataSource = ds1.Tables[0].DefaultView;
            tipo2.ValueMember = "DESCRIPCION";
            tipo2.SelectedItem = null;
        }
   
        private void LimpiarCliente_Click(object sender, EventArgs e)
        {
            tipo.Text = null;
         
            dniNum.Text = "";
            apellido.Text = "";
            nombre.Text = "";
            direccion.Text = "";
            mail.Text = "";
            telefono.Text = "";
            numero.Text = "";
            fechaNacimiento.ResetText();
                    
        }

        private void tipoDeDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo2.Text = tipo.Text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo.Text = tipo2.Text;
            
        }


        private void dni_TextChanged(object sender, EventArgs e)
        {
          //  dniNum.TextChanged += dni_TextChanged;
            dniNum.Text = Regex.Replace(dniNum.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS

            numero.Text = dniNum.Text;
        }

        private void verificacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //BOTON SELECCIONAR DEL DATAGRID DE BUTACAS
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            aeroButacaID = tipoBucata = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            butaca = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tipoBucata = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            butacaSeleccionada.Text = "Seleccionaste la butaca " +butaca+ ", " + tipoBucata;
            butacaSeleccionada.Visible = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void numero_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            numero.Text = Regex.Replace(numero.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS

            dniNum.Text = numero.Text;
            
        }


        private void telefono_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }

        private void verificacion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string idButacaAlta = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           
            ////BUG
            //darAltaButaca(idButacaAlta);

            borrarFilaDeTabla(idButacaAlta);

            verificacion.Rows.RemoveAt(e.RowIndex);

            darAltaButaca(idButacaAlta);
            llenarButacas();

            cantidadPasajesCargados--;

                 
       }

        private void borrarFilaDeTabla(string idButaca)
        {
            for (int i = tabla.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = tabla.Rows[i];
                if (dr["Id Butaca"] == idButaca.ToString())
                    dr.Delete();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cantidadPasajesCargados < FormPasaje.cantPasajes)
            {
                int resta = FormPasaje.cantPasajes - cantidadPasajesCargados;
                avisar("Todavia debe agregar los datos de  " + resta + " pasajeros.");
            }

            if (cantidadPasajesCargados == FormPasaje.cantPasajes)
            {

                //lo mando a pagar
                FormFormaDePago siguiente = new FormFormaDePago();
                siguiente.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormFormaDePago)this.ActiveMdiChild;
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {

        }
      
    }
}



/*
COSAS QUE FALTAN HACER

 * PROBLEMA CON LAS FECHAS
 * OBLIGAR A QUE INTRODUZCA NUMEROS

 
 */