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

namespace Petrol_Akaryakit_Projesi
{
    public partial class Petrol : Form
    {
        public Petrol()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T6JACR2\SQLEXPRESS;Initial Catalog=Benzinİstasyonu;Integrated Security=True");



        void listele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLBENZIN where petroltur='Kurşunsuz95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblKursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                LblKursunsuz95Litre.Text = dr[4].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from TBLBENZIN where petroltur='Kurşunsuz97'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblKursunsuz97.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                LblKursunsuz97Litre.Text = dr2[4].ToString();


            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select * from TBLBENZIN where petroltur='EuroDizel10'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblEuroDizel10.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                LblEuroDizelLitre.Text = dr3[4].ToString();


            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from TBLBENZIN where petroltur='YeniProDizel'", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblYeniPro.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                LblYeniProLitre.Text = dr4[4].ToString();


            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from TBLBENZIN where petroltur='Gaz'", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblGaz.Text = dr5[3].ToString();
                progressBar5.Value = int.Parse(dr5[4].ToString());
                LblGazLitre.Text = dr5[4].ToString();


            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * from tblkasa", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblKasa.Text = dr6[0].ToString();

            }
            baglanti.Close();
        }

        private void Petrol_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            TxtKursunsuz95Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            TxtKursunsuz97Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel10, litre, tutar;
            eurodizel10 = Convert.ToDouble(LblEuroDizel10.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel10 * litre;
            TxtEuroDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yeniprodizel, litre, tutar;
            yeniprodizel = Convert.ToDouble(LblYeniPro.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yeniprodizel * litre;
            TxtYeniProDizelFiyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            TxtGazFiyat.Text = tutar.ToString();
        }

        private void BtnDepoDoldur_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLHAREKET (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtKursunsuz95Fiyat.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz95Fiyat.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='kurşunsuz95'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

            }
            if (numericUpDown2.Value != 0)
            {


                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("insert into TBLHAREKET (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut4.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut4.Parameters.AddWithValue("@p2", "Kurşunsuz97");
                komut4.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut4.Parameters.AddWithValue("@p4", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                komut4.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut5 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut5.Parameters.AddWithValue("@p1", decimal.Parse(TxtKursunsuz97Fiyat.Text));
                komut5.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut6 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='kurşunsuz97'", baglanti);
                komut6.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut6.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

            }

                if (numericUpDown3.Value != 0)
                {


                    baglanti.Open();
                    SqlCommand komut7 = new SqlCommand("insert into TBLHAREKET (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                    komut7.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                    komut7.Parameters.AddWithValue("@p2", "EuroDizel10");
                    komut7.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                    komut7.Parameters.AddWithValue("@p4", decimal.Parse(TxtEuroDizelFiyat.Text));
                    komut7.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Başarılı");

                    baglanti.Open();
                    SqlCommand komut8 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                    komut8.Parameters.AddWithValue("@p1", decimal.Parse(TxtEuroDizelFiyat.Text));
                    komut8.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Başarılı");

                    baglanti.Open();
                    SqlCommand komut9 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='eurodizel10'", baglanti);
                    komut9.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                    komut9.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Başarılı");
                    listele();

                }
            
               if (numericUpDown4.Value != 0)
            {
                baglanti.Open();
                SqlCommand komut10 = new SqlCommand("insert into TBLHAREKET (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut10.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut10.Parameters.AddWithValue("@p2", "YeniProDizel");
                komut10.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut10.Parameters.AddWithValue("@p4", decimal.Parse(TxtYeniProDizelFiyat.Text));
                komut10.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut11 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut11.Parameters.AddWithValue("@p1", decimal.Parse(TxtYeniProDizelFiyat.Text));
                komut11.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut12 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='yeniprodizel'", baglanti);
                komut12.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut12.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");
                listele();

            }
                if (numericUpDown5.Value != 0)
            {


                baglanti.Open();
                SqlCommand komut13 = new SqlCommand("insert into TBLHAREKET (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut13.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut13.Parameters.AddWithValue("@p2", "Gaz");
                komut13.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                komut13.Parameters.AddWithValue("@p4", decimal.Parse(TxtGazFiyat.Text));
                komut13.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut14 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", baglanti);
                komut14.Parameters.AddWithValue("@p1", decimal.Parse(TxtGazFiyat.Text));
                komut14.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");

                baglanti.Open();
                SqlCommand komut15 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='gaz'", baglanti);
                komut15.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                komut15.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarılı");
                listele();

            }
        }
    }
}
