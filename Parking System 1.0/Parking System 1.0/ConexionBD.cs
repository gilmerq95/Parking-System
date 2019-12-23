using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_System_1._0
{
    class ConexionBD
    {
         public SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=parking;Integrated Security=True");
            
        //procedimiento que abre la conexion sqlsever
            public void conectar()
            {
                //myCon.Open();
                //mi conexion:
                try
                {
                    con.Open();
                MessageBox.Show("Conectadoawsd");
                SqlConnection conexi = con;
                
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        //procedimiento que cierra la conexion sqlserver
       public void desconectar()
            {
                con.Close();
            }
    }
}
