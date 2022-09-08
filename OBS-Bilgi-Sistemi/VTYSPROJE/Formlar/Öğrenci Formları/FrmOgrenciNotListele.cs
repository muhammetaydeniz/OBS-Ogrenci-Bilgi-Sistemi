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
    public partial class FrmOgrenciNotListele : Form
    {
        public FrmOgrenciNotListele()
        {
            InitializeComponent();
        }

        public string GirisOgrID;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmOgrenciNotListele_Load(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select TBLDERSLER.DersAd,TBLNOTLAR.Vize,TBLNOTLAR.Final,TBLNOTLAR.Proje,TBLNOTLAR.Ortalama,TBLNOTLAR.Durum,TBLNOTLAR.Devamsizlik From TBLNOTLAR INNER JOIN TBLDERSLER ON TBLDERSLER.DersID = TBLNOTLAR.DersID where TBLNOTLAR.OgrID = '" + GirisOgrID + "'  ", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Bağlantınızda Sorun Var", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
