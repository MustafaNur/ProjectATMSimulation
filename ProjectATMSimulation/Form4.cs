using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectATMSimulation
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=dbBankaTest;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("execute hareketler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;

        }
    }
}
