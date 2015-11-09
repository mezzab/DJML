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
            CompraPasaje m = new CompraPasaje();
            this.Hide();
            m.StartPosition = FormStartPosition.CenterScreen;
          
            m.ShowDialog();
            m = (CompraPasaje)this.ActiveMdiChild;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pagoEnEfectivo = true;

            Form1 t = new Form1();
            t.StartPosition = FormStartPosition.CenterScreen;
          
            this.Hide();
            t.ShowDialog();
            t = (Form1)this.ActiveMdiChild;

        }

        private void button1_Click(object sender, EventArgs e)
        {       //dice efectivo pero tiene mal creado el nombre el puto form, todavia no se como sacarlo
            
            pagoEnEfectivo = false;

            FormEfectivo t = new FormEfectivo();
            t.StartPosition = FormStartPosition.CenterScreen;
          
            this.Hide();
            t.ShowDialog();
            t = (FormEfectivo)this.ActiveMdiChild;
        }

        private void FormFormaDePago_Load(object sender, EventArgs e)
        {
        }
    }
}
