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

namespace AerolineaFrba.Canje_Millas
{
    /*
     * 12. Canje de millas de pasajero frecuente
    Funcionalidad que permite a un cliente cambiar sus millas de pasajero frecuente
    por beneficios. Simplemente el cliente elegirá una recompensa que estará al alcance de
    sus millas. Las mismas no serán viajes, ni crédito a favor para futuros viajes, las
    recompensas serán productos y se debe validar que la cantidad en stock del producto
    elegido permita realizar el canje.
    Los productos del programa serán determinados por los alumnos, como así
    también las millas necesarias para realizar el canje.
    Una vez que el stock de un determinado producto se agota no se vuelve a reponer.
    El canje solo podrá ser realizado por un administrativo quien es el encargado de
    validar si el número de documento se corresponde con la persona que desea realizar el
    canje. Para hacerse efectivo el canje, será necesario que se registre:
     Número de documento
     Producto elegido
     Cantidad del producto elegido
     Fecha de canje.*/
    public partial class canjeMillas : Form
    {
        public canjeMillas()
        {
            InitializeComponent();
        }

        private void canjeMillas_Load(object sender, EventArgs e)
        {

           LlenarComboBoxTipoDocumento();
           tipoDeDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
           LlenarGridProductos();
        }

        public void LlenarComboBoxTipoDocumento()
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = Settings.Default.CadenaDeConexion;

            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DESCRIPCION FROM DJML.TIPO_DOCUMENTO", conexion1);
            da.Fill(ds1, "DJML.TIPO_DOCUMENTO");

            tipoDeDocumento.DataSource = ds1.Tables[0].DefaultView;
            tipoDeDocumento.ValueMember = "DESCRIPCION";
            tipoDeDocumento.SelectedItem = null;
        }

        public void LlenarGridProductos() 
        {
            string qry = "SELECT PROD_NOMBRE as 'Producto', PROD_MILLAS_REQUERIDAS as 'Millas Requeridas', PROD_STOCK as 'Stock'" +
                         " FROM DJML.PRODUCTO";

            var result = new Query(qry).ObtenerDataTable();
            dataGridProductos.DataSource = result;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            FormInicioFuncionalidades FormInicioFuncionalidades = new FormInicioFuncionalidades();
            this.Hide();
            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (FormInicioFuncionalidades)this.ActiveMdiChild;
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            String dni = textBoxDNI.Text;
            String tipo = tipoDeDocumento.Text;
            if (dni != string.Empty && tipo != string.Empty)
            {
               string qryMillas = "SELECT COMPRA_FECHA as 'Fecha', COMPRA_CODIGO as 'Compra', '$ ' + cast (COMPRA_MONTO as VARCHAR(100)) as 'Importe', FLOOR(COMPRA_MONTO / 10) AS 'Millas'" +
                                   " FROM DJML.COMPRAS" +
                                   " JOIN DJML.VIAJES on COMPRA_VIAJE_ID = VIAJE_ID" +
                                   " JOIN DJML.CLIENTES on COMPRA_CLIE_ID = CLIE_ID" +
                                   " JOIN DJML.TIPO_DOCUMENTO td on CLIE_TIPO_DOC = ID_TIPO_DOC" +
                                   " WHERE CLIE_DNI = '" + dni + "'" +
                                   " AND td.DESCRIPCION = '" + tipo + "'" +
                                   " AND VIAJE_FECHA_SALIDA < GETDATE()";

                var resultMillas = new Query(qryMillas).ObtenerDataTable();
                dataGridProductos.DataSource = resultMillas;
            }
            else
                MessageBox.Show("Complete los campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
