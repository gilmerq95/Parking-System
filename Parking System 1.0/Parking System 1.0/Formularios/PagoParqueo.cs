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
    public partial class PagoParqueo : Form
    {
        public static SqlConnection myCon = null;
        public PagoParqueo()
        {
            InitializeComponent();
        }

        private void PagoParqueo_Load(object sender, EventArgs e)
        {
            myCon = new SqlConnection("Data Source=.;Initial Catalog=parking;Integrated Security=True");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();this.Hide();p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id =  Convert.ToInt32(txtDni.Text);

            try
            {
                SqlCommand cmd = myCon.CreateCommand();
                cmd.CommandText = "Select * from ClienteNormal inner join Plaza on id_plaza=id_plaza_fk where id_cliente='" + id + "'";
                myCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtHoraEntrada.Text = Convert.ToString(reader["hora"]);
                    txtPlaza.Text = Convert.ToString(reader["letra"]);
                }
                else
                {
                    MessageBox.Show("Parqueo no encontrado.");

                }
                myCon.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);
                myCon.Close();
            }

        }
    }
}
