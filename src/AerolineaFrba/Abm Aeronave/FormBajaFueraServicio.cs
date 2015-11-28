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
    public partial class FormBajaFueraServicio : Form
    {
        public static string MATRICULASERVICIO;
        public static string inicio;
        public static string fin;

        public FormBajaFueraServicio()
        {
            InitializeComponent();
        }

        private void FormBajaFueraServicio_Load(object sender, EventArgs e)
        {
             cargarAeronaves();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;

            finicio.Format = DateTimePickerFormat.Custom;
            finicio.CustomFormat = "yyyy-dd-MM";

            ffin.Format = DateTimePickerFormat.Custom;
            ffin.CustomFormat = "yyyy-dd-MM";
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
            comboBoxAeronaves.SelectedItem = null;
        

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         if (comboBoxAeronaves.Text != "")
            {
                 inicio = finicio.Text + " 00:00:00.000";
                 fin = ffin.Text + " 00:00:00.000";

                /*
                TODO: FIJARSE SI LA AERONAVE TIENE RUTAS (O VIAJES, NOSE) PROGRAMADOS ENTRE LAS FECHAS (inicio y fin)
                    * SI LOS TIENE, SUPLANTAR LA AERONAVE ACTUAL POR OTRA DE LA FLOTA ( DEL MISMO TIPO Y FABRICANTE)
                        * SI SE DA EL CASO DE QUE NO EXISTE UNA AERONAVE ASI, SE DEBE DAR EL ALTA DE UNA AERONAVE ASI
                
                string qry2 = "UPDATE A VIAJES  " 
                new Query(qry2).Ejecutar();
                */


                //doy la baja logica de fuera de servicio
                string qry = " update DJML.AERONAVES " +
                                " set AERO_BAJA_FUERA_SERVICIO = 1  " +
                                " where AERO_MATRICULA = '" + comboBoxAeronaves.Text.ToString() + "'";
                new Query(qry).Ejecutar();

               
                //inserto periodo y me guardo el id

                string qry2 = " INSERT INTO [DJML].[PERIODOS_DE_INACTIVIDAD] ([PERI_FECHA_INICIO] ,[PERI_FECHA_FIN]) VALUES ('" + inicio + "' , '" + fin + "')";
                new Query(qry2).Ejecutar();
                
                string sqlid = "SELECT TOP 1 PERI_ID FROM DJML.PERIODOS_DE_INACTIVIDAD ORDER BY PERI_ID DESC";
                Query qryid = new Query(sqlid);
                int periodo_id = Convert.ToInt32(qryid.ObtenerUnicoCampo());

                //relaciono el periodo con la aeronave
                string qry3 = " INSERT INTO [DJML].[AERONAVES_POR_PERIODOS] ([AXP_MATRI_AERONAVE],[AXP_ID_PERIODO]) " +
                                " VALUES('" + MATRICULASERVICIO + "' , " + periodo_id + ")";
                new Query(qry3).Ejecutar();




                this.Visible = false;

                Form funcionalidades = new FormBajaFinal();
                this.Hide();
                funcionalidades.ShowDialog();
                funcionalidades = (FormBajaFinal)this.ActiveMdiChild;

            }
            else
            {
                //MESAJE DE ERROR
                MessageBox.Show("Seleccione una Aeronave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            MATRICULASERVICIO = comboBoxAeronaves.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAeronaveBaja funcionalidades = new FormAeronaveBaja();
            this.Hide();
            funcionalidades.ShowDialog();
            funcionalidades = (FormAeronaveBaja)this.ActiveMdiChild;
        }
    }
}
