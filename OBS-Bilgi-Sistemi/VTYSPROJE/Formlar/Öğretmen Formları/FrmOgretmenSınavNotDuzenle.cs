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
    public partial class FrmOgretmenSınavNotDuzenle : Form
    {
        public FrmOgretmenSınavNotDuzenle()
        {
            InitializeComponent();
        }
        public string GirisOgretmenID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Page1list()
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select TBLDERSLER.DersID,TBLBOLUMLER.BolumAd,TBLOGRETMEN.OgretmenAd,TBLDERSLER.DersAd,TBLDERSLER.DersKod, TBLDERSLER.DersTarih From TBLDERSLER INNER JOIN TBLBOLUMLER ON TBLBOLUMLER.BolumID = TBLDERSLER.BolumID INNER JOIN TBLOGRETMEN ON TBLOGRETMEN.OgretmenID = TBLDERSLER.OgretmenID where TBLOGRETMEN.OgretmenID = '" + GirisOgretmenID + "'  ", bgl.baglanti());
                da.Fill(dt);
                dataGridView2.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void Page2list()
        {
            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBLNOTLAR where OgretmenID='" + GirisOgretmenID + "'  ", bgl.baglanti());
                da.Fill(dt);
                dataGridView3.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Page3list()
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select TBLOGRENCI.OgrID,TBLBOLUMLER.BolumAd,TBLOGRENCI.OgrAd,TBLOGRENCI.OgrSoyAd,TBLOGRENCI.OgrDogumTarihi,TBLOGRENCI.OgrKullaniciAdi From TBLOGRENCI INNER JOIN TBLBOLUMLER ON TBLBOLUMLER.BolumID = TBLOGRENCI.BolumID ", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        void comboboxlistele()
        {
            try
            {
                SqlCommand komut = new SqlCommand("Select * From TBLDERSLER where OgretmenID='" + GirisOgretmenID + "' ", bgl.baglanti());
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "DersAd";
                comboBox1.ValueMember = "DersID";
                comboBox1.DataSource = dt;
                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOgretmenSınavNotDuzenle_Load(object sender, EventArgs e)
        {             
            Page1list();
            comboboxlistele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Visible == true)
                {
                    int secilen = dataGridView1.SelectedCells[0].RowIndex;
                    txtOgrIDOgr.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                    txtOgrAdOgr.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                    txtOgrSoyAdOgr.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                    txtOgrKullaniciOgr.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                    txtDogumTarihOgr.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Bir Sorun Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Visible == true)
                {

                    int secilen = dataGridView2.SelectedCells[0].RowIndex;
                    textBox2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
                    textBox1.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Bir Sorun Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView3.Visible == true)
                {
                    int secilen = dataGridView3.SelectedCells[0].RowIndex;
                    txtnotid.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
                    txtogrid.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();
                    txtdersıd.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
                    txtvize.Text = dataGridView3.Rows[secilen].Cells[4].Value.ToString();
                    txtfinal.Text = dataGridView3.Rows[secilen].Cells[5].Value.ToString();
                    txtproje.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
                    txtortalama.Text = dataGridView3.Rows[secilen].Cells[7].Value.ToString();
                    txtdevamsizlik.Text = dataGridView3.Rows[secilen].Cells[9].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Bir Sorun Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grupdersBtnbul_Click(object sender, EventArgs e)
        {
            try
            {
                //STORED PROCEDURES KULLANILMIŞ HALİ...

                SqlCommand komutAra = new SqlCommand("Exec sp_OgrDersProcedureFrmOgretmen @p1,@p2", bgl.baglanti());
                komutAra.Parameters.AddWithValue("@p1", "%" + textBox3.Text + "%");
                komutAra.Parameters.AddWithValue("@p2", GirisOgretmenID);
                SqlDataAdapter da = new SqlDataAdapter(komutAra);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
              //ESKİ HALİ...
                try
                {
                    string deger = textBox3.Text;

                    System.Data.DataTable dt = new System.Data.DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("Select * From TBLDERSLER where DersID='" + deger+ "' and OgretmenID='" + GirisOgretmenID + "' ", bgl.baglanti());
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;

                    bgl.baglanti().Close();   
                }
                catch
                {
                    MessageBox.Show("Lütfen Ders Id'sini giriniz.","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            */
        }

        private void grupnotBtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update TBLNOTLAR set DersID=@d1,OgretmenID=@d2,OgrID=@d3,Vize=@d4,Final=@d5,Proje=@d6,Devamsizlik=@d7 where NotID=@d8", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", txtdersıd.Text);
                komut.Parameters.AddWithValue("@d2", GirisOgretmenID);
                komut.Parameters.AddWithValue("@d3", txtogrid.Text);
                komut.Parameters.AddWithValue("@d4", txtvize.Text);
                komut.Parameters.AddWithValue("@d5", txtfinal.Text);
                komut.Parameters.AddWithValue("@d6", txtproje.Text);
                komut.Parameters.AddWithValue("@d7", txtdevamsizlik.Text);
                komut.Parameters.AddWithValue("@d8", txtnotid.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Not Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Page2list();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grupogrbtnbul_Click(object sender, EventArgs e)
        {
            try
            {
                ////STORED PROCEDURES KULLANILMIŞ HALİ...
                
                SqlCommand komutAra = new SqlCommand("Exec sp_OgrOgrenciProcedure @p1", bgl.baglanti());
                komutAra.Parameters.AddWithValue("@p1", "%" + txtbulogrid.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(komutAra);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            /*
             //ESKİ HALİ 
            try
            {
                string deger = txtbulogrid.Text;

                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBLOGRENCI where OgrID='" + deger +"' ", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Lütfen Ogr Id'sini giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                Page1list();
            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                Page2list();                
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                Page3list();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int secilencombobox = Convert.ToInt32(comboBox1.SelectedValue);

                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBLNOTLAR where DersID='" + secilencombobox + "' and OgretmenID='" + GirisOgretmenID + "' ", bgl.baglanti());
                da.Fill(dt);
                dataGridView3.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }
    }
}
