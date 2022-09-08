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
using System.Diagnostics;

namespace VTYSPROJE
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        public string GirisOgretmenID;
        SqlBaglantisi bgl = new SqlBaglantisi();


        private void FrmOgretmen_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLOGRETMEN where OgretmenID='" + GirisOgretmenID + "'  ", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    labelisim.Text = dr[2].ToString() + " " + dr[3].ToString();
                    labeltc.Text = dr[4].ToString();
                    this.Text = dr[2].ToString() + " " + dr[3].ToString();
                }

                bgl.baglanti().Close();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select TBLDUYURULAR.DuyuruID,TBLOGRETMEN.OgretmenAd,TBLOGRETMEN.OgretmenSoyAd,TBLDUYURULAR.DuyuruMetni,TBLDUYURULAR.DuyuruTarihi From TBLDUYURULAR INNER JOIN TBLOGRETMEN ON TBLDUYURULAR.OgretmenID = TBLOGRETMEN.OgretmenID", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgretmenSınavNotDuzenle fr = new FrmOgretmenSınavNotDuzenle();
                fr.GirisOgretmenID = GirisOgretmenID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgretmenDersProgramı fr = new FrmOgretmenDersProgramı();
                fr.GirisOgretmenID = GirisOgretmenID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgretmenTakvim fr = new FrmOgretmenTakvim();
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OgrtBilgiDüzenle_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgretmenBilgiDuzenle fr = new FrmOgretmenBilgiDuzenle();
                fr.GirisOgretmenID = GirisOgretmenID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text=="")
            {
                MessageBox.Show("Lütfen Duyuru İçin Metin Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("insert into TBLDUYURULAR (OgretmenID,DuyuruMetni,DuyuruTarihi) values (@d1,@d2,@d3)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@d2", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@d1", GirisOgretmenID);
                    komut.Parameters.AddWithValue("@d3", DateTime.Now.Date);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Duyuru Oluşturuldu");

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("Select * From TBLDUYURULAR", bgl.baglanti());
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    bgl.baglanti().Close();
                }
                catch
                {
                    MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ogr.duzce.edu.tr/#4");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://duzce.edu.tr/");
        }

        public string secilenduyuru;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            secilenduyuru = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            FrmOgretmenDuyuruDetay fr = new FrmOgretmenDuyuruDetay();
            fr.secilenduyuru = secilenduyuru;
            fr.Show();
        }
    }
}
