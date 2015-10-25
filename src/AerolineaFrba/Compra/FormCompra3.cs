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
        //Para agregar las columnas y darles un nombre haremos lo siguiente:

        public static int datosDe = 1;

        public static bool esModificar = false;

        public FormCompra3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Query qry10 = new Query("SELECT VIAJE_AERO_ID FROM DJML.VIAJES WHERE VIAJE_ID =" + "'" + FormCompra1.viajeID + "'");
            string aeroID = (string)qry10.ObtenerUnicoCampo();

            //    MessageBox.Show("El numero de matricula de la aeronave que realizara el viaje es:" + aeroID , "Consulta de matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);



            string qryButacas = "SELECT B.BUTA_NRO NUMERO, T.DESCRIPCION " +
                                "FROM DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T " +
                                "WHERE X.BXA_BUTA_ID = B.BUTA_ID " +
                                "AND T.TIPO_BUTACA_ID = B.BUTA_TIPO_ID " +
                                "AND X.BXA_AERO_MATRICULA = '" + aeroID + "'";

            //MessageBox.Show(qryButacas);

            dataGridView1.DataSource = new Query(qryButacas).ObtenerDataTable();
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

        private void Siguiente_Click(object sender, EventArgs e)
        {
            //validar si estan todos los datos completos


            if (FormPasaje.cantPasajes > 1)
            {
                if (FormPasaje.cantPasajes == FormPasaje.cantPasajes1) // si es el primero entonces crea las columnas
                {   //creo las columnas de la tabla statica

                    tabla.Columns.Add("Nombre", typeof(string));
                    tabla.Columns.Add("Apellido", typeof(string));
                    tabla.Columns.Add("Tipo de Documento", typeof(string));
                    tabla.Columns.Add("Numero de Documento", typeof(int));
                    tabla.Columns.Add("Mail", typeof(string));
                    tabla.Columns.Add("Telefono", typeof(int));
                    tabla.Columns.Add("Fecha de nacimiento", typeof(DateTime));
                    tabla.Columns.Add("Direccion", typeof(string));
                }
                //agrego los datos del pasajero

                DataRow uno = tabla.NewRow();
                
                uno["Nombre"] = nombre.Text ;
                uno["Apellido"] = apellido.Text;
                uno["Tipo de Documento"] = tipo2.Text;
                uno["Numero de Documento"] = numero.Text;
                uno["mail"] = mail.Text;
                uno["Telefono"] = telefono.Text;
                uno["Fecha de nacimiento"] = fechaNacimiento.Text;
                uno["Direccion"] = direccion.Text;

                //agrego los datos del pasajero a la tabla
                tabla.Rows.Add(uno);

                /*FormCompra3_2 siguiente = new FormCompra3_2();
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormCompra3_)this.ActiveMdiChild;
                */
                
                 FormPasaje.cantPasajes = (FormPasaje.cantPasajes - 1);
                 datosDe = datosDe + 1;
                 pasajero.Text = datosDe.ToString();
                 LimpiarCliente_Click(sender, e);


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
                {   //creo las columnas de la tabla statica

                    tabla.Columns.Add("Nombre", typeof(string));
                    tabla.Columns.Add("Apellido", typeof(string));
                    tabla.Columns.Add("Tipo de Documento", typeof(string));
                    tabla.Columns.Add("Numero de Documento", typeof(int));
                    tabla.Columns.Add("Mail", typeof(string));
                    tabla.Columns.Add("Telefono", typeof(int));
                    tabla.Columns.Add("Fecha de nacimiento", typeof(DateTime));
                    tabla.Columns.Add("Direccion", typeof(string));
                }
                DataRow uno = tabla.NewRow();

                uno["Nombre"] = nombre.Text;
                uno["Apellido"] = apellido.Text;
                uno["Tipo de Documento"] = tipo2.Text;
                uno["Numero de Documento"] = numero.Text;
                uno["mail"] = mail.Text;
                uno["Telefono"] = telefono.Text;
                uno["Fecha de nacimiento"] = fechaNacimiento.Text;
                uno["Direccion"] = direccion.Text;

                //agrego los datos del pasajero a la tabla
                tabla.Rows.Add(uno);
                
                //lo mando a verificacion
                FormCompra4 siguiente = new FormCompra4();
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormCompra4)this.ActiveMdiChild;
            }
        }

        private void actualizar_datos()
        {
           // si los datos fueron modificados
            {
             //   update de base de datos
            }
            
        }
  
        private void BuscarPorCliente_Click(object sender, EventArgs e)
        {
            String tipoDoc = tipo.Text.Trim();
                     
            String dni = this.dni.Text;

                      
            if (dni != "" && tipoDoc != "")
            {
                if (dni.Length >= 7)
                {
                    if (validarDni(dni, tipoDoc))
                    {
                        completarDatos(dni, tipoDoc);
                    }
                    else
                    {
                        MessageBox.Show("El cliente es inexistente, debe cargar sus datos para poder seguir con las operaciones");

                        
                        apellido.Text = "";
                        nombre.Text = "";
                        direccion.Text = "";
                        mail.Text = "";
                        telefono.Text = "";
                        numero.Text = "";
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


        private void completarDatos(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_NOMBRE FROM DJML.CLIENTES " +
                        "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            nombre.Text = qry.ObtenerUnicoCampo().ToString();

            string sql1 = "SELECT CLIE_APELLIDO FROM DJML.CLIENTES " +
            "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry1 = new Query(sql1);
            apellido.Text = qry1.ObtenerUnicoCampo().ToString();

            string sql2 = "SELECT CLIE_DIRECCION FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry2 = new Query(sql2);
            direccion.Text = qry2.ObtenerUnicoCampo().ToString();

            string sql3 = "SELECT CLIE_EMAIL FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry3 = new Query(sql3);
            mail.Text = qry3.ObtenerUnicoCampo().ToString();


            string sql4 = "SELECT CLIE_TELEFONO FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry4 = new Query(sql4);
            telefono.Text = qry4.ObtenerUnicoCampo().ToString();

            numero.Text = dni;
            //  tipo2.Text = tipoDoc;

            string sql5 = "SELECT CLIE_FECHA_NACIMIENTO FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI =" + dni;
            Query qry5 = new Query(sql5);
            fechaNacimiento.Text = qry5.ObtenerUnicoCampo().ToString();


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

        private void FormCompra3_Load(object sender, EventArgs e)
        {
            if (esModificar == true)
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


            //inicio lleno butacas

            Query qry10 = new Query("SELECT VIAJE_AERO_ID FROM DJML.VIAJES WHERE VIAJE_ID =" + "'" + FormCompra1.viajeID + "'");
            string aeroID = (string)qry10.ObtenerUnicoCampo();

            //    MessageBox.Show("El numero de matricula de la aeronave que realizara el viaje es:" + aeroID , "Consulta de matricula", MessageBoxButtons.OK, MessageBoxIcon.Information);



            string qryButacas = "SELECT B.BUTA_NRO NUMERO, T.DESCRIPCION " +
                                "FROM DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T " +
                                "WHERE X.BXA_BUTA_ID = B.BUTA_ID " +
                                "AND T.TIPO_BUTACA_ID = B.BUTA_TIPO_ID " +
                                "AND X.BXA_AERO_MATRICULA = '" + aeroID + "'";

            //MessageBox.Show(qryButacas);

            dataGridView1.DataSource = new Query(qryButacas).ObtenerDataTable();

            //fin llenar butacas
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
            //tipo.DataSource = Nothing;
           // tipo2.DataSource = Nothing;
            dni.Text = "";
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

        private void dni_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void verificacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



/*
COSAS QUE FALTAN HACER
 * CARGAR SU BUTACA A LA TABLA DE VALIDACION 
 * PROBLEMA CON LOS COMBO BOX A LA HORA DE LIMPIARLOS
 * 

 
 */