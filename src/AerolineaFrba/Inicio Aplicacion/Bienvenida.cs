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
using AerolineaFrba.Login_Usuario;
using AerolineaFrba.Abm_Rol;

namespace AerolineaFrba
{   


    public partial class Bienvenida : Form
    {

        public static string rol;

        public Bienvenida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //ESTO TE MANDA AL LOGIN!!!!!!!!!!!
            rol = "Administrador";
            this.Visible = false;
            Form frm = new FormLogin();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            frm = (FormLogin)this.ActiveMdiChild;

           

         /*
            
            this.Visible = false;
            Form frm = new FormInicioFuncionalidades();
            frm.ShowDialog();
            frm = (FormInicioFuncionalidades)this.ActiveMdiChild;*/
        
          }

        private void button2_Click(object sender, EventArgs e)
        {
            rol = "Cliente";
            this.Visible = false;
            Form frm = new FormInicioFuncionalidades();
            frm.ShowDialog();
            frm = (FormInicioFuncionalidades)this.ActiveMdiChild;
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
