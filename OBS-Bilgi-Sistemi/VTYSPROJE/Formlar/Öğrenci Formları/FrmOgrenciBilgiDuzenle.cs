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

namespace VTYSPROJE
{
    public partial class FrmOgrenciBilgiDuzenle : Form
    {
        public FrmOgrenciBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string GirisOgrID;
        string eskiSifre;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtSifre.Text == "")
            {
                MessageBox.Show("Lütfen Şifre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(TxtSifre.Text==eskiSifre)
            {
                MessageBox.Show("Lütfen Farklı Şifre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    SqlCommand komut2 = new SqlCommand("Update TBLOGRENCI set OgrSifre=@p4 where OgrID=@p5", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p5", GirisOgrID);
                    komut2.Parameters.AddWithValue("@p4", TxtSifre.Text);
                    komut2.ExecuteNonQuery();

                    MessageBox.Show("Bilgileriniz Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch
                {
                    MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmOgrenciBilgiDuzenle_Load(object sender, EventArgs e)
        {
            TxtSifre.PasswordChar = '*';
 
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLOGRENCI where OgrID='" + GirisOgrID + "'  ", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                
                while (dr.Read())
                {
                    txtbolumıd.Text = dr[1].ToString();
                    TxtAd.Text = dr[2].ToString();
                    TxtSoyad.Text = dr[3].ToString();
                    txttc.Text = dr[4].ToString();
                    Txtdogumtarihi.Text = dr[6].ToString();
                    TxtKullancıAdı.Text = dr[7].ToString();
                    TxtSifre.Text = dr[8].ToString();
                    eskiSifre = dr[8].ToString();
                }

                    bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                TxtSifre.PasswordChar = '\0';
            }
            else
            {
                TxtSifre.PasswordChar = '*';

            }
        }
    }
}
