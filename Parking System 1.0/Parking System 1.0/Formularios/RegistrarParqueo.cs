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
    public partial class RegistrarParqueo : Form
    {
        public static SqlConnection myCon = null;
        public RegistrarParqueo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            this.Hide();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                SqlCommand cmd = myCon.CreateCommand();
                cmd.CommandText = "Exec pa_registroNormal  @dni,@id_plaza,@placa,@hora";
                
                cmd.Parameters.Add("@dni", SqlDbType.Int).Value = txtDni.Text;
                cmd.Parameters.Add("@id_plaza", SqlDbType.Int).Value = cmbPlaza.SelectedValue;
                cmd.Parameters.Add("@placa", SqlDbType.VarChar, 20).Value = txtPlaca.Text;
                cmd.Parameters.Add("@hora", SqlDbType.VarChar, 20).Value = DateTime.Now.ToString("HH:mm");

                myCon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro Exitoso !");
                myCon.Close();
                txtDni.Text = "";txtPlaca.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err);
                myCon.Close();
            }

        }

        private void RegistrarParqueo_Load(object sender, EventArgs e)
        {
            myCon = new SqlConnection("Data Source=.;Initial Catalog=parking;Integrated Security=True");
            DataTable dt = Plazas();
            cmbPlaza.DataSource = dt;
            cmbPlaza.ValueMember = "id_plaza";
            cmbPlaza.DisplayMember = "letra";
        }
        private DataTable Plazas()
        {
          
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = myCon.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id_plaza,letra FROM plaza where Estado='Disponible'";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            
        }

        private void cmbPlaza_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
