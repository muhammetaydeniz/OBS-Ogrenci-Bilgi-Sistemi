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
    public partial class FrmAdminVeriTabanıDuzenle : Form
    {
        public FrmAdminVeriTabanıDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sayac = " " + Convert.ToString(DateTime.Now.Day) + "." + Convert.ToString(DateTime.Now.Month) + "." + Convert.ToString(DateTime.Now.Year) + "." + Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Millisecond);
                string dizinyolu = "BACKUP DATABASE[OGRSISTEMI] TO DISK = N'D:\\VeriTabaniYedek\\OgrSistemiYedekdb" + sayac + ".bak' WITH NOFORMAT, NOINIT, NAME = N'OGRSISTEMI-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlCommand komut = new SqlCommand(dizinyolu, bgl.baglanti());
                komut.ExecuteNonQuery();

                MessageBox.Show("Veri Tabanı Yedeklendi");
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        SqlCommand komut2 = new SqlCommand("DROP DATABASE OGRSISTEMIYEDEK", bgl.baglanti());
                        komut2.ExecuteNonQuery();

                    }
                    catch
                    {
                        MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string deger = "RESTORE DATABASE[OGRSISTEMIYEDEK] FROM DISK = N'" + textBox1.Text + "' WITH FILE = 1, MOVE N'OGRSISTEMI' TO N'C:\\Program Files\\Microsoft SQL Server\\MSSQL14.MSSQLSERVER\\MSSQL\\DATA\\OGRSISTEMIYEDEK.mdf',  MOVE N'OGRSISTEMI_log' TO N'C:\\Program Files\\Microsoft SQL Server\\MSSQL14.MSSQLSERVER\\MSSQL\\DATA\\OGRSISTEMIYEDEK_log.ldf',  NOUNLOAD,  STATS = 5";
                    SqlCommand komut = new SqlCommand(deger, bgl.baglanti());

                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Başarılı");
                }
                else
                {
                    MessageBox.Show("Lütfen *.bak dosyasının yolunu seçiniz.");
                }
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                textBox1.Text = openFileDialog1.FileName;
                openFileDialog1.Filter = "|*.bak";
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdminVeriTabanıDuzenle_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }
    }
}
