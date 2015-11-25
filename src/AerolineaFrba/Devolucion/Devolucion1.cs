using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Devolucion
{
    public partial class Devolucion1 : Form
    {

        public static string codigo_devolucion;

        public static int id_devolucion;

        public static decimal sumaPreciosPasajesEncomiendasDevueltos = 0;

        public Devolucion1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Devolucion0 FormInicioFuncionalidades = new Devolucion0();
            this.Hide();
            FormInicioFuncionalidades.StartPosition = FormStartPosition.CenterScreen;

            FormInicioFuncionalidades.ShowDialog();
            FormInicioFuncionalidades = (Devolucion0)this.ActiveMdiChild;
        }

        private void Devolucion1_Load(object sender, EventArgs e)
        {

        }

        private void cargarDevolucionPasa(string id)
        {
            string Q = " UPDATE [DJML].[PASAJES] SET [CANCELACION_ID] = " + id_devolucion + " WHERE PASA_ID = '" + id + "'";
            Query qry = new Query(Q);
            qry.Ejecutar();

        }


        private void cargarDevolucionEnco(string id)
        {
            string Q = " UPDATE [DJML].[ENCOMIENDAS] SET [CANCELACION_ID] = " + id_devolucion + " WHERE ENCO_ID = '" + id + "'";
            Query qry = new Query(Q);
            qry.Ejecutar();
        }

        private void sumarPrecioPasa(string id)
        {
            string Q = " SELECT [PASA_PRECIO] FROM [DJML].[PASAJES] WHERE PASA_ID = '" + id + "'";
            Query qry = new Query(Q);
            decimal precioPasa = Convert.ToDecimal(qry.ObtenerUnicoCampo());

           
            sumaPreciosPasajesEncomiendasDevueltos = precioPasa + sumaPreciosPasajesEncomiendasDevueltos;
           // avisarBien(" SUMA: " + sumaPreciosPasajesEncomiendasDevueltos + "Y precioEnco: " + precioPasa);

        }

        private void sumarPrecioEnco(string id)
        {
            string Q = " SELECT [ENCO_PRECIO] FROM [DJML].[ENCOMIENDAS] WHERE ENCO_ID = '" + id + "'";
            Query qry = new Query(Q);
            decimal precioEnco = Convert.ToDecimal(qry.ObtenerUnicoCampo());

            sumaPreciosPasajesEncomiendasDevueltos = precioEnco + sumaPreciosPasajesEncomiendasDevueltos;

            //avisarBien(" SUMA: " + sumaPreciosPasajesEncomiendasDevueltos + "Y precioEnco: " + precioEnco);
        }
        
        private void avisarBien(string quePaso)
        {
            MessageBox.Show(quePaso, "SE INFORMA QUE:", MessageBoxButtons.OK, MessageBoxIcon.None);
        }


        private void avisar(string quePaso)
        {
            MessageBox.Show(quePaso, "AVISO! ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Siguiente_Click(object sender, EventArgs e)
        {   
            //INSERT DE LA NUEVA CANCELACION
            DateTime fechaHoy = DateTime.Now;
            string eugenia = fechaHoy.ToString("yyyy-dd-MM") + " 00:00:00.000";

            string nuevoPasaje = " INSERT INTO [DJML].[CANCELACIONES] ([CANC_FECHA_DEVOLUCION] , [CANC_COMPRA_ID] , [CANC_MOTIVO])" +
                                 " VALUES ('" + eugenia + "' , '" + Devolucion0.id_compra + "' , '" + motivo.Text + "' )";
            Query qry = new Query(nuevoPasaje);
            qry.pComando = nuevoPasaje;
            qry.Ejecutar();

            guardarCodigoEId();

            // LE AGREGO EL CODIGO DE DEVOLUCION A LOS PASAJES
            for (int i = 0; i <= Devolucion0.IDsPasajes.Count - 1; i++)
            {
                cargarDevolucionPasa(Devolucion0.IDsPasajes[i].ToString());
                sumarPrecioPasa(Devolucion0.IDsPasajes[i].ToString());
            }

            // LE AGREGO EL CODIGO DE DEVOLUCION A LAS ENCOMIENDAS
            for (int i = 0; i <= Devolucion0.IDsEncomiendas.Count - 1; i++)
            {
                cargarDevolucionEnco(Devolucion0.IDsEncomiendas[i].ToString());
                sumarPrecioEnco(Devolucion0.IDsEncomiendas[i].ToString());
            }

            //MODIFICO EL PRECIO DE COMPRA (LE RESTO EL PRECIO DE LOS PASAJES Y ENCOMIENDAS CANCELADAS)
            modificarPrecioCompra();

            //LIBERO BUTACAS DE LOS PASAJES CANCELADOS
            for (int i = 0; i <= Devolucion0.butacasALiberar.Count - 1; i++)
            {
                //avisar("Se da alta de butaca: " + butacasCargadas[i].ToString());

                darBajaAltaButaca(Devolucion0.butacasALiberar[i].ToString(), 1);
            }
            //LIBERO KILOS DE LA AERONAVE DE LAS ENCOMIENDAS CANCELADAS
            restarKilosAeronave(Devolucion0.pesoALiberar.ToString());

            Devolucion2 m = new Devolucion2();
            this.Hide();
            m.StartPosition = FormStartPosition.CenterScreen;
            m.ShowDialog();
            m = (Devolucion2)this.ActiveMdiChild;


        }

        private void modificarPrecioCompra()
        {

            string sqlc = "select compra_monto from djml.compras where compra_id = '" + Devolucion0.id_compra + "'";
            Query qryc = new Query(sqlc);
            decimal montoViejo = Convert.ToDecimal(qryc.ObtenerUnicoCampo());

            decimal montoNuevo = montoViejo - sumaPreciosPasajesEncomiendasDevueltos;

            string aux = montoNuevo.ToString().Replace(",", ".");

            string x = " UPDATE [DJML].[COMPRAS] SET [COMPRA_MONTO] = '" + aux + "' WHERE COMPRA_ID = '" + Devolucion0.id_compra + "'";
            Query qry = new Query(x);
            qry.Ejecutar();

        }

        private void guardarCodigoEId()
        {
         
            string sqlc = "select top 1 CANC_ID from djml.CANCELACIONES order by CANC_ID desc";
            Query qryc = new Query(sqlc);
            id_devolucion = Convert.ToInt32(qryc.ObtenerUnicoCampo());


            string sql = "select canc_codigo from djml.CANCELACIONES where canc_id =" + id_devolucion ;
            Query qry = new Query(sql);
            codigo_devolucion = qry.ObtenerUnicoCampo().ToString();

        
        }

        private void motivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void darBajaAltaButaca(string aeroButacaID, int bajaAlta)
        {
            //DAR DE BAJA BUTACA
            // MessageBox.Show("se ha dado de baja la butaca de id= " + aeroButacaID);

            string qry = " update DJML.BUTACA_AERO " +
                            " set BXA_ESTADO = " + bajaAlta + "" +
                            " where BXA_ID = '" + aeroButacaID + "'";

            new Query(qry).Ejecutar();
        }

        private void restarKilosAeronave(string kilosIngresados)
        {
            
            string sql = " select VIAJE_AERO_ID from djml.VIAJES where viaje_id = (SELECT COMPRA_VIAJE_ID FROM DJML.COMPRAS where compra_id =" + Devolucion0.id_compra + ")";
            Query qry = new Query(sql);
            string aeroID = qry.ObtenerUnicoCampo().ToString();

            string aux = "+ 0";

            
            aux = "- " + kilosIngresados;

            string qry2000 = "update djml.AERONAVES " +
                       "set AERO_KILOS_DISPONIBLES = AERO_KILOS_DISPONIBLES" + aux +
                       "where AERO_MATRICULA = '" + aeroID + "'";

            new Query(qry2000).Ejecutar();

        }
    }
}
