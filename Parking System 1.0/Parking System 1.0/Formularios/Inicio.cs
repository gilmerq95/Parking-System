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

namespace Parking_System_1._0.Formularios
{
    public partial class Inicio : Form
    {
        public static SqlConnection myCon = null;
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            myCon = new SqlConnection("Data Source=.;Initial Catalog=parking;Integrated Security=True");

        }

        private void button1_Click(object sender, EventArgs e)
        {string clave = txtClave.Text; 
            
            try
            {
                SqlCommand cmd = myCon.CreateCommand();
                cmd.CommandText = "Select * from usuario where contrasenha_usuario='"+clave+"'";
                myCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               // reader.Read();
                        if (reader.Read())
                        {
                            //MessageBox.Show("Contraseña incorrecta");
                            Principal p = new Principal();
                            this.Hide();
                            p.Show();
                        }
                        else {
                           MessageBox.Show("Contraseña Invalida.");
                            
                        }
                myCon.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: "+err);
                myCon.Close();
            }
          

        }
    }
}
