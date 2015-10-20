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
    public partial class FormEncomienda : Form
    {
        public FormEncomienda()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCompra2 m = new FormCompra2();
            this.Hide();
            m.ShowDialog();
            m = (FormCompra2)this.ActiveMdiChild;
        }
    }
}
