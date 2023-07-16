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
using System.Data.SqlClient;

namespace ProjectATMSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=dbBankaTest;Integrated Security=True");

        public string hesap;
        private void Form2_Load(object sender, EventArgs e)
        {
            lblHesapNo.Text= hesap;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tblKisiler Where HesapNo=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", hesap);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblAdSoyad.Text = dr[1] + " " +dr[2];
                lblTCNo.Text = dr[3].ToString();
                lblTelefon.Text = dr[4].ToString();
            }
            baglanti.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            
            // Gönderilen hesabın para artışı
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update tblHesap set Bakiye=Bakiye+@p1 where HesapNo=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p2", mskHesapNo.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            

            // Gönderen Hesabın Para Azalışı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("update tblHesap set Bakiye=Bakiye-@k1 where HesapNo=@k2", baglanti);
            komut2.Parameters.AddWithValue("@k1", decimal.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@k2", hesap);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Gerçekleştirildi");

            //işlem geçmişi

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }
    }
}
