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

namespace AerolineaFrba.Compra
{
    public partial class CargaDatos : Form
    {


        public static DataTable tabla2 = new DataTable();
        public static DataTable tabla = new DataTable();
      
        public static string butaca = "";
        public static string tipoBucata = "";
        public static string aeroButacaID = "";

        public static string kgs = "";

        public static string Nombre;
        public static string Apellido;
        public static string Direccion;
        public static string Telefono;
        public static string Mail;
        public static string DNI;
        public static string TipoDNI;
        public static DateTime FechaNacimiento;

        public static string TIPO;
        public static bool esNuevo = true;

        public static int cantidadPasajesCargados = 0; 
        public static int cantidadEncomiendasCargados = 0;
        public static int maxPasajes = 10;
        public static int maxEncomiendas = 10;

        public static int idEncomienda = 0;

        public static bool primeraE = true;
        public static bool primerP = true;
    
        public static decimal precioBasePasaje;
        public static decimal precioBaseEncomienda;
        public static decimal porcentajeServicio;

        public static string IDC;



        
        public CargaDatos()
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
            
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            DataGridViewColumn column = dataGridView1.Columns[0];     
            column.Width = 52;                                       
            DataGridViewColumn column1 = dataGridView1.Columns[2];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView1.Columns[3];
            column2.Width = 78;
        }

        private void Volver_Click(object sender, EventArgs e)
        {

            //avisar("Se suman" + pesoCargado.ToString() + "kilos");
            modificarKilosAeronave(FormCompra1.pesoCargado.ToString(), "sumar");
         
             for (int i = 0; i <= FormCompra1.butacasCargadas.Count - 1; i++)
             {
                 //avisar("Se da alta de butaca: " + butacasCargadas[i].ToString());

                 darBajaAltaButaca(FormCompra1.butacasCargadas[i].ToString(), 1);
             }

           // llenarButacas();

            cantidadEncomiendasCargados = 0; 
            cantidadPasajesCargados = 0;

            tabla.Clear();
            tabla2.Clear();
            
            FormCompra1.pesoCargado = 0;
            FormCompra1.butacasCargadas.Clear();



            FormCompra1 volver = new FormCompra1();
            volver.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            volver.ShowDialog();
            volver = (FormCompra1)this.ActiveMdiChild;

        }

        private void crearColumnas()
        {
            tabla.Columns.Add("Id Butaca", typeof(string));
            tabla.Columns.Add("Butaca", typeof(string));
            tabla.Columns.Add("Tipo Butaca", typeof(string));
            tabla.Columns.Add("Id Cliente", typeof(string));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Tipo de Documento", typeof(string));
            tabla.Columns.Add("Numero de Documento", typeof(int));
            tabla.Columns.Add("Mail", typeof(string));
            tabla.Columns.Add("Telefono", typeof(UInt64));
            tabla.Columns.Add("Fecha de nacimiento", typeof(string));
            tabla.Columns.Add("Direccion", typeof(string));
            tabla.Columns.Add("Precio", typeof(decimal));
        }

        private void crearColumnas2()
        {
            tabla2.Columns.Add("Id Encomienda", typeof(int));
            tabla2.Columns.Add("Id Cliente", typeof(string));
            tabla2.Columns.Add("Kgs", typeof(int));
            tabla2.Columns.Add("Nombre", typeof(string));
            tabla2.Columns.Add("Apellido", typeof(string));
            tabla2.Columns.Add("Tipo de Documento", typeof(string));
            tabla2.Columns.Add("Numero de Documento", typeof(int));
            tabla2.Columns.Add("Mail", typeof(string));
            tabla2.Columns.Add("Telefono", typeof(UInt64));
            tabla2.Columns.Add("Fecha de nacimiento", typeof(string));
            tabla2.Columns.Add("Direccion", typeof(string));
            tabla2.Columns.Add("Precio", typeof(decimal));
        }

        private void calcularDatosParaCalculoDePrecios()
        {
            string sqls = "select SERV_PORCENTAJE from djml.SERVICIOS" +
                            " where serv_id = (select RUTA_SERVICIO from djml.RUTAS" +
                            " where ruta_codigo = ( select VIAJE_RUTA_ID from djml.viajes where viaje_id  =" + FormCompra1.viajeID + "))";
            Query qrys = new Query(sqls);
            porcentajeServicio = Convert.ToDecimal(qrys.ObtenerUnicoCampo());


            string sqle = "select RUTA_PRECIO_BASE_KILO from djml.RUTAS" +
                           " where ruta_codigo = ( select VIAJE_RUTA_ID from djml.viajes where viaje_id  =" + FormCompra1.viajeID + ")";
            Query qrye = new Query(sqle);
            precioBaseEncomienda = Convert.ToDecimal(qrye.ObtenerUnicoCampo());

            string sqlp = "select RUTA_PRECIO_BASE_PASAJE from djml.RUTAS" +
                        " where ruta_codigo = ( select VIAJE_RUTA_ID from djml.viajes where viaje_id  =" + FormCompra1.viajeID + ")";
            Query qryp = new Query(sqlp);
           precioBasePasaje = Convert.ToDecimal(qryp.ObtenerUnicoCampo());

           // avisar("El id del viaje es: " + FormCompra1.viajeID + " .. el precio base de enco es :" + precioBaseEncomienda + " .. el precio base de pasaje es :" + precioBasePasaje + " ..y el porcentaje de servicio es :" + porcentajeServicio );

       }

        private void cargarDatosATabla()
        {
            DataRow uno = tabla.NewRow();

            uno["Id Butaca"] = aeroButacaID;
            uno["Butaca"] = butaca;
            uno["Tipo Butaca"] = tipoBucata;

            uno["Id Cliente"] = IDC;
            uno["Nombre"] = nombre.Text;
            uno["Apellido"] = apellido.Text;
            uno["Tipo de Documento"] = tipo.Text;
            uno["Numero de Documento"] = numero.Text;
            uno["mail"] = mail.Text;
            uno["Telefono"] = telefono.Text;
            uno["Fecha de nacimiento"] = fechaNacimiento.Text;
            uno["Direccion"] = direccion.Text;

            uno["Precio"] = (precioBasePasaje * (1 + porcentajeServicio));

            //agrego los datos del pasajero a la tabla
            tabla.Rows.Add(uno);

            //guardo el id en la lista 

        }

        private void cargarDatosATabla2()
        {
            DataRow uno = tabla2.NewRow();
            uno["Id Encomienda"] = idEncomienda;
            uno["Kgs"] = kgs;
            uno["Id Cliente"] = IDC;
            uno["Nombre"] = nombre.Text;
            uno["Apellido"] = apellido.Text;
            uno["Tipo de Documento"] = tipo.Text;
            uno["Numero de Documento"] = numero.Text;
            uno["mail"] = mail.Text;
            uno["Telefono"] = telefono.Text;
            uno["Fecha de nacimiento"] = fechaNacimiento.Text;
            uno["Direccion"] = direccion.Text;
            uno["Precio"] = (precioBaseEncomienda * Convert.ToDecimal(kgs));


            //agrego los datos del pasajero a la tabla
            tabla2.Rows.Add(uno);
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
            tipoBucata != "" &&
                tipo.Text != "" )
            {
                estanTodos = true;
            }

            return estanTodos;
        }

        private bool controlarQueEsteTodoCompletado2()
        {
            bool estanTodos = false;

            if (apellido.Text != "" &&
            nombre.Text != "" &&
            direccion.Text != "" &&
                //mail.Text != "" && //es opcional
            telefono.Text != "" &&
            numero.Text != "" &&
            fechaNacimiento.Text != "" &&
            kilos.Text != ""&&
                 tipo.Text != "")
            {
                estanTodos = true;
            }

            return estanTodos;
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompletado())
            {
                if (cantidadPasajesCargados == maxPasajes)
                {
                    avisar("Usted ya cargó el maximo de pasajes permitidos en una transaccion.");
                }

                if (cantidadPasajesCargados < maxPasajes)
                {
                    
                    if (elClienteNoEstaEnLaTabla())
                    { // avisar("el cliente no esta en tabla"); //borrar
                        if (existeCliente() && esNuevo)
                        {
                            avisar("Ya existe cliente con ese tipo y numero de documento. Preciona el boton buscar");

                        }  
                        if (elClienteYaTieneAsignadoUnViajeEseDia() == true)
                        {
                            avisar("El cliente tiene un viaje asignado ese dia");
                            //LimpiarCliente_Click(sender, e);
                        }
                    
                        if (elClienteYaTieneAsignadoUnViajeEseDia() == false)
                        {  // avisar("no tiene asignado viaje"); //borrar

                            if (primerP) // si es el primero entonces crea las columnas
                            {   //creo las columnas de la tabla statica

                                crearColumnas();
                                primerP = false;
                            }
                            //agrego los datos del pasajero

                            FormCompra1.butacasCargadas.Add(Convert.ToInt32(aeroButacaID));
                             
                            cargarDatosATabla();
                           
                            darBajaAltaButaca(aeroButacaID, 0);
                            
                            cantidadPasajesCargados++;

                          
                            LimpiarCliente_Click(sender, e);
                            button1.Enabled = true;
                            llenarButacas();
                         
                            butacaSeleccionada.Visible = false;
                            esNuevo = false;
                            groupBox3.Enabled = false;
                            butaca = "";
                            tipoBucata = "";


                            verificacion.DataSource = tabla;

                            verificacion.Show();

                            verificacion.Columns["Id Butaca"].Visible = false;
                            verificacion.Columns["Id Cliente"].Visible = false;
                            verificacion.Columns["Mail"].Visible = false;
                            verificacion.Columns["Telefono"].Visible = false;
                            verificacion.Columns["Fecha de nacimiento"].Visible = false;
                            verificacion.Columns["Direccion"].Visible = false;

                            verificacion.ReadOnly = true;
                            verificacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                            //DataGridViewColumn column = verificacion.Columns[0];
                            //column.Width = 50;                                    ELIMINAR
                            DataGridViewColumn column2 = verificacion.Columns[1];
                            column2.Width = 55;
                            DataGridViewColumn column3 = verificacion.Columns[2];
                            column3.Width = 75;
                            DataGridViewColumn column6 = verificacion.Columns[6];
                            column6.Width = 64;
                            DataGridViewColumn column12 = verificacion.Columns[12];
                            column6.Width = 82;
                        }
                      
             

                    }
                    if (elClienteNoEstaEnLaTabla() == false)
                    {
                        avisar("Ya cargo un pasaje para este cliente");
                        LimpiarCliente_Click(sender, e);

                    }
                    


                }
              
               

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox4.Enabled = false;

                t.ForeColor = Color.Red;
                t1.ForeColor = Color.Red;

                tipo2.SelectedIndex = -1;
                tipo.SelectedIndex = -1;
                combo.SelectedIndex = -1;

            }

            else if (controlarQueEsteTodoCompletado() == false)
            {
                MessageBox.Show("Debes completar los datos obligatorios y seleccionar una butaca.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private bool elClienteNoEstaEnLaTabla() 
        {
            return (!buscarFilaDeTabla(IDC));
        }

        private bool elClienteNoTieneViajes()
        {


            string sql = "select VIAJE_FECHA_SALIDA from djml.viajes where VIAJE_ID = '" + FormCompra1.viajeID + "'";
            Query qry1 = new Query(sql);
            DateTime fechaSalida = Convert.ToDateTime(qry1.ObtenerUnicoCampo());

            DateTime fechaMasUno = fechaSalida.AddDays(1);

            string aux = "1";
            if (tipo.Text.ToString() == "DNI")
            { aux = "1"; }
            if (tipo.Text.ToString() == "LC")
            { aux = "2"; }
            if (tipo.Text.ToString() == "LE")
            { aux = "3"; }

            string sql1 = "select viaje_id from djml.pasajes p, djml.viajes v, djml.CLIENTES c " +
                            "where v.VIAJE_ID = p.PASA_VIAJE_ID " +
                            " and p.PASA_CLIE_ID =  c.CLIE_ID " +
                            " and c.clie_dni = '" + dniNum.Text + "' " +
                            " and c.clie_tipo_doc = '" + aux + "' " +
                            " and p.cancelacion_id = null " +
                            " and v.VIAJE_FECHA_SALIDA between '" + fechaSalida.ToString() + "' and '" + fechaMasUno.ToString() + "' ";
            Query qry11 = new Query(sql1);
            object tieneViaje = qry11.ObtenerUnicoCampo();

           // avisarBien(fechaSalida.ToString() + "     " + fechaMasUno.ToString());

            return (tieneViaje == null);

        }

        
        private bool elClienteYaTieneAsignadoUnViajeEseDia() //TODO:
        {
            //string quePaso = "nose";
            bool tieneAsignado = true;

            if (esNuevo)
            {
                
                cargarNuevoCliente(); //INSERT DE LOS CAMPOS
                //  avisar("Se guardo el nuevo cliente.");
                  
                guardarIdCliente();
                //quePaso = "tieneAsignado";
                tieneAsignado = true;
                if (elClienteNoTieneViajes())
                { 
                    //quePaso = "noTieneAsignado";
                    tieneAsignado = false;
                }
                
            }
            if (esNuevo == false) 
            {   
                actualizarDatos(); // SI EL USUARIO CAMBIO UN DATO ACTUALIZA LOS DATOS DEL CLIENTE 
                guardarIdCliente();
                tieneAsignado = true;
                if (elClienteNoTieneViajes())
                { tieneAsignado = false; }
            }

            return tieneAsignado;
        } 
    
        private void avisarBien(string quePaso)
        {
            MessageBox.Show(quePaso, "SE INFORMA QUE:", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

   
        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            if (Nombre != nombre.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_NOMBRE = '" + nombre.Text + "'" +
                          " where CLIE_DNI = '" + DNI +"'"+
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }
            if (Apellido != apellido.Text)
            {

                string qry = "update DJML.CLIENTES " +
                            " set CLIE_APELLIDO = '" + apellido.Text + "'" +
                            " where CLIE_DNI = '" + DNI + "'" +
                            " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();
                seCambioAlgo = true;
            }
            if (Direccion != direccion.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_DIRECCION= '" + direccion.Text + "'" +
                          " where CLIE_DNI = '" + DNI + "'" +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }
            if (Telefono != telefono.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_TELEFONO = '" + telefono.Text + "'" +
                          " where CLIE_DNI = '" + DNI + "'" +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();
                seCambioAlgo = true;
            }
            if (Mail != mail.Text)
            {
                string qry = "update DJML.CLIENTES " +
                          " set CLIE_EMAIL = '" + mail.Text + "'" +
                          " where CLIE_DNI = '" + DNI + "'" +
                          " and CLIE_TIPO_DOC =(SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO where DESCRIPCION = '" + TipoDNI + "')";

                new Query(qry).Ejecutar();

                seCambioAlgo = true;

            }

            if (FechaNacimiento.ToString("yyyy-dd-MM") != fechaNacimiento.Text)
            {

                string aux5 = fechaNacimiento.Text + " 00:00:00.000";
                string qry = "update DJML.CLIENTES" +
                            " set CLIE_FECHA_NACIMIENTO ='" + aux5 + "'" +
                            " where CLIE_ID = " + IDC;
                new Query(qry).Ejecutar();

                seCambioAlgo = true;
            }

            if (TipoDNI != tipo.Text)
            {
                if (existeCliente())
                {
                    avisar("No se pudieron actualizar los nuevos datos ingresados. Ya hay un cliente con ese numero de dni y tipo.");

                 //  tipo.Text = TipoDNI;  Problema
                  
                
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
                avisarBien(cambio);
            }

        }

        private void cargarNuevoCliente()
        {

                   
                string aux = "1";
                if (tipo.Text.ToString() == "DNI")
                { aux = "1"; }
                if (tipo.Text.ToString() == "LC")
                { aux = "2"; }
                if (tipo.Text.ToString() == "LE")
                { aux = "3"; }

                string sql = "INSERT INTO DJML.CLIENTES(CLIE_DNI, CLIE_TIPO_DOC, CLIE_NOMBRE, CLIE_APELLIDO, CLIE_DIRECCION, CLIE_EMAIL, CLIE_TELEFONO, CLIE_FECHA_NACIMIENTO) " +
                                                "VALUES('" + numero.Text + "' , '" + aux + "', '" + nombre.Text + "', '" + apellido.Text + "', '" + direccion.Text + "', '" + mail.Text + "', '" + telefono.Text + "', '" + fechaNacimiento.Text + "' )";
                Query qry = new Query(sql);
                //qry.pComando = sql;
                qry.Ejecutar();

                esNuevo = false;


            
            
        }

        private void darBajaAltaButaca(string aeroButacaID, int bajaAlta)
        {

            //DAR DE BAJA BUTACA
            // MessageBox.Show("se ha dado de baja la butaca de id= " + aeroButacaID);

            string qry = " update DJML.BUTACA_AERO " +
                            " set BXA_ESTADO = "+bajaAlta+ "" +
                            " where BXA_ID = '" + aeroButacaID + "'";

            new Query(qry).Ejecutar();
        }

   
        //AUTOCOMPLETA CAMPOS
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

                        groupBox3.Enabled = true;
                        // avisar("existe usuario");
                    }
                    else if( existeUsuario(dni, tipoDoc) ==false )
                    {
                        MessageBox.Show("El cliente es inexistente, debe cargar sus datos para poder seguir con las operaciones");

                        esNuevo = true;

                        apellido.Text = "";
                        nombre.Text = "";
                        direccion.Text = "";
                        mail.Text = "";
                        telefono.Text = "";

                        fechaNacimiento.ResetText();
                        groupBox3.Enabled = true;

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
                         "AND CLIE_DNI = '" + dni + "'";
            Query qry = new Query(sql);
            Nombre = qry.ObtenerUnicoCampo().ToString();

            string sql1 = "SELECT CLIE_APELLIDO FROM DJML.CLIENTES " +
            "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI = '" + dni + "'";
            Query qry1 = new Query(sql1);
            Apellido = qry1.ObtenerUnicoCampo().ToString();

            string sql2 = "SELECT CLIE_DIRECCION FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI = '" + dni + "'";
            Query qry2 = new Query(sql2);
            Direccion = qry2.ObtenerUnicoCampo().ToString();

            string sql3 = "SELECT CLIE_EMAIL FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI = '" + dni + "'";
            Query qry3 = new Query(sql3);
            Mail = qry3.ObtenerUnicoCampo().ToString();


            string sql4 = "SELECT CLIE_TELEFONO FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI = '" + dni + "'";
            Query qry4 = new Query(sql4);
            Telefono = qry4.ObtenerUnicoCampo().ToString();

            DNI = dni;
            TipoDNI = tipoDoc;

            // MessageBox.Show("mmm" + TipoDNI + "MMM");
            string sql5 = "SELECT CLIE_FECHA_NACIMIENTO FROM DJML.CLIENTES " +
             "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
             "AND CLIE_DNI = '" + dni + "'";
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
            numero.Text = DNI.ToString();
            fechaNacimiento.Text = FechaNacimiento.ToString();

        }

        private bool existeUsuario(string dni, string tipoDoc)
        {
            string sql = "SELECT CLIE_DNI FROM DJML.CLIENTES " +
                         "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipoDoc + "') " +
                         "AND CLIE_DNI = '" + dni + "'";
            Query qry = new Query(sql);
            object ndni = qry.ObtenerUnicoCampo();

            return ndni != null;
        }

        private void FormCompra3_Load(object sender, EventArgs e)
        {
            
            t.ForeColor = Color.Red;
            t1.ForeColor = Color.Red;

            groupBox3.Enabled = false;
            
            this.StartPosition = FormStartPosition.CenterScreen;

            fechaNacimiento.Format = DateTimePickerFormat.Custom;
            fechaNacimiento.CustomFormat = "yyyy-dd-MM";
            
            verificacion.DataSource = tabla;
            verificacion.Show();
            //verificacion.Columns["Id Butaca"].Visible = false;

            // Siguiente.Enabled = false;
            LlenarComboBoxTipoDocumento();
            tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            LlenarComboBoxTipoDocumento2();
            tipo2.DropDownStyle = ComboBoxStyle.DropDownList;
            LlenarCombo();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            tipo2.Enabled = false;
            //tipo.Text = tipo2.Text;
            numero.Enabled = false;
            //tipo2.Text = "DNI";
            //DataGridViewColumn column = verificacion.Columns[0];
            //column.Width = 52;                                    ELIMINAR

            llenarButacas();

            
            tipo2.SelectedIndex = -1;
            tipo.SelectedIndex = -1;
            combo.SelectedIndex = -1;

            verificacion.DataSource = tabla;
            verificacion2.DataSource = tabla2;

            
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;

            t.ForeColor = Color.Red;
            t1.ForeColor = Color.Red;

            calcularDatosParaCalculoDePrecios();

            if (FormCompra1.vuelve == true)
            {
                button1.Enabled = true;
            }
            if (FormCompra1.vuelve == false)
            {
                button1.Enabled = false;
                tabla.Clear();
                tabla2.Clear();

            }
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

            kilos.Text = "";

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
         //   dniNum.Text = Regex.Replace(dniNum.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS

            groupBox3.Enabled = false;

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
            butacaSeleccionada.Text = "Seleccionaste la butaca " + butaca + ", " + tipoBucata;
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

       

   
        private void button1_Click(object sender, EventArgs e)
        {
                //TODO: controlar que se haya cargado aunquesea un pasaje o una encomienda
                FormCompra1.vuelve = false;
              
                FormFormaDePago siguiente = new FormFormaDePago();
                siguiente.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                siguiente.ShowDialog();
                siguiente = (FormFormaDePago)this.ActiveMdiChild;
            
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TIPO = combo.Text;

            if (TIPO == "Un Pasaje")
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox4.Enabled = false;
                t.ForeColor = Color.Black;
                t1.ForeColor = Color.Black;

            }
            if (TIPO == "Una Encomienda")
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox4.Enabled = true;

                t.ForeColor = Color.Black;
                t1.ForeColor = Color.Black;
            }

        }

        public void LlenarCombo()
        {
            combo.Items.Add("Un Pasaje");
            combo.Items.Add("Una Encomienda");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (controlarQueEsteTodoCompletado2())
            {
                if (cantidadEncomiendasCargados == maxEncomiendas)
                {
                    avisar("Usted ya cargó el maximo de encomiendas permitidas por tramite.");
                }


                if (cantidadEncomiendasCargados < maxEncomiendas)
                {

                    if (sePasa(kilos.Text) == true)
                    {
                        avisar("No queda espacio en el avion para llevar una encomienda de ese peso.");

                    }

                    if (sePasa(kilos.Text) == false)
                    {

                        if (primeraE == true) // si es el primero entonces crea las columnas
                        {   //creo las columnas de la tabla statica

                            crearColumnas2();
                            primeraE = false;
                        }
                        //agrego los datos del pasajero


                        if (esNuevo)
                        {
                            //avisar("Todavia no anda el Insert para un cliente nuevo");
                            cargarNuevoCliente(); //INSERT DE LOS CAMPOS
                           
                        }
                        else if(esNuevo==false)
                        {
                            actualizarDatos(); // SI EL USUARIO CAMBIO UN DATO ACTUALIZA LOS DATOS DEL CLIENTE
                        }


                        cargarDatosATabla2();

                        button1.Enabled = true;

                        modificarKilosAeronave(kilos.Text, "restar");

                        FormCompra1.pesoCargado = FormCompra1.pesoCargado + Convert.ToInt32(kilos.Text); 

                        cantidadEncomiendasCargados++;
                        idEncomienda++;
                        
                        verificacion2.DataSource = tabla2;
                        verificacion2.Show();
                        verificacion2.Columns["Id Encomienda"].Visible = false;
                        verificacion2.Columns["Id Cliente"].Visible = false;
                        verificacion2.Columns["Mail"].Visible = false;
                        verificacion2.Columns["Telefono"].Visible = false;
                        verificacion2.Columns["Fecha de nacimiento"].Visible = false;
                        verificacion2.Columns["Direccion"].Visible = false;

                        //DataGridViewColumn column = verificacion2.Columns[0];  ELIMINACION
                        //column.Width = 50;                                     ELIMINACION
                        //   DataGridViewColumn column2 = verificacion2.Columns[2];
                        //   column2.Width = 50;

                        verificacion2.ReadOnly = true;
                        verificacion2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        

                        groupBox3.Enabled = false;
                        esNuevo = false;


                        DataGridViewColumn column3 = verificacion2.Columns[1];
                        column3.Width = 75;
                        DataGridViewColumn column6 = verificacion2.Columns[4];
                        column6.Width = 60;
                        DataGridViewColumn column12 = verificacion2.Columns[10];
                        column6.Width = 78;

                    }

                
                }

                LimpiarCliente_Click(sender, e);

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox4.Enabled = false;

                t.ForeColor = Color.Red;
                t1.ForeColor = Color.Red;
       
                tipo2.SelectedIndex = -1;
                tipo.SelectedIndex = -1;
                combo.SelectedIndex = -1;
            }

            else if (controlarQueEsteTodoCompletado2() == false)
            {
                MessageBox.Show("Debes completar los datos obligatorios e ingresar el peso de su encomienda", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void modificarKilosAeronave(string kilosIngresados, string operacion)
        {
                       
            string aux = "+ 0";

            //avisar("se van a " + operacion + kilosIngresados.ToString() + " kilos");

            if (operacion == "sumar")
            {
                aux = "+ "+kilosIngresados;

            }
            else if (operacion == "restar")
            {   
                aux = "- " + kilosIngresados;
                
            }


            string qry2000 = "update djml.AERONAVES " +
                       "set AERO_KILOS_DISPONIBLES = AERO_KILOS_DISPONIBLES" + aux +
                       "where AERO_MATRICULA = '" + FormCompra1.aeroID + "'";

            new Query(qry2000).Ejecutar();
            


        }

        private void kilos_TextChanged(object sender, EventArgs e)
        {
           kilos.Text = Regex.Replace(kilos.Text, @"[^\d]", "");
            //OBLIGA A QUE INTRODUZCA NUMEROS
            kgs = kilos.Text;
        }

        private void mail_TextChanged(object sender, EventArgs e)
        {

        }

       
            
       
        
        private bool sePasa(string kilosDisponibles)
        {
            Query qry101 = new Query("SELECT AERO_KILOS_DISPONIBLES FROM DJML.AERONAVES WHERE AERO_MATRICULA=" + "'" + FormCompra1.aeroID + "'");
            int A = Convert.ToInt32(qry101.ObtenerUnicoCampo());

            int B = Convert.ToInt32(kilosDisponibles);
            bool C= false;

            int resta = A - B;

            if (resta > 0)
            { C = false ; }

            if (resta == 0)
            { C = false; }
             
            if (resta < 0)
            { C = true ;}

            return C;
                
        }

        private void guardarIdCliente()
        {

            string sql = "SELECT CLIE_ID FROM DJML.CLIENTES " +
            "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipo.Text + "')" +
            " AND CLIE_DNI = '" + numero.Text +"'";
            Query qry1 = new Query(sql);
            IDC = qry1.ObtenerUnicoCampo().ToString();

        }

        private bool existeCliente()
        {
            string sql = "SELECT CLIE_ID FROM DJML.CLIENTES " +
                          "WHERE CLIE_TIPO_DOC = (SELECT ID_TIPO_DOC FROM DJML.TIPO_DOCUMENTO WHERE DESCRIPCION = '" + tipo.Text + "')" +
                         " AND CLIE_DNI = '" + numero.Text + "'";
            Query qry1 = new Query(sql);
            object id_cliente = qry1.ObtenerUnicoCampo();

            return (id_cliente != null);
        }

        private bool buscarFilaDeTabla(string idm)
        {
            bool existeEnTabla = false;
            
            for (int i = tabla.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = tabla.Rows[i];
                if (dr["Tipo de Documento"].ToString() == tipo.Text && dr["Numero de Documento"].ToString() == dniNum.Text)
                {
                    existeEnTabla = true;
                }

            }

            return existeEnTabla;         

        }

        private void verificacion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }


        private void dniNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}



//TODO: validar que el cliente no haya comprado un pasaje para ese dia

//TODO: calcular el precio de los pasajes y encomiendas y agregarlos a la tabla! 


/*  ///////////// COSAS QUE TAL VEZ USE MAS ADELNTE ////////////
        
 * ESTO ERA EL BOTON ELIMINAR DEL DATAGRID VERIFICAICON2          
{
    string kilosALiberar = verificacion2.Rows[e.RowIndex].Cells[2].Value.ToString();
    string idEncomiendaA = verificacion2.Rows[e.RowIndex].Cells[1].Value.ToString();
                      
    borrarFilaDeTabla2(idEncomiendaA);

    verificacion2.Rows.RemoveAt(e.RowIndex);

    modificarKilosAeronave(kilosALiberar, "sumar");
         
    cantidadEncomiendasCargados--; 
}        
        
 * ESTO ERA EL BOTON ELIMINAR DEL DATAGRID VERIFICAR
{            
    string idButacaAlta = verificacion.Rows[e.RowIndex].Cells[1].Value.ToString();

    avisar(idButacaAlta);

    borrarFilaDeTabla(idButacaAlta);

    verificacion.Rows.RemoveAt(e.RowIndex);

    darBajaAltaButaca(idButacaAlta, 1);

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

private void borrarFilaDeTabla2(string idEnco)
{
    for (int i = tabla.Rows.Count - 1; i >= 0; i--)
    {
        DataRow dr = tabla.Rows[i];
        if (dr["Id Encomienda"] == idEnco.ToString())
            dr.Delete();
    }
}

 * 
 * actualizar datos
 * 
 * 
*/
