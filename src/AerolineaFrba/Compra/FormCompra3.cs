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
    public partial class FormCompra3 : Form
    {
        public static DataTable tabla = new DataTable();
        public static int datosDe = 1;
        public static string butaca = "";
        public static string tipoBucata = "";
        public static string aeroButacaID = "";

        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static UInt32 DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;

        public static bool esNuevo = false;
        
        public FormCompra3()
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
            if (FormCompra2.tipoPasaje == true)
            {
                FormPasaje volver = new FormPasaje();
                this.Hide();
                volver.ShowDialog();
                volver = (FormPasaje)this.ActiveMdiChild;
            }

            else
            {
                FormEncomienda volver = new FormEncomienda();
                this.Hide();
                volver.ShowDialog();
                volver = (FormEncomienda)this.ActiveMdiChild;
            }
        }

        private void crearColumnas()
        {
            tabla.Columns.Add("Butaca", typeof(string));
            tabla.Columns.Add("Tipo Butaca", typeof(string));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Tipo de Documento", typeof(string));
            tabla.Columns.Add("Numero de Documento", typeof(int));
            tabla.Columns.Add("Mail", typeof(string));
            tabla.Columns.Add("Telefono", typeof(int));
            tabla.Columns.Add("Fecha de nacimiento", typeof(DateTime));
            tabla.Columns.Add("Direccion", typeof(string));
            tabla.Columns.Add("Precio", typeof(int));
        }

        private void cargarDatos()
        {
            DataRow uno = tabla.NewRow();
            uno["Butaca"] = butaca;
            uno["Tipo Butaca"] = tipoBucata;
            uno["Nombre"] = nombre.Text;
            uno["Apellido"] = apellido.Text;
            uno["Tipo de Documento"] = tipo2.Text;
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

                if (FormPasaje.cantPasajes > 1)
                {
                    if (FormPasaje.cantPasajes == FormPasaje.cantPasajes1) // si es el primero entonces crea las columnas
                    {   //creo las columnas de la tabla statica

                        crearColumnas();
                    }
                    //agrego los datos del pasajero

                    cargarDatos();
                    actualizarDatos();
                    darBajaButaca();


                    FormPasaje.cantPasajes = (FormPasaje.cantPasajes - 1);
                    datosDe = datosDe + 1;
                    pasajero.Text = datosDe.ToString();
                    LimpiarCliente_Click(sender, e);
                    llenarButacas();
                    butacaSeleccionada.Visible = false;
                    esNuevo = false;

                    ////////
                    //DESELECCIONAR BUTACA
                    //////////

                    /* FormCompra3 nuevaCarga = new FormCompra3();
                     this.Hide();
                     nuevaCarga.ShowDialog();
                     nuevaCarga = (FormCompra3)this.ActiveMdiChild; */

                    /*
                    FormFormaDePago siguiente = new FormFormaDePago();
                    this.Hide();
                    siguiente.ShowDialog();
                    siguiente = (FormFormaDePago)this.ActiveMdiChild;*/

                }
                else if (FormPasaje.cantPasajes == 1)
                {
                    if (FormPasaje.cantPasajes == FormPasaje.cantPasajes1) // si es el unico entonces crea las columnas
                    {
                        crearColumnas();
                    }

                    cargarDatos();
                    actualizarDatos();
                    darBajaButaca();


                    //lo mando a verificacion
                    FormCompra4 siguiente = new FormCompra4();
                    this.Hide();
                    siguiente.ShowDialog();
                    siguiente = (FormCompra4)this.ActiveMdiChild;

                }
            }
            else if (controlarQueEsteTodoCompletado() == false)
            {
                MessageBox.Show("Debes completar los datos obligatorios y seleccionar una butaca" ,"", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void avisar()
        {
            MessageBox.Show("Se han guardado los nuevos datos del cliente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //FALTA HACER LOS UPDATES
        private void actualizarDatos()
        {
           bool seCambioAlgo = false;

           if(Nombre != nombre.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_NOMBRE = '" + nombre.Text + "'" +
                          " where CLIE_DNI = " + DNI +
                          "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();
               
                seCambioAlgo = true;
           }
           if (Apellido != apellido.Text)
           {

               string qry = "update DJML.CLIENTES " +
                           " set CLIE_APELLIDO = '" + apellido.Text + "'" +
                           " where CLIE_DNI = " + DNI +
                           "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

               new Query(qry).Ejecutar();
               seCambioAlgo = true;
           }
           if (Direccion != direccion.Text)
           {
               string qry = "update DJML.CLIENTES " +
                         " set CLIE_DIRECCION= '" + direccion.Text + "'" +
                         " where CLIE_DNI = " + DNI +
                         "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

               new Query(qry).Ejecutar();

               seCambioAlgo = true;
           }
           if (Telefono != telefono.Text)
           {
               string qry = "update DJML.CLIENTES " +
                         " set CLIE_TELEFONO = '" + telefono.Text + "'" +
                         " where CLIE_DNI = " + DNI +
                         "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

               new Query(qry).Ejecutar();
               seCambioAlgo = true;
           }
           if (Mail != mail.Text)
           {
               string qry = "update DJML.CLIENTES " +
                         " set CLIE_EMAIL = '" + mail.Text + "'" +
                         " where CLIE_DNI = " + DNI +
                         "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

               new Query(qry).Ejecutar();

               seCambioAlgo = true;
           }
          /* if (FechaNacimiento.ToString() != fechaNacimiento.Text)
           {

               seCambioAlgo = true;
           }
           if (DNI.ToString() != numero.Text)
           {
               string qry = "update DJML.CLIENTES " +
                         " set CLIE_DNI = '" + numero.Text + "'" +
                         " where CLIE_DNI = " + DNI +
                         "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

               new Query(qry).Ejecutar();
               seCambioAlgo = true;
           }
              if (TipoDNI != tipo2.Text)
           {
               string qry = "update DJML.CLIENTES " +
                      " set CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + tipo2.Text + "')" +
                      " where CLIE_DNI = " + dniNum.Text +
                      "and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

               new Query(qry).Ejecutar();

               seCambioAlgo = true;
           }*/

           if (seCambioAlgo)
           {
               avisar();
           }

        }

    
        private void darBajaButaca()
        {

            //DAR DE BAJA BUTACA
         // MessageBox.Show("se ha dado de baja la butaca de id= " + aeroButacaID);

            string qry = " update DJML.BUTACA_AERO " +
                            " set BXA_ESTADO = 0  " +
                            " where BXA_ID = '" + aeroButacaID + "'";

            new Query(qry).Ejecutar();
        }
  
        //AUTOCOMPLETA CAMPOS
        private void BuscarPorCliente_Click(object sender, EventArgs e)
        {
            String tipoDoc = tipo.Text.Trim();

            UInt32 dni = Convert.ToUInt32(dniNum.Text);

                      
            if (dni != 0 && tipoDoc != "")
            {
                if (dni >= 999999)
                {
                    if (validarDni(dni, tipoDoc))
                    {
                        buscarDatos(dni,tipoDoc );
                        completarDatos();
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

        //AUXILIAR DE AUTOCOMPLETAR DATOS
        private void buscarDatos(UInt32 dni, string tipoDoc) //completarDatos
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
            numero.Text = DNI.ToString() ;
            fechaNacimiento.Text = FechaNacimiento.ToString();

        }


        private bool validarDni(UInt32 dni, string tipoDoc)
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
            if (FormCompra2.esModificar == true)
            {
                Siguiente.Visible = false;
                Actualizar.Visible = true;
            }

            Actualizar.Visible = false;

            pasajero.Text = datosDe.ToString();
           // Siguiente.Enabled = false;
            LlenarComboBoxTipoDocumento();
            LlenarComboBoxTipoDocumento2();
            tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            tipo2.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void tipoDeDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool isCaracterValido(Char c)
        {
            if ((c >= '0' && c <= '9'))
            {
                return true;
            }
            return false;
        }

        private void dni_TextChanged(object sender, EventArgs e)
        {

            //OBLIGAR A QUE INTRODUZCA NUMEROS
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
           /* if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }*/
        }


       
    }
}



/*
COSAS QUE FALTAN HACER

 * PROBLEMA CON LAS FECHAS
 * OBLIGAR A QUE INTRODUZCA NUMEROS

 
 */