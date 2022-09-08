using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYSPROJE
{
    public partial class FrmOgretmenSınavNot : Form
    {
        public FrmOgretmenSınavNot()
        {
            InitializeComponent();
        }

        VTYSPROJEEntities db = new VTYSPROJEEntities();

        public string ogretmentcgiris;

        void Page1list()
        {
            var query = db.TBLOGRETMENLER.Where(x => x.OgretmenTC == ogretmentcgiris).FirstOrDefault();

            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;

            var sorgu2 = from x in db.TBLDERSLER.Where(x => x.OgretmenID == query.OgretmenID)
                         select new
                         {
                             x.DersID,
                             x.DersAd,
                             x.DersKod

                         };
            dataGridView2.DataSource = sorgu2.ToList();
        }

        void Page2list()
        {

            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            var sorgu1 = db.TBLOGRETMENLER.Where(x => x.OgretmenTC == ogretmentcgiris).SingleOrDefault();
            var sorgu3 = db.TBLDERSLER.Where(x => x.OgretmenID == sorgu1.OgretmenID).FirstOrDefault();

            var sorgu2 = from x in db.TBLNOTLAR.Where(x => x.DersID == sorgu3.DersID)
                         select new
                         {
                             x.NotID,
                             x.DersID,
                             x.OgrID,
                             x.TBLOGRENCI.OgrAd,
                             x.TBLOGRENCI.OgrSoyad,
                             x.Vize,
                             x.Fİnal,
                             x.Ortalama,
                             x.Devamsızlık,
                             x.Durum
                         };

            dataGridView3.DataSource = sorgu2.ToList();
            
        }

        void Page3list()
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            var sorgu2 = from x in db.TBLOGRENCI
                         select new
                         {
                             x.OgrID,
                             x.OgrAd,
                             x.OgrSoyad,
                             x.OgrKullanıcıAdı,
                             x.OgrDogumTarihi
                         };
            dataGridView1.DataSource = sorgu2.ToList();
        }

        private void FrmOgretmenSınavNot_Load(object sender, EventArgs e)
        {
            /*
            Page1list();


            var query = db.TBLOGRETMENLER.Where(x => x.OgretmenTC == ogretmentcgiris).FirstOrDefault();
            var sorgu2 = from x in db.TBLDERSLER.Where(x => x.OgretmenID == query.OgretmenID)
                         select new
                         {
                             x.DersAd,
                         };

            
            comboBox1.DataSource = sorgu2.;
            */
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Visible == true)
            {
                int secilen = dataGridView3.SelectedCells[0].RowIndex;
                label16.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
                txtogrid.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
                txtograd.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();
                txtogrsoyad.Text = dataGridView3.Rows[secilen].Cells[4].Value.ToString();
                txtvize.Text = dataGridView3.Rows[secilen].Cells[5].Value.ToString();
                txtfinal.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
                //txtproje.Text = dataGridView3.Rows[secilen].Cells[7].Value.ToString();
                txtortalama.Text = dataGridView3.Rows[secilen].Cells[7].Value.ToString();
                txtdurum.Text = dataGridView3.Rows[secilen].Cells[9].Value.ToString();
            }

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Visible == true)
            {

                int secilen = dataGridView2.SelectedCells[0].RowIndex;
                textBox2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
                textBox1.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();

            }

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Visible == true)
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtOgrIDOgr.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtOgrAdOgr.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtOgrSoyAdOgr.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtOgrKullaniciOgr.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtDogumTarihOgr.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            }
        }

        private void grupogrbtnbul_Click(object sender, EventArgs e)
        {

        }

        private void grupnotBtnKaydet_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(label16.Text);

            var x = db.TBLNOTLAR.Find(id);
            x.Vize = Convert.ToByte(txtvize.Text);
            x.Fİnal = Convert.ToByte(txtfinal.Text);
           
            /*
            int id = Convert.ToInt32(txtogrid.Text);

            var query = db.TBLNOTLAR.Where(x => x.TBLOGRENCI.OgrID == id).FirstOrDefault();
            query.Vize= Convert.ToByte(txtvize.Text);
            query.Fİnal = Convert.ToByte(txtfinal.Text);
            */

            db.SaveChanges();
            MessageBox.Show("Öğrenci Güncellendi", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int deger = Convert.ToInt32(textBox3.Text);
                var query = db.TBLOGRETMENLER.Where(x => x.OgretmenTC == ogretmentcgiris).FirstOrDefault();

                var query2 = from x in db.TBLDERSLER.Where(x => x.DersID == deger && x.OgretmenID == query.OgretmenID)
                            select new
                            {
                                x.DersID,
                                x.DersAd,
                                x.DersKod,

                            };

                dataGridView2.DataSource = query2.ToList();

            }
            
            catch
            {
                MessageBox.Show("Lütfen Ders Id'sini giriniz.","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

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
    }
}
