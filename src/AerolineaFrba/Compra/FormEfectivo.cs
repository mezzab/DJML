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
using System.Globalization;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace AerolineaFrba.Compra
{
    public partial class PagoEfectivo : Form
    {

        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;

        public static bool esNuevo = true;

        public static int compraID;
        public static string IDCliente;

        public static decimal precioTotal;

        public PagoEfectivo()
        {
            InitializeComponent();
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
                        guardarIdCliente();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberDecimalSeparator = ".";

            fechaNacimiento.Format = DateTimePickerFormat.Custom;
            fechaNacimiento.CustomFormat = "yyyy-dd-MM";
            
            tipo2.Enabled = false;
            numero.Enabled = false;

            LlenarComboBoxTipoDocumento();
            tipo.DropDownStyle = ComboBoxStyle.DropDownList;

            calcularPrecioTotal();



        }

        private void guardarIdCliente()
        {

            string sql1 = "SELECT CLIE_ID FROM DJML.CLIENTES " +
            "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipo.Text + "')" +
             " AND CLIE_DNI =" + numero.Text;
            Query qry11 = new Query(sql1);
            IDCliente = qry11.ObtenerUnicoCampo().ToString();

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
            fechaNacimiento.Text != "")
            {
                estanTodos = true;
            }

            return estanTodos;
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

         
            if (FechaNacimiento.ToString("yyyy-dd-MM") != fechaNacimiento.Text)
            {

                string aux5 = fechaNacimiento.Text + " 00:00:00.000";
                string qry = "update DJML.CLIENTES" +
                            " set CLIE_FECHA_NACIMIENTO ='"+ aux5 +"'" +
                            " where CLIE_ID = "+ IDCliente;
                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }

            if (TipoDNI != tipo.Text)
            {
                if (existeCliente())
                {
                    avisar("No se pudieron actualizar los nuevos datos ingresados. Ya hay un cliente con ese numero de dni y tipo.");

                    tipo.Text = TipoDNI;


                }

                string qry = "update DJML.CLIENTES " +
                       " set CLIE_TIPO_DOC =" + aux +
                       " where CLIE_DNI = " + dniNum.Text +
                       " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }
            if (DNI != numero.Text)//
            {
                if (existeCliente())
                {
                    avisar("No se pueden actualizar los datos. Ya hay un cliente con ese numero de dni y tipo.");

                    numero.Text = DNI;
                }

                string qry = "update DJML.CLIENTES " +
                       " set CLIE_DNI= '" + numero.Text + "'" +
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


        private bool existeUsuario(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                         "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }

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

        private bool validarDni(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                         "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI =" + dni;
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {

            if (existeUsuario(numero.Text, tipo2.Text))
            {
                avisar("Ya existe un usuario con ese tipo y numero de documento. Debe cargarlo y luego, de ser necesario, actualizar sus datos.");
            }
            if (existeUsuario(numero.Text, tipo2.Text) == false)
            {

                cargarNuevoCliente();

                esNuevo = false;

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

        private void Volver_Click(object sender, EventArgs e)
        {
            FormFormaDePago volver = new FormFormaDePago();
            volver.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            volver.ShowDialog();
            volver = (FormFormaDePago)this.ActiveMdiChild;
        }

        private void dniNum_TextChanged(object sender, EventArgs e)
        {
            //  dniNum.TextChanged += dni_TextChanged;
            dniNum.Text = Regex.Replace(dniNum.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS

            numero.Text = dniNum.Text;
        }

        private void tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo2.Text = tipo.Text;
        }

        private void telefono_TextChanged(object sender, EventArgs e)
        {
            telefono.Text = Regex.Replace(telefono.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
        }

        private void total_TextChanged(object sender, EventArgs e)
        {


        }
        private void calcularPrecioTotal()
        {

            decimal totalCalculado = 0;

            for (int i = CargaDatos.tabla.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = CargaDatos.tabla.Rows[i];
                decimal aux = Convert.ToDecimal(dr["Precio"]);
                totalCalculado = totalCalculado + aux;

            }
            for (int i = CargaDatos.tabla2.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = CargaDatos.tabla2.Rows[i];
                decimal aux = Convert.ToDecimal(dr["Precio"]);
                totalCalculado = totalCalculado + aux;

            }

            precioTotal = totalCalculado;

            total.Text = "$ " + totalCalculado.ToString();


        }


        private bool existeCliente()
        {
            string sql = "SELECT CLIE_ID FROM DJML.CLIENTES " +
                          "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipo.Text + "')" +
                         " AND CLIE_DNI =" + numero.Text;
            Query qry1 = new Query(sql);
            object id_cliente = qry1.ObtenerUnicoCampo();

            return (id_cliente != null);
        }

        private void Comprar_Click(object sender, EventArgs e)
        {

            if (controlarQueEsteTodoCompletado())
            {

                controlarCliente();
                registrarCompra();
                registrarPasajes();
                registrarEncomiendas();

                CompraExitosa volver = new CompraExitosa();
                volver.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                volver.ShowDialog();
                volver = (CompraExitosa)this.ActiveMdiChild;

            }


            if (controlarQueEsteTodoCompletado() == false)
            {
                avisar("Debe completar todos los campos obligatorios.");
            }

        }


        private void controlarCliente()
        {
    
            if (esNuevo)
            {
                if (existeCliente())
                {
                    avisar("Ya existe un usuario con ese numero y tipo de documento. Presione el boton buscar");
                }
                if (existeCliente() == false)
                {

                    cargarNuevoCliente(); //INSERT DE LOS CAMPOS
                    guardarIdCliente();
                }

            }
            else if (esNuevo == false)
            {
                actualizarDatos(); // SI EL USUARIO CAMBIO UN DATO ACTUALIZA LOS DATOS DEL CLIENTE

            }

        }

        private void registrarCompra()
        {
            DateTime fechaHoy = DateTime.Now;


            string aux = fechaHoy.ToString("yyyy-dd-MM") + " 00:00:00.000";
            string aux0 = precioTotal.ToString("C").Replace(",", ".");
            string aux1 = aux0.Replace(" ", "");
            //string aux2 = aux1.Remove((paramstr.Length - 1), 1);
            string aux2 = aux1.Substring(0, aux1.Length - 1);


            string sql = " INSERT INTO DJML.COMPRAS( COMPRA_VIAJE_ID , COMPRA_CLIE_ID , COMPRA_MEDIO_DE_PAGO , COMPRA_TARJETA_DE_CREDITO , COMPRA_MONTO , COMPRA_FECHA )" +
                                        " VALUES ( '" + FormCompra1.viajeID + "' , '" + IDCliente + "' , '1' , null , '" + aux2 + "' , '" + aux + "')";

            
            Query qry1 = new Query(sql);
            qry1.pComando = sql;
            qry1.Ejecutar();


            string sqlc = "SELECT COMPRA_CODIGO FROM DJML.COMPRAS " +
                            "WHERE COMPRA_ID = (SELECT MAX(COMPRA_ID) from DJML.COMPRAS)";
            Query qryc = new Query(sqlc);
            FormFormaDePago.codigoCompra = qryc.ObtenerUnicoCampo().ToString();
        }

        private void registrarPasajes()
        {

            
            //TODO:
        }

        private void registrarEncomiendas()
        {

            //TODO:


        }


    }

}
