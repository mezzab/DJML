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


namespace AerolineaFrba.Compra
{
    public partial class CompraEncomiendas : Form
    {
        public static DataTable tablaEnco = new DataTable();
        public static int identificador = 1;

        public static bool esNuevo = true;
        public static bool esLaPrimeraVez = true;

        public static int cantidadEncomiendasCargadas = 0;
       
        public static string kilosEncomienda = "";
     
        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;


        public CompraEncomiendas()
        {
            InitializeComponent();
        }

        private void CompraEncomiendas_Load(object sender, EventArgs e)
        {
            encomiendas.DataSource = tablaEnco;
            encomiendas.Show();
            //verificacion.Columns["Id Butaca"].Visible = false;

            // Siguiente.Enabled = false;
            LlenarComboBoxTipoDocumento();
            LlenarComboBoxTipoDocumento2();
            tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            tipo2.DropDownStyle = ComboBoxStyle.DropDownList;

            //DataGridViewColumn column = encomiendas.Columns[0];
            //column.Width = 52;
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                           ape.Text = "";
                           nom.Text = "";
                           dir.Text = "";
                           mai.Text = "";
                           tel.Text = "";
                           num.Text = dniNum.Text;
                           fecha.ResetText();

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

         private bool existeUsuario(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                        "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                        "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }

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
               ape.Text = Apellido;
               nom.Text = Nombre;
               dir.Text = Direccion;
               mai.Text = Mail;
               tel.Text = Telefono;
               num.Text = DNI.ToString();
               fecha.Text = FechaNacimiento.ToString();

           }

        private void crearColumnas()
        {
            tablaEnco.Columns.Add("Id", typeof(int));
            tablaEnco.Columns.Add("Kilos", typeof(string));
            tablaEnco.Columns.Add("Nombre", typeof(string));
            tablaEnco.Columns.Add("Apellido", typeof(string));
            tablaEnco.Columns.Add("Tipo de Documento", typeof(string));
            tablaEnco.Columns.Add("Numero de Documento", typeof(int));
            tablaEnco.Columns.Add("Mail", typeof(string));
            tablaEnco.Columns.Add("Telefono", typeof(UInt64));
            tablaEnco.Columns.Add("Fecha de nacimiento", typeof(DateTime));
            tablaEnco.Columns.Add("Direccion", typeof(string));
            tablaEnco.Columns.Add("Precio", typeof(int));
        }

        private bool controlarQueEsteTodoCompletado()
        {
            bool estanTodos = false;

            if (ape.Text != "" &&
                nom.Text != "" &&
                dir.Text != "" &&
                //mail.Text != "" && //es opcional
                tel.Text != "" &&
                num.Text != "" &&
                fecha.Text != "" &&
                kgs.Text != "")
                {
                    estanTodos = true;
                }

            return estanTodos;
        }

        private void cargarDatosATabla()
        {
            DataRow encomienda = tablaEnco.NewRow();
            encomienda["Id"] = identificador;
         
            encomienda["Kilos"] = kgs.Text;
   
            encomienda["Nombre"] = nom.Text;

            encomienda["Apellido"] = ape.Text;
            encomienda["Tipo de Documento"] = tipo2.Text;
            encomienda["Numero de Documento"] = num.Text;
            encomienda["mail"] = mai.Text;
            encomienda["Telefono"] = tel.Text;
            encomienda["Fecha de nacimiento"] = fecha.Text;
            encomienda["Direccion"] = dir.Text;
            // encomienda["Precio"] = precio; BUG
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

               if (Nombre != nom.Text)
               {
                   string qry = "update DJML.CLIENTES " +
                             " set CLIE_NOMBRE = '" + nom.Text + "'" +
                             " where CLIE_DNI = " + DNI +
                             " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                   new Query(qry).Ejecutar();

                   seCambioAlgo = true;
               }
               if (Apellido != ape.Text)
               {

                   string qry = "update DJML.CLIENTES " +
                               " set CLIE_APELLIDO = '" + ape.Text + "'" +
                               " where CLIE_DNI = " + DNI +
                               " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                   new Query(qry).Ejecutar();
                   seCambioAlgo = true;
               }
               if (Direccion != dir.Text)
               {
                   string qry = "update DJML.CLIENTES " +
                             " set CLIE_DIRECCION= '" + dir.Text + "'" +
                             " where CLIE_DNI = " + DNI +
                             " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                   new Query(qry).Ejecutar();

                   seCambioAlgo = true;
               }
               if (Telefono != tel.Text)
               {
                   string qry = "update DJML.CLIENTES " +
                             " set CLIE_TELEFONO = '" + tel.Text + "'" +
                             " where CLIE_DNI = " + DNI +
                             " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                   new Query(qry).Ejecutar();
                   seCambioAlgo = true;
               }
               if (Mail != mai.Text)
               {
                   string qry = "update DJML.CLIENTES " +
                             " set CLIE_EMAIL = '" + mai.Text + "'" +
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
                   string cambio = "Se han guardado los nuevos datos del cliente.";
                   avisar(cambio);
               }

           }

          

        private void button3_Click(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompletado())
               {
                   if (cantidadEncomiendasCargadas == 10)
                   {
                       avisar("El sistema no permite enviar mas de 10 encomiendas por compra.");
                   }

                   if (cantidadEncomiendasCargadas < 10)
                   {   if (FormPasaje.cantPasajes == FormPasaje.cantPasajes1) // si es el primero entonces crea las columnas
                       {   //creo las columnas de la tabla statica
                          crearColumnas();
                       }

                       cargarDatosATabla();
                       cantidadEncomiendasCargadas++;

                       if (esNuevo)
                       {  //avisar("Todavia no anda el Insert para un cliente nuevo");
                           cargarNuevoCliente(); //INSERT DE LOS CAMPOS
                       }
                       else
                       {
                           actualizarDatos(); // SI EL USUARIO CAMBIO UN DATO ACTUALIZA LOS DATOS DEL CLIENTE
                       }
                        
                      //limpiar???? 

                      
                       esNuevo = false;                    

                   }


                   encomiendas.DataSource = tablaEnco;
                   encomiendas.Show();
                 
                   encomiendas.Columns["Mail"].Visible = false;
                   encomiendas.Columns["Telefono"].Visible = false;
                   encomiendas.Columns["Fecha de nacimiento"].Visible = false;
                   encomiendas.Columns["Direccion"].Visible = false;
                   DataGridViewColumn column = encomiendas.Columns[0];
                   column.Width = 50;
                   DataGridViewColumn column2 = encomiendas.Columns[2];
                   column2.Width = 50;
                   DataGridViewColumn column3 = encomiendas.Columns[5];
                   column3.Width = 75;
            

                    // encomiendas.Columns["Id"].Visible = false;
               }

               else if (controlarQueEsteTodoCompletado() == false)
               {
                   MessageBox.Show("Debes completar los datos obligatorios e ingresar la cantidad de kilos que deseas enviar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }

            
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
                                               "VALUES(" + num.Text + ", '" + aux + "', '" + nom.Text + "', '" + ape.Text + "', '" + dir.Text + "', '" + mai.Text + "', " + tel.Text + ", '" + fecha.Text + "' )";
               Query qry = new Query(sql);
               //qry.pComando = sql;
               qry.Ejecutar();

           }

        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
                    

               tipo.Text = null;
               tipo2.Text = null;
               dniNum.Text = "";
               ape.Text = "";
               nom.Text = "";
               dir.Text = "";
               mai.Text = "";
               tel.Text = "";
               num.Text = "";
               fecha.ResetText();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Atras_Click(object sender, EventArgs e)
        {
            FormCompra2 volver = new FormCompra2();
            volver.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            volver.ShowDialog();
            volver = (FormCompra2)this.ActiveMdiChild;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cantidadEncomiendasCargadas <= 0)
            {
                avisar("Debe agregar una encomienda como minimo");
            }

            if (cantidadEncomiendasCargadas >= 1)
            {

                //lo mando a pagar
                FormFormaDePago siguiente = new FormFormaDePago();
                siguiente.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormFormaDePago)this.ActiveMdiChild;
            }
        }



    }
}
