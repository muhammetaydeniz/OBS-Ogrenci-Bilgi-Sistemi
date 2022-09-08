using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace VTYSPROJE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GirisOgrID;
        SqlBaglantisi bgl = new SqlBaglantisi();


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLOGRENCI where OgrID='" + GirisOgrID + "'  ", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    labelisim.Text = dr[2].ToString() + " " + dr[3].ToString();
                    labeltc.Text = dr[4].ToString();
                    labelkullanıcıadı.Text = dr[7].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgrenciDersProgramı fr = new FrmOgrenciDersProgramı();
                fr.GirisOgrID = GirisOgrID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void BtnOgrBilgiDüzenle_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgrenciBilgiDuzenle fr = new FrmOgrenciBilgiDuzenle();
                fr.GirisOgrID = GirisOgrID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmOgrenciNotListele fr = new FrmOgrenciNotListele();
                fr.GirisOgrID = GirisOgrID;
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
                FrmOgrTakvim fr = new FrmOgrTakvim();
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            FrmOgrenciDuyuruDetay fr = new FrmOgrenciDuyuruDetay();
            fr.secilenduyuru = secilenduyuru;
            fr.Show();
        }
    }
}
