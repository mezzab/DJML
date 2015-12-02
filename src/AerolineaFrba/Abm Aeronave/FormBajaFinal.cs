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
using AerolineaFrba.Inicio_Aplicacion;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class FormBajaFinal : Form
    {
        public static string matriculaSimilar;

        public FormBajaFinal()
        {
            InitializeComponent();
        }


        private void FormBajaFinal_Load(object sender, EventArgs e)
        {

            comboBoxTipoBaja.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoBaja.Items.Add("Cancelar todos los viajes.");
            comboBoxTipoBaja.Items.Add("Suplantar la aeronave por otra.");
        }

        private void button1_Click(object sender, EventArgs e) //BOTON VOLVER
        {

            if (FormAeronaveBaja.tipo == "VIDA")
            {
                Form funcionalidades = new FormBajaCompletoVidaUtil();
                this.Hide();
                funcionalidades.ShowDialog();
                funcionalidades = (FormBajaCompletoVidaUtil)this.ActiveMdiChild;
            }
            if (FormAeronaveBaja.tipo == "SERVICIO")
            {
                Form funcionalidades = new FormBajaFueraServicio();
                this.Hide();
                funcionalidades.ShowDialog();
                funcionalidades = (FormBajaFueraServicio)this.ActiveMdiChild;
            }
        }

        private void button2_Click(object sender, EventArgs e) //BOTON DAR DE BAJA
        {
            if (comboBoxTipoBaja.Text == "Cancelar todos los viajes.")
            {
                darDeBaja();

                MessageBox.Show("Aeronave inhabilitada exitosamente y se cancelaron todos los viajes de la aeronave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Lo envia a form Funcionalidades
                FormInicioFuncionalidades inicioF = new FormInicioFuncionalidades();
                this.Hide();
                inicioF.ShowDialog();
                inicioF = (FormInicioFuncionalidades)this.ActiveMdiChild;
            }

            if (comboBoxTipoBaja.Text == "Suplantar la aeronave por otra.")
            {
                //POR EL MOMENTO SUPLANTO SIEMPRE. 
                if (existeAeronaveSimiliar())
                {
                    darDeBaja();
                    avisarBien("Aeronave inhabilitada exitosamente. Se asignaros los viajes a una Aeronave de la misma flota.");
                    FormInicioFuncionalidades aero = new FormInicioFuncionalidades();
                    this.Hide();
                    aero.ShowDialog();
                    aero = (FormInicioFuncionalidades)this.ActiveMdiChild;
                }
                
                else
                {
                    string nuevaMatric = crearAeronaveSimilar();
                    
                    asignarViajesA(nuevaMatric);
                    asignarButacasA(nuevaMatric);

                    darDeBaja();
                    avisarBien("Aeronave inhabilitada exitosamente. Se creo dio de alta una aeronave del mismo modelo, fabricante, y tipo de servicio (de matricula = "+  nuevaMatric + " ).");
                    FormInicioFuncionalidades aero = new FormInicioFuncionalidades();
                    this.Hide();
                    aero.ShowDialog();
                    aero = (FormInicioFuncionalidades)this.ActiveMdiChild;
                }
            }
        }


        #region Funciones Para Baja

        public void darDeBaja()
        {
             if (FormAeronaveBaja.tipo == "VIDA")
                {
                    DateTime fechaHoy = DateTime.Now;
                    string aux = fechaHoy.ToString("yyyy-dd-MM") + " 00:00:00.000";
                    string baja = "UPDATE [DJML].[AERONAVES] SET [AERO_BAJA_VIDA_UTIL] = 1 ,[AERO_FECHA_BAJA_DEF] = '" + aux + "' WHERE AERO_MATRICULA = '" + FormBajaCompletoVidaUtil.MATRICULAVIDA + "'";
                    Query qry = new Query(baja);
                    qry.pComando = baja;
                    qry.Ejecutar();
                }
                
                if (FormAeronaveBaja.tipo == "SERVICIO")
                {
                    string inse = "INSERT INTO [DJML].[PERIODOS_DE_INACTIVIDAD]([PERI_FECHA_INICIO],[PERI_FECHA_FIN]) " +
                                    " VALUES ('" + FormBajaFueraServicio.inicio + "' , '" + FormBajaFueraServicio.fin + "') ";
                    Query qry = new Query(inse);
                    qry.pComando = inse;
                    qry.Ejecutar();

                    string sqlc = "select top 1 PERI_ID from djml.PERIODOS_DE_INACTIVIDAD order by PERI_ID desc";
                    Query qryc = new Query(sqlc);
                    int id_periodo = Convert.ToInt32(qryc.ObtenerUnicoCampo());

                    string baja = "UPDATE [DJML].[AERONAVES] SET [AERO_BAJA_FUERA_SERVICIO] = 1 WHERE AERO_MATRICULA = '" + FormBajaCompletoVidaUtil.MATRICULAVIDA + "'";
                    Query qry1 = new Query(baja);
                    qry1.pComando = baja;
                    qry1.Ejecutar();

                    string inse2 = "INSERT INTO [DJML].[AERONAVES_POR_PERIODOS] ([AXP_MATRI_AERONAVE] ,[AXP_ID_PERIODO]) " +
                                   " VALUES ('" + FormBajaFueraServicio.MATRICULASERVICIO + "' , '" + id_periodo + "') ";
                    Query qry2 = new Query(inse2);
                    qry2.pComando = inse;
                    qry2.Ejecutar();

                }
        }

        public string crearAeronaveSimilar()
        {
            string letras = "AUX";
            int numero = 999;
            string nuevaMatricula = letras + "-" + numero;

            while(existeAeronave(nuevaMatricula))
            {
                numero--;
                nuevaMatricula = letras + "-" + numero;
            }
            string matricula;
            if (FormAeronaveBaja.tipo == "VIDA")
            {
                matricula = FormBajaCompletoVidaUtil.MATRICULAVIDA;
            }
            else
            {
                matricula = FormBajaFueraServicio.MATRICULASERVICIO;
            }

            string sql = "SELECT AERO_SERVICIO_ID FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qr = new Query(sql);
            object marc = qr.ObtenerUnicoCampo();
            string ID_SERV = marc.ToString();

            string sql2 = "SELECT AERO_KILOS_DISPONIBLES FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry2 = new Query(sql2);
            int KG_DISP = Convert.ToInt32(qry2.ObtenerUnicoCampo());

            string sql4 = " SELECT AERO_FABRICANTE FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry4 = new Query(sql4);
            string ID_FABR = qry4.ObtenerUnicoCampo().ToString();

            DateTime fechaHoy = DateTime.Now;
            string aux = fechaHoy.ToString("yyyy-dd-MM") + " 00:00:00.000";

            string sql3 = " SELECT AERO_MODELO FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry3 = new Query(sql3);
            string modelo = qry3.ObtenerUnicoCampo().ToString();

            string sq = "INSERT INTO [DJML].[AERONAVES]([AERO_MATRICULA] , [AERO_MODELO] , [AERO_FABRICANTE] , [AERO_KILOS_DISPONIBLES] , [AERO_SERVICIO_ID] , [AERO_FECHA_ALTA] , [AERO_BAJA_FUERA_SERVICIO] , [AERO_BAJA_VIDA_UTIL]) " +
                        " values ( '" + nuevaMatricula + "' , '"+ modelo + "' , '" + ID_FABR + "' , " + KG_DISP + " , '" + ID_SERV + "' , '" + aux + "' , 0 , 0 ) ";
            
            Query qry1 = new Query(sq);
            qry1.pComando = sq;
            qry1.Ejecutar();

            return nuevaMatricula;

        }

        private void asignarViajesA( string matriculaNueva)
        {
            if (FormAeronaveBaja.tipo == "VIDA")
            {
                string sqy = "UPDATE [DJML].[VIAJES] SET [VIAJE_AERO_ID] = '" + matriculaNueva + "' WHERE VIAJE_AERO_ID = '" + FormBajaCompletoVidaUtil.MATRICULAVIDA + "'";
                Query qry = new Query(sqy);
                qry.pComando = sqy;
                qry.Ejecutar();
            }
            if (FormAeronaveBaja.tipo == "SERVICIO")
            {
                string sqy = "UPDATE [DJML].[VIAJES] SET [VIAJE_AERO_ID] = '" + matriculaNueva + "' WHERE VIAJE_AERO_ID = '" + FormBajaFueraServicio.MATRICULASERVICIO + "' AND VIAJE_FECHA_SALIDA BETWEEN '" + FormBajaFueraServicio.inicio + "' AND '" + FormBajaFueraServicio.fin + "'";
                Query qry = new Query(sqy);
                qry.pComando = sqy;
                qry.Ejecutar();
            }

        }

        private void asignarButacasA( string matriculaNueva)
        {
            if (FormAeronaveBaja.tipo == "VIDA")
            {
                string up = "UPDATE [DJML].[BUTACA_AERO] SET  [BXA_AERO_MATRICULA] = '" + matriculaNueva + "'  WHERE BXA_AERO_MATRICULA = '" + FormBajaCompletoVidaUtil.MATRICULAVIDA + "'";
                Query qry = new Query(up);
                qry.pComando = up;
                qry.Ejecutar();
            
            }

            if (FormAeronaveBaja.tipo == "SERVICIO") //bxv
            {       
                string up = "UPDATE [DJML].[BUTACA_AERO] SET  [BXA_AERO_MATRICULA] = '" + matriculaNueva + "'  WHERE BXA_AERO_MATRICULA = '" + FormBajaFueraServicio.MATRICULASERVICIO + "'";
                Query qry = new Query(up);
                qry.pComando = up;
                qry.Ejecutar();
            
            }
        }

        #endregion
            
        #region Funciones Otras

        private bool existeAeronaveSimiliar()
        {
            string matricula; 
            if (FormAeronaveBaja.tipo == "VIDA")
            { 
                matricula = FormBajaCompletoVidaUtil.MATRICULAVIDA;
            }
            else
            {
                matricula = FormBajaFueraServicio.MATRICULASERVICIO;
            }


            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;
            conexion.Open();

            SqlCommand cmd = new SqlCommand("djml.Proc_Aeronaves", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.Int);
            resultado.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@idaeronave", matricula);
            cmd.Parameters.Add(resultado);

            SqlDataReader dr = cmd.ExecuteReader();

            /*
            string sql = "exec djml.Proc_Aeronaves '" + matricula + "' , null";
            Query qr = new Query(sql);
            object marc = qr.ObtenerUnicoCampo();*/
            
            conexion.Close();



         /*   string sql4 = " SELECT AERO_FABRICANTE FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry4 = new Query(sql4);
            string id_fabricante = qry4.ObtenerUnicoCampo().ToString();


            string sql3 = " SELECT AERO_MODELO FROM DJML.AERONAVES WHERE AERO_MATRICULA = '" + matricula + "'";
            Query qry3 = new Query(sql3);
            string modelo = qry3.ObtenerUnicoCampo().ToString();



            string sqlm = "SELECT AERO_MATRICULA FROM DJML.AERONAVES" +
                         " WHERE AERO_MODELO = '" + modelo + "'" +
                         " AND AERO_FABRICANTE = '" + id_fabricante + "'" +
                         " AND AERO_BAJA_FUERA_SERVICIO = 0 and AERO_BAJA_VIDA_UTIL = 0 " +
                         " AND AERO_SERVICIO_ID = '" + id_servicio + "'";
                         
            Query qrym = new Query(sqlm);
            object obj = qrym.ObtenerUnicoCampo();

            if (obj != null)
            {
                matriculaSimilar = obj.ToString();
            }
            

            return (obj != null);


            */
            return Convert.ToInt32(cmd.Parameters["@resultado"].Value) == 1;
        }


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


        /* ESTO ES PARA CREAR NUEVAS BUTACAS, TAMBIEN VAS A TENER QUE CAMBIARLO EN EL NUUEVO BRANCH
         * string sql5 = "SELECT COUNT(BXA_AERO_MATRICULA) FROM [DJML].[BUTACA_AERO] WHERE BXA_AERO_MATRICULA = '" + matriculaVieja + "'" +
          " group by BXA_AERO_MATRICULA ORDER BY 1 ";
        Query qry5 = new Query(sql5);
        int C_BUTA = (Convert.ToInt32(qry5.ObtenerUnicoCampo()) - 1);

        for (int i = (C_BUTA + 1); i >= 1; i--) // lo hago hasta 1, por que los ids empiezan de 1
        {
            string sql1 = "INSERT INTO [DJML].[BUTACA_AERO] ([BXA_BUTA_ID],[BXA_AERO_MATRICULA] ,[BXA_ESTADO]) VALUES (" + i + ", '" + matriculaNueva + "' , 1 ) ";

            Query qry1 = new Query(sql1);
            qry1.pComando = sql1;
            qry1.Ejecutar();
        }*/
            



          #endregion

    }
}
