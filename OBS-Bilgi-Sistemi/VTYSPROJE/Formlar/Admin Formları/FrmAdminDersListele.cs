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
    public partial class FrmAdminDersListele : Form
    {
        public FrmAdminDersListele()
        {
            InitializeComponent();
        }

        public string GirisAdminID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        void DersListele()
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From TBLDERSLER", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmAdminDersListele_Load(object sender, EventArgs e)
        {
            DersListele();
            txtdersid.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtdersid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtbolumid.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtogretmenid.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtdersad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtderskod.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                txtderstarih.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                txtderssinif.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
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
                SqlCommand komut = new SqlCommand("insert into TBLDERSLER (BolumID,OgretmenID,DersAd,DersKod,DersTarih,DersSınıfı) values (@d1,@d2,@d3,@d4,@d5,@d6)", bgl.baglanti());
                komut.Parameters.AddWithValue("@d1", txtbolumid.Text);
                komut.Parameters.AddWithValue("@d2", txtogretmenid.Text);
                komut.Parameters.AddWithValue("@d3", txtdersad.Text);
                komut.Parameters.AddWithValue("@d4", txtderskod.Text);
                komut.Parameters.AddWithValue("@d5", txtderstarih.Text);
                komut.Parameters.AddWithValue("@d6", txtderssinif.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Ders Eklendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DersListele();

                txtdersid.Text = null;
                txtbolumid.Text = null;
                txtogretmenid.Text = null;
                txtdersad.Text = null;
                txtderskod.Text = null;
                txtderstarih.Text = null;
                txtderssinif.Text = null;
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
                SqlCommand komut = new SqlCommand("update TBLDERSLER set BolumID=@d1,OgretmenID=@d2,DersAd=@d3,DersKod=@d4,DersTarih=@d5,DersSınıfı=@d6 where DersID=@d7", bgl.baglanti());
                komut.Parameters.AddWithValue("@d7", txtdersid.Text);
                komut.Parameters.AddWithValue("@d1", txtbolumid.Text);
                komut.Parameters.AddWithValue("@d2", txtogretmenid.Text);
                komut.Parameters.AddWithValue("@d3", txtdersad.Text);
                komut.Parameters.AddWithValue("@d4", txtderskod.Text);
                komut.Parameters.AddWithValue("@d5", txtderstarih.Text);
                komut.Parameters.AddWithValue("@d6", txtderssinif.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Ders Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DersListele();

                txtdersid.Text = null;
                txtbolumid.Text = null;
                txtogretmenid.Text = null;
                txtdersad.Text = null;
                txtderskod.Text = null;
                txtderstarih.Text = null;
                txtderssinif.Text = null;
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
                SqlCommand komut = new SqlCommand("delete TBLDERSLER where DersID=@d7", bgl.baglanti());
                komut.Parameters.AddWithValue("@d7", txtdersid.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Ders Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DersListele();

                txtdersid.Text = null;
                txtbolumid.Text = null;
                txtogretmenid.Text = null;
                txtdersad.Text = null;
                txtderskod.Text = null;
                txtderstarih.Text = null;
                txtderssinif.Text = null;
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            DersListele();
        }

        private void btndersıdbul_Click(object sender, EventArgs e)
        {
            try
            {
                //STORED PROCEDURE
                SqlCommand komutAra = new SqlCommand("Exec sp_OgrDersProcedure @p1", bgl.baglanti());
                komutAra.Parameters.AddWithValue("@p1", "%" + txtdersbulid.Text + "%");
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
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLDERSLER where DersID='" + txtdersbulid.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();

            txtdersbulid.Text = null;
            */
        }

        private void btnbolumıdbul_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBLDERSLER  where BolumID='" + txtbolumbulid.Text + "'", bgl.baglanti());
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

        private void btnogretmenıdbul_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from TBLDERSLER  where OgretmenID='" + txtogretmenbulid.Text + "'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();

                txtogretmenbulid.Text = null;
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
    }
}
