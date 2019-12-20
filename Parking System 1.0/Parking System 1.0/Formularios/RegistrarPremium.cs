using Parking_System_1._0.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_System_1._0
{
    public partial class Form1 : Form
    {
        public static SqlConnection myCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             myCon = new SqlConnection("Data Source=.;Initial Catalog=parking;Integrated Security=True");
            myCon.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           String genero= cmbgenero.Text;
            //SqlConnection con = ConexionBD.myCon;
            try {
                SqlCommand cmd = myCon.CreateCommand();
            cmd.CommandText = "Exec pa_registroPremium  @dni,@nombres,@apellidos,@nacimiento, @genero, @telefono, @direccion, @correo";

            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = txtdni.Text;
            cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = txtnombres.Text;
            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 80).Value = txtapellidos.Text;
            cmd.Parameters.Add("@nacimiento", SqlDbType.DateTime).Value = txtfecha.Text;
            cmd.Parameters.Add("@genero", SqlDbType.VarChar, 20).Value = genero;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 15).Value = txttelefono.Text;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = txtdireccion.Text;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = txtemail.Text;
            myCon.Open();
            cmd.ExecuteNonQuery();
            myCon.Close(); 
            }
            catch(Exception err) {
                //MessageBox.Show("error: "+ err);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            this.Hide();
            p.Show();
        }
    }
}
