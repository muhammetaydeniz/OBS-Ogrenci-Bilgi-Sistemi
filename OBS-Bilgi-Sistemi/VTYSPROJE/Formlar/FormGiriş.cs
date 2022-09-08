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
    public partial class FormGiriş : Form
    {
        public FormGiriş()
        {
            InitializeComponent();
        }

        //Data Source=DESKTOP-LMDJP8S;Initial Catalog=OGRSISTEMI;Integrated Security=True

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FormGiriş_Load(object sender, EventArgs e)
        {
            txtsifre.PasswordChar = '*';
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtsifre.PasswordChar = '\0';
            }
            else
            {
                txtsifre.PasswordChar = '*';

            }
        }

        private void btngiriş_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLOGRENCI where OgrKullaniciAdi=@p1 and OgrSifre=@p2 ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
                komut.Parameters.AddWithValue("@p2", txtsifre.Text);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    Form1 fr = new Form1();

                    SqlCommand komut4 = new SqlCommand("Select OgrID From TBLOGRENCI where OgrKullaniciAdi='" + txtkullanıcıadı.Text + "' and OgrSifre='" + txtsifre.Text + "'", bgl.baglanti());
                    SqlDataReader dr4 = komut4.ExecuteReader();
                    while (dr4.Read())
                    {
                        fr.GirisOgrID = dr4[0].ToString();
                    }

                    fr.Show();
                    this.Hide();

                    bgl.baglanti().Close();
                }

                else
                {
                    SqlCommand komut2 = new SqlCommand("Select  OgretmenKullaniciAdi,OgretmenSifre From TBLOGRETMEN where OgretmenKullaniciAdi=@p1 and OgretmenSifre=@p2 ", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
                    komut2.Parameters.AddWithValue("@p2", txtsifre.Text);
                    SqlDataReader dr2 = komut2.ExecuteReader();

                    if (dr2.Read())
                    {
                        FrmOgretmen fr = new FrmOgretmen();

                        SqlCommand komut5 = new SqlCommand("Select OgretmenID From TBLOGRETMEN where OgretmenKullaniciAdi='" + txtkullanıcıadı.Text + "' and OgretmenSifre='" + txtsifre.Text + "'", bgl.baglanti());
                        SqlDataReader dr5 = komut5.ExecuteReader();
                        while (dr5.Read())
                        {
                            fr.GirisOgretmenID = dr5[0].ToString();
                        }

                        fr.Show();
                        this.Hide();

                        bgl.baglanti().Close();
                    }

                    else
                    {
                        SqlCommand komut3 = new SqlCommand("Select * From TBLADMIN where AdminKullaniciAdi=@p1 and AdminSifre=@p2 ", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@p1", txtkullanıcıadı.Text);
                        komut3.Parameters.AddWithValue("@p2", txtsifre.Text);
                        SqlDataReader dr3 = komut3.ExecuteReader();

                        if (dr3.Read())
                        {
                            FrmAdmin fr = new FrmAdmin();

                            SqlCommand komut5 = new SqlCommand("Select AdminID From TBLADMIN where AdminKullaniciAdi='" + txtkullanıcıadı.Text + "' and AdminSifre='" + txtsifre.Text + "'", bgl.baglanti());
                            SqlDataReader dr5 = komut5.ExecuteReader();
                            while (dr5.Read())
                            {
                                fr.GirisAdminID = dr5[0].ToString();
                            }

                            fr.Show();
                            this.Hide();

                            bgl.baglanti().Close();
                        }

                        else
                        {
                            MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre Girişi Yaptınız", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        bgl.baglanti().Close();
                    }

            

                }
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://duzce.edu.tr/");
        }
    }
}
