using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_System_1._0
{
    class ConexionBD
    {
        public static SqlConnection myCon = null;

        public void CreateConnection()
        {
            myCon = new SqlConnection("Data Source=.;Initial Catalog=parking;Integrated Security=True");
            myCon.Open();

        }
    }
}
