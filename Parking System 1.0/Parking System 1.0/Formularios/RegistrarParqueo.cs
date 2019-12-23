using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_System_1._0.Formularios
{
    public partial class RegistrarParqueo : Form
    {
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

        }
    }
}
