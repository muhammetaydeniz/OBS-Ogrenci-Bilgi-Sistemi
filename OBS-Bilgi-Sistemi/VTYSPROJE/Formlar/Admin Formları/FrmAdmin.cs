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
using VTYSPROJE.Formlar.Admin_Formları;

namespace VTYSPROJE
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        public string GirisAdminID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLADMIN where AdminID='" + GirisAdminID + "'  ", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    lblAdminAd.Text = dr[1].ToString() + " " + dr[2].ToString();
                    lblKullaniciAdi.Text = dr[3].ToString();
                    this.Text = dr[1].ToString() + " " + dr[2].ToString();
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

        private void AdminBilgiDüzenle_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminBilgiDuzenle fr = new FrmAdminBilgiDuzenle();
                fr.GirisAdminID = GirisAdminID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBolumListele_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminBolumListele fr = new FrmAdminBolumListele();
                fr.GirisAdminID = GirisAdminID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDersListele_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminDersListele fr = new FrmAdminDersListele();
                fr.GirisAdminID = GirisAdminID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOgrenciListele_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminOgrenciDuzenle fr = new FrmAdminOgrenciDuzenle();
                fr.GirisAdminID = GirisAdminID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDersProgrami_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminDersProgrami fr = new FrmAdminDersProgrami();
                fr.GirisAdminID = GirisAdminID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOgretmenListele_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminOgretmenDuzenle fr = new FrmAdminOgretmenDuzenle();
                fr.GirisAdminID = GirisAdminID;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVeriTabanıAyarla_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminVeriTabanıDuzenle fr = new FrmAdminVeriTabanıDuzenle();
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Aradığınız Sayfa Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://duzce.edu.tr/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ogr.duzce.edu.tr/#4");
        }

        public string secilenduyuru;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            secilenduyuru = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            FrmAdminDuyuruDetay fr = new FrmAdminDuyuruDetay();
            fr.secilenduyuru = secilenduyuru;
            fr.Show();
            
        }
    }
}
