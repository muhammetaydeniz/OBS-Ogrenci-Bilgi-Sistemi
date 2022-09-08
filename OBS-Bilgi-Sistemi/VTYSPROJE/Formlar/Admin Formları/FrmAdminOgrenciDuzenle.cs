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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace VTYSPROJE
{
    public partial class FrmAdminOgrenciDuzenle : Form
    {
        public FrmAdminOgrenciDuzenle()
        {
            InitializeComponent();
        }

        public string GirisAdminID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        void OgrListele()
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBLOGRENCI", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdminOgrenciDuzenle_Load(object sender, EventArgs e)
        {
            OgrListele();
            txtogrid.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtogrid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtbolumid.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtograd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtogrsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtogrtc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                txtogrcinsiyet.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                txtogrdogumtarih.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                txtogrkullaniciadi.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
                txtogrsifre.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into TBLOGRENCI (BolumID,OgrAd,OgrSoyAd,OgrTC,OgrCinsiyet,OgrDogumTarihi,OgrKullaniciAdi,OgrSifre) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", txtbolumid.Text);
                komut.Parameters.AddWithValue("@d2", txtograd.Text);
                komut.Parameters.AddWithValue("@d3", txtogrsoyad.Text);
                komut.Parameters.AddWithValue("@d4", txtogrtc.Text);
                komut.Parameters.AddWithValue("@d5", txtogrcinsiyet.Text);
                komut.Parameters.AddWithValue("@d6", txtogrdogumtarih.Text);
                komut.Parameters.AddWithValue("@d7", txtogrkullaniciadi.Text);
                komut.Parameters.AddWithValue("@d8", txtogrsifre.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Öğrenci Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtogrid.Text = null;
                txtogrid.Text = null;
                txtbolumid.Text = null;
                txtograd.Text = null;
                txtogrsoyad.Text = null;
                txtogrtc.Text = null;
                txtogrcinsiyet.Text = null;
                txtogrdogumtarih.Text = null;
                txtogrkullaniciadi.Text = null;
                txtogrsifre.Text = null;

                OgrListele();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update TBLOGRENCI set BolumID=@p1, OgrAd=@p2, OgrSoyAd=@p3, OgrTC=@p4, OgrCinsiyet=@p5, OgrDogumTarihi=@p6, OgrKullaniciAdi=@p7, OgrSifre=@p8 where OgrID=@p9", bgl.baglanti());

                komut.Parameters.AddWithValue("@p9", txtogrid.Text);

                komut.Parameters.AddWithValue("@p1", txtbolumid.Text);
                komut.Parameters.AddWithValue("@p2", txtograd.Text);
                komut.Parameters.AddWithValue("@p3", txtogrsoyad.Text);
                komut.Parameters.AddWithValue("@p4", txtogrtc.Text);
                komut.Parameters.AddWithValue("@p5", txtogrcinsiyet.Text);
                komut.Parameters.AddWithValue("@p6", txtogrdogumtarih.Text);
                komut.Parameters.AddWithValue("@p7", txtogrkullaniciadi.Text);
                komut.Parameters.AddWithValue("@p8", txtogrsifre.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Öğrenci Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtogrid.Text = null;
                txtogrid.Text = null;
                txtbolumid.Text = null;
                txtograd.Text = null;
                txtogrsoyad.Text = null;
                txtogrtc.Text = null;
                txtogrcinsiyet.Text = null;
                txtogrdogumtarih.Text = null;
                txtogrkullaniciadi.Text = null;
                txtogrsifre.Text = null;

                OgrListele();

            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete TBLOGRENCI where OgrID=@p9", bgl.baglanti());

                komut.Parameters.AddWithValue("@p9", txtogrid.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Öğrenci Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtogrid.Text = null;
                txtogrid.Text = null;
                txtbolumid.Text = null;
                txtograd.Text = null;
                txtogrsoyad.Text = null;
                txtogrtc.Text = null;
                txtogrcinsiyet.Text = null;
                txtogrdogumtarih.Text = null;
                txtogrkullaniciadi.Text = null;
                txtogrsifre.Text = null;

                OgrListele();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            OgrListele();
        }

        private void btndersıdbul_Click(object sender, EventArgs e)
        {
            try
            {
                //STORED PROCEDURE
                SqlCommand komutAra = new SqlCommand("Exec sp_OgrOgrenciProcedure @p1", bgl.baglanti());
                komutAra.Parameters.AddWithValue("@p1", "%" + txtogrbulid.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(komutAra);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //ESKİ HALİ...
            /*
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLOGRENCI where OgrID='" + txtogrbulid.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();

            txtogrbulid.Text = null;
            */
        }

        private void btnbolumıdbul_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBLOGRENCI where BolumID='" + txtbolumbulid.Text + "'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();

                txtbolumbulid.Text = null;
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application exceldosya = new Excel.Application();
                exceldosya.Visible = true;
                object Missing = Type.Missing;

                Workbook bolumlistesi = exceldosya.Workbooks.Add(Missing);
                Worksheet sheet1 = (Worksheet)bolumlistesi.Sheets[1];
                int sutun = 1;
                int satır = 1;

                for (int j = 0; j < dataGridView1.Columns.Count; j++)

                {
                    Range myrange = (Range)sheet1.Cells[satır, sutun + j];
                    myrange.Value2 = dataGridView1.Columns[j].HeaderText;


                }

                satır++;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        Range myrange = (Range)sheet1.Cells[satır + i, sutun + j];
                        myrange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        myrange.Select();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public System.Data.DataTable ToDataTable(ExcelApp.Range range, int rows, int cols)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            for (int i = 1; i <= rows; i++)
            {
                if (i == 1)
                { // ilk satırı Sutun Adları olarak kullanıldığından
                  // bunları Sutün Adları Olarak Kaydediyoruz.
                    for (int j = 1; j <= cols; j++)
                    {
                        //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                            table.Columns.Add(range.Cells[i, j].Value2.ToString());
                        else //Boş olduğunda Kaçınsı Sutünsa Adı veriliyor.
                            table.Columns.Add(j.ToString() + ".Sütun");
                    }
                    continue;
                }
                // Yukarıda Sütunlar eklendi
                // onun şemasına göre yeni bir satır oluşturuyoruz. 
                // Okunan verileri yan yana sıralamak için
                var yeniSatir = table.NewRow();
                for (int j = 1; j <= cols; j++)
                {
                    // Sütunların içeriği boş mu kontrolü yapılmaktadır.
                    if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                        yeniSatir[j - 1] = range.Cells[i, j].Value2.ToString();
                    else // İçeriği boş hücrede hata vermesini önlemek için
                        yeniSatir[j - 1] = String.Empty;
                }
                table.Rows.Add(yeniSatir);
            }
            return table;
        }

        public int satirSayisi;
        public int sutunSayisi;

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string DosyaYolu;
                string DosyaAdi;
                System.Data.DataTable dt;
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                    DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                    ExcelApp.Application excelApp = new ExcelApp.Application();
                    if (excelApp == null)
                    { //Excel Yüklümü Kontrolü Yapılmaktadır.
                        MessageBox.Show("Excel yüklü değil.");
                        return;
                    }

                    //Excel Dosyası Açılıyor.
                    ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(DosyaYolu);
                    //Excel Dosyasının Sayfası Seçilir.
                    ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                    //Excel Dosyasının ne kadar satır ve sütun kaplıyorsa tüm alanları alır.
                    ExcelApp.Range excelRange = excelSheet.UsedRange;
                    satirSayisi = excelRange.Rows.Count; //Sayfanın satır sayısını alır.
                    sutunSayisi = excelRange.Columns.Count;//Sayfanın sütun sayısını alır.
                    dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                else
                {
                    MessageBox.Show("Dosya Seçilemedi.");
                }
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAdminOgrenciRaporla fr = new FrmAdminOgrenciRaporla();
                fr.secilen = txtogrid.Text;
                fr.Show();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
