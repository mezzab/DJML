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
    public partial class FormBajaCompletoVidaUtil : Form
    {

        public static string MATRICULAVIDA;

        public FormBajaCompletoVidaUtil()
        {
            InitializeComponent();
        }

        private void FormBajaCompletoVidaUtil_Load(object sender, EventArgs e)
        {
            cargarAeronaves();
            comboBoxAeronaves.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        private void cargarAeronaves()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Settings.Default.CadenaDeConexion;


            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select AERO_MATRICULA from DJML.AERONAVES  where AERO_BAJA_FUERA_SERVICIO = 0 and AERO_BAJA_VIDA_UTIL = 0", conexion);
            da.Fill(ds, "DJML.AERONAVES");

            comboBoxAeronaves.DataSource = ds.Tables[0].DefaultView;
            comboBoxAeronaves.ValueMember = "AERO_MATRICULA";
            comboBoxAeronaves.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAeronaves.Text != "")
            {

                /*
                TODO: FIJARSE SI LA AERONAVE TIENE RUTAS (O VIAJES, NOSE) PROGRAMADOS:
                    * SI LOS TIENE, SUPLANTAR LA AERONAVE ACTUAL POR OTRA DE LA FLOTA ( DEL MISMO TIPO Y FABRICANTE)
                        * SI SE DA EL CASO DE QUE NO EXISTE UNA AERONAVE ASI, SE DEBE DAR EL ALTA DE UNA AERONAVE ASI
                
                string qry2 = "UPDATE A VIAJES  " 
                new Query(qry2).Ejecutar();
                */

                   // doy de baja la aeronave
                string qry = " update DJML.AERONAVES " +
                                " set AERO_BAJA_VIDA_UTIL = 1  " +
                                " where AERO_MATRICULA = '" + comboBoxAeronaves.Text.ToString() + "'";
                new Query(qry).Ejecutar();

               

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

        private void button2_Click(object sender, EventArgs e)
        {
            FormAeronaveBaja funcionalidades = new FormAeronaveBaja();
            this.Hide();
            funcionalidades.ShowDialog();
            funcionalidades = (FormAeronaveBaja)this.ActiveMdiChild;
        }

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
           MATRICULAVIDA = comboBoxAeronaves.Text;
        }
    }
}
