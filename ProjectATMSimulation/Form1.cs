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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ABE0UME;Initial Catalog=dbBankaTest;Integrated Security=True");

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tblKisiler Where HesapNo=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 fr = new Form2();
                fr.hesap = mskHesapNo.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatali Giris");
            }
            baglanti.Close();
        }
    }
}
