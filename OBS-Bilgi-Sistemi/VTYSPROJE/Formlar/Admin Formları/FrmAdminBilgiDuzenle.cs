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
    public partial class FrmAdminBilgiDuzenle : Form
    {
        public FrmAdminBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string GirisAdminID;
        string eskiSifre;
        SqlBaglantisi bgl = new SqlBaglantisi();


        private void FrmAdminBilgiDuzenle_Load(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            TxtSifre.PasswordChar = '*';

            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLADMIN where AdminID='" + GirisAdminID + "'  ", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    TxtID.Text = dr[0].ToString();
                    TxtAd.Text = dr[1].ToString();
                    TxtAdminSoyad.Text = dr[2].ToString();
                    TxtKullancıAdı.Text = dr[3].ToString();
                    TxtSifre.Text = dr[4].ToString();
                    eskiSifre= dr[4].ToString();
                }

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtSifre.Text == "")
            {
                MessageBox.Show("Lütfen Şifre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (TxtSifre.Text == eskiSifre)
            {
                MessageBox.Show("Lütfen Farklı Şifre giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    SqlCommand komut2 = new SqlCommand("Update TBLADMIN set AdminAd=@p1, AdminSoyAd=@p2, AdminKullaniciAdi=@p3, AdminSifre=@p4 where AdminID=@p5", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p5", GirisAdminID);
                    komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
                    komut2.Parameters.AddWithValue("@p2", TxtAdminSoyad.Text);
                    komut2.Parameters.AddWithValue("@p3", TxtKullancıAdı.Text);
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
