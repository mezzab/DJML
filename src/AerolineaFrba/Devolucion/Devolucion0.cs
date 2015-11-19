using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Inicio_Aplicacion;

namespace AerolineaFrba.Devolucion
{
    public partial class Devolucion0 : Form
    {

        public static string id_compra;

        public Devolucion0()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.StartPosition = FormStartPosition.CenterScreen;

            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void Devolucion0_Load(object sender, EventArgs e)
        {

        }

        private bool existeCompra()
        {
            string sql = "SELECT COMPRA_ID FROM DJML.COMPRAS " +
                          "WHERE COMPRA_CODIGO = '" + codigo.Text + "'";
            Query qry1 = new Query(sql);
            object id_compra_object = qry1.ObtenerUnicoCampo();
            id_compra = id_compra_object.ToString();

            return (id_compra_object != null);
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (existeCompra())
            {

                string qry = "SELECT D.CIUD_DETALLE DESTINO, V.VIAJE_FECHA_SALIDA FECHA_SALIDA, C.CLIE_NOMBRE NOMBRE,  C.CLIE_APELLIDO APELLIDO, B.BUTA_ID BUTA_NUM, T.DESCRIPCION BUTA_TIPO" +
                               " FROM DJML.PASAJES P, DJML.VIAJES V, DJML.CLIENTES C, DJML.BUTACA_AERO X, DJML.BUTACAS B, DJML.TIPO_BUTACA T, DJML.RUTAS R, DJML.TRAMOS Y, DJML.CIUDADES D" +
                               " WHERE P.PASA_VIAJE_ID = V.VIAJE_ID" +
                               " AND P.PASA_CLIE_ID = C.CLIE_ID" +
                               " AND P.PASA_BUTA_ID = X.BXA_ID " +
                               " AND X.BXA_BUTA_ID = B.BUTA_ID" +
                               " AND B.BUTA_TIPO_ID = T.TIPO_BUTACA_ID" +
                               " AND V.VIAJE_RUTA_ID = R.RUTA_CODIGO" +
                               " AND R.RUTA_TRAMO = Y.TRAMO_ID" +
                               " AND D.CIUD_ID = Y.TRAMO_CIUDAD_DESTINO" +
                               " AND PASA_COMPRA_ID = '"+ id_compra +"'";


                pasajes.DataSource = new Query(qry).ObtenerDataTable();
             
               // pasajes.Columns[""].Visible = false;

                pasajes.ReadOnly = true;
                //pasajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
               DataGridViewColumn column = pasajes.Columns[0];
               column.Width = 55;
               DataGridViewColumn column1 = pasajes.Columns[1];
               column1.Width = 90;
               DataGridViewColumn column2 = pasajes.Columns[3];
               column2.Width = 75;
               DataGridViewColumn column3 = pasajes.Columns[4];
               column3.Width = 80;
               DataGridViewColumn column5 = pasajes.Columns[5];
               column5.Width = 75;
               DataGridViewColumn column4 = pasajes.Columns[6];
               column4.Width = 75;

                //ENCOMIENDAS


               string qry0 = "SELECT D.CIUD_DETALLE DESTINO, V.VIAJE_FECHA_SALIDA FECHA_SALIDA, C.CLIE_NOMBRE NOMBRE,  C.CLIE_APELLIDO APELLIDO, E.ENCO_KG KILOS" +
                               " FROM DJML.ENCOMIENDAS E, DJML.VIAJES V, DJML.CLIENTES C, DJML.RUTAS R, DJML.TRAMOS Y, DJML.CIUDADES D" +
                               " WHERE E.ENCO_VIAJE_ID = V.VIAJE_ID" +
                               " AND E.ENCO_CLIE_ID = C.CLIE_ID" +
                               " AND V.VIAJE_RUTA_ID = R.RUTA_CODIGO" +
                               " AND R.RUTA_TRAMO = Y.TRAMO_ID" +
                               " AND D.CIUD_ID = Y.TRAMO_CIUDAD_DESTINO" +
                              " AND ENCO_COMPRA_ID = '" + id_compra + "'";


               encomiendas.DataSource = new Query(qry0).ObtenerDataTable();

               // pasajes.Columns[""].Visible = false;

               encomiendas.ReadOnly = true;
               //encomiendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
               DataGridViewColumn column0 = encomiendas.Columns[0];
               column0.Width = 55;
              /* DataGridViewColumn column10 = encomiendas.Columns[1];
               column10.Width = 80;
               DataGridViewColumn column20 = encomiendas.Columns[3];
               column20.Width = 75;
               DataGridViewColumn column30 = encomiendas.Columns[4];
               column30.Width = 75;
               DataGridViewColumn column50 = encomiendas.Columns[5];
               column50.Width = 70;
               DataGridViewColumn column40 = encomiendas.Columns[6];
               column40.Width = 70;*/

            }

            if (existeCompra() == false)
            {
                avisar("El codigo de compra ingresado no existe. Intentelo nuevamente.");
            }

        }

        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}
