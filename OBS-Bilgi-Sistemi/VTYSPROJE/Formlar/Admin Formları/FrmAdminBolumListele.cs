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
    public partial class FrmAdminBolumListele : Form
    {
        public FrmAdminBolumListele()
        {
            InitializeComponent();
        }

        public string GirisAdminID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        void BolumListele()
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBLBOLUMLER", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Veri Tabanınızda Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdminBolumListele_Load(object sender, EventArgs e)
        {            
            BolumListele();
            txtbolumid.Enabled=false;
            button8.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtbolumid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtbolumad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtbolumkod.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
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
                SqlCommand komut = new SqlCommand("insert into TBLBOLUMLER (BolumAd,BolumKod) values (@d1,@d2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", txtbolumad.Text);
                komut.Parameters.AddWithValue("@d2", txtbolumkod.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Bölüm Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                BolumListele();

                txtbolumid.Text = null;
                txtbolumad.Text = null;
                txtbolumkod.Text = null;
            }
            catch
            {
                MessageBox.Show("Veri Tabanınızda Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update TBLBOLUMLER set BolumAd=@d1,BolumKod=@d2 where BolumID=@d3", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", txtbolumad.Text);
                komut.Parameters.AddWithValue("@d2", txtbolumkod.Text);
                komut.Parameters.AddWithValue("@d3", txtbolumid.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Bölüm Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                BolumListele();

                txtbolumid.Text = null;
                txtbolumad.Text = null;
                txtbolumkod.Text = null;
            }
            catch
            {
                MessageBox.Show("Veri Tabanınızda Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete TBLBOLUMLER where BolumID=@d1", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", txtbolumid.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Bölüm Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                BolumListele();

                txtbolumid.Text = null;
                txtbolumad.Text = null;
                txtbolumkod.Text = null;
            }
            catch
            {
                MessageBox.Show("Veri Tabanınızda Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //STORED PROCEDURE HALİ...
                SqlCommand komutAra = new SqlCommand("Exec sp_OgrBolumProcedure @p1", bgl.baglanti());
                komutAra.Parameters.AddWithValue("@p1", "%" + txtbolumbulıd.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(komutAra);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Veri Tabanınızda Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //ESKİ HALİ...
            /*
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLBOLUMLER where BolumID='"+ txtbolumbulıd.Text +"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BolumListele();
        }

        private void button6_Click(object sender, EventArgs e)
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
            button8.Visible = true;

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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("EKLEME Yapmaya Devam Etmek İstiyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i < satirSayisi - 1; i++)
                    {
                        SqlCommand komut = new SqlCommand("insert into TBLBOLUMLER (BolumAd,BolumKod) values (@d1,@d2)", bgl.baglanti());
                        komut.Parameters.AddWithValue("@d1", dataGridView1.Rows[i].Cells[1].Value.ToString());
                        komut.Parameters.AddWithValue("@d2", dataGridView1.Rows[i].Cells[2].Value.ToString());

                        komut.ExecuteNonQuery();
                    }

                    bgl.baglanti().Close();

                    BolumListele();
                }

                else
                {
                    MessageBox.Show("Kayıt Yapılmadı");
                }
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
