using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class FormFormaDePago : Form
    {
        public static Boolean pagoEnEfectivo;

        public FormFormaDePago()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCompra3 m = new FormCompra3();
            this.Hide();
            m.ShowDialog();
            m = (FormCompra3)this.ActiveMdiChild;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pagoEnEfectivo = true;

            FormEfectivo t = new FormEfectivo();
            this.Hide();
            t.ShowDialog();
            t = (FormEfectivo)this.ActiveMdiChild;

           // MessageBox.Show("Todavia no hice este form guacho", "AGUANNNNNTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

        private void button1_Click(object sender, EventArgs e)
        {       //dice efectivo pero tiene mal creado el nombre el puto form, todavia no se como sacarlo
            
            pagoEnEfectivo = false;

            FormEfectivo t = new FormEfectivo();
            this.Hide();
            t.ShowDialog();
            t = (FormEfectivo)this.ActiveMdiChild;
        }

        private void FormFormaDePago_Load(object sender, EventArgs e)
        {

        }
    }
}
